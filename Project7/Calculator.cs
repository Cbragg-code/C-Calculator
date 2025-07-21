///////////////////////////////////////////////////////////////////////////////
//
//  Author: Christopher Bragg, braggc1@etsu.edu
//  Course: CSCI-2210-001 - Data Structures
//  Assignment: Project 7 
//  Description: File for storing the state of the calculator,
//  performing actions on the current state of the calculator,
//  storing the variables of the calculator,
//  and performing actions using the variables 
//  
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project7
{
	public class Calculator
	{
        /// <summary>
        /// the current state of the calculator.
        /// </summary>
        public double Result { get; set; } = 0;

        /// <summary>
        /// stack containing the calculator's state(s)
        /// </summary>
        public Stack<double> ResultHistory = new();

        /// <summary>
        /// a dictionary of variables, contains the name of the
        /// variables as well as the value associated with them
        /// </summary>
        public Dictionary<string, double> Variables = new();

        /// <summary>
        /// constructor for the claculator
        /// </summary>
        public Calculator() { }

        /// <summary>
        /// creates a variable based on the current state of the calculator
        /// </summary>
        /// <param name="variable">the name of the variable provided by the user</param>
        public void CreateVariable(string variable)
        {
            Variables.Add(variable, this.Result);
        }

        /// <summary>
        /// gets the variable from the variables dictionary for the user to use in arithmetic operations
        /// </summary>
        /// <param name="variable">the name of the variable the user wants to use in their operation</param>
        /// <returns>the value from the key value pair</returns>
        public double GetVariable(string variable)
        {
            double value = this.Result;
            Variables.TryGetValue(variable, out value);
            return value;
        }

        /// <summary>
        /// sets an existing variable to whatever the current state is.
        /// </summary>
        /// <param name="variable">the variable the user is setting a value to</param>
        public void SetVariable(string variable)
        {
            Variables[variable] = this.Result;
        }

        /// <summary>
        /// writes all of the variables from the dictionary into a file
        /// that is then stored inside of the bin folder of the project 
        /// </summary>
        /// <param name="file">the name of the file the user wants to store their variables in</param>
        public void WriteVariables(string file)
        {
            using (StreamWriter streamWriter = new StreamWriter(file))
            {
                foreach (KeyValuePair<string, double> varPair in Variables)
                {
                    streamWriter.Write(varPair.Key + ":");
                    streamWriter.WriteLine(varPair.Value);
                }
                streamWriter.Close();
            }
        }

        /// <summary>
        /// reads from a file containting variables
        /// </summary>
        /// <param name="file">the name of the file the user wants to read variables from</param>
        public void ReadVariables(string file)
        {
            using (StreamReader streamReader = new StreamReader(file))
            {
                this.Variables = new Dictionary<string, double>();
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] lines = line.Split(':');
                    Console.WriteLine(lines[0] + lines[1]);
                    this.Variables.Add(lines[0], Convert.ToDouble(lines[1]));
                }
                streamReader.Close();
            }
        }

        /// <summary>
        /// performs addition on the current state 
        /// </summary>
        /// <param name="variable">the number or variable the user wants to perform addition with</param>
        public void Add(double variable)
		{
			this.Result += variable;
            ResultHistory.Push(this.Result);
		}

        /// <summary>
        /// performs subtraction on the current state
        /// </summary>
        /// <param name="variable">the number or variable the user wants to perform subtraction with</param>
        public void Subtract(double variable)
        {
            this.Result -= variable;
            ResultHistory.Push(this.Result);
        }

        /// <summary>
        /// performs multiplication on the current state
        /// </summary>
        /// <param name="variable">the number or variable the user wants to perform multiplication with</param>
        public void Multiply(double variable)
        {
            this.Result *= variable;
            ResultHistory.Push(this.Result);
        }

        /// <summary>
        /// performs division on the current state 
        /// </summary>
        /// <param name="variable">the number or variable the user wants to perform division with</param>
        public void Divide(double variable)
        {
            this.Result /= variable;
            ResultHistory.Push(this.Result);
        }

        /// <summary>
        /// performs modulous on the current state
        /// </summary>
        /// <param name="variable">the number or variable the user wants to perform mod with</param>
        public void Mod(double variable)
        {
            this.Result %= variable;
            ResultHistory.Push(this.Result);
        }

        /// <summary>
        /// squares the current state
        /// </summary>
        public void Square()
        {
            this.Result *= Result;
            ResultHistory.Push(this.Result);
        }

        /// <summary>
        /// takes the square root of the current state
        /// </summary>
        public void SquareRoot()
        {
            this.Result = Math.Sqrt(Result);
            ResultHistory.Push(this.Result);
        }

        /// <summary>
        /// exponentiates the current state
        /// </summary>
        /// <param name="variable"></param>
        public void Exponentiate(double variable)
        {
            this.Result = Math.Pow(Result, variable);
            ResultHistory.Push(this.Result);
        }

        /// <summary>
        /// takes the factorial of the current state
        /// </summary>
        public void Factorial()
        {
            double num = this.Result;
            if (num > 0)
            {
                for (double i = num -1; i > 0; i--)
                {
                    Result *= i;
                }
            }
            else
            {
                this.Result = 1;
            }
            ResultHistory.Push(this.Result);
        }

        /// <summary>
        /// undo the last command by removing the top value from the stack,
        /// then peek the stack to get the current state of the calculator.
        /// </summary>
        public void Undo()
        {
            ResultHistory.TryPop(out double x);
            ResultHistory.TryPeek(out double n);
            this.Result = n;
        }

        /// <summary>
        /// clears the calculators current state by setting to zero,
        /// clears the history of the calculator by clearing ResultHistory
        /// clears the variables stored in the calculator by clearing Variables
        /// </summary>
        public void Clear()
        {
            this.Result = 0;
            ResultHistory.Clear();
            Variables.Clear();
        }
    }
}