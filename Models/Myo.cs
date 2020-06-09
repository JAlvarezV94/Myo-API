using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Myo.Models
{

    public class Myo
    {

        [Key]
        public int IdMyo { get; set; }

        public int OwnerIdUser { get; set; }

        [ForeignKey("OwnerIdUser")]
        public User Owner { get; set; }

        public string Title { get; set; }

        public string Goal { get; set; }

        public List<Checkpoint> CheckpointList { get; set; }

    }
}