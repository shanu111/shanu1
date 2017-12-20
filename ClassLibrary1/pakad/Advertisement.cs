using ClassLibrary1.user;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.pakad
{
   
   public class Advertisement
    {
        
        public Advertisement()
        {
            Images = new List<AdImage>();
        }
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(300)]
        public string Title { get; set; }

        [Column(TypeName = "varchar")]
        public string Description { get; set; }

        public float Price { get; set; }
        public Nullable< bool> isFeatured { get; set; }

        public DateTime PostedOn { get; set; }
        public DateTime ValidUpto { get; set; }

        [Required]
        public virtual User User { get; set; }

        [Required]
        public virtual City City { get; set; }

        [Required]
        public virtual SubCategory SubCategory { get; set; }

        [Required]
        public virtual AdType Type { get; set; }

        [Required]
        public virtual AdStatus Status { get; set; }

        public virtual ICollection<AdImage> Images { get; set; }
    }
}
