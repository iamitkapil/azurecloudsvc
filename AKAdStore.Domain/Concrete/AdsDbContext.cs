using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AKAdStore.Domain.Entities;
using System.Data.Entity;

namespace AKAdStore.Domain.Concrete
{
    class AdsDbContext : DbContext
    {
        public AdsDbContext() : base("name=AKAdsContext")
        {
        }

        public AdsDbContext(string connString) : base(connString)
        {
        }

        public DbSet<Ad> Ads { get; set; }
    }
}
