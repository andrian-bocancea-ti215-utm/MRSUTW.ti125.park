using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using parkTrumpet.Domain.Entities;

namespace parkTrumpet.BusinessLogic.DBModel
{
    public class ParkingSystemContext : DbContext
    {
        public ParkingSystemContext() : base("name=parkTrump")
        {
            Database.SetInitializer(new TestingParkInitializer());
        }
        public virtual DbSet<adminAccountDbTable> AdminAccounts { get; set; }
        public virtual DbSet<carDbTable> Cars { get; set; }
        public virtual DbSet<clientDbTable> Clients { get; set; }
        public virtual DbSet<lotDbTable> Lots { get; set; }
        public virtual DbSet<ownerDbTable> Owners { get; set; }
        public virtual DbSet<parkingDbTable> Parkings { get; set; }
        public virtual DbSet<parkingSessionDbTable> ParkingSessions { get; set; }
    }
}
