using MentoringProgram.Abstract;
using MentoringProgram.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace MentoringProgram.BussinessLogic
{
    public class StoredProceduresAndUDFHelper : IStoredProceduresAndUDFHelper
    {
        private readonly MentoringContext _mentoringContext;

        public StoredProceduresAndUDFHelper(MentoringContext mentoringContext)
        {
            _mentoringContext = mentoringContext;
        }

        public List<Game> GetGames()
        {
            return _mentoringContext.Games.FromSqlRaw("EXEC dbo.GetGames").ToList();
        }

        public Game GetGame(int id)
        {
            var param = new SqlParameter("@ID", id);
            return _mentoringContext.Games.FromSqlRaw("EXEC dbo.GetGame @ID", param).FirstOrDefault();
        }

        public bool InsertGame(Models.Game game)
        {
            var sql = "EXEC dbo.InsertGame @Name @Description @SystemRequirenments @Genres @Genres @InterfaceLanguages @FullSupportLanguage @ReleaseDate @IsFreeToPLay @Price, @Developer, @Publisher";
            var parameters = new string[] { game.Name, game.Description, game.SystemRequirenments, string.Join(",", game.Genres), string.Join(",", game.InterfaceLanguages), string.Join(",", game.FullSupportLanguage), game.ReleaseDate, game.IsFreeToPlay.ToString(), game.Price.ToString(), game.Developer, game.Publisher };
            var result = _mentoringContext.Database.ExecuteSqlRaw(sql, parameters: parameters);
            return result == 1;
        }


        public bool UpdateGame(int id, Models.Game game)
        {
            var sql = "EXEC dbo.UpdateGame @ID, @Name @Description @SystemRequirenments @Genres @Genres @InterfaceLanguages @FullSupportLanguage @ReleaseDate @IsFreeToPLay @Price";
            var parameters = new string[] { id.ToString(), game.Name, game.Description, game.SystemRequirenments, string.Join(",", game.Genres), string.Join(",", game.InterfaceLanguages), string.Join(",", game.FullSupportLanguage), game.ReleaseDate, game.IsFreeToPlay.ToString(), game.Price.ToString() };
            var result =_mentoringContext.Database.ExecuteSqlRaw(sql, parameters: parameters);
            return result == 1;
        }
    }
}
