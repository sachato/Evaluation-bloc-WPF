using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_bloc.Model
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Nom { get; set; }
    }
}
