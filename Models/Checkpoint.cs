using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Myo.Models
{
    public class Checkpoint
    {
        [Key]
        public int IdCheckpoint { get; set; }

        public DateTime Date { get; set; }

        public string TestDescription { get; set; }

        public int IdMyo { get; set; }
        
        [ForeignKey("MyoIdMyo")]
        public Myo Myo { get; set; }
    }
}