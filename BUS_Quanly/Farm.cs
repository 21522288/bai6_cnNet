using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Quanly;
using DAL_Quanly;
using System.Data;

namespace BUS_Quanly
{
    public class Farm
    {
        public List<DTO_Animal> Animals { get; set; }

        DAL_ReProduction dalreproduction = new DAL_ReProduction();
        DAL_Animal dalanimal = new DAL_Animal();
        DAL_MilkProduction dalmilk = new DAL_MilkProduction();
        public Farm()
        {
            Animals = new List<DTO_Animal>();
        }

        public void AddAnimal(DTO_Animal animal)
        {
            dalanimal.InsertAnimal(animal.GetAnimalID(), animal.GetTypeAnimal(), animal.GetQuantity());
            dalmilk.InsertMilkProduction(animal.GetAnimalID(), animal.GetAnimalID(), 0);
            dalreproduction.InsertReproduction(animal.GetAnimalID(), animal.GetAnimalID(), 0);
        }

        public void getAllAnimals()
        {
            DataTable dt = dalanimal.getAnimal();
            // Khởi tạo danh sách mới
            Animals = new List<DTO_Animal>();

            // Duyệt qua từng hàng trong DataTable
            foreach (DataRow row in dt.Rows)
            {
                // Tạo một đối tượng DTO_Animal từ từng hàng
                if (row["TypeAnimal"].ToString() == "Cow")
                {
                    DTO_Animal animal = new DTO_Cow(Convert.ToInt32(row["AnimalID"]), Convert.ToInt32(row["Quantity"]));
                    Animals.Add(animal);
                }    
                else if (row["TypeAnimal"].ToString() == "Goat")
                {
                    DTO_Animal animal = new DTO_Goat(Convert.ToInt32(row["AnimalID"]), Convert.ToInt32(row["Quantity"]));
                    Animals.Add(animal);
                }
                if (row["TypeAnimal"].ToString() == "Sheep")
                {
                    DTO_Animal animal = new DTO_Sheep(Convert.ToInt32(row["AnimalID"]), Convert.ToInt32(row["Quantity"]));
                    Animals.Add(animal);
                }
            }

        }

        public string GetAllSounds()
        {
            getAllAnimals();
            StringBuilder sounds = new StringBuilder();
            foreach (var animal in Animals)
            {
                for (int i = 0; i < animal.GetQuantity(); i++)
                {
                    sounds.Append(animal.MakeSound() + " ");
                }
            }
            return sounds.ToString().Trim();
        }

        public void SimulateReproduction()
        {
            getAllAnimals();
            foreach (var animal in Animals)
            {
                int count = 0;
                for (int i = 0; i < animal.GetQuantity(); i++)
                {
                    int offspring = animal.Reproduce();
                    count += offspring;
                    // Ghi vào cơ sở dữ liệu bảng Reproduction
                    // ...
                }
                dalanimal.UpdateAnimal(animal.GetAnimalID(), count + animal.GetQuantity());
                dalreproduction.UpdateReproduction(animal.GetAnimalID(), count);
            }
        }

        public void CalculateTotalMilk()
        {
            getAllAnimals();

            foreach (var animal in Animals)
            {
                int totalMilk = 0;
                for (int i = 0; i < animal.GetQuantity(); i++)
                {
                    totalMilk += animal.ProduceMilk();
                    // Ghi vào cơ sở dữ liệu bảng MilkProduction
                    // ...
                }
                dalmilk.UpdateMilkProductionl(animal.GetAnimalID(), totalMilk);
            }
        }

        public DataTable getMilkProduction()
        {
            DataTable dt = dalmilk.getMilkProduction();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("MilkID", typeof(int));
            dt2.Columns.Add("TypeAnimal", typeof(string));
            dt2.Columns.Add("Liters", typeof(int));
            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["AnimalID"]);
                string type = dalanimal.getTypeAnimal(id);
                dt2.Rows.Add(Convert.ToInt32(row["MilkID"]), type, Convert.ToInt32(row["Liters"]));
            }
            return dt2;
        }
        public DataTable getAnimal()
        {
            return dalanimal.getAnimal();
        }
    }
}
