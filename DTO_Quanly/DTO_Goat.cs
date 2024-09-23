using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTO_Quanly
{
    public class DTO_Goat:DTO_Animal
    {
        private static Random rand = new Random();

        public DTO_Goat(int id, int qty):base(id, qty)
        {
            typeAnimal = "Goat";
        }

        public override string MakeSound()
        {
            return "Bleat";
        }

        public override int ProduceMilk()
        {
            // Giới hạn 0 – 10 lít
            return rand.Next(0, 11);
        }

        public override int Reproduce()
        {
            // Giả sử mỗi con dê sinh từ 1 đến 2 con
            return rand.Next(1, 3);
        }
    }
}
