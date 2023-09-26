// Write a program to keep track of some inventory items as shown below.
// Hint: when creating arrays, as you get or read items into
// your array, then initialize each array spot before its use
// and place a counter or use your own Mylength to keep track
// of your array length as it is used.
/***************************************
 * Marcus Newsome
 * Homework 7: Final Project
 * 6/7/23
 **************************************/

using System;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    // create an array of your ItemData struct
    struct ItemData
    {
        public string ItemID;
        public string Description;
        public double PricePerUnit;
        public int Quantity;
        public double CostPerUnit;
        public double TotalValue;
    }

    public static void Main()
    {
        // create an object of type ItemData
        ItemData[] items = new ItemData[99];

        // use an integer to keep track of the count of items in your inventory
        int itemCount = 0;

        // use a never ending loop that shows the user what options they can select 
        // as long as no one Quits, continue the inventory update
        // in that loop, show what user can select from the list
        // read the user's input and then create what case it falls
        bool keepGoing = true;

        while(keepGoing)
        {
            Console.WriteLine("\n" + "Welcome to Tennis Plus! Please select an option from the list below: ");
            Console.WriteLine("(1) Add a new item" + "\n" + "(2) Update an item" + "\n" + "(3) Remove an item"
                + "\n" + "(4) List all items in inventory" + "\n" + "(5) Exit the program");
            Console.Write("I would like to (only type in the digit): ");

            // read user's input
            string strx = Console.ReadLine();

            // validate that user put in only a digit
            bool isValidOption;
            isValidOption = int.TryParse(strx, out int v);

            // if input other than a digit is put in, user is re-prompted
            while (!isValidOption)
            {
                Console.WriteLine("\n" + "Welcome to Tennis Plus! Please select an option from the list below: ");
                Console.WriteLine("(1) Add a new item" + "\n" + "(2) Update an item" + "\n" + "(3) Remove an item"
                    + "\n" + "(4) List all items in inventory" + "\n" + "(5) Exit the program");
                Console.Write("I would like to (only type in the digit): ");

                // read user's input
                strx = Console.ReadLine();

                isValidOption = int.TryParse(strx, out int w);

            }

            // convert the given string to integer to match our case types shown below
            int optx = int.Parse(strx);

            // provide an extra blank line on screen
            Console.WriteLine();

            switch (optx)
            {
                // add an item to the list if this option is selected
                case 1:
                {
                    Console.WriteLine("I would like to: (1) Add a new item");

                    // Item ID
                    Console.Write("Please enter the item ID (limit to 5 numbers, letters, and/or special characters): ");
                    string strItemID = Console.ReadLine();
                    for (int x = 0; x < itemCount; x++) // check to make sure ID isn't a duplicate
                    {
                        if (strItemID == items[x].ItemID)
                        {
                            Console.Write("That item ID already exists. Please enter a new item ID (limit to 5 numbers, letters, and/or special characters): ");
                            strItemID = Console.ReadLine(); // re-prompt for non-duplicate ID
                            x = 0; // reset the counter
                        }
                    }

                    while (strItemID.Length > 5) // check to make sure that ID isn't more than 10 characters long
                    {
                        Console.Write("Please enter the item ID (limit to 5 numbers, letters, and/or special characters): ");
                        strItemID = Console.ReadLine();
                    }

                    items[itemCount].ItemID = strItemID;

                    // Description
                    Console.Write("Please enter a description of the item (limit to 50 characters max): "); 
                    string strDescription = Console.ReadLine();
                    if (strDescription.Length > 50) // if over 50 characters, substring it
                    {
                        strDescription = strDescription.Substring(0, 50);
                    }
                    items[itemCount].Description = strDescription;

                    // Price per unit
                    string str1PricePerUnit;
                    bool isNumeric1PricePerUnit;
                    do
                    {
                        Console.Write("Please enter the sale price per item (limit to numbers and decimals only; no letters or special characters): ");
                        str1PricePerUnit = Console.ReadLine();
                        isNumeric1PricePerUnit = double.TryParse(str1PricePerUnit, out double a);
                    } while (!isNumeric1PricePerUnit);  // ensure only numbers are entered
                    double dblPricePerUnit = double.Parse(str1PricePerUnit);
                    items[itemCount].PricePerUnit = dblPricePerUnit;

                    // Quantity
                    string str1Quantity;
                    bool isNumeric1Quantity;
                    do
                    {
                        Console.Write("Please enter the total quantity for this item (limit to whole numbers only; no letters or special characters): "); 
                        str1Quantity = Console.ReadLine();
                        isNumeric1Quantity = int.TryParse(str1Quantity, out int b);
                    } while (!isNumeric1Quantity); // ensure only numbers are entered
                    int intQuantity = int.Parse(str1Quantity);
                    items[itemCount].Quantity = intQuantity;

                    // Cost per unit
                    string str1CostPerUnit;
                    bool isNumeric1CostPerUnit;
                    do
                    {
                        Console.Write("Please enter the cost to purchase each item (limit to numbers and decimals only; no letters or special characters): ");
                        str1CostPerUnit = Console.ReadLine();
                        isNumeric1CostPerUnit = double.TryParse(str1CostPerUnit, out double b);
                    } while (!isNumeric1CostPerUnit);  // ensure only numbers are entered
                    double dblCostPerUnit = double.Parse(str1CostPerUnit);
                    items[itemCount].CostPerUnit = dblCostPerUnit;

                    // Total value
                    double dblTotalValue = dblPricePerUnit * intQuantity;
                    items[itemCount].TotalValue = dblTotalValue;

                    Console.WriteLine();

                    itemCount++;

                    break;
                }

                case 2: //change items in the list if this option is selected
                {
                    Console.WriteLine("I would like to: (2) Update an item");

                    Console.Write("Please enter the ID of the item you'd like to update: ");
                    string changeItemID = Console.ReadLine();
                    bool fFound = false;

                    for (int x = 0; x < itemCount; x++)
                    {
                        if (items[x].ItemID == changeItemID)
                        {
                            fFound = true;
                            // code to show what has to happen if the item in the list is found
                            // reset the count to show a new count for your list 
                            // (Note: your list is now increased by one item)

                            // Description
                            Console.WriteLine("\n" + "What should the new description be for {0}?", items[x].ItemID);
                            Console.WriteLine("Old Description for {0}: {1}", items[x].ItemID, items[x].Description);
                            Console.Write("New Description for {0} (limit to 50 characters max): ", items[x].ItemID);
                            string newDescription = Console.ReadLine();
                            if (newDescription.Length > 50) // if over 50 characters, substring it
                            {
                                newDescription = newDescription.Substring(0, 50);
                            }
                            items[x].Description = newDescription;

                            // Price per unit
                            Console.WriteLine("\n" + "What should the new price per unit be for {0}?", items[x].ItemID);
                            Console.WriteLine("Old price per unit for {0}: {1}", items[x].ItemID, items[x].PricePerUnit);
                            string str2PricePerUnit;
                            bool isNumeric2PricePerUnit;
                            do
                            {
                                Console.Write("New price per unit for {0} (limit to numbers and decimals only; no letters or special characters): ", items[x].ItemID);
                                str2PricePerUnit = Console.ReadLine();
                                isNumeric2PricePerUnit = double.TryParse(str2PricePerUnit, out double a);
                            } while (!isNumeric2PricePerUnit);  // ensure only numbers are entered
                            double newPricePerUnit = double.Parse(str2PricePerUnit);
                            items[x].PricePerUnit = newPricePerUnit;

                            // Quantity
                            Console.WriteLine("\n" + "What should the new quantity be for {0}?", items[x].ItemID);
                            Console.WriteLine("Old quantity for {0}: {1}", items[x].ItemID, items[x].Quantity);
                            string str2Quantity;
                            bool isNumeric2Quantity;
                            do
                            {
                                Console.Write("New quantity for {0} (limit to whole numbers only; no letters or special characters): ", items[x].ItemID);
                                str2Quantity = Console.ReadLine();
                                isNumeric2Quantity = int.TryParse(str2Quantity, out int b);
                            } while (!isNumeric2Quantity); // ensure only numbers are entered
                            int newQuantity = int.Parse(str2Quantity);
                            items[x].Quantity = newQuantity;

                            // Cost per unit
                            Console.WriteLine("\n" + "What should the new cost per unit be for {0}?", items[x].ItemID);
                            Console.WriteLine("Old cost per unit for {0}: {1}", items[x].ItemID, items[x].CostPerUnit);
                            string str2CostPerUnit;
                            bool isNumeric2CostPerUnit;
                            do
                            {
                                Console.Write("New cost per unit for {0} (limit to numbers and decimals only; no letters or special characters): ", items[x].ItemID);
                                str2CostPerUnit = Console.ReadLine();
                                isNumeric2CostPerUnit = double.TryParse(str2CostPerUnit, out double b);
                            } while (!isNumeric2CostPerUnit);  // ensure only numbers are entered
                            double newCostPerUnit = double.Parse(str2CostPerUnit);
                            items[x].CostPerUnit = newCostPerUnit;

                            // Total value
                            Console.WriteLine("\n" + "Previously, the total value for {0} was {1}", items[x].ItemID, items[x].TotalValue);
                            double newTotalValue = newPricePerUnit * newQuantity;
                            items[x].TotalValue = newTotalValue;
                            Console.Write("Now, the updated total value for {0} is {1}", items[x].ItemID, items[x].TotalValue);
                        }
                    }

                    if (!fFound) // and if not found
                    {
                        Console.WriteLine("Item {0} not found", changeItemID);
                    }

                    Console.WriteLine();

                    break;
                }

                case 3: //delete items in the list if this option is selected
                {
                    Console.WriteLine("I would like to: (3) Remove an item");

                    Console.Write("Please enter the ID of the item you'd like to delete: ");
                    string deleteItemID = Console.ReadLine();
                    bool deleted = false;

                    for (int x = 0; x < itemCount; x++)
                    {
                        if (items[x].ItemID == deleteItemID)
                        {
                            deleted = true;
                            // delete the item if you found it
                            // reset the count to show a new count for your list 
                            //(Note: your list is now reduced by one item)
                            int indexToDelete = x;

                            for (int y = indexToDelete; y < itemCount - 1; y++)
                            {
                                items[y].ItemID = items[y + 1].ItemID;
                                items[y].Description = items[y + 1].Description;
                                items[y].PricePerUnit = items[y + 1].PricePerUnit;
                                items[y].Quantity = items[y + 1].Quantity;
                                items[y].CostPerUnit = items[y + 1].CostPerUnit;
                                items[y].TotalValue = items[y + 1].TotalValue;
                            }

                            itemCount--;
                        }
                    }

                    if (deleted) // hint the user that you deleted the requested item
                    {
                        Console.WriteLine("Item {0} was deleted.", deleteItemID);
                    }
                    else // if did not find it, hint the user that you did not find it in your list
                    {
                        Console.WriteLine("Item {0} was not found.", deleteItemID);
                    }

                    Console.WriteLine();

                    break;
                }

                case 4:  //list all items in current database if this option is selected
                {
                    Console.WriteLine("Item#       ItemID      Description                                         Price       QOH         Cost        Value");
                    Console.WriteLine("----------  ----------  --------------------------------------------------  ----------  ----------  ----------  --------------------");

                    // code in this block. Use the above line format as a guide for printing or displaying
                    // the items in your list right under it
                    for (int x = 0; x < itemCount; x++)
                    {
                        Console.WriteLine("{0, -11} {1, -11} {2, -51} {3, -11:C} {4, -11} {5, -11:C} {6, -19:C}", x + 1, items[x].ItemID, items[x].Description, items[x].PricePerUnit
                            , items[x].Quantity, items[x].CostPerUnit, items[x].TotalValue);
                    }

                    Console.WriteLine();

                    break;
                }

                case 5: //quit the program if this option is selected
                {
                    Console.Write("Are you sure that you want to quit? Enter y (yes) to quit or n (no) to stay. ");
                    string input = Console.ReadLine();

                    if (input == "y" || input == "Y")
                    {
                        //optx = 0; //as long as it is not 5, the process is not breaking   
                        keepGoing = false;
                    }

                    break;
                }

                default:
                {
                    Console.WriteLine("That's an invalid option. Please select an option from the list below.");
                    break;
                }
            }

        }

    }
}
