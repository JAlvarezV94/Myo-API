using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Myo.Models
{

    public class Myo
    {

        [Key]
        public int IdMyo { get; set; }

        public User Owner { get; set; }

        public string Title { get; set; }

        public string Goal { get; set; }

        public List<Checkpoint> CheckpointList { get; set; }

    }
}