using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parkTrumpet.Domain.Entities
{
    public class parkingSessionDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public carDbTable Car { get; set; }

        [Required]
        public parkingDbTable Parking { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ArrivalTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DepartureTime { get; set; }

        public bool IsPaid { get; set; } = false;
    }
}
