using MentoringProgram.Abstract;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
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

            string sql = $"Select Game.ID, Game.Name, Description, SystemRequirenments, Genres, InterfaceLanguages, FullSupportLanguage, ReleaseDate, IsFreeToPLay, Price, GameCreator.Name as 'CreatorName', GamePublisher.Name as 'PublisherName' FROM Game INNER JOIN GameCreator ON(Game.DeveloperID = GameCreator.ID) INNER JOIN GamePublisher ON(Game.PublisherID = GamePublisher.ID) WHERE Game.ID={id}";

            using (var connection = new SqlConnection(conectionString))
            {
                var command = new SqlCommand(sql, connection);
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

            string sql = $"UPDATE Game SET Name = {game.Name}, Description = {game.Description}, SystemRequirenments = {game.SystemRequirenments}, Genres = {string.Join(",", game.Genres)}, InterfaceLanguages = {string.Join(",", game.InterfaceLanguages)}, FullSupportLanguage = {string.Join(",", game.FullSupportLanguage)}, ReleaseDate = {game.ReleaseDate}, IsFreeToPLay = {game.IsFreeToPlay}, Price = {game.Price} WHERE ID = {id}";

            using (var connection = new SqlConnection(conectionString))
            {
                var command = new SqlCommand(sql, connection);
                var result = command.ExecuteNonQueryAsync().Result;
                return result == 1;
            }
        }

        public bool Insert(Models.Game game)
        {
            var conectionString = config.GetValue<string>("ConnectionStrings:DefaultConnection");

            string sqlCreator = $"SELECT ID FROM GameCreator WHERE Name ={game.Developer}";
            string sqlPublisher = $"SELECT ID FROM GameCreator WHERE Name ={game.Developer}";
           
            using (var connection = new SqlConnection(conectionString))
            {
                var creatorID = 0;
                var publisherID = 0;
                var commandCreator  = new SqlCommand(sqlCreator, connection);                                        
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
                
                string sql = $"INSERT INTO Game (Name, Description, SystemRequirenments, Genres, InterfaceLanguages, FullSupportLanguage, ReleaseDate, IsFreeToPLay, Price, DeveloperID, PublisherID) VALUES ({game.Name}, {game.Description}, {game.SystemRequirenments}, {string.Join(",", game.Genres)}, {string.Join(",", game.InterfaceLanguages)}, {string.Join(",", game.FullSupportLanguage)}, {game.ReleaseDate}, {game.IsFreeToPlay}, {game.Price}, {creatorID}, {publisherID}";

                var command = new SqlCommand(sql, connection);
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
