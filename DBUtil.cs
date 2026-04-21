using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X500.Style;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HCIProjekat1
{
    static class DBUtil
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MySqlHciEsportLiga"].ConnectionString;

        public static Account CheckAccountCredentials(string username, string password)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open(); 
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM nalog WHERE KorisnickoIme=@KorisnickoIme AND Lozinka=@Lozinka";
            cmd.Parameters.AddWithValue("@KorisnickoIme", username);
            cmd.Parameters.AddWithValue("@Lozinka", password);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) // Nalog je pronađen, ali treba provjeriti da li se možda radi o zahtjevu:
            {
                Account account = new Account()
                {
                    AccountId = reader.GetInt32(0),
                    Type = reader.GetString(1),
                    Username = reader.GetString(2),
                    // Password nije potreban
                    DateOfCreation = reader.GetDateTime(4),
                    DateOfRequest = reader.GetDateTime(5),
                    // Info nije potreban
                    Theme = reader.GetString(7)
                };
                reader.Close();
                conn.Close();
                return account; 
            } else
            {
                reader.Close();
                conn.Close();
                return null; 
            }
        }

        public static bool CheckUsernameAvailability(string username)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM nalog WHERE KorisnickoIme=@Username";
            cmd.Parameters.AddWithValue("@Username", username);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                conn.Close();
                return true; 
            } else
            {
                reader.Close();
                conn.Close();
                return false; 
            }
        }

        public static string FindAccountThemeForUsername(string username)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Tema FROM nalog WHERE KorisnickoIme=@KorisnickoIme";
            cmd.Parameters.AddWithValue("@KorisnickoIme", username);
            MySqlDataReader reader = cmd.ExecuteReader(); 
            if (reader.Read())
            {
                return reader.GetString(0);
            } else
            {
                return null;
            }
        }

        public static void RequestAccountAcceptance(Account account)
        {
            MySqlConnection conn = new MySqlConnection(connectionString); 
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO nalog (IdNaloga, TipNaloga, KorisnickoIme, Lozinka, " +
                "DatumKreiranja, DatumZahtjeva, DodatneInformacije)" +
                " VALUES (@IdNaloga, @TipNaloga, @KorisnickoIme, @Lozinka, @DatumKreiranja," +
                " @DatumZahtjeva, @DodatneInformacije)";
            cmd.Parameters.AddWithValue("@IdNaloga", null);
            cmd.Parameters.AddWithValue("@TipNaloga", account.Type);
            cmd.Parameters.AddWithValue("@KorisnickoIme", account.Username);
            cmd.Parameters.AddWithValue("@Lozinka", account.Password);
            cmd.Parameters.AddWithValue("@DatumKreiranja", null); 
            cmd.Parameters.AddWithValue("@DatumZahtjeva", account.DateOfRequest);
            cmd.Parameters.AddWithValue("@DodatneInformacije", account.Info);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void AcceptRequest(Account account)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE nalog SET TipNaloga='Obicni nalog', DatumKreiranja=@DatumKreiranja, " +
                "DodatneInformacije='' Tema=@Tema WHERE IdNaloga=@IdNaloga";
            cmd.Parameters.AddWithValue("@DatumKreiranja", DateTime.Today);
            cmd.Parameters.AddWithValue("@IdNaloga", account.AccountId);
            cmd.Parameters.AddWithValue("@Tema", "Spring,srb");
            cmd.ExecuteNonQuery();
            conn.Close(); 
        }

        public static void DenyRequest(int accountId)
        {
            MySqlConnection conn = new MySqlConnection(connectionString); 
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM nalog WHERE IdNaloga=@IdNaloga";
            cmd.Parameters.AddWithValue("@IdNaloga", accountId);
            cmd.ExecuteNonQuery();
            conn.Close(); 
        }

        public static void UpdateThemeForAccount(string username, string theme)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE nalog SET Tema=@Tema WHERE KorisnickoIme=@KorisnickoIme";
            cmd.Parameters.AddWithValue("@Tema", theme); 
            cmd.Parameters.AddWithValue("@KorisnickoIme", username);
            cmd.ExecuteNonQuery();
            conn.Close(); 
        }

        public static List<Account> GetAccounts(string enteredText) // Čitanje svega osim lozinke
        {
            List<Account> accounts = new List<Account>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT IdNaloga, TipNaloga, KorisnickoIme, DatumKreiranja, DatumZahtjeva," +
                " DodatneInformacije FROM nalog WHERE KorisnickoIme LIKE @str" +
                " OR DatumKreiranja LIKE @str OR DatumZahtjeva LIKE @str";
            cmd.Parameters.AddWithValue("@str", enteredText + "%");
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Account account = new Account()
                {
                    AccountId = reader.GetInt32(0),
                    Type = reader.GetString(1),
                    Username = reader.GetString(2),
                    DateOfCreation = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                    DateOfRequest = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                    Info = reader.IsDBNull(5) ? null : reader.GetString(5)
                };
                if (!account.Type.Equals("Admin"))
                {
                    accounts.Add(account);
                }
            }
            reader.Close();
            conn.Close();
            return accounts;
        }

        public static void DeleteAccountById(int accountId)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open(); 
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM nalog WHERE IdNaloga=@IdNaloga";
            cmd.Parameters.AddWithValue("@IdNaloga", accountId);
            cmd.ExecuteNonQuery();
            conn.Close(); 
        }

        public static List<Match> GetMatches(int seasonId, String filter)
        {
            List<Match> matches = new List<Match>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT m.IdMeca, m.TipMeca, m.PrviTim, m.Rezultat, m.DrugiTim, m.DatumIgranja," +
                " m.Lokacija, f.IdFaze, f.NazivFaze, s.IdSezone, s.Split, s.Godina FROM mec m" +
                " INNER JOIN faza f ON m.IdFaze=f.IdFaze " +
                " INNER JOIN sezona s ON f.IdSezone=s.IdSezone" +
                " WHERE s.IdSezone=@IdSezone AND" +
                " (m.TipMeca LIKE @str OR m.PrviTim LIKE @str OR m.DrugiTim LIKE @str " +
                " OR m.Rezultat LIKE @str OR m.DatumIgranja LIKE @str OR m.Lokacija LIKE @str " +
                " OR f.NazivFaze LIKE @str OR s.Split LIKE @str OR s.Godina LIKE @str)";
            cmd.Parameters.AddWithValue("@IdSezone", seasonId);
            cmd.Parameters.AddWithValue("@str", filter + "%");
            MySqlDataReader reader = cmd.ExecuteReader(); 
            while (reader.Read())
            {
                matches.Add(new Match()
                {
                    MatchId = reader.GetInt32(0),
                    Format = reader.GetString(1),
                    Team1 = reader.GetString(2),
                    Result = reader.GetString(3),
                    Team2 = reader.GetString(4),
                    Date = reader.GetDateTime(5),
                    Location = reader.GetString(6),
                    Phase = new Phase()
                    {
                        PhaseId = reader.GetInt32(7),
                        PhaseName = reader.GetString(8),
                        Season = new Season()
                        {
                            SeasonId = reader.GetInt32(9),
                            Split = reader.GetString(10),
                            Year = reader.GetInt32(11)
                        }
                    }
                });
            }
            reader.Close();
            conn.Close();
            return matches;
        }

        public static List<Season> GetSeasons()
        {
            List<Season> seasons = new List<Season>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * from sezona";
            MySqlDataReader reader = cmd.ExecuteReader(); 
            while (reader.Read())
            {
                seasons.Add(new Season()
                {
                    SeasonId = reader.GetInt32(0),
                    Split = reader.GetString(1),
                    Year = reader.GetInt32(2)
                });
            }
            reader.Close();
            conn.Close();
            return seasons;
        }

        public static void InsertSeason(Season season)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO sezona VALUES (@IdSezone, @Split, @Godina)";
            cmd.Parameters.AddWithValue("@IdSezone", null); 
            cmd.Parameters.AddWithValue("@Split", season.Split);
            cmd.Parameters.AddWithValue("@Godina", season.Year);
            cmd.ExecuteNonQuery();
            conn.Close(); 
        }

        public static string FindSeasonById(int id)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM sezona WHERE IdSezone=@IdSezone";
            cmd.Parameters.AddWithValue("@IdSezone", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                Season season = new Season()
                {
                    SeasonId = reader.GetInt32(0),
                    Split = reader.GetString(1),
                    Year = reader.GetInt32(2)
                };
                reader.Close();
                conn.Close();
                return season.Display;
            } else
            {
                reader.Close();
                conn.Close();
                return ""; 
            }
        }

        public static List<Team> GetTeams()
        {
            List<Team> teams = new List<Team>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Naziv, GodinaOsnivanja, Drzava, Slika FROM tim";
            MySqlDataReader reader = cmd.ExecuteReader(); 
            while (reader.Read())
            {
                teams.Add(new Team()
                {
                    Name = reader.GetString(0),
                    YearOfEstablishment = reader.GetInt32(1),
                    Country = reader.GetString(2),
                    Picture = (byte[])reader["Slika"]
                });
            }
            reader.Close();
            conn.Close();
            return teams;
        }

        public static List<Team> GetTeamsBySeason(int seasonId)
        {
            List<Team> teams = new List<Team>(); 
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT t.Naziv, t.GodinaOsnivanja, t.Drzava, t.Slika " +
                "FROM tim t INNER JOIN t_u_s tus ON t.Naziv=tus.NazivTima " +
                "WHERE tus.IdSezone=@IdSezone";
            cmd.Parameters.AddWithValue("@IdSezone", seasonId);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                teams.Add(new Team()
                {
                    Name = reader.GetString(0),
                    YearOfEstablishment = reader.GetInt32(1),
                    Country = reader.GetString(2),
                    Picture = (byte[])reader["Slika"]
                });
            }
            reader.Close();
            conn.Close();
            return teams;
        }

        public static List<Team> GetTeamsWithoutSeason(int seasonId)
        {
            List<Team> teams = new List<Team>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT t.Naziv, t.GodinaOsnivanja, t.Drzava FROM tim t " +
                "LEFT OUTER JOIN t_u_s tus ON t.Naziv=tus.NazivTima AND tus.IdSezone=@IdSezone " +
                "WHERE tus.NazivTima IS NULL";
            cmd.Parameters.AddWithValue("@IdSezone", seasonId);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                teams.Add(new Team()
                {
                    Name = reader.GetString(0),
                    YearOfEstablishment = reader.GetInt32(1),
                    Country = reader.GetString(2)
                });
            }
            reader.Close();
            conn.Close();
            return teams;
        }

        public static List<TeamPlacement> GetTeamPlacementsBySeason(int seasonId)
        {
            List<TeamPlacement> teamPlacements = new List<TeamPlacement>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT NazivTima, Plasman FROM t_u_s WHERE IdSezone=@IdSezone " +
                "ORDER BY Plasman ASC";
            cmd.Parameters.AddWithValue("@IdSezone", seasonId);
            MySqlDataReader reader = cmd.ExecuteReader(); 
            while (reader.Read())
            {
                teamPlacements.Add(new TeamPlacement()
                {
                    TeamName = reader.GetString(0),
                    SeasonId = seasonId,
                    Placement = reader.GetInt32(1)
                });
            }
            reader.Close();
            conn.Close();
            return teamPlacements;
        }

        public static Team GetTeamInfo(string teamName)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Naziv, GodinaOsnivanja, Drzava FROM tim WHERE Naziv=@Naziv";
            cmd.Parameters.AddWithValue("@Naziv", teamName); 
            MySqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                Team team = new Team()
                {
                    Name = teamName,
                    YearOfEstablishment = reader.GetInt32(1),
                    Country = reader.GetString(2)
                };
                reader.Close();
                conn.Close();
                return team;
            } else
            {
                reader.Close();
                conn.Close();
                return null; 
            }
        }

        public static byte[] FindTeamPicture(string team)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Slika FROM tim WHERE Naziv=@Naziv";
            cmd.Parameters.AddWithValue("@Naziv", team);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            byte[] picture = (byte[])reader["Slika"];
            reader.Close();
            conn.Close();
            return picture;
        }

        public static void InsertPhase(Phase phase)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO faza VALUES(@IdFaze, @NazivFaze, @DatumPocetka, @DatumZavrsetka," +
                " @IdSezone)";
            cmd.Parameters.AddWithValue("@IdFaze", null); 
            cmd.Parameters.AddWithValue("@NazivFaze", phase.PhaseName); 
            cmd.Parameters.AddWithValue("@DatumPocetka", phase.StartDate); 
            cmd.Parameters.AddWithValue("@DatumZavrsetka", phase.EndDate); 
            cmd.Parameters.AddWithValue("@IdSezone", phase.Season.SeasonId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void UpdatePhase(Phase phase)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE faza SET NazivFaze=@NazivFaze, DatumPocetka=@DatumPocetka, " +
                "DatumZavrsetka=@DatumZavrsetka, IdSezone=@IdSezone WHERE IdFaze=@IdFaze";
            cmd.Parameters.AddWithValue("@NazivFaze", phase.PhaseName);
            cmd.Parameters.AddWithValue("@DatumPocetka", phase.StartDate);
            cmd.Parameters.AddWithValue("@DatumZavrsetka", phase.EndDate);
            cmd.Parameters.AddWithValue("@IdSezone", phase.Season.SeasonId);
            cmd.Parameters.AddWithValue("@IdFaze", phase.PhaseId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void DeletePhaseById(Phase phase)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM mec WHERE IdFaze=@IdFaze";
            cmd.Parameters.AddWithValue("@IdFaze", phase.PhaseId);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "DELETE FROM faza WHERE IdFaze=@IdFaze";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Phase> GetPhasesBySeason(int seasonId)
        {
            List<Phase> phases = new List<Phase>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT f.IdFaze, f.NazivFaze, f.DatumPocetka, f.DatumZavrsetka, f.IdSezone," +
                "s.Split, s.Godina FROM faza f INNER JOIN sezona s ON f.IdSezone=s.IdSezone " +
                "WHERE s.IdSezone=@IdSezone";
            cmd.Parameters.AddWithValue("@IdSezone", seasonId);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                phases.Add(new Phase()
                {
                    PhaseId = reader.GetInt32(0),
                    PhaseName = reader.GetString(1),
                    StartDate = reader.GetDateTime(2),
                    EndDate = reader.GetDateTime(3),
                    Season = new Season()
                    {
                        SeasonId = reader.GetInt32(4),
                        Split = reader.GetString(5),
                        Year = reader.GetInt32(6)
                    }
                });
            }
            reader.Close(); 
            conn.Close();
            return phases;
        }

        public static int CheckIfPhaseAlreadyExists(string phaseName, int seasonId)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open(); 
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM faza WHERE NazivFaze=@NazivFaze AND IdSezone=@IdSezone";
            cmd.Parameters.AddWithValue("@NazivFaze", phaseName);
            cmd.Parameters.AddWithValue("@IdSezone", seasonId);
            MySqlDataReader reader = cmd.ExecuteReader(); 
            if(reader.Read())
            {
                int phaseId = reader.GetInt32(0); // Vraća se ID faze ukoliko je pronađena
                reader.Close();
                conn.Close();
                return phaseId;
            } else
            {
                reader.Close();
                conn.Close();
                return 0; // U suprotnom vraća 0
            }
        }

        public static void InsertMatch(Match match)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO mec VALUES (@IdMeca, @TipMeca, @PrviTim, @Rezultat, " +
                "@DrugiTim, @DatumIgranja, @Lokacija, @IdFaze)";
            cmd.Parameters.AddWithValue("@IdMeca", null);
            cmd.Parameters.AddWithValue("@TipMeca", match.Format);
            cmd.Parameters.AddWithValue("@PrviTim", match.Team1);
            cmd.Parameters.AddWithValue("@Rezultat", match.Result);
            cmd.Parameters.AddWithValue("@DrugiTim", match.Team2);
            cmd.Parameters.AddWithValue("@DatumIgranja", match.Date.Date);
            cmd.Parameters.AddWithValue("@Lokacija", match.Location);
            cmd.Parameters.AddWithValue("@IdFaze", match.Phase.PhaseId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void UpdateMatch(Match match)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE mec SET TipMeca=@TipMeca, PrviTim=@PrviTim, " +
                "Rezultat=@Rezultat, DrugiTim=@DrugiTim, DatumIgranja=@DatumIgranja, Lokacija=@Lokacija, " +
                "IdFaze=@IdFaze WHERE IdMeca=@IdMeca";
            cmd.Parameters.AddWithValue("@IdMeca", match.MatchId);
            cmd.Parameters.AddWithValue("@TipMeca", match.Format);
            cmd.Parameters.AddWithValue("@PrviTim", match.Team1);
            cmd.Parameters.AddWithValue("@Rezultat", match.Result);
            cmd.Parameters.AddWithValue("@DrugiTim", match.Team2);
            cmd.Parameters.AddWithValue("@DatumIgranja", match.Date.Date);
            cmd.Parameters.AddWithValue("@Lokacija", match.Location);
            cmd.Parameters.AddWithValue("@IdFaze", match.Phase.PhaseId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void DeleteMatchById(int matchId)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM mec WHERE IdMeca=@IdMeca";
            cmd.Parameters.AddWithValue("@IdMeca", matchId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void InsertTeam(Team team)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO tim VALUES (@Naziv, @GodinaOsnivanja, @Drzava, @Slika)";
            cmd.Parameters.AddWithValue("@Naziv", team.Name); 
            cmd.Parameters.AddWithValue("@GodinaOsnivanja", team.YearOfEstablishment); 
            cmd.Parameters.AddWithValue("@Drzava", team.Country); 
            cmd.Parameters.AddWithValue("@Slika", team.Picture);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void UpdateTeam(Team team)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            // Infinite Loop problem: 
            // Prvo se moraju ažurirati mečevi, a da bi ažurirali mečeve, moramo ažurirati t_u_s, a da bi
            // ažurirali t_u_s, moramo ažurirati tim, a da bi ažurirali tim, moramo mečeve itd...
            // RJEŠENJE: ISKLJUČENJE OPCIJE MIJENJANJA IMENA TIMA

            // Ažuriramo tim (bez mijenjanja imena tima):
            cmd.CommandText = "UPDATE tim SET GodinaOsnivanja=@GodinaOsnivanja, " +
                "Drzava=@Drzava, Slika=@Slika WHERE Naziv=@Naziv";
            cmd.Parameters.AddWithValue("@GodinaOsnivanja", team.YearOfEstablishment);
            cmd.Parameters.AddWithValue("@Drzava", team.Country);
            cmd.Parameters.AddWithValue("@Slika", team.Picture);
            cmd.Parameters.AddWithValue("@Naziv", team.Name);
            cmd.ExecuteNonQuery();
            conn.Close(); 
        }

        public static void DeleteTeamByName(string teamName)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            // Prvo brišemo sve igrače koji su nastupali za taj tim u nekom periodu:
            cmd.CommandText = "DELETE FROM igrao_za WHERE NazivTima=@Naziv";
            cmd.Parameters.AddWithValue("@Naziv", teamName);
            cmd.ExecuteNonQuery();

            // Zatim brišemo sve mečeve u kojima se pojavio taj tim:
            cmd.CommandText = "DELETE FROM mec WHERE PrviTim=@Naziv OR DrugiTim=@Naziv";
            cmd.ExecuteNonQuery();

            // Nakon toga, brišemo sve timove titule: 
            cmd.CommandText = "DELETE FROM titula WHERE NazivTima=@Naziv";
            cmd.ExecuteNonQuery();

            // Zatim brišemo sve sezone u kojima je tim učestvovao: 
            cmd.CommandText = "DELETE FROM t_u_s WHERE NazivTima=@Naziv";
            cmd.ExecuteNonQuery();

            // Na kraju, brišemo tim iz postojanja:
            cmd.CommandText = "DELETE FROM tim WHERE Naziv=@Naziv";
            cmd.ExecuteNonQuery();
            conn.Close(); 
        }

        public static bool CheckIfTeamPlacementIsCorrect(int placement, int seasonId)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Plasman FROM t_u_s WHERE Plasman=@Plasman " +
                "AND IdSezone=@IdSezone";
            cmd.Parameters.AddWithValue("@Plasman", placement);
            cmd.Parameters.AddWithValue("@IdSezone", seasonId);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                conn.Close();
                return false; 
            } else
            {
                reader.Close();
                conn.Close();
                return true;
            }
        }

        public static void RegisterTeamForSeason(string teamName, int seasonId, int placement)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open(); 
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO t_u_s VALUES (@NazivTima, @IdSezone, @Plasman)";
            cmd.Parameters.AddWithValue("@NazivTima", teamName); 
            cmd.Parameters.AddWithValue("@IdSezone", seasonId); 
            cmd.Parameters.AddWithValue("@Plasman", placement);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        
        public static void UpdateTeamForSeason(string teamName, int seasonId, int placement)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE t_u_s SET Plasman=@Plasman " +
                "WHERE IdSezone=@IdSezone AND NazivTima=@NazivTima";
            cmd.Parameters.AddWithValue("@Plasman", placement);
            cmd.Parameters.AddWithValue("@IdSezone", seasonId);
            cmd.Parameters.AddWithValue("@NazivTima", teamName);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void DeleteTeamForSeason(string teamName, int seasonId)
        {
            MySqlConnection conn = new MySqlConnection(connectionString); 
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();

            // Prvo brišemo sve mečeve u sezoni u kojima je taj tim nastupao: 
            cmd.CommandText = "SELECT IdFaze FROM faza WHERE IdSezone=@IdSezone";
            cmd.Parameters.AddWithValue("@IdSezone", seasonId);
            List<int> phaseIds = new List<int>();
            MySqlDataReader reader = cmd.ExecuteReader(); 
            while (reader.Read())
            {
                phaseIds.Add(reader.GetInt32(0));
            }
            reader.Close();

            cmd.CommandText = "DELETE FROM mec WHERE IdFaze=@IdFaze " +
                         "AND (PrviTim=@NazivTima OR DrugiTim=@NazivTima)";
            cmd.Parameters.AddWithValue("@NazivTima", teamName);

            foreach (int idFaze in phaseIds)
            {
                cmd.Parameters.AddWithValue("@IdFaze", idFaze);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@NazivTima", teamName); // Re-add the static parameter
            }
            cmd.Parameters.Clear();

            // Zatim brišemo sve igrače koji su nastupali za taj tim u toj sezoni: 
            cmd.CommandText = "DELETE FROM igrao_za WHERE IdSezone=@IdSezone AND NazivTima=@NazivTima";
            cmd.Parameters.AddWithValue("@IdSezone", seasonId);
            cmd.Parameters.AddWithValue("@NazivTima", teamName); 
            cmd.ExecuteNonQuery(); 

            // Na kraju, brišemo učešće tima u toj sezoni: 
            cmd.CommandText = "DELETE FROM t_u_s WHERE IdSezone=@IdSezone AND NazivTima=@NazivTima";
            cmd.ExecuteNonQuery();
            conn.Close(); 
        } 

        public static List<Player> GetPlayers()
        {
            List<Player> players = new List<Player>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM igrac";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                players.Add(new Player()
                {
                    InGameId = reader.GetString(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Position = reader.GetString(3),
                    DateOfBirth = reader.GetDateTime(4),
                    Country = reader.GetString(5)
                });
            }
            reader.Close();
            conn.Close();
            return players;
        }

        public static List<Player> GetPlayersBySeason(int seasonId, string teamName)
        {
            List<Player> players = new List<Player>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open(); 
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT ig.InGameId, ig.Ime, ig.Prezime, ig.DatumRodjenja, " +
                "ig.Drzava, pf.Pozicija FROM igrac ig " +
                "INNER JOIN igrao_za pf ON ig.InGameId=pf.InGameId " +
                "WHERE pf.IdSezone=@IdSezone AND pf.NazivTima=@NazivTima";
            cmd.Parameters.AddWithValue("@IdSezone", seasonId);
            cmd.Parameters.AddWithValue("@NazivTima", teamName);
            MySqlDataReader reader = cmd.ExecuteReader(); 
            while (reader.Read())
            {
                players.Add(new Player()
                {
                    InGameId = reader.GetString(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    DateOfBirth = reader.GetDateTime(3),
                    Country = reader.GetString(4),
                    Position = reader.GetString(5)
                });
            }
            reader.Close();
            conn.Close();
            return players;
        }

        public static List<Player> GetPlayersThatDidNotPlayThisSeason(int seasonId)
        {
            List<Player> players = new List<Player>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT ig.InGameID FROM igrac ig " +
                "LEFT OUTER JOIN igrao_za pf ON ig.InGameId=pf.InGameId " +
                "WHERE pf.InGameId IS NULL OR pf.IdSezone<>@IdSezone";
            cmd.Parameters.AddWithValue("@IdSezone", seasonId);
            MySqlDataReader reader = cmd.ExecuteReader(); 
            while (reader.Read())
            {
                players.Add(new Player()
                {
                    InGameId = reader.GetString(0)
                });
            }
            reader.Close();
            conn.Close();
            return players;
        }

        public static void InsertPlayer(Player player)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO igrac VALUES (@InGameId, @Ime, @Prezime, @Pozicija, " +
                "@DatumRodjenja, @Drzava)";
            cmd.Parameters.AddWithValue("@InGameId", player.InGameId);
            cmd.Parameters.AddWithValue("@Ime", player.FirstName);
            cmd.Parameters.AddWithValue("@Prezime", player.LastName);
            cmd.Parameters.AddWithValue("@Pozicija", player.Position);
            cmd.Parameters.AddWithValue("@DatumRodjenja", player.DateOfBirth);
            cmd.Parameters.AddWithValue("@Drzava", player.Country);
            cmd.ExecuteNonQuery();
            conn.Close(); 
        }

        public static void UpdatePlayer(Player player)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE igrac SET InGameId=@InGameId, Ime=@Ime, Prezime=@Prezime, " +
                "Pozicija=@Pozicija, DatumRodjenja=@DatumRodjenja, Drzava=@Drzava " +
                "WHERE InGameId=@InGameId";
            cmd.Parameters.AddWithValue("@InGameId", player.InGameId);
            cmd.Parameters.AddWithValue("@Ime", player.FirstName);
            cmd.Parameters.AddWithValue("@Prezime", player.LastName);
            cmd.Parameters.AddWithValue("@Pozicija", player.Position);
            cmd.Parameters.AddWithValue("@DatumRodjenja", player.DateOfBirth);
            cmd.Parameters.AddWithValue("@Drzava", player.Country);
            cmd.ExecuteNonQuery(); 
            conn.Close();
        }

        public static void DeletePlayerById(string inGameId)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            // Prvo brišemo podatke o timovima za koje je igrao igrač: 
            cmd.CommandText = "DELETE FROM igrao_za WHERE InGameId=@InGameId";
            cmd.Parameters.AddWithValue("@InGameId", inGameId);
            cmd.ExecuteNonQuery(); 

            // Zatim brišemo igrača iz baze podataka:
            cmd.CommandText = "DELETE FROM igrac WHERE InGameId=@InGameId";
            cmd.ExecuteNonQuery();
            conn.Close(); 
        }

        public static Player GetPlayer(string inGameId)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM igrac WHERE InGameId=@InGameId";
            cmd.Parameters.AddWithValue("@InGameId", inGameId); 
            MySqlDataReader reader = cmd.ExecuteReader();   
            if(reader.Read())
            {
                Player player = new Player()
                {
                    InGameId = reader.GetString(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Position = reader.GetString(3),
                    DateOfBirth = reader.GetDateTime(4),
                    Country = reader.GetString(5)
                };
                reader.Close();
                conn.Close();
                return player;
            } else
            {
                reader.Close();
                conn.Close();
                return null; 
            }
        }

        public static List<PastTeamsForPlayer> GetPastTeamsForPlayer(string inGameId)
        {
            List<PastTeamsForPlayer> pastTeams = new List<PastTeamsForPlayer>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT s.IdSezone, s.Split, s.Godina, pf.NazivTima, pf.Pozicija " +
                "FROM igrao_za pf INNER JOIN sezona s ON pf.IdSezone=s.IdSezone " +
                "WHERE pf.InGameId=@InGameId";
            cmd.Parameters.AddWithValue("@InGameId", inGameId);
            MySqlDataReader reader = cmd.ExecuteReader(); 
            while (reader.Read())
            {
                pastTeams.Add(new PastTeamsForPlayer()
                {
                    InGameId = inGameId,
                    Season = new Season()
                    {
                        SeasonId = reader.GetInt32(0),
                        Split = reader.GetString(1),
                        Year = reader.GetInt32(2)
                    },
                    TeamName = reader.GetString(3),
                    Position = reader.GetString(4)
                });
            }
            reader.Close();
            conn.Close();
            return pastTeams;
        }

        public static void InsertPastTeamsForPlayer(PastTeamsForPlayer pbs)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO igrao_za VALUES (@InGameId, @IdSezone, @NazivTima, @Pozicija)";
            cmd.Parameters.AddWithValue("@InGameId", pbs.InGameId);
            cmd.Parameters.AddWithValue("@IdSezone", pbs.Season.SeasonId);
            cmd.Parameters.AddWithValue("@NazivTima", pbs.TeamName);
            cmd.Parameters.AddWithValue("@Pozicija", pbs.Position);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void UpdatePastTeamsForPlayer(PastTeamsForPlayer pbs)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open(); 
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE igrao_za SET IdSezone=@IdSezone, NazivTima=@NazivTima, Pozicija=@Pozicija " +
                "WHERE InGameId=@InGameId";
            cmd.Parameters.AddWithValue("@IdSezone", pbs.Season.SeasonId);
            cmd.Parameters.AddWithValue("@NazivTima", pbs.TeamName);
            cmd.Parameters.AddWithValue("@Pozicija", pbs.Position);
            cmd.Parameters.AddWithValue("@InGameId", pbs.InGameId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void DeletePastTeamsForPlayer(string inGameId)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM igrao_za WHERE InGameId=@InGameId";
            cmd.Parameters.AddWithValue("@InGameId", inGameId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Title> GetTitlesForTeam(string teamName)
        {
            List<Title> titles = new List<Title>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM titula WHERE NazivTima=@NazivTima";
            cmd.Parameters.AddWithValue("@NazivTima", teamName);
            MySqlDataReader reader = cmd.ExecuteReader();   
            while (reader.Read())
            {
                titles.Add(new Title()
                {
                    TitleId = reader.GetInt32(0),
                    YearWon = reader.GetInt32(1),
                    Name = reader.GetString(2),
                    TeamName = reader.GetString(3)
                }); 
            }
            reader.Close();
            conn.Close();
            return titles;
        }

        public static void InsertTitle(Title title)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO titula VALUES (@IdTitule, @GodinaOsvajanja, @NazivTitule, " +
                "@NazivTima)";
            cmd.Parameters.AddWithValue("@IdTitule", null);
            cmd.Parameters.AddWithValue("@GodinaOsvajanja", title.YearWon); 
            cmd.Parameters.AddWithValue("@NazivTitule", title.Name); 
            cmd.Parameters.AddWithValue("@NazivTima", title.TeamName);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void UpdateTitle(Title title)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE titula SET GodinaOsvajanja=@GodinaOsvajanja, NazivTitule=@NazivTitule" +
                " WHERE IdTitule=@IdTitule";
            cmd.Parameters.AddWithValue("@GodinaOsvajanja", title.YearWon);
            cmd.Parameters.AddWithValue("NazivTitule", title.Name);
            cmd.Parameters.AddWithValue("IdTitule", title.TitleId);
            cmd.ExecuteNonQuery();
            conn.Close(); 
        }

        public static void DeleteTitleById(int titleId)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM titula WHERE IdTitule=@IdTitule";
            cmd.Parameters.AddWithValue("@IdTitule", titleId);
            cmd.ExecuteNonQuery();
            conn.Close(); 
        }
    }
}
