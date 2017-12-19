﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.pakad
{
   public class AdStatus
    {

        

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
    }
}
