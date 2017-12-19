using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.user
{
  public  class Signup
    {
        public int Id { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string FirstName { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string LasttName { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string password { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string City { get; set; }
    }
}
