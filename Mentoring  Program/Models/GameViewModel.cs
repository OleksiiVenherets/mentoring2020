﻿using System;

namespace MentoringProgram.Models
{
    public class GameViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string Description { get; set; }

        public string Developer { get; set; }

        public string Publisher { get; set; }
    }
}
