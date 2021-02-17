using MentoringProgram.Abstract;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace MentoringProgram.BussinessLogic
{
    public class AdoNetHelper: IAdoNetHelper
    {
        private readonly IConfiguration config;

        public AdoNetHelper(IConfiguration config)
        {
            this.config = config;
        }

        public List<Models.Game> GetGames()
        {
            var games = new List<Models.Game>();
            var conectionString = config.GetValue<string>("ConnectionStrings:DefaultConnection");

            string sql = "Select Game.ID, Game.Name, Description, SystemRequirenments, Genres, InterfaceLanguages, FullSupportLanguage, ReleaseDate, IsFreeToPLay, Price, GameCreator.Name as 'CreatorName', GamePublisher.Name as 'PublisherName' FROM Game INNER JOIN GameCreator ON(Game.DeveloperID = GameCreator.ID) INNER JOIN GamePublisher ON(Game.PublisherID = GamePublisher.ID)";

            using (var connection = new SqlConnection(conectionString))
            {
                var command = new SqlCommand(sql, connection);
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        games.Add(MapGame(dataReader));
                    }
                }

                dataReader.Close();
            }

            return games;
        }

        public Models.Game GetGame(int id)
        {
            var game = new Models.Game();
            var conectionString = config.GetValue<string>("ConnectionStrings:DefaultConnection");

            string sql = $"Select Game.ID, Game.Name, Description, SystemRequirenments, Genres, InterfaceLanguages, FullSupportLanguage, ReleaseDate, IsFreeToPLay, Price, GameCreator.Name as 'CreatorName', GamePublisher.Name as 'PublisherName' FROM Game INNER JOIN GameCreator ON(Game.DeveloperID = GameCreator.ID) INNER JOIN GamePublisher ON(Game.PublisherID = GamePublisher.ID) WHERE Game.ID=@GameID";

            using (var connection = new SqlConnection(conectionString))
            {
                var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@GameID", id);
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    if (dataReader.Read())
                    {
                        game = MapGame(dataReader);
                    }
                }

                dataReader.Close();
            }

            return game;
        }

        public bool UpdateGame(int id, Models.Game game)
        {
            var conectionString = config.GetValue<string>("ConnectionStrings:DefaultConnection");

            string sql = $"UPDATE Game SET Name = @Name, Description = @Description, SystemRequirenments = @SystemRequirenments, Genres = @Genres, InterfaceLanguages = @InterfaceLanguages, FullSupportLanguage = @FullSupportLanguage, ReleaseDate = @ReleaseDate, IsFreeToPlay = @IsFreeToPlay, Price = @Price WHERE ID = @GameID";

            using (var connection = new SqlConnection(conectionString))
            {
                var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Name", game.Name);
                command.Parameters.AddWithValue("@Description", game.Description);
                command.Parameters.AddWithValue("@SystemRequirenments", game.SystemRequirenments);
                command.Parameters.AddWithValue("@Genres", string.Join(",", game.Genres));
                command.Parameters.AddWithValue("@InterfaceLanguages", string.Join(",", game.InterfaceLanguages));
                command.Parameters.AddWithValue("@FullSupportLanguage", string.Join(",", game.FullSupportLanguage));
                command.Parameters.AddWithValue("@ReleaseDate", game.ReleaseDate);
                command.Parameters.AddWithValue("@IsFreeToPLay", game.IsFreeToPlay);
                command.Parameters.AddWithValue("@Price", game.Price);
                command.Parameters.AddWithValue("@GameID", id);
                var result = command.ExecuteNonQueryAsync().Result;
                return result == 1;
            }
        }

        public bool Insert(Models.Game game)
        {
            var conectionString = config.GetValue<string>("ConnectionStrings:DefaultConnection");

            string sqlCreator = $"SELECT ID FROM GameCreator WHERE Name = @Developer";
            string sqlPublisher = $"SELECT ID FROM GameCreator WHERE Name = @Publisher";
           
            using (var connection = new SqlConnection(conectionString))
            {
                var creatorID = 0;
                var publisherID = 0;
                var commandCreator  = new SqlCommand(sqlCreator, connection);
                commandCreator.Parameters.AddWithValue("@Developer", game.Developer);
                var resultCreator = commandCreator.ExecuteReader();
                if (resultCreator.HasRows)
                {
                    if (resultCreator.Read())
                    {
                        creatorID = resultCreator.GetInt32(0);
                        resultCreator.Close();
                    }
                    else
                    {
                        resultCreator.Close();
                        return false;
                    }
                }

                var commandPublisher = new SqlCommand(sqlPublisher, connection);
                commandPublisher.Parameters.AddWithValue("@Publisher", game.Publisher);
                var resultresultPubliser = commandPublisher.ExecuteReader();
                if (resultresultPubliser.HasRows)
                {
                    if (resultresultPubliser.Read())
                    {
                        publisherID = resultresultPubliser.GetInt32(0);
                        resultresultPubliser.Close();
                    }
                    else
                    {
                        resultresultPubliser.Close();
                        return false;
                    }
                }
                
                string sql = $"INSERT INTO Game (Name, Description, SystemRequirenments, Genres, InterfaceLanguages, FullSupportLanguage, ReleaseDate, IsFreeToPLay, Price, DeveloperID, PublisherID) VALUES (@Name, @Description, @SystemRequirenments, @Genres, @InterfaceLanguages, @FullSupportLanguage, @ReleaseDate, @IsFreeToPLay, @IsFreeToPLay, @Price, @CreatorID, @PublisherID";

                var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Name", game.Name);
                command.Parameters.AddWithValue("@Description", game.Description);
                command.Parameters.AddWithValue("@SystemRequirenments", game.SystemRequirenments);
                command.Parameters.AddWithValue("@Genres", string.Join(",", game.Genres));
                command.Parameters.AddWithValue("@InterfaceLanguages", string.Join(",", game.InterfaceLanguages));
                command.Parameters.AddWithValue("@FullSupportLanguage", string.Join(",", game.FullSupportLanguage));
                command.Parameters.AddWithValue("@ReleaseDate", game.ReleaseDate);
                command.Parameters.AddWithValue("@IsFreeToPLay", game.IsFreeToPlay);
                command.Parameters.AddWithValue("@Price", game.Price);
                command.Parameters.AddWithValue("@creatorID", creatorID);
                command.Parameters.AddWithValue("@publisherID", publisherID);
                var result = command.ExecuteNonQuery();
                return result == 1;
            }
        }

        private Models.Game MapGame(SqlDataReader dataReader)
        {
            return new Models.Game
            {
                Id = dataReader.GetInt32(0),
                Name = dataReader.GetString(1),
                Description = dataReader.GetString(2),
                SystemRequirenments = dataReader.GetString(3),
                Genres = dataReader.GetString(4).Split(',').ToList(),
                InterfaceLanguages = dataReader.GetString(5).Split(',').ToList(),
                FullSupportLanguage = dataReader.GetString(6).Split(',').ToList(),
                ReleaseDate = dataReader.GetString(7),
                IsFreeToPlay = dataReader.GetBoolean(8),
                Price = dataReader.GetDecimal(9),
                Developer = dataReader.GetString(10),
                Publisher = dataReader.GetString(10)
            };
        }
    }
}
