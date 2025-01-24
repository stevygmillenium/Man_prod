using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Man_prod
{
    public class order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string card_type { get; set; }
        public string data { get; set; }
        public DateTime dateTime { get; set; }
        public float amount { get; set; }
    }
}