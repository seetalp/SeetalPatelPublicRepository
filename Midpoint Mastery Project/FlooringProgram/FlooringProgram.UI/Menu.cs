using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringPogram.Data;
using FlooringPogram.Data.Loaders;
using FlooringPogram.Data.Mocks;
using FlooringProgram.Models;
using FlooringProgram.Models.DTOs;
using FlooringProgram.Operations;
using FlooringProgram.UI.WorkFlows;
using Ninject;
using System.Configuration;

namespace FlooringProgram.UI
{
    public class Menu
    {
        
  
      

        private string _userChoice;

        private IKernel _kernel;//Instantiate the container


        public void StartApplication()
        {
            ConfigureIOC();//Create method to configure our IOC 
            do
            {
                DisplayMenu();
                _userChoice = PromptUser();
                ExecuteChoice(_userChoice);


                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();

            } while (_userChoice != "5");
        }

        private IKernel ConfigureIOC()//if statement for app config file to be in Test Mode or Prod Mode 
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            if (mode == "Test")
            {
                return _kernel = new StandardKernel(new FlooringProgramTestModule());
            }
            return _kernel = new StandardKernel(new FlooringProgramModule());
        }

        private void ExecuteChoice(string userChoice)
        {
            switch (userChoice)
            {
                case "1":
                    DisplayOrder flow1 = _kernel.Get<DisplayOrder>();//WHAT DOES THIS MEAN IN ENGLISH?
                    flow1.Execute();
                    break;
                case "2":
                    AddOrder flow2 = _kernel.Get<AddOrder>();
                    flow2.Execute();
                    break;
                case "3":
                    EditOrder flow3 = _kernel.Get<EditOrder>();
                    flow3.Execute();
                    break;
                case "4":
                    RemoveOrder flow4 = _kernel.Get<RemoveOrder>();
                    flow4.Execute();
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("That was not a valid input.");
                    break;
            }
        }

        private string PromptUser()
        {
            Console.WriteLine();
            //get userinput from the user
            Console.Write("Enter you choice: ");
            return Console.ReadLine();
        }

        private void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Flooring Manager");
            Console.WriteLine("- - - - - - - - - - - - - - - - -");
            Console.WriteLine("1) Display Orders");
            Console.WriteLine("2) Add an Order");
            Console.WriteLine("3) Edit an Order");
            Console.WriteLine("4) Remove an Order");
            Console.WriteLine("5) Quit");
        }
    }
}
