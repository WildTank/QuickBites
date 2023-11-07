using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVEDRI_online_food_ordering
{
    public partial class OrderingForm : Form
    {
        QuickBitesDataContext db = new QuickBitesDataContext();
        List<string> courseMealsIndexZero = new List<string>();
        List<string> drinksIndexOne = new List<string>();
        List<string> specialtiesIndexTwo = new List<string>();
        int currentUserID = 0;
        string currentUserName = "";
        public OrderingForm(int user_id, string user_name)
        {
            InitializeComponent();
            this.CenterToScreen();
            currentUserID = user_id;
            currentUserName = user_name;
            Debug.WriteLine("Getting ready to order!");
            var courseMealItems = from item in db.Products.ToList()
                                  where item.category == "Course Meal"
                                  select item.item;
            var drinkItems = from item in db.Products.ToList()
                             where item.category == "Drinks"
                             select item.item;
            var specialtyItems = from item in db.Products.ToList()
                                 where item.category == "Specialties"
                                 select item.item;
            courseMealsIndexZero.AddRange(courseMealItems);
            drinksIndexOne.AddRange(drinkItems);
            specialtiesIndexTwo.AddRange(specialtyItems);
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;
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
                    comboBox2.Items.AddRange(courseMealsIndexZero.ToArray());
                    break;
                case 1:
                    comboBox2.Items.AddRange(drinksIndexOne.ToArray());
                    break;
                case 2:
                    comboBox2.Items.AddRange(specialtiesIndexTwo.ToArray());
                    break;
                default:
                    break;
            }
            this.comboBox2.SelectedIndex = 0;
        }

        double totalPrice = 0.00;
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
                var price = db.Products.Where(i => i.item == orderItemName).Select(i => i.price).FirstOrDefault();
                totalPrice += Convert.ToDouble(price) * orderQuantity;
                this.label2.Text = totalPrice.ToString();
            }
        }
    }
}
