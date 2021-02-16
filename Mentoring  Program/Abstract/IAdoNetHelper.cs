using System.Collections.Generic;

namespace MentoringProgram.Abstract
{
    public interface IAdoNetHelper
    {
        List<Models.Game> GetGames();

        Models.Game GetGame(int id);

        bool UpdateGame(int id, Models.Game game);

        bool Insert(Models.Game game);
    }
}
