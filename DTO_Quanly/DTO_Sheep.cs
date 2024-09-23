using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTO_Quanly
{
    public class DTO_Sheep:DTO_Animal
    {
        private static Random rand = new Random();


        public DTO_Sheep(int id, int qty) : base(id, qty)
        {
            typeAnimal = "Sheep";
        }

        public override string MakeSound()
        {
            return "Baa";
        }

        public override int ProduceMilk()
        {
            // Giới hạn 0 – 5 lít
            return rand.Next(0, 6);
        }

        public override int Reproduce()
        {
            // Giả sử mỗi con cừu sinh từ 1 đến 2 con
            return rand.Next(1, 3);
        }
    }
}
