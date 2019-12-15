using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Track_Sport_Events_MVC.Models;

namespace Track_Sport_Events_MVC.Models
{
    public class Track_Sport_EventsDataContext : DbContext
    {
        public Track_Sport_EventsDataContext (DbContextOptions<Track_Sport_EventsDataContext> options)
            : base(options)
        {
        }

        public DbSet<Track_Sport_Events_MVC.Models.Runner> Runner { get; set; }

        public DbSet<Track_Sport_Events_MVC.Models.TimingRecord> TimingRecord { get; set; }

        public DbSet<Track_Sport_Events_MVC.Models.TrackSportEvent> TrackSportEvent { get; set; }
    }
}
