using AKAdStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/* I need some way of getting Ad entities from a database. The model includes the persistence logic for storing 
 * and retrieving the data from the persistent data store, but even within the model, we want to keep a degree of 
 * separation between the data model entities and the storage and retrieval logic, which we achieve using the 
 * repository pattern*/
namespace AKAdStore.Domain.Abstract
{
    public interface IAdsRepository
    {
        IEnumerable<Ad> Ads { get; }

        Task<IEnumerable<Ad>> GetAds();

        Task<Ad> FetchbyAdId(int id);

        Task<int> addAd(Ad ad);

        Task<int> updateAd(Ad ad);

        Task<int> DeleteAd(int id);
    }
}
