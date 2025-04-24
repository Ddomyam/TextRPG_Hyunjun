using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public enum ItemType
    {
        Attack,
        Defense
    }
    internal class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Stats { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool isHaving { get; set; }
        public bool isEquipped { get; set; }
        public ItemType Type { get; set; }

        List<Items> items = new List<Items>();
       
    }   
}
