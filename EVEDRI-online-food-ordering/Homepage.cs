using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVEDRI_online_food_ordering
{
    public partial class Homepage : Form
    {
        int currentUserID = 0;
        string currentUserName = "";
        QuickBitesDataContext db = new QuickBitesDataContext();
        public Homepage(int user_id, string user_name)
        {
            InitializeComponent();
            this.CenterToScreen();
            currentUserID = user_id;
            currentUserName = user_name;
            this.label19.Text = user_name;
            List<string> courseMealList = new List<string>();
            List<string> drinksList = new List<string>();
            List<string> specialtiesList = new List<string>();
            var courseMeal = from item in db.Products.ToList()
                             where item.category == "Course Meal"
                             select item.item;
            var drinks = from item in db.Products.ToList()
                         where item.category == "Drinks"
                         select item.item;
            var specialties = from item in db.Products.ToList()
                         where item.category == "Specialties"
                         select item.item;
            courseMealList.AddRange(courseMeal);
            drinksList.AddRange(drinks);
            specialtiesList.AddRange(specialties);
            // dynamic product page menu
            int groupBoxLabelIndex = 0;
            foreach (Control c in groupBox1.Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.Panel))
                {
                    foreach (Control d in c.Controls)
                    {
                        d.Text = courseMealList.ElementAt(groupBoxLabelIndex);
                        groupBoxLabelIndex++;
                    }
                }
            }
            groupBoxLabelIndex = 0;
            foreach (Control c in groupBox2.Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.Panel))
                {
                    foreach (Control d in c.Controls)
                    {
                        d.Text = drinksList.ElementAt(groupBoxLabelIndex);
                        groupBoxLabelIndex++;
                    }
                }
            }
            groupBoxLabelIndex = 0;
            foreach (Control c in groupBox3.Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.Panel))
                {
                    foreach (Control d in c.Controls)
                    {
                        d.Text = specialtiesList.ElementAt(groupBoxLabelIndex);
                        groupBoxLabelIndex++;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // start ordering button
            this.Hide();
            var orderForm = new OrderingForm(currentUserID, currentUserName);
            orderForm.Show();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainHomePage = new MainHomePage();
            mainHomePage.Show();
        }
    }
}