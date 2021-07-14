using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class StoresBL
    {
        private StoreRepository _repo;
        public StoresBL(StoreRepository p_repo)
        {
            _repo=p_repo;
        }

        public Stores AddStore(Stores _stAdd)
        {
            return _repo.AddStore(_stAdd);
        }

        public List<Stores> GetAllStores()
        {
            return _repo.GetAllStores();
        }
        public Stores EditStore(Stores p_store)
        {
            _repo.EditStore(p_store);
            return p_store;
        }

        public List<Stores> FilterStore(Stores p_store)
        {
            return _repo.FilterStore(p_store);
        }

        public Stores DeleteStore(Stores p_store)
        {
            _repo.DeleteStore(p_store);
            return p_store;
        }
        public Stores GetStoreByNumber(string p_storeID)
        {
            return _repo.GetStoreByNumber(p_storeID);
        }
        public int CountCustomers(Stores p_store)
        {
            return _repo.CountCustomers(p_store);
        }
        public List<LineItems> GamesAtEachLocation(Stores p_store)
        {
            return _repo.GamesAtEachLocation(p_store);
        }
    }
}