using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customers.Data_model
{
    public class Customers
    {

        [Key] public int Customer_id { get; set; }
        public string Customer_name { get; set; }

        public double Customer_lat { get; set; }

        public double Customer_long { get; set; }

    }
}
