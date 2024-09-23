using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTO_Quanly
{
    public class DTO_Cow: DTO_Animal
    {
        private static Random rand = new Random();
        public DTO_Cow(int id, int qty): base(id, qty)
        {
            typeAnimal = "Cow";
        }

        public override string MakeSound()
        {
            return "Moo";
        }

        public override int ProduceMilk()
        {
            // Giới hạn 0 – 20 lít
            return rand.Next(0, 21);
        }

        public override int Reproduce()
        {
            // Giả sử mỗi con bò sinh từ 1 đến 3 con
            return rand.Next(1, 4);
        }
    }
}
