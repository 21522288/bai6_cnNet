using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Quanly
{
    public abstract class DTO_Animal
    {
        private int AnimalID;
        protected string typeAnimal;
        private int quantity;

        public DTO_Animal(int id, int qty)
        {
            AnimalID = id;
            quantity = qty;
        }
        public int GetQuantity()
        {
            return quantity;
        }

        public void SetQuantity(int value)
        {
            quantity = value;
        }

        public string GetTypeAnimal()
        {
            return typeAnimal;
        }

        public void SetTypeAnimal(string value)
        {
            typeAnimal = value;
        }

        public int GetAnimalID()
        {
            return AnimalID;
        }

        public void SetAnimalID(int value)
        {
            AnimalID = value;
        }

        public abstract string MakeSound();
        public abstract int ProduceMilk();
        public abstract int Reproduce();
    }
}
