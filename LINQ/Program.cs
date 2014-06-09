using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace LINQ
{
    class Program
    {
        /* Practice your LINQ!
         * You can use the methods in Data Loader to load products, customers, and some sample numbers
         * 
         * NumbersA, NumbersB, and NumbersC contain some ints
         * 
         * The product data is flat, with just product information
         * 
         * The customer data is hierarchical as customers have zero to many orders
         */
        static void Main()
        {
            //foreach (Product p in DataLoader.LoadProducts())
            //{
            //    Console.WriteLine(p.ProductName);
            //}

            //foreach (Customer c in DataLoader.LoadCustomers())
            //{
            //    Console.WriteLine(c.CompanyName);
            //}



            //PrintOutOfStock_1();
            //Morethan3PerUnit();
            //WashingtonCustomers();
            //ProductsAscending();
            //IncreaseUnitPricesbyQuarter();
            //ProductinUpperCase();
            //ProductEvenNumbers();
            //ProductNewList();
            //NumberPairs();
            //Lessthan500();
            //FirstThree();
            //FirstThreeOrdersWA();
            //SkipFirstThree();
            //SkipFirstThreeWA();
            //LessThanPosition();
            //FirstDivThree();
            //OrderProdsAlpha();
            //OrderProdsStock();
            //SortListA();
            //ReverseNumberC();
            //Remainder5();
            //ProductbyCategory();
            //GroupYearMonth();
            //UniqueProdCat();
            //UniqueAB();
            //SharedAB();
            //ExceptAB();
            //ProductID();
            //ProductID789();
            //PrintOutOfStockCats();
            //LessThan9();
            //InStockCats();
            //OddinA();
            //CustIDandCount();
            //CatandCount();
            //CatandStockCount();
            //LowestPriceCats();
            //HighestPriceCats();
            AvePriceCats();






            Console.ReadLine();
        }

        //1. Find out of stock products
        static void PrintOutOfStock_1()//EXAMPLE ONE ERIC DID
        {
            var products = DataLoader.LoadProducts();

            var outOfStock = products.Where(p => p.UnitsInStock == 0);

            Console.WriteLine("Out of stock: ");
            foreach (var p in outOfStock)
            {
                Console.WriteLine(p.ProductName);
            }

            Console.Write("Press enter to continue");
            Console.ReadLine();
        }

        //2. Find all products that are in stock and cost more than 3.00 per unit.
        static void Morethan3PerUnit()
        {
            var products = DataLoader.LoadProducts();

            var moreThan3 = products.Where(p => p.UnitPrice > 3);

            Console.WriteLine("Products with a Unit Price of more than $3.00: ");
            foreach (var p in moreThan3)
            {
                Console.WriteLine(p.ProductName);
            }

            Console.Write("Press enter to continue");
            Console.ReadLine();
        }

        //3. Find all customers in Washington, print their name then their orders. (Region == "WA")
        static void WashingtonCustomers()
        {
            var customers = DataLoader.LoadCustomers();//var (we don't know types in list we want) + name of our data set = DataLoader (class that has my list data).Name of List Data (which has been formatted from XML into a usable format for c Sharp

            var customerlist = customers.Where(c => c.Region == "WA");

            Console.WriteLine("WA-based Customer Names and Orders:");
            foreach (var customer in customerlist)
            {
                Console.WriteLine("{0}", customer.CompanyName);

                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("{0}, {1}", order.OrderID, order.Total);
                }


            }
            Console.Write("Press enter to continue");
            Console.ReadLine();
        }

        //4. Create a new sequence with just the names of the products.
        static void ProductsAscending()
        {
            var products = DataLoader.LoadProducts();

            var productlist = from product in products
                              orderby product.ProductName
                              select product;

            Console.WriteLine("Product List:");
            foreach (var product in productlist)
            {
                Console.WriteLine(product.ProductName);
            }

            Console.Write("Press enter to continue");
            Console.ReadLine();
        }

        //5. Create a new sequence of products and unit prices where the unit prices are increased by 25%.
        static void IncreaseUnitPricesbyQuarter()
        {
            var products = DataLoader.LoadProducts();

            var productlist = from product in products
                              orderby product.ProductName
                              select new { product.ProductName, price = product.UnitPrice * 1.25M };//creates result set

            Console.WriteLine("Product List:");
            foreach (var product in productlist)//print each item in the result set
            {
                Console.WriteLine("{0:-25},  {1:c}", product.ProductName, product.price);
            }

            Console.Write("Press enter to continue");
            Console.ReadLine();
        }

        //6. Create a new sequence of just product names in all upper case.
        static void ProductinUpperCase()
        {
            var products = DataLoader.LoadProducts();

            var results = from product in products
                          orderby product.ProductName
                          select new { newProductName = product.ProductName.ToUpper() };

            foreach (var item in results)
            {
                Console.WriteLine("{0}", item.newProductName);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }


        //7. Create a new sequence with products with even numbers of units in stock.
        static void ProductEvenNumbers()
        {
            var products = DataLoader.LoadProducts();

            var results = from product in products
                          where product.ProductID % 2 == 0
                          orderby product.ProductName
                          select new { product.ProductID, newProductName = product.ProductName.ToUpper() };

            foreach (var item in results)
            {
                Console.WriteLine("{0} - {1}", item.ProductID, item.newProductName);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        //8. Create a new sequence of products with ProductName, Category, and rename UnitPrice to Price.

        static void ProductNewList()
        {
            var products = DataLoader.LoadProducts();

            var results = from product in products
                          orderby product.ProductName
                          select new { product.ProductName, product.Category, Price = product.UnitPrice };

            foreach (var item in results)
            {
                Console.WriteLine("{0} - {1} - {2:c}", item.ProductName, item.Category, item.Price);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }


        //9.Make a query that returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.

        static void NumberPairs()
        {
            var numbersA = DataLoader.NumbersA;
            var numbersB = DataLoader.NumbersB;

            var results = from elementA in numbersA
                          from elementB in numbersB
                          where elementA < elementB
                          select new { elementA, elementB };

            foreach (var item in results)
            {
                Console.WriteLine("{0} less than {1}", item.elementA, item.elementB);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }



        //10.Select CustomerID, OrderID, and Total where the order total is less than 500.00.

        static void Lessthan500()
        {
            var customers = DataLoader.LoadCustomers();



            var results = from customer in customers
                          from order in customer.Orders
                          where order.Total < 500.00M
                          select new { customer.CustomerID, order.OrderID, order.Total };

            foreach (var item in results)
            {
                Console.WriteLine("{0}  -  {1}  -  {2:c}", item.CustomerID, item.OrderID, item.Total);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }


        //11. Write a query to take only the first 3 elements from NumbersA.

        static void FirstThree()
        {
            var alist = DataLoader.NumbersA;
            var results = alist.Take(3);
            foreach (var item in results)
            {
                Console.WriteLine("{0}", item);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        //12. Get only the first 3 orders from customers in Washington.
        static void FirstThreeOrdersWA()
        {
            var customers = DataLoader.LoadCustomers();

            var results = from customer in customers
                          from order in customer.Orders.Take(3)
                          where customer.Region == "WA"
                          select new { customer.CompanyName, order.OrderID };


            foreach (var item in results)
            {
                Console.WriteLine("{0} - {1}", item.CompanyName, item.OrderID);

            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        //13. Skip the first 3 elements of NumbersA.
        static void SkipFirstThree()
        {
            var alist = DataLoader.NumbersA;
            var results = alist.Skip(3);
            foreach (var item in results)
            {
                Console.WriteLine("{0}", item);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        //14. Get all except the first two orders from customers in Washington.
        static void SkipFirstThreeWA()
        {
            var customers = DataLoader.LoadCustomers();

            var results = from customer in customers
                          from order in customer.Orders.Skip(3)
                          where customer.Region == "WA"
                          select new { customer.CompanyName, order.OrderID };


            foreach (var item in results)
            {
                Console.WriteLine("{0} - {1}", item.CompanyName, item.OrderID);

            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        //15.Get all the elements in NumbersC from the beginning until an element is greater or equal to 6.
        static void TakeWhileNumberC()
        {
            var clist = DataLoader.NumbersC;
            var results = clist.TakeWhile(c => c < 6);
            foreach (var item in results)
            {
                Console.WriteLine("{0}", item);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        //16. Return elements starting from the beginning of NumbersC until a number is hit that is less than its position in the array.
        static void LessThanPosition()
        {
            var clist = DataLoader.NumbersC;
            var results = clist.TakeWhile((c, index) => c >= index);
            foreach (var item in results)
            {
                Console.WriteLine("{0}", item);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

        }

        //17. Return elements from NumbersC starting from the first element divisible by 3.
        static void FirstDivThree()
        {
            var clist = DataLoader.NumbersC;
            var results = clist.SkipWhile(c => c % 3 != 0);
            foreach (var item in results)
            {
                Console.WriteLine("{0}", item);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

        }
        // //18. Order products alphabetically by name.
        static void OrderProdsAlpha()
        {
            var clist = DataLoader.NumbersC;
            var results = clist.OrderBy(c => c);
            foreach (var item in results)
            {
                Console.WriteLine("{0}", item);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
        // //19. Order products by UnitsInStock descending.

        static void OrderProdsStock()
        {
            var clist = DataLoader.NumbersC;
            var results = from item in clist
                          orderby item descending
                          select item;

            foreach (var item in results)
            {
                Console.WriteLine("{0}", item);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
        //20. Sort the list of products, first by category, and then by unit price, from highest to lowest.
        static void SortListA()
        {
            var products = DataLoader.LoadProducts();
            var results = from product in products
                orderby product.Category, product.UnitPrice descending
                select product;

         foreach (var product in results)
            {
                Console.WriteLine("{0}, {1}", product.Category, product.UnitPrice);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        //21. Reverse NumbersC.
         private static void ReverseNumberC()
         {
             var clist = DataLoader.NumbersC;
             var results = from item in clist.Reverse()
                            select item;

             foreach (var item in results)
             {
                 Console.WriteLine("{0}", item);
             }
             Console.WriteLine("Press enter to continue");
             Console.ReadLine();
         }

         //22. Display the elements of NumbersC grouped by their remainder when divided by 5.
         private static void Remainder5()
         {
             var clist = DataLoader.NumbersC;
             var results = from item in clist
                 group item by item%5
                 into itemgrouping
                 select new {remainder = itemgrouping.Key, item = itemgrouping};
    
             foreach (var r in results)
             {
                 Console.WriteLine("{0}", r.remainder );
             }
             Console.WriteLine("Press enter to continue");
             Console.ReadLine();

         }

        // 23. Display products by Category.
         private static void ProductbyCategory()
         {

             var products = DataLoader.LoadProducts();
             var results = from product in products
                           group product by product.Category
                               into categories
                               select new { categories.Key, groupproducts = categories };

             foreach (var category in results)
             {
                 Console.WriteLine("*****{0}", category.Key);

                 foreach (var p in category.groupproducts)
                 {
                     Console.WriteLine("{0}",p.ProductName );
                 }
             }
             Console.WriteLine("Press enter to continue");
             Console.ReadLine();
         }

         //24. Group customer orders by year, then by month.
        private static void GroupYearMonth()
        {
            var customers = DataLoader.LoadCustomers();
            var customerOrderGroups = from c in customers
                select new {
                    c.CompanyName, YearGroups = from o in c.Orders
                        group o by o.OrderDate.Year
                        into yg
                        select new
                        {
                            Year = yg.Key,
                            MonthGroups =
                                from o in yg
                                group o by o.OrderDate.Month
                                into mg
                                select new {Month = mg.Key, Orders = mg}//innergroup
                        }
                };


            foreach (var element in customerOrderGroups )
            {
                
                foreach (var element2 in element.YearGroups)
                {
                    Console.WriteLine("{0}", element2.Year);

                    foreach (var element3 in element2.MonthGroups)
                    {
                        Console.WriteLine("{0}", element3.Month);
                    }
                }

                
            }


            Console.WriteLine("Press enter to continue");
            Console.ReadLine();   


        }


         //25. Create a list of unique product category names.
        private static void UniqueProdCat()
        {
            var products = DataLoader.LoadProducts();
            var categories = (from product in products
                                select product.Category).Distinct();

        Console.WriteLine("--Unique Categories--");
        foreach (var n in categories)
        {
            Console.WriteLine(n);
        }

    }

         //26. Get a list of unique values from NumbersA and NumbersB.
         private static void UniqueAB()
         {
             var listA = DataLoader.NumbersA;
             var listB = DataLoader.NumbersB;
             var listAB = listA.Union(listB);

             foreach (var item in listAB)
             {
                 Console.WriteLine(item);
             }

         }
       

        // 27. Get a list of the shared values from NumbersA and NumbersB.
         private static void SharedAB()
         {
             var listA = DataLoader.NumbersA;
             var listB = DataLoader.NumbersB;
             var listAB = listA.Intersect(listB);

             foreach (var item in listAB)
             {
                 Console.WriteLine(item);
             }
         }
        
         //28. Get a list of values in NumbersA that are not also in NumbersB..
         private static void ExceptAB()
         {
             var listA = DataLoader.NumbersA;
             var listB = DataLoader.NumbersB;
             var listAB = listA.Except(listB);

             foreach (var item in listAB)
             {
                 Console.WriteLine(item);
             }
         }
       
         //29. Select only the first product with ProductID = 12 (not a list).
         private static void ProductID()
         {
             var products = DataLoader.LoadProducts();
             var productID = products.FirstOrDefault(p => p.ProductID == 12);

             Console.WriteLine("ProductID 12: {0}", productID.ProductName);
         }
        
         //30. Write code to check if ProductID 789 exists.
         private static void ProductID789()
         {
             var products = DataLoader.LoadProducts();
             var productID = products.FirstOrDefault(p => p.ProductID == 789);

             Console.WriteLine("ProductID 12 Exists: {0}", productID != null);
         }


        //31. Get a list of categories that have at least one product out of stock.
         static void PrintOutOfStockCats()
         {
             var products = DataLoader.LoadProducts();
             var outOfStock = from product in products
                 where product.UnitsInStock == 0
                 group product by product.Category
                 into outofstockcategories
                 select new { outofstockcategories.Key, groupproducts = outofstockcategories };
              

             Console.WriteLine("Out of stock: ");
             foreach (var p in outOfStock)
             {
                 Console.WriteLine(p.Key);
             }

             Console.Write("Press enter to continue");
             Console.ReadLine();
         }

        //32. Determine if NumbersB contains only numbers less than 9.
        private static void LessThan9()
        {
            var blist = DataLoader.NumbersB;
            bool lessthanNine = blist.All(b => b < 9);

            Console.WriteLine("List only contains numbers less than 9: {0}", lessthanNine);
            

            Console.Write("Press enter to continue");
            Console.ReadLine();
        }

        //33. Get a grouped a list of products only for categories that have all of their products in stock.
        static void InStockCats()
        {
            var products = DataLoader.LoadProducts();
            var inStock = from product in products
                          group product by product.Category
                          into Categories
                          where Categories.All(p => p.UnitsInStock >0 )
                          select new { Categories.Key, Products = Categories };


            Console.WriteLine("Categories with all products in stock: ");
            foreach (var p in inStock)
            {
                Console.WriteLine(p.Key);
            }

            Console.Write("Press enter to continue");
            Console.ReadLine();
        }


        //34. Count the number of odds in NumbersA.
        private static void OddinA()
        {
            var products = DataLoader.NumbersA;
            int oddNumbers = products.Count(p => p % 2 == 1);//Count property

            Console.WriteLine("Odd numbers in NumbersA: {0}", oddNumbers);
        }

        //35. Display a list of CustomerIDs and only the count of their orders.var orderCounts =
        //from c in customers
        //select new {c.CustomerID, OrderCount = c.Orders.Count()};
        private static void CustIDandCount()
        {
            var customers = DataLoader.LoadCustomers();
            var results = from customer in customers
                          select new {customer.CustomerID, OrderCount = customer.Orders.Count()};
            foreach (var item in results)
            {
                Console.WriteLine("{0} :{1}", item.CustomerID, item.OrderCount);
            }
 
            Console.Write("Press enter to continue");
            Console.ReadLine();
        }

        //36. Display a list of categories and the count of their products.

        private static void CatandCount()
        {
            var products = DataLoader.LoadProducts();
            var results = from product in products
                          group product by product.Category
                          into categories
                          select new { categories.Key, grouped = categories.Count() };
            foreach (var item in results)
            {
                Console.WriteLine("{0}:{1}", item.Key, item.grouped);
                
            }

            Console.Write("Press enter to continue");
            Console.ReadLine();
        }
        //37. Display the total units in stock for each category.
        private static void CatandStockCount()
        {
            var products = DataLoader.LoadProducts();
            var results = from product in products
                          where product.UnitsInStock >0
                          group product by product.Category
                              into categories
                              select new { categories.Key, grouped = categories.Count() };
            foreach (var item in results)
            {
                
                Console.WriteLine("{0}:{1}", item.Key, item.grouped);

            }

            Console.Write("Press enter to continue");
            Console.ReadLine();
        }

        //38. Display the lowest priced product in each category.

        private static void LowestPriceCats()
        {
            var products = DataLoader.LoadProducts();
            var results = from product in products
                          where product.UnitsInStock > 0
                          group product by product.Category
                              into categories
                              select new { categories.Key, grouped = categories.Min(p => p.UnitPrice) };
            foreach (var item in results)
            {

                Console.WriteLine("{0}:{1:c}", item.Key, item.grouped);

            }

            Console.Write("Press enter to continue");
            Console.ReadLine();
        }
        //39. Display the highest priced product in each category.
        private static void HighestPriceCats()
        {
            var products = DataLoader.LoadProducts();
            var results = from product in products
                          where product.UnitsInStock > 0
                          group product by product.Category
                              into categories
                              select new { categories.Key, grouped = categories.Max(p => p.UnitPrice) };
            foreach (var item in results)
            {

                Console.WriteLine("{0}:{1:c}", item.Key, item.grouped);

            }

            Console.Write("Press enter to continue");
            Console.ReadLine();
        }

        //40. Show the average price of product for each category.

        private static void AvePriceCats()
        {
            var products = DataLoader.LoadProducts();
            var results = from product in products
                          where product.UnitsInStock > 0
                          group product by product.Category
                              into categories
                              select new { categories.Key, grouped = categories.Average(p => p.UnitPrice) };
            foreach (var item in results)
            {

                Console.WriteLine("{0}:{1:c}", item.Key, item.grouped);

            }

            Console.Write("Press enter to continue");
            Console.ReadLine();
        }
    

    
     
    }
}
