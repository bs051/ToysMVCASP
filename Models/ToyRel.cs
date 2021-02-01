using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToysMVCASP.Models
{
    public class ToyRel
    {
       // toy rel 
        [Key]
        public  int ToyRelId { get; set; }
        // is toy in stock
        public bool InStock { get; set; } = true;
        // toy stock quantity
        public int AvailableQuantity { get; set; }

        // fk relations

        public int ToyId { get; set; }
        public Toy ToyObj { get; set; }


        public int ToyStoreId { get; set; }
        public ToyStore ToyStoreObj { get; set; }
    }
}
