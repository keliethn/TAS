using Media.res;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using TAS.Utilities;

namespace TAS
{
    public partial class Startup : Form
    {
        public Startup()
        {
            InitializeComponent();
        }

        private void Startup_Load(object sender, EventArgs e)
        {
            // bool Verification = false;
            string UUID = GetProcessorID() + "-" + GetMotherBoardID() + "-" + GetHddID();

            if (CheckForInternetConnection())
            {
                InternetStatusLabel.Text = Resources.Online.ToUpper();
                if (VerifyRegistration(StationVerificationType.Online, UUID))
                {
                    StationStatusLabel.Text = Resources.RegisteredStation.ToUpper();
                    /// This station is registered and here we save the 
                    /// 1. Station Configuration in Station.config file
                    string path = Environment.CurrentDirectory + "/Resources/";
                    TASEntities db = new TASEntities();
                    var terminal_data = db.Terminals.Where(terminal_entity => terminal_entity.UUID == UUID).ToList();
                    List<Terminal> term_list = terminal_data;
                    if (File.Exists("Station.config"))
                    {
                        File.Delete("Station.config");
                    }
                    XmlTextWriter station_writer = new XmlTextWriter("Station.config", System.Text.Encoding.UTF8);
                    station_writer.WriteStartDocument(true);
                    station_writer.Formatting = Formatting.Indented;
                    station_writer.Indentation = 2;
                    station_writer.WriteStartElement("Station");
                    foreach (var item in terminal_data)
                    {
                        createStationNode(item.UUID, item.Location.LocationName, item.Status, station_writer);
                    }
                    station_writer.WriteEndElement();
                    station_writer.WriteEndDocument();
                    station_writer.Close();
                    // 2.- Ticket data (Name, Price) in Tickets.xml file
                    int ticket_location = term_list.First().LocationID;
                    var ticket_data = db.Tickets.Where(tickets_entity => tickets_entity.TicketLocation == ticket_location && tickets_entity.Status == true).ToList();
                    if (File.Exists("Tickets.config"))
                    {
                        File.Delete("Tickets.config");
                        if (File.Exists("Cash.count"))
                        {
                            File.Delete("Cash.count");
                        }
                    }
                    XmlTextWriter ticket_writer = new XmlTextWriter("Tickets.config", System.Text.Encoding.UTF8);
                    ticket_writer.WriteStartDocument(true);
                    ticket_writer.Formatting = Formatting.Indented;
                    ticket_writer.Indentation = 2;
                    ticket_writer.WriteStartElement("Ticket");
                    XmlTextWriter cashcount_writer = new XmlTextWriter("Cash.count", System.Text.Encoding.UTF8);
                    cashcount_writer.WriteStartDocument(true);
                    cashcount_writer.Formatting = Formatting.Indented;
                    cashcount_writer.Indentation = 2;
                    cashcount_writer.WriteStartElement("Cash");
                    createCashCount("Efectivo", 0, cashcount_writer);
                    foreach (var item in ticket_data)
                    {
                        createTicketNode(item.Name, item.Value, item.Status, ticket_writer);
                        createCashCount(item.Name,0,cashcount_writer);
                    }
                    ticket_writer.WriteEndElement();
                    ticket_writer.WriteEndDocument();
                    ticket_writer.Close();
                    cashcount_writer.WriteEndElement();
                    cashcount_writer.WriteEndDocument();
                    cashcount_writer.Close();

                    //Cash Count

                    // 3.- The Game data (Home Club, Visitor, Game Place, Date and Time) in GameData.xml file

                    DateTime TodayDate = DateTime.Now.Date;
                    var loaded_game = db.Games.Where(game_entity => game_entity.GameDate == TodayDate && game_entity.GameStatus == 2);
                    if (loaded_game.Count() <= 0)
                    {
                        var nearest_active_game = db.Games.Where(game_entity => game_entity.GameStatus == 2 && game_entity.GameDate > TodayDate).Take(1);
                        if (nearest_active_game.Count() <= 0)
                        {
                            GameInfoLabel.ForeColor = Color.Red;
                            GameInfoLabel.Text = Resources.NoUpcomingGames.ToUpper();
                            loginPanel.Enabled = false;
                        }
                        else
                        {
                            DateTime next_game_date = nearest_active_game.First().GameDate;
                            TimeSpan t = TodayDate - next_game_date;
                            double NrOfDays = t.TotalDays;
                            GameInfoLabel.ForeColor = Color.Orange;
                            GameInfoLabel.Text = "Faltan " + Convert.ToString(NrOfDays) + " días para el próximo juego";
                            loginPanel.Enabled = false;
                        }

                    }
                    else
                    {
                        if (File.Exists("Game.config"))
                        {
                            File.Delete("Game.config");
                        }
                        XmlTextWriter game_writer = new XmlTextWriter("Game.config", System.Text.Encoding.UTF8);
                        game_writer.WriteStartDocument(true);
                        game_writer.Formatting = Formatting.Indented;
                        game_writer.Indentation = 2;
                        game_writer.WriteStartElement("Game");
                        foreach (var item in loaded_game)
                        {
                            createGameNode(item.HomeClubName, item.VisitorName, item.GameDate, item.Location.LocationName, game_writer);
                        }
                        game_writer.WriteEndElement();
                        game_writer.WriteEndDocument();
                        game_writer.Close();
                        GameInfoLabel.Text = loaded_game.First().HomeClubName.ToUpper() + " VS. " + loaded_game.First().VisitorName.ToUpper();
                        PlaceInfoLabel.Text = loaded_game.First().Location.LocationName.ToUpper();
                    }
                    // 4.- The list of operators (Name,username) assigned to this game to create the login screen
                    int terminal_id = term_list.First().TerminalID;
                    var salesman_list = db.Salesmen.Where(salesman_entity => salesman_entity.Status == true && salesman_entity.AssignedTerminal == terminal_id);
                    if (File.Exists("Salesmen.info"))
                    {
                        File.Delete("Salesmen.info");
                    }
                    XmlTextWriter salesman_writer = new XmlTextWriter("Salesmen.info", System.Text.Encoding.UTF8);
                    salesman_writer.WriteStartDocument(true);
                    salesman_writer.Formatting = Formatting.Indented;
                    salesman_writer.Indentation = 2;
                    salesman_writer.WriteStartElement("Salesmen");
                    foreach (var item in salesman_list)
                    {
                        createSalesmanNode(item.UserName, item.Password, item.FirstName, item.LastName, item.Status, salesman_writer);
                    }
                    salesman_writer.WriteEndElement();
                    salesman_writer.WriteEndDocument();
                    salesman_writer.Close();

                    var salesmen =
                            from sl in salesman_list
                            select new SalesmanList
                            {
                                Name = sl.FirstName + " " + sl.LastName,
                                Value = sl.UserName
                            };
                    List<SalesmanList> slm = salesmen.ToList<SalesmanList>();
                    int columnNumber = 0;
                    foreach (var item in slm)
                    {
                        int rowNumber = 0;
                        Button button = new Button();
                        button.Name = "smid_" + item.Value;
                        button.Text = item.Name;
                        button.Dock = DockStyle.Fill;
                        button.Click += new EventHandler(salesman_btn_Click);
                        if ((columnNumber / 3) != 1)
                        {

                            tableLayoutPanel1.Controls.Add(button, columnNumber, rowNumber);
                        }
                        else
                        {
                            rowNumber++;
                            columnNumber = 0;
                            tableLayoutPanel1.Controls.Add(button, columnNumber, rowNumber);
                        }

                        columnNumber++;
                    }
                }
                else
                {
                    StationStatusLabel.ForeColor = System.Drawing.Color.Red;
                    StationStatusLabel.Text = Resources.UnregisteredStation.ToUpper();
                    loginPanel.Enabled = false;
                }
            }
            else
            {
                InternetStatusLabel.ForeColor = System.Drawing.Color.Red;
                InternetStatusLabel.Text = Resources.Offline.ToUpper();
                if (VerifyRegistration(StationVerificationType.Offline, UUID))
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
                    salesmen_list.ToList<Salesman2>();
                    int columnNumber = 0;
                    foreach (var item in salesmen_list)
                    {
                        int rowNumber = 0;
                        Button button = new Button();
                        button.Name = "smid_" + item.UserName;
                        button.Text = item.FirstName + " " + item.LastName;
                        button.Dock = DockStyle.Fill;
                        button.Click += new EventHandler(salesman_btn_Click);
                        if (item.Status == true)
                        {
                            if ((columnNumber / 3) != 1)
                            {

                                tableLayoutPanel1.Controls.Add(button, columnNumber, rowNumber);
                            }
                            else
                            {
                                rowNumber++;
                                columnNumber = 0;
                                tableLayoutPanel1.Controls.Add(button, columnNumber, rowNumber);
                            }
                        }
                        columnNumber++;
                    }

                }
                else
                {
                    StationStatusLabel.ForeColor = System.Drawing.Color.Red;
                    StationStatusLabel.Text = Resources.UnregisteredStation.ToUpper();
                    loginPanel.Enabled = false;
                }
            }


        }

        private string GetProcessorID()
        {
            ManagementObjectCollection mbsList = null;
            ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select ProcessorID From Win32_processor");
            mbsList = mbs.Get();
            string id = "";
            foreach (ManagementObject mo in mbsList)
            {
                id = mo["ProcessorID"].ToString();
            }
            return id;
        }

        private string GetHddID()
        {
            ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
            dsk.Get();
            string id = dsk["VolumeSerialNumber"].ToString();
            return id;
        }

        private string GetMotherBoardID()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
            ManagementObjectCollection moc = mos.Get();
            string serial = "";
            foreach (ManagementObject mo in moc)
            {
                serial = (string)mo["SerialNumber"];
            }
            return serial;
        }

        private bool VerifyRegistration(StationVerificationType verifType, string UUID)
        {
            bool result = false;

            if (verifType == 0)
            {
                TASEntities db = new TASEntities();
                Terminal terminal_seeker = new Terminal();
                terminal_seeker = db.Terminals.FirstOrDefault(terminal_entity => terminal_entity.UUID == UUID && terminal_entity.Status == true);
                if (terminal_seeker != null)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                if (File.Exists("Station.config"))
                {
                    result = true;
                    XDocument xmlDoc = XDocument.Load("Station.config");
                    var station_config =
                            from station in xmlDoc.Descendants("Station")
                            select new StationConfig
                            {
                                UUID = station.Element("UUID").Value,
                                LocationName = station.Element("LocationName").Value,
                                Status = Convert.ToBoolean(station.Element("Status").Value),

                            };
                    station_config.ToList<StationConfig>();
                    bool status = station_config.First().Status;
                    if (status)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    result = false;
                }
            }
            return result;
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

        private void createStationNode(string UUID, string LocationName, bool Status, XmlTextWriter station_writer)
        {
            station_writer.WriteStartElement("UUID");
            station_writer.WriteString(UUID);
            station_writer.WriteEndElement();
            station_writer.WriteStartElement("LocationName");
            station_writer.WriteString(LocationName);
            station_writer.WriteEndElement();
            station_writer.WriteStartElement("Status");
            station_writer.WriteString(Convert.ToString(Status));
            station_writer.WriteEndElement();

        }
        private void createTicketNode(string Name, decimal Value, bool Status, XmlTextWriter ticket_writer)
        {
            ticket_writer.WriteStartElement("Item");
            ticket_writer.WriteStartElement("Name");
            ticket_writer.WriteString(Name);
            ticket_writer.WriteEndElement();
            ticket_writer.WriteStartElement("Value");
            ticket_writer.WriteString(Convert.ToString(Value));
            ticket_writer.WriteEndElement();
            ticket_writer.WriteStartElement("Status");
            ticket_writer.WriteString(Convert.ToString(Status));
            ticket_writer.WriteEndElement();
            ticket_writer.WriteEndElement();

        }

        private void createSalesmanNode(string UserName, string Password, string FirstName, string Lastname, bool Status, XmlTextWriter salesman_writer)
        {
            salesman_writer.WriteStartElement("Salesman");
            salesman_writer.WriteStartElement("UserName");
            salesman_writer.WriteString(UserName);
            salesman_writer.WriteEndElement();
            salesman_writer.WriteStartElement("Password");
            salesman_writer.WriteString(Password);
            salesman_writer.WriteEndElement();
            salesman_writer.WriteStartElement("FirstName");
            salesman_writer.WriteString(FirstName);
            salesman_writer.WriteEndElement();
            salesman_writer.WriteStartElement("LastName");
            salesman_writer.WriteString(Lastname);
            salesman_writer.WriteEndElement();
            salesman_writer.WriteStartElement("Status");
            salesman_writer.WriteString(Convert.ToString(Status));
            salesman_writer.WriteEndElement();
            salesman_writer.WriteEndElement();

        }
        private void createCashCount(string ticket_name,int start_amount, XmlTextWriter cashcount_writer)
        {
            cashcount_writer.WriteStartElement("CashSection");
            cashcount_writer.WriteStartElement("Concepto");
            cashcount_writer.WriteString(ticket_name);
            cashcount_writer.WriteEndElement();
            cashcount_writer.WriteStartElement("Cantidad");
            cashcount_writer.WriteString(Convert.ToString(0));
            cashcount_writer.WriteEndElement();
            cashcount_writer.WriteStartElement("Subtotal");
            cashcount_writer.WriteString(Convert.ToString(start_amount));
            cashcount_writer.WriteEndElement();
            cashcount_writer.WriteEndElement();

        }
        private void createGameNode(string HomeClub, string Visitor, DateTime GameDate, string GamePlace, XmlTextWriter game_writer)
        {
            game_writer.WriteStartElement("HomeClub");
            game_writer.WriteString(HomeClub);
            game_writer.WriteEndElement();
            game_writer.WriteStartElement("Visitor");
            game_writer.WriteString(Visitor);
            game_writer.WriteEndElement();
            game_writer.WriteStartElement("GameDate");
            game_writer.WriteString(Convert.ToString(GameDate));
            game_writer.WriteEndElement();
            game_writer.WriteStartElement("GamePlace");
            game_writer.WriteString(Convert.ToString(GamePlace));
            game_writer.WriteEndElement();

        }

        private void salesman_btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            salesman_username.Text = btn.Name;
            usr_lbl.Text = btn.Text;
            txt_pwd.Focus();
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

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_pwd.Text = String.Empty;
            txt_pwd.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GameDateTimeLabel.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
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

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            TASEntities db = new TASEntities();
            string username = salesman_username.Text.Substring(5);
            string password = txt_pwd.Text;
            if (CheckForInternetConnection())
            {
                Salesman salesman_finder = db.Salesmen.FirstOrDefault(salesman_entity => salesman_entity.UserName == username && salesman_entity.Password == password);
                if (salesman_finder != null)
                {
                    StartupCash startup_cash = new StartupCash(salesman_finder.FirstName+" "+salesman_finder.LastName,salesman_finder.UserName);
                    startup_cash.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("VENDEOR NO ENCONTRADO. Verifique su contraseña");
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
                int isRegistered=salesmen_list.Where(salesman_entity => salesman_entity.UserName == username && salesman_entity.Password == password).Count();
                if (isRegistered > 0)
                {
                    StartupCash startup_cash = new StartupCash(salesmen_list.First().FirstName + " " + salesmen_list.First().LastName, salesmen_list.First().UserName);
                    startup_cash.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("VENDEOR NO ENCONTRADO. Verifique su contraseña");
                }
                
            }
        }
    }
}
