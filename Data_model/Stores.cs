using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customers.Data_model
{
    public class Stores
    {
        [Key] 
        public int Store_id { get; set; }
        public string Store_name { get; set; }

        public double Store_lat {  get; set; }

        public double Store_long { get; set; }

    }
}
