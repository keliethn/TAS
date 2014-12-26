using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAS.Utilities
{
    class StationConfig
    {
        public string UUID { get; set; }
        public string LocationName { get; set; }
        public bool Status { get; set; }
    }

    class SalesmanList
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    class Salesman2
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }

    class Tickets
    {
        public string LocationName { get; set; }
        public string LocationPrice { get; set; }
    }

    class CashCount
    {
        public string LocationName { get; set; }
        public int Count { get; set; }
        public decimal Subtotal { get; set; }
    }

    class Games
    {
        public string HomeClub { get; set; }
        public string Visitor { get; set; }
        public string GameDate { get; set; }
        public string GamePlace { get; set; }

    }

}
