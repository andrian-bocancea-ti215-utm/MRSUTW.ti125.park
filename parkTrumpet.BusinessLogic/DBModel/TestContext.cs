using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using parkTrumpet.Domain.Entities.Test;

namespace parkTrumpet.BusinessLogic.DBModel
{
    class TestContext : DbContext
    {
        public TestContext() : base("name=parkTrump")
        {
            Database.SetInitializer<TestContext>(new DropCreateDatabaseAlways<TestContext>());
        }
        public virtual DbSet<TestDbTable> Test { get; set; }
    }
}
