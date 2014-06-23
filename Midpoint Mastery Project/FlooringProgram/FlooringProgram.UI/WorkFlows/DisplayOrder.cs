using System;
using System.Collections.Generic;
using FlooringProgram.Models;
using FlooringProgram.Models.DTOs;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Operations;


namespace FlooringProgram.UI.WorkFlows
{
    public class DisplayOrder
    {
        //We need to bring over the managers - they do all the work, we will use these manager objects to trigger methods we need
        private ProductManager _myProductManager;
        private TaxRateManager _myTaxManager;
        private OrderManager _myOrderManager;
        private string orderDate;
      

      public DisplayOrder(ProductManager pMgr, OrderManager oMgr, TaxRateManager tMgr)
        {
            _myProductManager = pMgr;
            _myTaxManager = tMgr;
            _myOrderManager = oMgr;

        }
       

        public void Execute()
        {
            
            DisplayOrders();

        }

        private void DisplayOrders()
        {
            Console.Clear();
            var orders = SearchOrders();
            Console.WriteLine("\nOrder#    Name   State   Tax Rate   P.Type Area      Tax    Total ");
            foreach (var x in orders)
            {
                Console.WriteLine("{0,4} {1,10} {2,3} {3,12:P} {4,7} {5,8} {6,09:C} {7,08:C}", x.OrderNumber, x.CustomerName, x.State, x.TaxRate, x.ProductType, x.Area, x.Tax, x.Total);
            }
        }

        public List<Order> SearchOrders()
        {
            Console.Write("Enter order date in the format of 00(month)00(day)0000(year): ");
            string userDate = Console.ReadLine();

            return _myOrderManager.LoadOrders(userDate);           
        }

        
    }
}
