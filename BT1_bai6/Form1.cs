using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_Quanly;
using DTO_Quanly;

namespace BT1_bai6
{
    public partial class Form1 : Form
    {
        Farm farm;
        public Form1()
        {
            InitializeComponent();
            farm = new Farm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DTO_Animal a;
            int textBoxValue = int.Parse(textBox1.Text);
            var selectedText = comboBox1.Text;
            
            DataTable dt = farm.getAnimal();

            if (dt.Rows.Count == 3)
            {
                comboBox1.Enabled = false;  // Khóa ComboBox
                return;
            }
            if (selectedText == "Cow")
            {
                a = new DTO_Cow(dt.Rows.Count,textBoxValue);
                farm.AddAnimal(a);
            }
            else if (selectedText == "Goat")
            {
                a = new DTO_Goat(dt.Rows.Count, textBoxValue);
                farm.AddAnimal(a);
            }
            else if (selectedText == "Sheep")
            {
                a = new DTO_Sheep(dt.Rows.Count, textBoxValue);
                farm.AddAnimal(a);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            richTextBox1.Visible = false;
            //dt.Columns.Add("ID", typeof(int));
            //dt.Columns.Add("Type", typeof(string));
            //dt.Columns.Add("Qty", typeof(int));
            farm.SimulateReproduction();
            DataTable dt = farm.getAnimal();
            // Gán DataTable vào DataGridView
            dataGridView1.DataSource = dt;

            // Đặt tên cột cho DataGridView sau khi gán DataSource
            dataGridView1.Columns["AnimalID"].HeaderText = "Mã";
            dataGridView1.Columns["TypeAnimal"].HeaderText = "Vật nuôi";
            dataGridView1.Columns["Quantity"].HeaderText = "Số lượng";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            richTextBox1.Visible = false;
            farm.CalculateTotalMilk();
            DataTable dt = farm.getMilkProduction();
            //dt.Columns.Add("ID", typeof(int));
            //dt.Columns.Add("Type", typeof(string));
            //dt.Columns.Add("Qty", typeof(int));

            // Gán DataTable vào DataGridView
            dataGridView1.DataSource = dt;

            // Đặt tên cột cho DataGridView sau khi gán DataSource
            dataGridView1.Columns["MilkID"].HeaderText = "Mã";
            dataGridView1.Columns["TypeAnimal"].HeaderText = "Vật nuôi";
            dataGridView1.Columns["Liters"].HeaderText = "Số lượng sữa";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = true;
            dataGridView1.Visible = false;
            richTextBox1.Text = farm.GetAllSounds();
        }
    }
}
