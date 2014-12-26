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
using TAS.Utilities;

namespace TAS
{
    public partial class LockScreen : Form
    {
        string salesman_username;
        string salesman_fullname;
        public LockScreen(string fullname, string username)
        {
            InitializeComponent();
            salesman_username = username;
            salesman_fullname = fullname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_pwd.AppendText(button1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_pwd.AppendText(button2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txt_pwd.AppendText(button3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txt_pwd.AppendText(button4.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txt_pwd.AppendText(button5.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txt_pwd.AppendText(button6.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txt_pwd.AppendText(button7.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txt_pwd.AppendText(button8.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txt_pwd.AppendText(button9.Text);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            txt_pwd.AppendText(button0.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (txt_pwd.Text.Length != 0)
            {
                txt_pwd.Text = txt_pwd.Text.Remove(txt_pwd.Text.Length - 1, 1);
            }
            else
            {
                return;
            }

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_pwd.Text = String.Empty;
            txt_pwd.Focus();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            TASEntities db = new TASEntities();
            string password = txt_pwd.Text;
            if (CheckForInternetConnection())
            {
                Salesman salesman_finder = db.Salesmen.FirstOrDefault(salesman_entity => salesman_entity.UserName == salesman_username && salesman_entity.Password == password);
                if (salesman_finder != null)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Los datos ingresados no corresponden al vendedor activo. Verifique su contraseña");
                }
            }
            else
            {
                XDocument xmlDoc = XDocument.Load("Salesmen.info");
                var salesmen_list =
                        from salesmen in xmlDoc.Descendants("Salesman")
                        select new Salesman2
                        {
                            UserName = salesmen.Element("UserName").Value,
                            FirstName = salesmen.Element("FirstName").Value,
                            LastName = salesmen.Element("LastName").Value,
                            Password = salesmen.Element("Password").Value,
                            Status = Convert.ToBoolean(salesmen.Element("Status").Value)

                        };
                int isRegistered = salesmen_list.Where(salesman_entity => salesman_entity.UserName == salesman_username && salesman_entity.Password == password).Count();
                if (isRegistered > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Los datos ingresados no corresponden al vendedor activo. Verifique su contraseña");
                }

            }
        }

        private static bool CheckForInternetConnection()
        {
            return true;
            //try
            //{
            //    using (var client = new WebClient())
            //    using (var stream = client.OpenRead(Resources.PingURL))
            //    {
            //        return true;
            //    }
            //}
            //catch
            //{
            //    return false;
            //}
        }

        private void LockScreen_Load(object sender, EventArgs e)
        {
            usr_lbl.Text = salesman_username;
            lbl_salesman_fullname.Text = salesman_fullname;

        }
    }
}
