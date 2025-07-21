///////////////////////////////////////////////////////////////////////////////
//
//  Author: Christopher Bragg, braggc1@etsu.edu
//  Course: CSCI-2210-001 - Data Structures
//  Assignment: Project 7 
//  Description: File that handles interaction with the user,
//  contains all of the menu options, menu printouts, and printout of the current state
//  Code from Professor Gillenwater's StudentRoster project was utilized in parts of this file
//  link to post: https://elearn.etsu.edu/d2l/le/content/9044274/viewContent/86307849/View
//  
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Project7
{
	public class Menu
	{
        /// <summary>
        /// dictionary for the menu options of the calculator
        /// </summary>
        public Dictionary<string, dynamic> menuActions = new();

        /// <summary>
        /// dictionary for the variable specific menu options
        /// </summary>
        public Dictionary<string, dynamic> varMenuActions = new();

        /// <summary>
        /// for storing the error message
        /// </summary>
        public string ErrorMessage = string.Empty;

        /// <summary>
        /// bool to keep check on if the program should continue to run
        /// </summary>
        bool isRunning = true;

        /// <summary>
        /// a new calculator object
        /// </summary>
        public Calculator calculator = new();

        /// <summary>
        /// constructor of the menu, contains all of the menu options available to the user 
        /// </summary>
        public Menu()
		{
            menuActions["+"] = new Action<double>((var) => { calculator.Add(var); });
            menuActions["-"] = new Action<double>((var) => { calculator.Subtract(var); });
            menuActions["*"] = new Action<double>((var) => { calculator.Multiply(var); });
            menuActions["/"] = new Action<double>((var) => {calculator.Divide(var); });
            menuActions["mod"] = new Action<double>((var) => {calculator.Mod(var); });
            menuActions["sq"] = new Action(() => { calculator.Square(); });
            menuActions["sqrt"] = new Action(() => { calculator.SquareRoot(); });
            menuActions["exp"] = new Action<double>((var) => { calculator.Exponentiate(var); });
            menuActions["!"] = new Action(() => { calculator.Factorial(); });
            menuActions["undo"] = new Action(() => { calculator.Undo(); });
            menuActions["clear"] = new Action(() => { calculator.Clear(); });
            menuActions["exit"] = new Action(() => { isRunning = false; });

            varMenuActions["var"] = new Action<string>((varName) =>
            {
                //regex is used to verify that the variable entererd
                //meets the requirements in the spec
                var checkInput = ("^[a-z]*$");
                Regex regx = new Regex(checkInput);
                if (regx.IsMatch(varName))
                {
                    calculator.CreateVariable(varName);
                }
            });

            varMenuActions["set"] = new Action<string>((varName) =>
            {
                if (calculator.Variables.ContainsKey(varName))
                {
                    calculator.SetVariable(varName);
                }
                else
                {
                    ErrorMessage = "error - unknown variable";
                }
            });
            varMenuActions["+"] = new Action<string>((varName) =>
            {
                if (calculator.Variables.ContainsKey(varName))
                {

                    calculator.Add(calculator.GetVariable(varName));
                }
                else
                {
                    ErrorMessage = "error - unknown variable";
                }
            });
            varMenuActions["-"] = new Action<string>((varName) =>
            {
                if (calculator.Variables.ContainsKey(varName))
                {
                    calculator.Subtract(calculator.GetVariable(varName));
                }
                else
                {
                    ErrorMessage = "error - unknown variable";
                }
            });
            varMenuActions["*"] = new Action<string>((varName) =>
            {
                if (calculator.Variables.ContainsKey(varName))
                {
                    calculator.Multiply(calculator.GetVariable(varName));
                }
                else
                {
                    ErrorMessage = "error - unknown variable";
                }
            });
            varMenuActions["/"] = new Action<string>((varName) =>
            {
                if (calculator.Variables.ContainsKey(varName))
                {
                    calculator.Divide(calculator.GetVariable(varName));
                }
                else
                {
                    ErrorMessage = "error - unknown variable";
                }
            });
            varMenuActions["exp"] = new Action<string>((varName) =>
            {
                if (calculator.Variables.ContainsKey(varName))
                {
                    calculator.Exponentiate(calculator.GetVariable(varName));
                }
                else
                {
                    ErrorMessage = "error - unknown variable";
                }
            });
            varMenuActions["read"] = new Action<string>((filePath) => { calculator.ReadVariables(filePath); });
            varMenuActions["write"] = new Action<string>((filePath) => { calculator.WriteVariables(filePath); });
        }
        /// <summary>
        /// shows all of the menu options available 
        /// </summary>
        public void DisplayMenu()
        {
            Console.WriteLine(
                "+ \t [number] or [variable]\n-\t [number] or [variable]\n* \t " +
                "[number] or [variable]\n/\t [number] or [variable]\nmod\t " +
                "[number] or [variable]\nexp\t [number] or [variable]\nsqrt\t  " +
                "N/A\nsq\t  N/A\t\n!\t  N/A\n\nvar\t[variable name]" +
                "\nset\t[variable name]\nread\t[filename]\nwrite\t[filename]\n" +
                "\nundo\tundo last command\nclear\tclear the calculator" +
                "\nexit\texit the program\n-------------------------------------");
        }
        /// <summary>
        /// displays the current state of the calculator.
        /// from Program.cs of StudentRoster (altered)
        /// </summary>
        /// <param name="calculator">used to get the current state of the calculator</param>
        public void DisplayResult(Calculator calculator)
        {
            ConsoleColor oldbg, oldfg;
            oldbg = Console.BackgroundColor;
            oldfg = Console.ForegroundColor;
            Console.WriteLine("-------------------------------------\n\n");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(calculator.Result);
            Console.BackgroundColor = oldbg;
            Console.ForegroundColor = oldfg;
            //if the ErrorMessage isn't empty the error message is printed 
            if (!(ErrorMessage.Equals(string.Empty)))
            {
                Console.WriteLine(ErrorMessage);
            }
            //removes the error message from the screen by making it empty
            ErrorMessage = string.Empty;
            Console.WriteLine("-------------------------------------\n");
        }
        /// <summary>
        /// checks to see if the program needs to keep running
        /// </summary>
        /// <returns>a true or false based on the menuActions</returns>
        public bool CheckIfRunning()
        {
            return isRunning;
        }
    }
}