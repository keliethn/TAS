using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAS.Utilities
{
   public static class Constants
    {
      
       public const string station_id = "EYRD-01";
       public const string currency_symbol = "C$";

       public const string homeplate_item_name = "Home Plate";
       public const float homeplate_price = 40;
       public const string lateral_item_name = "Lateral";
       public const float lateral_price = 25;
       public const string balcony_item_name = "Palco";
       public const float balcony_price = 100;
        
       
       public const string home_club = "FRENTE SUR RIVAS";
       public const string visitor_name = "INDIOS DEL BOER";
       public const string game_place = "ESTADIO YAMIL RIOS UGARTE";
       public const string list_item = @"{0} - {1} (@ C$ {2})";
       public const int ticket_width = 320;

      
    }
    public enum StationVerificationType
       {
           Online=0,
           Offline=1
       }
}
