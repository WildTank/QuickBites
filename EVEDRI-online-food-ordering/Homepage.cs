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
        int currentUserID = 0;
        string currentUserName = "";
        public Homepage(int user_id, string user_name)
        {
            InitializeComponent();
            this.CenterToScreen();
            currentUserID = user_id;
            currentUserName = user_name;
            this.label3.Text = user_name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // start ordering button
            this.Hide();
            var orderForm = new OrderingForm(currentUserID, currentUserName);
            orderForm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // "our menu" label treated as logout button
            this.Hide();
            var mainHomePage = new MainHomePage();
            mainHomePage.Show();
        }
    }
}