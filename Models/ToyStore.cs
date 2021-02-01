using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToysMVCASP.Models
{
    public class ToyStore
    {
        // data annotation to set primary key
        [Key]
        public int ToyStoreId { get; set; }
        // store name
        public string StoreNAme { get; set; }
        // store city
        public string City { get; set; }
        // store contact no
        public string Phone { get; set; }
        
        // store opening time
        [DataType(DataType.Time)]
        public DateTime OpeningTime { get; set; }

        // store closing time
        [DataType(DataType.Time)]
        public DateTime ClosingTime { get; set; }

    }
}
