using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVEDRI_online_food_ordering
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        accountdetailsDataContext db = new accountdetailsDataContext();

        private void button1_Click(object sender, EventArgs e)
        {
            // login button
            string usernameInput = this.textBox1.Text;
            string passwordInput = this.textBox2.Text;
            var user = db.UserAccounts.Where(u => u.username == usernameInput).FirstOrDefault();
            //  ^^^ the first row that has matching username, is null if none
            try
            {
                if (user.pass == passwordInput)
                {
                    this.Hide();
                    var productsPage = new Homepage();
                    productsPage.Show();
                }
            }
            catch (System.NullReferenceException)
            {
                // pass
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // previous button
            this.Hide();
            var mainHomePage = new MainHomePage();
            mainHomePage.Show();
        }
    }
}
