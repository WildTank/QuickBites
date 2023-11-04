using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVEDRI_online_food_ordering
{
    public partial class Homepage : Form
    {
        EVEDRI_online_food_ordering.OrderingForm orderForm = new OrderingForm();
        EVEDRI_online_food_ordering.MainHomePage mainHomePage = new MainHomePage();
        public Homepage()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // start ordering button
            this.Hide();
            orderForm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // "our menu" label treated as logout button
            this.Hide();
            mainHomePage.Show();
        }
    }
}