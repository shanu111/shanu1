using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.user
{
  public  class Role
    {
        private int id;
        // TODO: Do something
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
