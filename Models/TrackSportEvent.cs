using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Track_Sport_Events_MVC.Models
{
    public class TrackSportEvent
    {
        public int Id { get; set; }

        public string EventName { get; set; }

        public EventType Type { get; set; }


    }

    public enum EventType { 
       
        NATIONAL, INTERNATIONAL
    
    }
   
}
