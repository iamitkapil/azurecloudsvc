using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AKAdStore.Domain.Abstract;
using AKAdStore.Domain.Entities;
using System.Data.Entity;

namespace AKAdStore.Domain.Concrete
{
   public class AdRepository : IAdsRepository
    {
        private AdsDbContext db;

        //public AdRepository()
        //{
        //    db = new Concrete.AdsDbContext(); 
        //}

        public AdRepository(string dbconnectionString)
        {
            if(String.IsNullOrEmpty(dbconnectionString)) 
                db = new Concrete.AdsDbContext();
            else
                db = new Concrete.AdsDbContext(dbconnectionString);

        }

        public IEnumerable<Ad> Ads
        {
            get { return db.Ads; }
        }

        public async Task<IEnumerable<Ad>> GetAds()
        {
            
            //get { return db.Ads; }
            return await db.Ads.ToListAsync(); 
        }

        public async Task<Ad> FetchbyAdId(int id)
        {
            Ad ad = await db.Ads.FindAsync(id);
            return ad;
        }

        public async Task<int> addAd(Ad ad)
        {
            db.Ads.Add(ad);
            int result= await db.SaveChangesAsync();
            return result;
        }

        public async Task<int> updateAd(Ad ad)
        {
            db.Entry(ad).State = EntityState.Modified;
            int result = await db.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteAd(int id)
        {
            Ad ad = await FetchbyAdId(id);
            db.Ads.Remove(ad);
            int result =await db.SaveChangesAsync();
            return result;
        }


    }
}
