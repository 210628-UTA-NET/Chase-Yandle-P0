using System;
using Models;
using System.Collections.Generic;

namespace DL
{
    public class OrdRepository
    {
        public List<Orders> GetAllOrders()
        {
            throw new NotImplementedException();
        }
        public Orders GetOrders(Orders p_orders)
        {
            throw new NotImplementedException();
        }
        public Orders AddOrders(Orders p_orders)
        {
            throw new NotImplementedException();
        }
        public List<Orders> FilterOrder(Orders p_order)
        {
            throw new NotImplementedException();
        }

        public List<Orders> FilterOrder(Orders p_order, string p_game, string p_system)
        {
            throw new NotImplementedException();
        }
    }
        public class StockOrdRepository
    {
        public List<StockOrders> GetAllStockOrders()
        {
            throw new NotImplementedException();
        }
        public StockOrders GetStockOrders(StockOrders p_stockorders)
        {
            throw new NotImplementedException();
        }
        public StockOrders AddStockOrders(StockOrders p_stockorders)
        {
            throw new NotImplementedException();
        }
        public List<StockOrders> FilterStockOrder(StockOrders p_stockorder)
        {
            throw new NotImplementedException();
        }
        public List<StockOrders> FilterStockOrder(StockOrders p_order, string p_game, string p_system)
        {
            throw new NotImplementedException();
        }
    }
}