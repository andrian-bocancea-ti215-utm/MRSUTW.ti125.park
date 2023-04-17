using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parkTrumpet.Domain.Entities
{
    public class carDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string RegistrationPlate { get; set; }
        
        [Required]
        public string Brand { get; set; }

        public string ModelName { get; set; }

        public string Color { get; set; }

        public clientDbTable Client { get; set; }

    }
}
