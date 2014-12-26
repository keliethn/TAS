using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAS
{
    public partial class calc : Form
    {
        char current_operation = 'N';
        bool override_bit = false;
        public calc()
        {
            InitializeComponent();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (oper_txt.Text == "0" || oper_txt.Text == "ERROR - DIVISION POR CERO" || override_bit == true)
            {
                oper_txt.Text = String.Empty;
            }
            oper_txt.AppendText(button1.Text);
            override_bit = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (oper_txt.Text == "0" || oper_txt.Text == "ERROR - DIVISION POR CERO" || override_bit == true)
            {
                oper_txt.Text = String.Empty;
            }
            oper_txt.AppendText(button2.Text);
            override_bit = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (oper_txt.Text == "0" || oper_txt.Text == "ERROR - DIVISION POR CERO" || override_bit == true)
            {
                oper_txt.Text = String.Empty;
            }
            oper_txt.AppendText(button3.Text);
            override_bit = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (oper_txt.Text == "0" || oper_txt.Text == "ERROR - DIVISION POR CERO" || override_bit == true)
            {
                oper_txt.Text = String.Empty;
            }
            oper_txt.AppendText(button4.Text);
            override_bit = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (oper_txt.Text == "0" || oper_txt.Text == "ERROR - DIVISION POR CERO" || override_bit == true)
            {
                oper_txt.Text = String.Empty;
            }
            oper_txt.AppendText(button5.Text);
            override_bit = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (oper_txt.Text == "0" || oper_txt.Text == "ERROR - DIVISION POR CERO" || override_bit == true)
            {
                oper_txt.Text = String.Empty;
            }
            oper_txt.AppendText(button6.Text);
            override_bit = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (oper_txt.Text == "0" || oper_txt.Text == "ERROR - DIVISION POR CERO" || override_bit == true)
            {
                oper_txt.Text = String.Empty;
            }
            oper_txt.AppendText(button7.Text);
            override_bit = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (oper_txt.Text == "0" || oper_txt.Text == "ERROR - DIVISION POR CERO" || override_bit == true)
            {
                oper_txt.Text = String.Empty;
            }
            oper_txt.AppendText(button8.Text);
            override_bit = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (oper_txt.Text == "0" || oper_txt.Text == "ERROR - DIVISION POR CERO" || override_bit == true)
            {
                oper_txt.Text = String.Empty;
            }
            oper_txt.AppendText(button9.Text);
            override_bit = false;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (oper_txt.Text == "0" || oper_txt.Text == "ERROR - DIVISION POR CERO" || override_bit == true)
            {
                oper_txt.Text = String.Empty;
            }
            oper_txt.AppendText(button0.Text);
            override_bit = false;
        }

        private void button_dot_Click(object sender, EventArgs e)
        {
            if (oper_txt.Text == "0" || oper_txt.Text == "ERROR - DIVISION POR CERO" || override_bit == true)
            {
                oper_txt.Text = "0";
            }
            else
            {
                oper_txt.AppendText(button_dot.Text);
                override_bit = false;
            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            current_operation = 'N';
            if (oper_txt.Text.Length != 0 && oper_txt.Text != "0")
            {
                oper_txt.Text = oper_txt.Text.Remove(oper_txt.Text.Length - 1, 1);
                if (oper_txt.Text.Length == 0)
                {
                    oper_txt.Text = "0";
                }
            }
            else
            {
                return;
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            current_operation = 'N';
            oper_txt.Text = "0";
            oper_txt.Focus();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            double total_due = 0;
            if (listBox1.Items.Count <= 0)
            {
                oper_txt.Text = Convert.ToString(total_due);
            }
            else
            {
                foreach (string item in listBox1.Items)
                {
                    if (item.IndexOf('|') > 0)
                    {
                        string[] price_holder = item.Split('|');
                        total_due = Convert.ToDouble(price_holder[1]) + total_due;
                    }

                }
                oper_txt.Text = Convert.ToString(total_due);
            }

        }

        private void button21_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            oper_txt.Text = "0";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int current_amount = Convert.ToInt32(button10.Text.Substring(3));
            if (oper_txt.Text == "ERROR - DIVISION POR CERO" || override_bit == true)
            {
                oper_txt.Text = Convert.ToString(current_amount);
                override_bit = true;
            }
            else
            {
                string[] operation_members = oper_txt.Text.Split(current_operation);
                if (operation_members.Length > 1 && operation_members[1] == "")
                {
                    oper_txt.AppendText(Convert.ToString(current_amount));
                }
                else
                {
                    oper_txt.Text = Convert.ToString(current_amount);
                    override_bit = true;
                }


            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            int current_amount = Convert.ToInt32(button11.Text.Substring(3));
            if (oper_txt.Text == "ERROR - DIVISION POR CERO" || override_bit == true)
            {
                oper_txt.Text = Convert.ToString(current_amount);
                override_bit = true;
            }
            else
            {
                string[] operation_members = oper_txt.Text.Split(current_operation);
                if (operation_members.Length > 1 && operation_members[1] == "")
                {
                    oper_txt.AppendText(Convert.ToString(current_amount));
                }
                else
                {
                    oper_txt.Text = Convert.ToString(current_amount);
                    override_bit = true;
                }


            }
            //oper_txt.Text = Convert.ToString(current_amount);
            //override_bit = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int current_amount = Convert.ToInt32(button12.Text.Substring(3));
            if (oper_txt.Text == "ERROR - DIVISION POR CERO" || override_bit == true)
            {
                oper_txt.Text = Convert.ToString(current_amount);
                override_bit = true;
            }
            else
            {
                string[] operation_members = oper_txt.Text.Split(current_operation);
                if (operation_members.Length > 1 && operation_members[1] == "")
                {
                    oper_txt.AppendText(Convert.ToString(current_amount));
                }
                else
                {
                    oper_txt.Text = Convert.ToString(current_amount);
                    override_bit = true;
                }


            }
            //oper_txt.Text = Convert.ToString(current_amount);
            //override_bit = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int current_amount = Convert.ToInt32(button13.Text.Substring(3));
            if (oper_txt.Text == "ERROR - DIVISION POR CERO" || override_bit == true)
            {
                oper_txt.Text = Convert.ToString(current_amount);
                override_bit = true;
            }
            else
            {
                string[] operation_members = oper_txt.Text.Split(current_operation);
                if (operation_members.Length > 1 && operation_members[1] == "")
                {
                    oper_txt.AppendText(Convert.ToString(current_amount));
                }
                else
                {
                    oper_txt.Text = Convert.ToString(current_amount);
                    override_bit = true;
                }


            }
            //oper_txt.Text = Convert.ToString(current_amount);
            //override_bit = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int current_amount = Convert.ToInt32(button14.Text.Substring(3));
            if (oper_txt.Text == "ERROR - DIVISION POR CERO" || override_bit == true)
            {
                oper_txt.Text = Convert.ToString(current_amount);
                override_bit = true;
            }
            else
            {
                string[] operation_members = oper_txt.Text.Split(current_operation);
                if (operation_members.Length > 1 && operation_members[1] == "")
                {
                    oper_txt.AppendText(Convert.ToString(current_amount));
                }
                else
                {
                    oper_txt.Text = Convert.ToString(current_amount);
                    override_bit = true;
                }

            }
            //oper_txt.Text = Convert.ToString(current_amount);
            //override_bit = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int current_amount = Convert.ToInt32(button15.Text.Substring(3));
            if (oper_txt.Text == "ERROR - DIVISION POR CERO" || override_bit == true)
            {
                oper_txt.Text = Convert.ToString(current_amount);
                override_bit = true;
            }
            else
            {
                string[] operation_members = oper_txt.Text.Split(current_operation);
                if (operation_members.Length > 1 && operation_members[1] == "")
                {
                    oper_txt.AppendText(Convert.ToString(current_amount));
                }
                else
                {
                    oper_txt.Text = Convert.ToString(current_amount);
                    override_bit = true;
                }


            }
            //oper_txt.Text = Convert.ToString(current_amount);
            //override_bit = true;
        }

        private void division_Click(object sender, EventArgs e)
        {
            if (current_operation != 'N')
            {
                string[] operation_members = oper_txt.Text.Split(current_operation);
                if (operation_members.Length > 1 && operation_members[1] == "")
                {
                    string current_txt = oper_txt.Text;
                    string exchange = current_txt.Replace(current_operation, Convert.ToChar(division.Text));
                    current_operation = Convert.ToChar(division.Text);
                    oper_txt.Text = exchange;
                }
                else
                {
                    make_operation(Convert.ToDecimal(operation_members[0]), current_operation, Convert.ToDecimal(operation_members[1]));
                    current_operation = Convert.ToChar(division.Text);
                    oper_txt.AppendText(division.Text);
                }
            }
            else
            {
                current_operation = Convert.ToChar(division.Text);
                oper_txt.AppendText(division.Text);
            }
            override_bit = false;

        }

        private void multiply_Click(object sender, EventArgs e)
        {
            if (current_operation != 'N')
            {
                string[] operation_members = oper_txt.Text.Split(current_operation);
                if (operation_members.Length > 1 && operation_members[1] == "")
                {
                    string current_txt = oper_txt.Text;
                    string exchange = current_txt.Replace(current_operation, Convert.ToChar(multiply.Text));
                    current_operation = Convert.ToChar(multiply.Text);
                    oper_txt.Text = exchange;
                }
                else
                {
                    make_operation(Convert.ToDecimal(operation_members[0]), current_operation, Convert.ToDecimal(operation_members[1]));
                    current_operation = Convert.ToChar(multiply.Text);
                    oper_txt.AppendText(multiply.Text);
                }
            }
            else
            {
                current_operation = Convert.ToChar(multiply.Text);
                oper_txt.AppendText(multiply.Text);
            }
            override_bit = false;
        }

        private void minus_Click(object sender, EventArgs e)
        {
            if (current_operation != 'N')
            {
                string[] operation_members = oper_txt.Text.Split(current_operation);
                if (operation_members.Length > 1 && operation_members[1] == "")
                {
                    string current_txt = oper_txt.Text;
                    string exchange = current_txt.Replace(current_operation, Convert.ToChar(substraction.Text));
                    current_operation = Convert.ToChar(substraction.Text);
                    oper_txt.Text = exchange;
                }
                else
                {
                    make_operation(Convert.ToDecimal(operation_members[0]), current_operation, Convert.ToDecimal(operation_members[1]));
                    current_operation = Convert.ToChar(substraction.Text);
                    oper_txt.AppendText(substraction.Text);
                }
            }
            else
            {
                current_operation = Convert.ToChar(substraction.Text);
                oper_txt.AppendText(substraction.Text);
            }
            override_bit = false;
        }

        private void addition_Click(object sender, EventArgs e)
        {
            if (current_operation != 'N')
            {
                string[] operation_members = oper_txt.Text.Split(current_operation);
                if (operation_members.Length > 1 && operation_members[1] == "")
                {
                    string current_txt = oper_txt.Text;
                    string exchange = current_txt.Replace(current_operation, Convert.ToChar(addition.Text));
                    current_operation = Convert.ToChar(addition.Text);
                    oper_txt.Text = exchange;
                }
                else
                {
                    make_operation(Convert.ToDecimal(operation_members[0]), current_operation, Convert.ToDecimal(operation_members[1]));
                    current_operation = Convert.ToChar(addition.Text);
                    oper_txt.AppendText(addition.Text);
                }
            }
            else
            {
                current_operation = Convert.ToChar(addition.Text);
                oper_txt.AppendText(addition.Text);
            }
            override_bit = false;
        }

        private void perform_oper_Click(object sender, EventArgs e)
        {
            //No operation recorded 
            if (current_operation == 'N')
            {
                // No number in oper_txt
                if (oper_txt.Text == "0")
                {
                    listBox1.Items.Add("-----------------------------------");
                    override_bit = true;
                }
                // A number recorded in oper_txt, no operation rerorded
                else
                {
                    override_bit = true;
                }

            }
            //Operation recorded
            else
            {
                string[] operation_members = oper_txt.Text.Split(current_operation);
                // Case 1*,1+,1-,1/
                if (operation_members.Length > 1 && operation_members[1] == "")
                {
                    decimal entrada = Convert.ToDecimal(oper_txt.Text);
                    make_operation(entrada, current_operation, entrada);
                    current_operation = 'N';
                    override_bit = true;
                    return;
                }
                //Case 1+1,1-1,1*1,1/1
                else
                {
                    if (current_operation == 'N')
                    {
                        override_bit = true;
                        return;
                    }
                    else
                    {
                        make_operation(Convert.ToDecimal(operation_members[0]), current_operation, Convert.ToDecimal(operation_members[1]));
                        current_operation = 'N';
                        override_bit = true;
                    }

                }

            }
        }

        private void make_operation(decimal v1, char operation, decimal v2)
        {
            string result = null;
            switch (operation)
            {
                case '+':
                    result = Convert.ToString(v1 + v2);
                    break;
                case '-':
                    result = Convert.ToString(v1 - v2);
                    break;
                case '*':
                    result = Convert.ToString(v1 * v2);
                    break;
                case '/':
                    if (v2 == 0 && v1 != 0)
                    {
                        result = "ERROR - DIVISION POR CERO";
                    }
                    else
                    {
                        result = Convert.ToString(v1 / v2);
                    }

                    break;
            }
            oper_txt.Text = result;
            if (result != "ERROR - DIVISION POR CERO")
            {
                listBox1.Items.Add(Convert.ToString(v1) + " " + operation + " " + Convert.ToString(v2)+"\n\r".PadRight(15, '.') + "  " + result);
            }
        }

    }
}
