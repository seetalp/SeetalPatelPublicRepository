using System.Collections.Generic;
using FlooringProgram.Models.DTOs;

namespace FlooringProgram.Models.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> LoadOrders(string userDate);
        void SaveFile(List<Order> orderList, string userDate);
        void AddOrderToFile(Order order, string userDate);
    }
}
