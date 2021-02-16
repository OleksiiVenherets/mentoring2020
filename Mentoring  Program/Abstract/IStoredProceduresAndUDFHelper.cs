using MentoringProgram.DataModels;
using System.Collections.Generic;

namespace MentoringProgram.Abstract
{
    public interface IStoredProceduresAndUDFHelper
    {
        List<Game> GetGames();

        Game GetGame(int id);

        bool InsertGame(Models.Game game);

        bool UpdateGame(int id, Models.Game game);
    }
}
