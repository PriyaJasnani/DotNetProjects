﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsJuly
{
    public class BookMaster
    {
        [Key]
        [Required]
        public int Bookid { get; set; }

        [Required] 
        public string BookName { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public double Price { get; set;}

        [Required]
        public string BookLanguage { get; set; }
    }
}
