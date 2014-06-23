using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.DTOs;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Operations
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;//We need to bring over our interface object (Load/Save methods)

        public OrderManager(IOrderRepository repositoryToUse)
        {
            _orderRepository = repositoryToUse;
        }

        public void AddOrder(Order newOrder, Product chosenProduct, TaxRate taxRateForCustomerState, string orderDate)
        {
           
            newOrder.CostPerSquareFoot = chosenProduct.CostPerSquareFoot;
            newOrder.MaterialCost = newOrder.CostPerSquareFoot*newOrder.Area;
            newOrder.LaborCost = newOrder.Area * chosenProduct.LaborCostPerSquareFoot;
            newOrder.Tax = (newOrder.LaborCost + newOrder.MaterialCost) * taxRateForCustomerState.TaxPercent;
            newOrder.Total = newOrder.LaborCost + newOrder.MaterialCost + newOrder.Tax;
            newOrder.LaborCostPerSquareFoot = chosenProduct.LaborCostPerSquareFoot;

        }

        public void Calculator(Order newOrder)
        {
            newOrder.MaterialCost = newOrder.CostPerSquareFoot * newOrder.Area;
            newOrder.LaborCost = newOrder.Area * newOrder.LaborCostPerSquareFoot;
            newOrder.Tax = (newOrder.LaborCost + newOrder.MaterialCost) * newOrder.TaxRate;
            newOrder.Total = newOrder.LaborCost + newOrder.MaterialCost + newOrder.Tax;
    
        }

        public void AddNewOrder(Order order, string orderDate)
        {

            var allOrders = _orderRepository.LoadOrders(orderDate);
            order.OrderNumber = GetNextOrderNumber(allOrders);
            allOrders.Add(order);
           _orderRepository.AddOrderToFile(order, orderDate);

        }

        private int GetNextOrderNumber(List<Order> allOrders)
        {
            if (allOrders.Any())
                return allOrders.Max(x => x.OrderNumber) + 1;

            return 1;
        }

        public List<Order> LoadOrders(string orderDate)
        {
            return _orderRepository.LoadOrders(orderDate);
        }

        public  void SaveEditedOrder(List<Order> allOrders, Order order, string orderDate, int orderNumber)
        {
            order.OrderNumber = orderNumber;
            Order Update = allOrders.FirstOrDefault(x => x.OrderNumber == orderNumber);
            Update.CustomerName = order.CustomerName;
            Update.ProductType = order.ProductType;
            Update.Area = order.Area;
            Update.State = order.State;

            _orderRepository.SaveFile(allOrders, orderDate);
        }

        public void RemoveSelectedOrder(List<Order> allOrders, int orderNumber, string orderDate)
        {
            var order = allOrders.Where(o => o.OrderNumber == orderNumber).First();
            allOrders.Remove(order);
            _orderRepository.SaveFile(allOrders, orderDate);

        }
    }
}
