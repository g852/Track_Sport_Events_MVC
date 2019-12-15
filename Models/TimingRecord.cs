using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Track_Sport_Events_MVC.Models
{
    public class TimingRecord
    {
        public int Id { get; set; }

        public int RunnerId { get; set; }
        public Runner Runner { get; set; }


        public int TrackSportEventId { get; set; }

        public TrackSportEvent TrackSportEvent { get; set; }

        public decimal RecordedTime { get; set; }

        public DateTime Date { get; set; }


    }
}
