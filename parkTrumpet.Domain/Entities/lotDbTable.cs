using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parkTrumpet.Domain.Entities
{
    public class lotDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public parkingDbTable Parking { get; set; }

        public int Number { get; set; }

        public bool IsActive { get; set; }
    }
}
