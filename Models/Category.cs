using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToysMVCASP.Enums;

namespace ToysMVCASP.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Brand { get; set; }
        public Gender ForGender { get; set; }

    }
}
