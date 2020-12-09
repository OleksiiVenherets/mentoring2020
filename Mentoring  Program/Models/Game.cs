﻿using System;
using System.Collections.Generic;

namespace Mentoring_Program.Models
{
    public class Game
    {
        public string Name { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public List<string> Genres { get; set; }

        public bool IsFreeToPlay { get; set; }

        public decimal? Price { get; set; }

        public string Description { get; set; }

        public string SystemRequirenments { get; set; }

        public List<string> InterfaceLanguages { get; set; }

        public List<string> FullSupportLanguage { get; set; }

        public string Developer { get; set; }

        public string Publisher { get; set; }

    }
}
