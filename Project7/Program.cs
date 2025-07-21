///////////////////////////////////////////////////////////////////////////////
//
//  Author: Christopher Bragg, braggc1@etsu.edu
//  Course: CSCI-2210-001 - Data Structures
//  Assignment: Project 7 
//  Description: Main file where the program is ran.
//  Code from Professor Gillenwater's StudentRoster project was utilized in parts of this file
//  link to post: https://elearn.etsu.edu/d2l/le/content/9044274/viewContent/86307849/View
//  
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Text.RegularExpressions;

namespace Project7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine();
            Menu menu = new();

            // from Program.cs of StudentRoster
            while (menu.CheckIfRunning())
            {
                Console.Clear();
                menu.DisplayResult(menu.calculator);
                
                menu.DisplayMenu();

                // from Program.cs of StudentRoster
                // Get menu option
                string[] inputs = Console.ReadLine().Split(" ");
                inputs[0] = inputs[0].ToLower();

                // from Program.cs of StudentRoster (altered)
                // Do menu option
                if (menu.menuActions.ContainsKey(inputs[0]) || menu.varMenuActions.ContainsKey(inputs[0] ))
                {
                    if (inputs.Length == 1)
                    {
                        menu.menuActions[inputs[0]]();
                    }
                    if (inputs.Length == 2)
                    {
                        //checks to see if the input contains a number 
                        if (double.TryParse(inputs[1], out double x))
                        {
                            menu.menuActions[inputs[0]](Convert.ToDouble(inputs[1]));
                        }
                        //the input is read as a string
                        else
                        {
                            menu.varMenuActions[inputs[0]](inputs[1]);
                        }
                    }                   
                }
            }
        }
    }
} 