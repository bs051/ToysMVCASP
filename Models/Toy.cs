using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToysMVCASP.Models
{
    public class Toy
    {
        // data annotation to set Primary key
        [Key]
        public int ToyId { get; set; }
        // save rtoy name
        public string ToyName { get; set; }
        // save toy price
        public double  Price { get; set; }
        // toy age group setting,s stores age
        public int AgeGroup { get; set; }
        // toy rating out of 10
        public int ToyRating { get; set; }


        public int CategoryID { get; set; }
        public Category CategoryObj { get; set; }

    }
}
