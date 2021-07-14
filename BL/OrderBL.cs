using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class OrdersBL
    {
        private OrdRepository _repo;
        public OrdersBL(OrdRepository p_repo)
        {
            _repo=p_repo;
        }

        public Orders AddOrders(Orders _oAdd)
        {
            return _repo.AddOrders(_oAdd);
        }

        public List<Orders> GetAllOrders()
        {
            return _repo.GetAllOrders();
        }
        public List<Orders> FilterOrder(Orders p_order)
        {
            return _repo.FilterOrder(p_order);
        }

        public List<Orders> FilterOrder(Orders p_order, string p_game, string p_system)
        {
            return _repo.FilterOrder(p_order, p_game, p_system);
        }
    }
    public class StockOrdersBL
    {
    private StockOrdRepository _repo;
        public StockOrdersBL(StockOrdRepository p_repo)
        {
            _repo=p_repo;
        }

        public StockOrders AddStockOrders(StockOrders _soAdd)
        {
            return _repo.AddStockOrders(_soAdd);
        }

        public List<StockOrders> GetAllStockOrders()
        {
            return _repo.GetAllStockOrders();
        }

        public List<StockOrders> FilterStockOrder(StockOrders p_stockorder)
        {
            return _repo.FilterStockOrder(p_stockorder);
        }
        public List<StockOrders> FilterStockOrder(StockOrders p_order, string p_game, string p_system)
        {
            return _repo.FilterStockOrder(p_order, p_game, p_system);
        }
    }
}