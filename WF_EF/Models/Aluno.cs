using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_EF.Models
{
    public class Aluno
    {
        [Key]
        public int AlunoId { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public override string ToString() => Nome.Trim();
    }
}
