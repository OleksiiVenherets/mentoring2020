using System.Collections.Generic;

#nullable disable

namespace MentoringProgram.DataModels
{
    public partial class GameCreator
    {
        public GameCreator()
        {
            Games = new HashSet<Game>();
        }

        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Country { get; set; }
        
        public string Address { get; set; }
        
        public string Owner { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
