using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_bloc.Model
{
    public class Salarie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Nom { get; set; }
        [Required]
        [StringLength(80)]
        public string Prenom { get; set; }
        [Required]
        [StringLength(80)]
        public string TelFixe { get; set; }
        [Required]
        [StringLength(80)]
        public string TelPortable { get; set; }
        [Required]
        [StringLength(80)]
        public string Email { get; set; }
        public int Service { get; set; }
        public string ServiceNom { get; set; }
        public int Site { get; set; }
        public string SiteNom { get; set; }
    }
}
