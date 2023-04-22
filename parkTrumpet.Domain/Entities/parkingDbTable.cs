using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parkTrumpet.Domain.Entities
{
    public class parkingDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ownerDbTable Owner { get; set; }

        public bool hasCamera { get; set; }
        public bool hasBarrier { get; set; }
        public bool hasLotSensor { get; set; }

        public int FreeTime { get; set; }

        public float DayPrice { get; set; }

        public float NightPrice { get; set; }
        
    }
}
