using Media.res;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
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
        private const string AuthToken = "HRpIjHRpIj120iKN";
        private const string pass_phrase = "Tong888Neat421";
        private const int key_size = 64;
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
            string plain_password = txt_pwd.Text;
            string encrypted_pass = EncryptThis(plain_password);
            if (CheckForInternetConnection())
            {
                Salesman salesman_finder = db.Salesmen.FirstOrDefault(salesman_entity => salesman_entity.UserName == salesman_username && salesman_entity.Password == encrypted_pass);
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
                int isRegistered = salesmen_list.Where(salesman_entity => salesman_entity.UserName == salesman_username && salesman_entity.Password == encrypted_pass).Count();
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
            //return true;
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead(Resources.PingURL))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void LockScreen_Load(object sender, EventArgs e)
        {
            usr_lbl.Text = salesman_username;
            lbl_salesman_fullname.Text = salesman_fullname;

        }
        private string EncryptThis(string plain_text)
        {
            byte[] init_vector_bytes = Encoding.UTF8.GetBytes(AuthToken);
            byte[] plain_text_bytes = Encoding.UTF8.GetBytes(plain_text);
            PasswordDeriveBytes password = new PasswordDeriveBytes(pass_phrase, null);
            byte[] key_bytes = password.GetBytes(key_size / 8);
            RijndaelManaged symmetric_key = new RijndaelManaged();
            symmetric_key.Mode = CipherMode.CBC;
            symmetric_key.Padding = PaddingMode.PKCS7;
            ICryptoTransform encryptor = symmetric_key.CreateEncryptor(key_bytes, init_vector_bytes);
            MemoryStream memory_stream = new MemoryStream();
            CryptoStream crypto_stream = new CryptoStream(memory_stream, encryptor, CryptoStreamMode.Write);
            crypto_stream.Write(plain_text_bytes, 0, plain_text_bytes.Length);
            crypto_stream.FlushFinalBlock();
            byte[] cipher_text_bytes = memory_stream.ToArray();
            memory_stream.Close();
            crypto_stream.Close();
            return Convert.ToBase64String(cipher_text_bytes);
        }

        public string DecryptThis(string cipher_text)
        {
            byte[] init_vector_bytes = Encoding.UTF8.GetBytes(AuthToken);
            byte[] cipher_text_bytes = Encoding.UTF8.GetBytes(cipher_text);
            PasswordDeriveBytes password = new PasswordDeriveBytes(pass_phrase, null);
            byte[] key_bytes = password.GetBytes(key_size / 8);
            RijndaelManaged symmetric_key = new RijndaelManaged();
            symmetric_key.Mode = CipherMode.CBC;
            symmetric_key.Padding = PaddingMode.PKCS7;
            ICryptoTransform decryptor = symmetric_key.CreateDecryptor(key_bytes, init_vector_bytes);
            MemoryStream memory_stream = new MemoryStream();
            CryptoStream crypto_stream = new CryptoStream(memory_stream, decryptor, CryptoStreamMode.Read);
            byte[] plain_text_bytes = new byte[cipher_text_bytes.Length];
            int decrypted_byte_count = crypto_stream.Read(plain_text_bytes, 0, plain_text_bytes.Length);
            memory_stream.Close();
            crypto_stream.Close();
            return Encoding.UTF8.GetString(plain_text_bytes, 0, decrypted_byte_count);
        }
    }
}
