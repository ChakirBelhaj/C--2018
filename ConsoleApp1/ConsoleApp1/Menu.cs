using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Menu
    {
        // declare public variable
        public string name;


        public void Run()
        {
            bool loop = true;
            while (loop) // Loop indefinitely
            {
                Console.WriteLine(" Please enter your choice! \n 1. Save your name \n 2. Count numbers \n 3. What is my name? \n 4. Exit program \n 5. PLEASE NO!"); // Menu
                string option = Console.ReadLine(); // Get string from user
                
                switch (option) // switch statement
                {
                    case "1":
                        saveName();
                        break;
                    case "2":
                        countNumbers();
                        break; 
                    case "3":
                        askName(name);
                        break;
                    case "4":
                        loop = exit(loop);
                        break;
                    case "5":
                        break;
                   default:
                       Console.WriteLine("please select an option");
                       break;
                }
            }
        }

        public bool exit(bool loop)
        {
            loop = false;
            return loop;
        }
        
        //writ to consol and save name variable
        public void saveName()
        {
            Console.WriteLine("Enter your name");   // Report output
            name = Console.ReadLine();  //reads user input
            Console.WriteLine("your new name = " + name + " \n");   // Report output
        }

        //if name is not empty, Report output
        public void askName(string name)
        {
            if (name == "")
            {
                Console.WriteLine("There is no name saved!");// Report output
            }
            else
            {
                Console.WriteLine("your current name = " + name + " \n");// Report output
            }
        }

        //  counts 2 user inputs
        public void countNumbers()
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int inputInt))  //  checks if input is int
            {
                string secondInput = Console.ReadLine();
                if (int.TryParse(secondInput, out int secondInputInt))  //  checks if input is int
                {
                    int result;
                    result = inputInt + secondInputInt;  //calculates 2 variables
                    Console.Write( inputInt + " + " + secondInputInt + " = " + result + "\n"); // Report output
                }else
                {
                    Console.Write("this is an int " + input + "\n"); // Report output
                }
            }
        }
    }
}
