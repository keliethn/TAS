using Media.res;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using TAS.Utilities;


namespace TAS
{
    public partial class MainScreen : Form
    {
        string sm_name;
        string sm_usrname;
        calc new_calc = new calc();
        public MainScreen(string Salesman_name, string salesman_username)
        {
            InitializeComponent();
            sm_name = Salesman_name;
            sm_usrname = salesman_username;
        }

        public string payment_amount { get { return due_amount.Text; } }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string qtyHolderText = qtyHolder.Text;
            string number2Add = button1.Text;
            string newNumberHolder = qtyHolderText + number2Add;
            qtyHolder.Text = newNumberHolder;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string qtyHolderText = qtyHolder.Text;
            string number2Add = button2.Text;
            string newNumberHolder = qtyHolderText + number2Add;
            qtyHolder.Text = newNumberHolder;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string qtyHolderText = qtyHolder.Text;
            string number2Add = button3.Text;
            string newNumberHolder = qtyHolderText + number2Add;
            qtyHolder.Text = newNumberHolder;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string qtyHolderText = qtyHolder.Text;
            string number2Add = button4.Text;
            string newNumberHolder = qtyHolderText + number2Add;
            qtyHolder.Text = newNumberHolder;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string qtyHolderText = qtyHolder.Text;
            string number2Add = button5.Text;
            string newNumberHolder = qtyHolderText + number2Add;
            qtyHolder.Text = newNumberHolder;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string qtyHolderText = qtyHolder.Text;
            string number2Add = button6.Text;
            string newNumberHolder = qtyHolderText + number2Add;
            qtyHolder.Text = newNumberHolder;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string qtyHolderText = qtyHolder.Text;
            string number2Add = button7.Text;
            string newNumberHolder = qtyHolderText + number2Add;
            qtyHolder.Text = newNumberHolder;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string qtyHolderText = qtyHolder.Text;
            string number2Add = button8.Text;
            string newNumberHolder = qtyHolderText + number2Add;
            qtyHolder.Text = newNumberHolder;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string qtyHolderText = qtyHolder.Text;
            string number2Add = button9.Text;
            string newNumberHolder = qtyHolderText + number2Add;
            qtyHolder.Text = newNumberHolder;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string qtyHolderText = qtyHolder.Text;
            string number2Add = button0.Text;
            string newNumberHolder = qtyHolderText + number2Add;
            qtyHolder.Text = newNumberHolder;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if ((lblInfo.Text != "") && (Convert.ToInt32(qtyHolder.Text) > 10))
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button0.Enabled = true;
                remove_item.Enabled = true;
                clear_all.Enabled = true;
                pay_tickets.Enabled = true;
                locations_group.Enabled = true;
                lblInfo.Text = String.Empty;
            }
            qtyHolder.Text = String.Empty;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            catch (Exception)
            {

                return;
            }
            changeDueAmount();
        }


        private void qtyHolder_TextChanged(object sender, EventArgs e)
        {
            int ticket_qty;
            if (qtyHolder.Text == "")
            {
                ticket_qty = 0;
            }
            else
            {
                ticket_qty = Convert.ToInt32(qtyHolder.Text);
            }

            if (ticket_qty > 10)
            {
                lblInfo.Text = "NO ESTA PERMITIDO VENDER MÁS DE 10 BOLETOS POR CADA UBICACIÓN";
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button0.Enabled = false;
                remove_item.Enabled = false;
                clear_all.Enabled = false;
                pay_tickets.Enabled = false;
                locations_group.Enabled = false;
            }
        }
        private void changeDueAmount()
        {
            double total_due = 0;
            foreach (string item in listBox1.Items)
            {
                string[] price_holder = item.Split('$');
                total_due = Convert.ToDouble(price_holder[2]) + total_due;
            }
            due_amount.Text = Convert.ToString(total_due);
        }

        private int getNumberOfItemInSaleList()
        {
            int total_items = 0;
            foreach (string item in listBox1.Items)
            {
                total_items++;
            }
            return total_items;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            changeDueAmount();
        }

        private void pay_tickets_Click(object sender, EventArgs e)
        {
            Payment payment_form = new Payment(due_amount.Text, sm_usrname, listBox1);
            payment_form.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed  
            payment_form.ShowDialog(this);
        }

        void child_FormClosed(object sender, FormClosedEventArgs e)
        {
            listBox1.Items.Clear();
            changeDueAmount();
            XmlReader xmlFile = XmlReader.Create("Cash.count", new XmlReaderSettings());
            DataSet dataSet = new DataSet();
            //Read xml to dataset
            dataSet.ReadXml(xmlFile);
            //Pass empdetails table to datagridview datasource
            dataGridView1.DataSource = dataSet.Tables["CashSection"];
            //Close xml reader
            xmlFile.Close();
            XDocument xmlDoc = XDocument.Load("Cash.count");
            var cash_list =
                    from cash_count in xmlDoc.Descendants("CashSection")
                    select new CashCount
                    {
                        LocationName = cash_count.Element("Concepto").Value,
                        Count = Convert.ToInt32(cash_count.Element("Cantidad").Value),
                        Subtotal = Convert.ToDecimal(cash_count.Element("Subtotal").Value)


                    };
            cash_list.ToList<CashCount>();
            decimal cash_count_total = 0;
            foreach (var item in cash_list)
            {
                cash_count_total += item.Subtotal;
            }
            cash_count_total_label.Text = Convert.ToString(cash_count_total);
        }

        private void logoff_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            new_calc.Hide();
            pay_tickets.Enabled = false;
            XDocument xmlDoc = XDocument.Load("Tickets.config");
            var tickets_list =
                    from tickets in xmlDoc.Descendants("Item")
                    select new Tickets
                    {
                        LocationName = tickets.Element("Name").Value,
                        LocationPrice = tickets.Element("Value").Value

                    };
            int columnNumber = 0;
            int rowNumber = 0;
            foreach (var item in tickets_list)
            {

                Button button = new Button();
                button.Name = "locval_" + item.LocationPrice.Remove(item.LocationPrice.Length - 5, 5);
                button.Text = item.LocationName;
                button.Dock = DockStyle.Fill;
                button.Height = 75;
                button.BackColor = Color.LightYellow;
                button.Click += new EventHandler(tickets_btn_Click);

                locationsTableLayout.Controls.Add(button, columnNumber, rowNumber);
                rowNumber++;

            }
            XmlReader xmlFile = XmlReader.Create("Cash.count", new XmlReaderSettings());
            DataSet dataSet = new DataSet();
            //Read xml to dataset
            dataSet.ReadXml(xmlFile);
            //Pass empdetails table to datagridview datasource
            dataGridView1.DataSource = dataSet.Tables["CashSection"];
            //Close xml reader
            xmlFile.Close();
            XDocument xmlCash = XDocument.Load("Cash.count");
            var cash_list =
                    from cash_count in xmlCash.Descendants("CashSection")
                    select new CashCount
                    {
                        LocationName = cash_count.Element("Concepto").Value,
                        Count = Convert.ToInt32(cash_count.Element("Cantidad").Value),
                        Subtotal = Convert.ToDecimal(cash_count.Element("Subtotal").Value)


                    };
            cash_list.ToList<CashCount>();
            decimal cash_count_total = 0;
            foreach (var item in cash_list)
            {
                cash_count_total += item.Subtotal;
            }
            cash_count_total_label.Text = Convert.ToString(cash_count_total);
            currentSalesmanLabel.Text = "Operador: " + sm_name;
        }

        private void logout_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "Está seguro de cerrar el turno actual?.\n\rSi escoge 'SI':\n\r1- El sistema se bloqueará.\n\r2- NO PODRA REALIZAR MAS VENTAS\n\r3- Se imprimirá un informe de cierre\n\r4- La estación quedará inactiva (No podrá entrar al sistema)\n\r5- El sistema se cerrará", "Verificación de Cierre de Turno", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    return;
                    break;
                default:
                    string station_id = null;
                    XDocument stationDoc = XDocument.Load("Station.config");
                    var station_list =
                            from station1 in stationDoc.Descendants("Station")
                            select new StationConfig
                            {
                                UUID = station1.Element("UUID").Value
                            };
                    station_list.ToList<StationConfig>();
                    foreach (var item in station_list)
                    {
                        station_id = item.UUID;
                    }
                    if (CheckForInternetConnection())
                    {
                        TASEntities db = new TASEntities();


                        try
                        {
                            Terminal selected_terminal = db.Terminals.FirstOrDefault(t => t.UUID == station_id);
                            selected_terminal.Status = false;
                            db.Entry(selected_terminal).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(Convert.ToString(ex.InnerException));
                        }
                    }
                    else
                    {
                        XDocument stationDoc2 = XDocument.Load("Station.config");
                        var station_list2 =
                                from station2 in stationDoc2.Descendants("Station")
                                where station2.Element("UUID").Value == station_id
                                select station2;
                        foreach (var station_item2 in station_list2)
                        {

                            station_item2.Element("Status").Value = Convert.ToString(false);
                          
                        }
                        stationDoc2.Save("Station.config");
                    }
                    PrintDialog printDialog = new PrintDialog();
                    PrintDocument printDocument = new PrintDocument();
                    //add the document to the dialog box... 
                    printDialog.Document = printDocument;
                    //add an event handler that will do the printing
                    printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateCashCountReport);
                    printDocument.Print();
                    Application.Exit();
                    break;
            }

        }

        private void clear_all_Click(object sender, EventArgs e)
        {
            pay_tickets.Enabled = false;
            listBox1.Items.Clear();
            changeDueAmount();
        }

        private void remove_item_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                if (getNumberOfItemInSaleList() > 0)
                {
                    pay_tickets.Enabled = true;
                }
                else
                {
                    pay_tickets.Enabled = false;
                }
                changeDueAmount();
            }
            catch (Exception)
            {

                return;
            }
        }

        private void pay_tickets_Click_1(object sender, EventArgs e)
        {
            Payment payment_form = new Payment(due_amount.Text, sm_usrname, listBox1);
            payment_form.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed  
            payment_form.ShowDialog(this);
        }

        private void tickets_btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string location_value = btn.Name.Substring(7);
            StringBuilder sb = new StringBuilder();
            if (qtyHolder.Text.Length <= 0)
            {
                sb.AppendFormat(Constants.list_item, "01", btn.Text, location_value);
                string subtotal_string = Constants.currency_symbol + " " + location_value;
                listBox1.Items.Add(sb.ToString().PadRight(29, '.') + subtotal_string);
            }
            else
            {
                string numOfTickets = null;
                if (qtyHolder.Text.Length < 2)
                {
                    numOfTickets = "0" + qtyHolder.Text;
                }
                else
                {
                    numOfTickets = qtyHolder.Text;
                }
                sb.AppendFormat(Constants.list_item, numOfTickets, btn.Text, location_value);
                float subtotal = Convert.ToInt32(qtyHolder.Text) * Convert.ToInt32(location_value);
                string subtotal_string = Constants.currency_symbol + " " + Convert.ToString(subtotal);
                listBox1.Items.Add(sb.ToString().PadRight(29, '.') + subtotal_string);
            }
            qtyHolder.Text = String.Empty;
            if (getNumberOfItemInSaleList() > 0)
            {
                pay_tickets.Enabled = true;
            }
            changeDueAmount();

        }

        private void qtyHolder_TextChanged_1(object sender, EventArgs e)
        {
            int ticket_qty;
            if (qtyHolder.Text == "")
            {
                ticket_qty = 0;
                if (getNumberOfItemInSaleList() > 0)
                {
                    pay_tickets.Enabled = true;
                }
                else
                {
                    pay_tickets.Enabled = false;
                }

            }
            else
            {
                ticket_qty = Convert.ToInt32(qtyHolder.Text);
                pay_tickets.Enabled = true;
            }

            if (ticket_qty > 10)
            {
                lblInfo.Text = "NO ESTA PERMITIDO VENDER MÁS DE 10 BOLETOS POR CADA UBICACIÓN";
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button0.Enabled = false;
                remove_item.Enabled = false;
                clear_all.Enabled = false;
                pay_tickets.Enabled = false;
                locations_group.Enabled = false;
            }
        }

        private void button10_Click_2(object sender, EventArgs e)
        {
            LockScreen lock_screen = new LockScreen(sm_name, sm_usrname);
            this.Hide();
            lock_screen.ShowDialog();
            this.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new_calc.ShowDialog();
        }

        public void CreateCashCountReport(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //this prints the reciept
            Image logo = Resources.fsr;
            Graphics graphic = e.Graphics;
            string short_date = DateTime.Now.ToShortDateString();
            string short_time = DateTime.Now.ToShortTimeString();
            string report_title = "Reporte de Caja";
            graphic.FillRectangle(new SolidBrush(Color.Black), 0, 0, 320, 30);
            int title_start_position = ((Constants.ticket_width / 2) - ((report_title.Length * 14) / 2));
            string game_date = DateTime.Now.ToLongDateString();

            graphic.DrawString(report_title.ToUpper(), new Font("Courier New", 15, FontStyle.Bold), new SolidBrush(Color.White), title_start_position, 3);

            graphic.DrawImage(logo, 80, 35);

            graphic.DrawString("Campeonato Nacional", new Font("Courier New", 7), new SolidBrush(Color.Black), 100, 104);
            graphic.DrawString("Germán Pomares Ordoñez", new Font("Courier New", 7), new SolidBrush(Color.Black), 92, 114);
            graphic.DrawString("2015", new Font("Courier New", 7), new SolidBrush(Color.Black), 147, 124);

            Font font = new Font("Courier New", 10); //must use a mono spaced font as the spaces need to line up
            string top = "Cant.".PadRight(10) + "Localidad".PadRight(15) + "Subtotal";
            graphic.DrawString(top, font, new SolidBrush(Color.Black), 10, 138);

            graphic.DrawString("----------------------------------", font, new SolidBrush(Color.Black), 10, 148);
            decimal totalprice = 0;
            int offset_list = 160;
            XDocument xmlCash = XDocument.Load("Cash.count");
            var cash_list =
                    from cash_count in xmlCash.Descendants("CashSection")
                    select new CashCount
                    {
                        LocationName = cash_count.Element("Concepto").Value,
                        Count = Convert.ToInt32(cash_count.Element("Cantidad").Value),
                        Subtotal = Convert.ToDecimal(cash_count.Element("Subtotal").Value)
                    };
            cash_list.ToList<CashCount>();
            foreach (var item in cash_list)
            {
                //create the string to print on the reciept

                string productLine = Convert.ToString(item.Count).PadRight(10) + Convert.ToString(item.LocationName).PadRight(15) + "C$ " + Convert.ToString(item.Subtotal);
                graphic.DrawString(productLine, new Font("Courier New", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, offset_list);
                offset_list += 15;
                totalprice += item.Subtotal;

            }

            graphic.DrawString("C$ " + Convert.ToString(totalprice), new Font("Courier New", 10), new SolidBrush(Color.Black), 225, offset_list + 20);

            graphic.DrawString("Fecha de impresión", new Font("Courier New", 6), new SolidBrush(Color.Black), 20, 340);
            graphic.DrawString(short_date + "  " + short_time, new Font("Courier New", 6), new SolidBrush(Color.Black), 20, 347);
            graphic.DrawString("Terminal: " + Constants.station_id, new Font("Courier New", 6), new SolidBrush(Color.Black), 20, 354);


        }
        private static bool CheckForInternetConnection()
        {
            // return true;
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
    }
}
