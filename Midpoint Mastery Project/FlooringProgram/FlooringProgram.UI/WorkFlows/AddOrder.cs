using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using FlooringPogram.Data.Loaders;
using FlooringProgram.Models.DTOs;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Operations;
using Microsoft.Win32;

namespace FlooringProgram.UI.WorkFlows
{
    public class AddOrder
    {
 //We need to bring over the managers - they do all the work, we will use these manager objects to trigger methods we need
     
        private ProductManager _myProductManager;
        private TaxRateManager _myTaxManager;
        private OrderManager _myOrderManager;
        private string orderDate;
       
//We have to tell our managers how to act! Rules of conduct.
     public AddOrder(ProductManager pMgr, OrderManager oMgr, TaxRateManager tMgr)
        {
            _myProductManager = pMgr;
            _myTaxManager = tMgr;
            _myOrderManager = oMgr;

        }
        

        public void Execute()
        {
            GetUserOrderInfo();
            Console.WriteLine(System.Environment.CurrentDirectory);
            
        }

        private void GetUserOrderInfo()
        {
            Order newOrder = new Order();

            // 1. Ask user for customer name
            newOrder.CustomerName = GetCustomerName();

            // 2. Ask user for product type
            var chosenProduct = GetProduct();
            newOrder.ProductType = chosenProduct.ProductType;

            // 3. Ask user for area of flooring
            newOrder.Area = GetArea();

            // 3. Ask user for state for taxes

            var chosenTaxRate = GetState();
            newOrder.State = chosenTaxRate.State;
            newOrder.TaxRate = chosenTaxRate.TaxPercent/100;


            //Get user date

            orderDate = GetOrderDate();


            // 5. Ask Order Manager to calculate and save (pass order, product, and tax rate to order manager)
            _myOrderManager.AddOrder(newOrder, chosenProduct, chosenTaxRate, orderDate);

            DisplayData(newOrder);
        }

        public string GetOrderDate()//Get the order object to pull up the file
        {
            string orderDate;

            do
            {
                Console.Write("Enter the order date in this format: 00(Date)00(Month)0000(Year) ");
                orderDate = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(orderDate));

            return orderDate;
        }
        //Get user input 
        public TaxRate GetState()
        {
            TaxRate chosenTaxRate;
            var allRates = _myTaxManager.GetAllTaxRates();
            string choice;
            
            do
            {
                Console.WriteLine("Available States");
                Console.WriteLine("------------------");
                foreach (var p in allRates)
                    Console.WriteLine(p.State);

                Console.Write("\nEnter State: ");
                choice = Console.ReadLine();

                chosenTaxRate = allRates.FirstOrDefault(r => r.State == choice);
                
            } while (chosenTaxRate== null);
            return chosenTaxRate;


        }

        public decimal GetArea()
        {
            bool valid = false;
            decimal userArea = 0;
            do
            {
                Console.Write("Enter the Area: ");
                valid = decimal.TryParse(Console.ReadLine(), out userArea);

            } while (!valid);

            return userArea;
        }

        public Product GetProduct()
        {
            Product chosenProduct;
            var allProducts = _myProductManager.GetAllProducts();

            do
            {
                Console.WriteLine("Available Products");
                Console.WriteLine("------------------");
                foreach(var p in allProducts)
                    Console.WriteLine(p.ProductType);

                Console.Write("\nEnter product type: ");
                string choice = Console.ReadLine();

                chosenProduct = allProducts.FirstOrDefault(p => p.ProductType == choice);
            } while (chosenProduct == null);

            return chosenProduct;
        }

        public string GetCustomerName()
        {
            string name;

            do
            {
                Console.Write("Enter the customer name: ");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            return name;
        }

        public void DisplayData(Order newOrder)
        {
            Console.WriteLine("Name: {0}", newOrder.CustomerName);
            Console.WriteLine("State: {0}", newOrder.State);
            Console.WriteLine("Tax Rate: {0:P}", newOrder.TaxRate);
            Console.WriteLine("Product Type: {0}", newOrder.ProductType);
            Console.WriteLine("Area: {0}", newOrder.Area);
            Console.WriteLine("Cost per square ft: {0:C}", newOrder.CostPerSquareFoot);
            Console.WriteLine("Labor cost per square ft: {0:C}", newOrder.LaborCostPerSquareFoot);
            Console.WriteLine("Material cost: {0:C}", newOrder.MaterialCost);
            Console.WriteLine("Labor cost: {0:C}", newOrder.LaborCost);
            Console.WriteLine("Tax: {0:C}", newOrder.Tax);
            Console.WriteLine("TOTAL COST: {0:C}", newOrder.Total);
            Console.WriteLine();

            string result = GetConfirmation();
            if (result == "Y")
                _myOrderManager.AddNewOrder(newOrder, orderDate);//tell the manager to add this order to the file
            

        }

        public string GetConfirmation()
        {
            string userConfirmation;
           
            do
            {
                Console.Write("Would you like to save this order? (Y/N) ");
                userConfirmation = Console.ReadLine();
                if (userConfirmation == "N")

                    break;
               
            } while (userConfirmation != "Y");

            return userConfirmation;

        }

       
    }
}
