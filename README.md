# CSharp Calculator

## Overview
This project implements a **menu-driven calculator** in C# designed to demonstrate proficiency with dictionaries and state management. It was developed for the **CSCI 2210 – Data Structures** course at East Tennessee State University.

## Features
- Basic arithmetic operations: **Add, Subtract, Multiply, Divide, Mod, Square, Square Root, Exponentiate, Factorial**
- **Stateful calculator**: Previous results are stored and reused
- **Variable storage**: Save results into named variables (lowercase only) for reuse
- **Undo feature**: Rollback the last operation
- **File save/load**: Export and import variables for later sessions
- **Friendly error messages** for unknown variable usage
- **Reverse Polish Notation (RPN)** calculation support
- **Fibonacci sequence generator** using current state value

## Project Structure
- **Calculator Class**: Core logic and operations
- **Menu Class**: Handles terminal-based menu navigation via dispatch tables
- **FileManager Class**: File I/O for saving/loading variable states
- **Undo Stack**: Supports undo functionality

## How to Run
1. Open the solution in **Visual Studio 2022**
2. Build the project
3. Run the project and follow the terminal prompts

## Notes
- Designed as a **terminal-based application** with clean user interaction.
- Implements **dispatch tables** for efficient operation selection.

## Author
Christopher Bragg
