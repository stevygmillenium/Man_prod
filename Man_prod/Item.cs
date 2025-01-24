using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Man_prod
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float price {  get; set; }
        public int quantity {  get; set; }
        public byte[] img {  get; set; }
        public string image {  get; set; }
    }    
}