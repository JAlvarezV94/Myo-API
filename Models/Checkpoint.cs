using System;
using System.ComponentModel.DataAnnotations;

namespace Myo.Models
{
    public class Checkpoint
    {
        [Key]
        public int IdCheckpoint { get; set; }

        public DateTime Date { get; set; }

        public string TestDescription { get; set; }
    }
}