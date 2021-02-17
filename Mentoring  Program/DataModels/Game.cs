#nullable disable

namespace MentoringProgram.DataModels
{
    public partial class Game
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string SystemRequirenments { get; set; }
       
        public string Genres { get; set; }
        
        public string InterfaceLanguages { get; set; }
        
        public string FullSupportLanguage { get; set; }
        
        public string ReleaseDate { get; set; }
        
        public bool? IsFreeToPlay { get; set; }
        
        public decimal? Price { get; set; }
        
        public int? DeveloperId { get; set; }
        
        public int? PublisherId { get; set; }

        public virtual GameCreator Developer { get; set; }
        
        public virtual GamePublisher Publisher { get; set; }
    }
}
