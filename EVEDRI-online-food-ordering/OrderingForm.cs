using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVEDRI_online_food_ordering
{
    public partial class OrderingForm : Form
    {
        string[] courseMealsIndexZero = { "Course 1", "Course 2", "Course 3" };
        string[] drinksIndexOne = { "Drink 1", "Drink 2", "Drink 3" };
        string[] specialtiesIndexTwo = { "Special1", "Special2", "Special3" };
        int currentUserID = 0;
        string currentUserName = "";
        public OrderingForm(int user_id, string user_name)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;
            currentUserID = user_id;
            currentUserName = user_name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // return to products page button
            this.Hide();
            var productsPage = new Homepage(currentUserID, currentUserName);
            productsPage.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // changing selected index of combo box
            comboBox2.Items.Clear();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    comboBox2.Items.AddRange(courseMealsIndexZero);
                    break;
                case 1:
                    comboBox2.Items.AddRange(drinksIndexOne);
                    break;
                case 2:
                    comboBox2.Items.AddRange(specialtiesIndexTwo);
                    break;
                default:
                    break;
            }
            this.comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // add item button
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            bool orderDetailsFull = false;
            // handles quantity
            string quantity = this.textBox1.Text;
            int orderQuantity;
            if (!int.TryParse(quantity, out orderQuantity))
            {
                this.textBox1.Text = "Input invalid";
                this.textBox1.ForeColor = System.Drawing.Color.Red;
            } else
            {
                this.textBox1.ForeColor = System.Drawing.Color.Green;
                orderDetailsFull = true;
            }
            // handles adding order item to order list
            if (orderDetailsFull)
            {
                string orderItemName = comboBox2.Text;
                this.listBox1.Items.Add($"{orderItemName} ({orderQuantity})");
            }
        }
    }
}
