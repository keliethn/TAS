using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TAS
{
    public partial class StartupCash : Form
    {
        string sm_username;
        string sm_fullname;
        public StartupCash(string fullname, string username)
        {
            InitializeComponent();
            sm_fullname = fullname;
            sm_username = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (startup_cash_txt.Text == "0")
            {
                startup_cash_txt.Text = String.Empty;
            }
            startup_cash_txt.AppendText(button1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (startup_cash_txt.Text == "0")
            {
                startup_cash_txt.Text = String.Empty;
            }
            startup_cash_txt.AppendText(button2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (startup_cash_txt.Text == "0")
            {
                startup_cash_txt.Text = String.Empty;
            }
            startup_cash_txt.AppendText(button3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (startup_cash_txt.Text == "0")
            {
                startup_cash_txt.Text = String.Empty;
            }
            startup_cash_txt.AppendText(button4.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (startup_cash_txt.Text == "0")
            {
                startup_cash_txt.Text = String.Empty;
            }
            startup_cash_txt.AppendText(button5.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (startup_cash_txt.Text == "0")
            {
                startup_cash_txt.Text = String.Empty;
            }
            startup_cash_txt.AppendText(button6.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (startup_cash_txt.Text == "0")
            {
                startup_cash_txt.Text = String.Empty;
            }
            startup_cash_txt.AppendText(button7.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (startup_cash_txt.Text == "0")
            {
                startup_cash_txt.Text = String.Empty;
            }
            startup_cash_txt.AppendText(button8.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (startup_cash_txt.Text == "0")
            {
                startup_cash_txt.Text = String.Empty;
            }
            startup_cash_txt.AppendText(button9.Text);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (startup_cash_txt.Text == "0")
            {
                startup_cash_txt.Text = String.Empty;
            }
            startup_cash_txt.AppendText(button0.Text);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            startup_cash_txt.Text = String.Empty;
            startup_cash_txt.Focus();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (startup_cash_txt.Text.Length != 0 && startup_cash_txt.Text != "0")
            {
                startup_cash_txt.Text = startup_cash_txt.Text.Remove(startup_cash_txt.Text.Length - 1, 1);
                if (startup_cash_txt.Text.Length == 0)
                {
                    startup_cash_txt.Text = "0";
                }
            }
            else
            {
                return;
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            XDocument xmlDoc = XDocument.Load("Cash.count");
            var cash_list =
                    from cash in xmlDoc.Descendants("CashSection")
                    where cash.Element("Concepto").Value == "Efectivo"
                    select cash;
            foreach (var cash_item in cash_list)
            {
                int cash_count = Convert.ToInt32(cash_item.Element("Cantidad").Value);
                int cash_amount = Convert.ToInt32(cash_item.Element("Subtotal").Value);
                cash_item.Element("Cantidad").Value = "1";
                cash_item.Element("Subtotal").Value = startup_cash_txt.Text;
            }
            xmlDoc.Save("Cash.count");
            MainScreen main_screen = new MainScreen(sm_fullname, sm_username);
            main_screen.Show();
            this.Hide();
        }
    }
}
