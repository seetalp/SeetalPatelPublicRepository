using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using FlooringPogram.Data.Loaders;
using FlooringProgram.Models.DTOs;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Operations;


namespace FlooringProgram.UI.WorkFlows
{
    public class EditOrder
    {

//We need to bring over the managers - they do all the work, we will use these manager objects to trigger methods we need

        private ProductManager _myProductManager;
        private TaxRateManager _myTaxManager;
        private OrderManager _myOrderManager;

//What will edit need? We will need a list of orders to pass through, an order date to search/pull up individual text files    
        List<Order> allOrders = new List<Order>();
        private string orderDate;
        private int orderNumber;
        
//We are bringing an order object of type Order to get the members of that class       
        Order newOrder = new Order();
        
//We need to provide default behavior that it must abide by...
        public EditOrder(ProductManager pMgr, OrderManager oMgr, TaxRateManager tMgr)
        {
            _myProductManager = pMgr;
            _myTaxManager = tMgr;
            _myOrderManager = oMgr;

        }

//Method we use to trigger from Main Menu
        public void Execute()
        {
            DisplayHeader();
            orderDate = GetOrderDate();//we declared orderDate above and we want it to equal the output of "GetOrderDate()" method
            allOrders = _myOrderManager.LoadOrders(orderDate);
            DisplayOrders(allOrders);//in order to display the orders from the file, we need to pass a list through our method 
            orderNumber = GetOrderNumber();
            newOrder = SelectandReviseOrder();
            _myOrderManager.Calculator(newOrder);//the manager object is asked to bring back data based on the "newOrder" or the edited information
            _myOrderManager.SaveEditedOrder(allOrders, newOrder,orderDate, orderNumber);

        }

//Ask the user to enter an order date
        private string GetOrderDate()
        {
            string userInput;
            do
            {
                Console.Write("What date do you want to search by 00(month)00(day)0000(year) ");
                userInput = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(userInput));

            return userInput;
        }

//Displays header in the console
        private void DisplayHeader()
        {
            Console.Clear();
            Console.WriteLine("Edit Order");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - -");
        }

//Once we get order date, we pull up a list of all orders on that date file
        public void DisplayOrders(List<Order> allOrders)
        {
           
                Console.WriteLine("\nOrder#    Name   State   Tax Rate   P.Type Area      Tax    Total ");
                foreach (var x in allOrders)
                {
                    Console.WriteLine("{0,4} {1,10} {2,3} {3,12:P} {4,7} {5,8} {6,09:C} {7,08:C}", x.OrderNumber, x.CustomerName, x.State, x.TaxRate, x.ProductType, x.Area, x.Tax, x.Total);
                }
        }

//The user will see the order number and is asked to input the order number of the order he/she wishes to edit
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

//The user needs to choose the order to edit using the order number and input new data for the fields
//We will also need to bring over those fields that are dependent on the input fields
//return an order object 
        public Order SelectandReviseOrder()//need to return an order object
        {
           var order = allOrders.Where(o => o.OrderNumber == orderNumber).First();//in our list of orders find the order number that matches the order number provided by user

                        Console.Clear();
                        string newValue;
                        decimal newValue2=0;//for all decimal values we need to have a separate placeholder

                        Console.WriteLine("To edit, enter a new value, otherwise leave blank");

                        Console.Write("Customer Name ({0}): ", order.CustomerName); 
                        newValue = Console.ReadLine();

                        if (!string.IsNullOrEmpty(newValue))
                        {
                            order.CustomerName = newValue;//Set Customer name equal to user input if not null or empty
                        }

                        Console.Write("State ({0}): ", order.State);
                        newValue = Console.ReadLine();

                        if (!string.IsNullOrEmpty(newValue))
                        {
                            order.State = newValue;//Set Customer name equal to user input if not null or empty
                            var taxRate = _myTaxManager.GetTaxRateFor(newValue);//call the tax manager to get teh rate for the State
                            order.TaxRate = taxRate.TaxPercent;//State drive the Tax Rate, so we also need to reset the tax rate to be the correct rate
                        }

                        Console.Write("Product Type ({0}): ", order.ProductType);
                        newValue = Console.ReadLine();

                        if (!string.IsNullOrEmpty(newValue))
                        {
                            order.ProductType = newValue;//Set Product equal to user input if not null or empty
                            var allProducts = _myProductManager.GetAllProducts();

                            var product = allProducts.FirstOrDefault(x => x.ProductType == newValue);

                            order.LaborCostPerSquareFoot = product.LaborCostPerSquareFoot;//Product drive Labor Cost Per Square Foot
                            order.CostPerSquareFoot = product.CostPerSquareFoot; //Product drives Cost Per Square Foot
                        }

                        Console.Write("Area ({0}): ", order.Area);
                        decimal.TryParse(Console.ReadLine(), out newValue2);//Area is a decimal
                        
                        if (newValue2 != null)
                        {
                            order.Area = newValue2;
                        }

                        Console.ReadLine();
            return order;

        }






    }
}

