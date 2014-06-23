using System;
using System.Collections.Generic;
using System.Linq;
using FlooringPogram.Data.Loaders;
using FlooringProgram.Models.DTOs;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Operations;


namespace FlooringProgram.UI.WorkFlows
{
    public class RemoveOrder
    {
        private ProductManager _myProductManager;
        private TaxRateManager _myTaxManager;
        private OrderManager _myOrderManager;
        
        List<Order> allOrders = new List<Order>();
        private string orderDate;
        private int orderNumber;
        
  
      public RemoveOrder(ProductManager pMgr, OrderManager oMgr, TaxRateManager tMgr)
        {
            _myProductManager = pMgr;
            _myTaxManager = tMgr;
            _myOrderManager = oMgr;

        }
 
        public void Execute()
        {
            DisplayHeader();
            orderDate = GetOrderDate();
            allOrders = _myOrderManager.LoadOrders(orderDate);
            DisplayOrders();
            orderNumber = GetOrderNumber();
            _myOrderManager.RemoveSelectedOrder(allOrders, orderNumber, orderDate);
        }

        private void DisplayHeader()
        {
            Console.Clear();
            Console.WriteLine("Remove Order");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - -");
        }

        private void DisplayOrders()
        {
            Console.WriteLine("\nOrder#    Name   State   Tax Rate   P.Type Area     Tax    Total ");
            foreach (var x in allOrders)
            {
                Console.WriteLine("{0,4} {1,10} {2,3} {3,12:P} {4,7} {5,8} {6,09:C} {7,08:C}", x.OrderNumber, x.CustomerName, x.State, x.TaxRate, x.ProductType, x.Area, x.Tax, x.Total);
            }
        }

        private string GetOrderDate()
        {
            string userInput;
            do
            {
                //Ask the user to enter an order date
                Console.Write("Please enter the date of the order to remove 00(month)00(day)0000(year) ");
                userInput = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(userInput));

            return userInput;
        }

        private int GetOrderNumber()
        {
            int userInput;
            do
            {
                Console.Write("What is the Order Number? ");
                userInput = int.Parse(Console.ReadLine());
            } while (userInput == null);
            //ask the user what the order number they want to search by

            return userInput;
        }

       



    }
}
