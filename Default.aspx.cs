/*      Program Name: Dice Roller
 *      Created: 10/27/2018
 *      Author: Ashley Ruffini
 *      Purpose: Roll any number of the same sided dice and view their results
 *      
 *      Last Update: 10/28/2018 - Ashley Ruffini
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace diceRoller
{
    public partial class _Default : Page
    {
        private string numOfDice; //Number of dice being rolled -> Text from Box
        private string diceSides;  //Type of di being rolled ie: d4, d8, d12...  -> Text from Box
        private int startNum; // This is the starting point for a di
        private int numOfDiceInt; //Number of dice being rolled
        private int diceSidesInt;  //Type of di being rolled ie: d4, d8, d12...
        private static List<int> rollResults = new List<int>(); //List for roll results
        Regex regex = new Regex("[0-9\b]+"); //Numerical values only

        protected void Page_Load(object sender, EventArgs e) // Set default values on load
        {
            startNum = 1;
            ResetResults();
        }

        //button click - validate, roll, show results, clear
        protected void RollBtn_Click(object sender, EventArgs e)
        {
            ResetResults(); // Clear out the list and div before populating again
            GetNumbers(); // Get numbers
            if (ValidateInput()) // if the validation has passed
            {
                RandomRoller(numOfDiceInt, diceSidesInt); // Roll the dice
                ShowResults(); // Show the results of the rolls
            }
        }

        //Assign Values from page
        private void GetNumbers()
        {
            numOfDice = numBox.Text;
            diceSides = sideBox.Text;

            ValidateInput(); //validate
        }

        private bool ValidateInput()
        {
            //Validation Result: T/F
            bool valResult;

            //Make sure only numbers were entered, and they were positive
            if (!regex.IsMatch(numOfDice.ToString()) || !regex.IsMatch(diceSides.ToString())) //not numeric, non neg since it's also getting the -.
            {
                outputDiv.InnerHtml = "<h3>Please enter Positive Numerical values only.</h3>";
                valResult = false;
            }
            else
            {
                numOfDiceInt = int.Parse(numOfDice);
                diceSidesInt = int.Parse(diceSides);

                //Check to for numbers greater than 0
                if (numOfDiceInt < 1 || diceSidesInt < 1)
                {
                    outputDiv.InnerHtml = "<h3>Please enter a number greater than 0.</h3>";
                    valResult = false;
                }
                else
                {
                    valResult = true;
                }
            }

            return valResult;
        }

        //Create a X number of random numbers between 1 and Y
        private void RandomRoller(int num, int sides) 
        {

            int n = startNum; // set n = starting number on the di

            while (n <= num)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode()); // Seed the random number

                int result = rand.Next(startNum, sides+1); // Use n incase the starting number needs to be increased for some reason. Add one to allow the max number to be included
                rollResults.Add(result); // Add result to the list 
                n++;
            }

        }

        // Show the result of the dice rolls
        private void ShowResults() 
        {
            outputDiv.InnerHtml = "<h3>Your Results for " + numOfDice + "d" + diceSides + ":<br />";

            foreach (int result in rollResults)
            {
                outputDiv.InnerHtml += "[" + result + "]  ";
            }
            outputDiv.InnerHtml += "</h3>";
        }

        // Reset the list for the next use
        private void ResetResults() 
        {
            rollResults.Clear();
            outputDiv.InnerHtml = "";
        }
    }
}