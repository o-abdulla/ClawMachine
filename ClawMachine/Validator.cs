using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleLab
{
    public class Validator
    {
        public static int GetPositiveInputInt()
        {
            int result = -1;
            while (int.TryParse(Console.ReadLine(), out result) == false || result <= 0)
            {
                Console.WriteLine("Invalid input. Try again with a positive number.");
            }
            return result;
        }

        public static double GetPositiveInputDouble()
        {
            double result = -1;
            while (double.TryParse(Console.ReadLine(), out result) == false || result <= 0)
            {
                Console.WriteLine("Invalid input. Try again with a positive number.");
            }
            return result;
        }

        public static float GetPositiveInputFloat()
        {
            float result = -1;
            while (float.TryParse(Console.ReadLine(), out result) == false || result <= 0)
            {
                Console.WriteLine("Invalid input. Try again with a positive number.");
            }
            return result;
        }
        public static decimal GetPositiveInputDecimal()
        {
            decimal result = -1;
            while (decimal.TryParse(Console.ReadLine(), out result) == false || result <= 0)
            {
                Console.WriteLine("Invalid input. Try again with a positive number.");
            }
            return result;
        }

        public static bool GetContinue()
        {
            bool result = false;
            while (true)
            {
                Console.WriteLine("Would you like to run again? y/n");
                string choice = Console.ReadLine().Trim().ToLower();
                if(choice == "y")
                {
                    result = true;
                    break;
                }
                else if(choice == "n")
                {
                    result = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again");
                }
            }
            return result;
        }

        public static bool GetContinue(string message)
        {
            bool result = false;
            while (true)
            {
                Console.WriteLine($"{message} y/n");
                string choice = Console.ReadLine().Trim().ToLower();
                if (choice == "y")
                {
                    result = true;
                    break;
                }
                else if (choice == "n")
                {
                    result = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again");
                }
            }
            return result;
        }


        public static bool numberCheck(int x, int y)
        {
            if(x > y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Date functions
        public static List<string> GetCurrentMonthDayYear()
        {
            string date = DateTime.Now.ToString("m/d/yyyy");
            List<string> monthYear = new List<string>();
            monthYear = date.Split('/').ToList();
            return monthYear;
        }
        // DD
        public static int GetCurrentDay()
        {
            List<string> monthYear = GetCurrentMonthDayYear();
            return int.Parse(monthYear[1]);
        }
        //MM
        public static int GetCurrentMonth()
        {
            List<string> monthYear = GetCurrentMonthDayYear();
            return int.Parse(monthYear[0]);
        }
        //YYYY
        public static int GetCurrentYear()
        {
            List<string> monthYear = GetCurrentMonthDayYear();
            return int.Parse(monthYear[2]);
        }
        //YY
        public static int GetCurrentYearAbb()
        {
            return int.Parse(GetCurrentYear().ToString().Substring(2, 2));
        }

        //cash payment
        public static decimal Cash(decimal grandTotal)
        {

            decimal cash = 0;
            decimal cashPaid = 0;
            decimal amountRemaining = 0;
            while (true)
            {

                Console.Write("Please enter cash amount:  ");

                while (decimal.TryParse(Console.ReadLine(), out cash) == false)
                {
                    Console.WriteLine("Invalid entry. Please enter only numerals.");
                }

                cashPaid += cash;
                if (cashPaid > grandTotal)
                {
                    decimal change = cashPaid - grandTotal;
                    Console.WriteLine($"Amount tendered: {cashPaid:c}");
                    Console.WriteLine($"Your change is: {change:c}");
                    return change;


                }
                else if (cash < grandTotal)
                {
                    amountRemaining = grandTotal - cashPaid;
                    Console.WriteLine($"Amount paid: {cashPaid:c}");
                    Console.WriteLine($"Amount remaining: {amountRemaining:c}");
                    Console.WriteLine($"Please enter remaining payment");


                }
                else if (cashPaid == grandTotal)
                {
                    decimal change = cashPaid - grandTotal;
                    Console.WriteLine($"Amount tendered: {cashPaid:c}");
                    Console.WriteLine($"Change: {change:c}");
                    return 0;

                }
            }

        }

        //credit payment
        public static void Card()
        {
            bool cardValidate = false;
            while (!cardValidate)
            {
                do
                {
                    cardValidate = true;
                    Console.WriteLine("Please enter 16-digit card number. \nWe do not accept American Express.");
                    ulong cardNum = 0;
                    //16 digit card number validation
                    while (ulong.TryParse(Console.ReadLine(), out cardNum) == false || cardNum < 0 || cardNum.ToString().Length != 16)
                    {

                        if (cardNum < 0)
                        {
                            Console.WriteLine("Invalid entry. Please enter only positive numbers");
                        }
                        else
                        {
                            Console.WriteLine("Only 16 digits allowed");
                        }
                        Console.WriteLine("Please enter a 16-digit account number.");
                    }
                    //Validation for expiration date (MM/YY)


                    int numMonth = 0;
                    Console.Write("Please enter two (2) digit card expiration month (MM):  ");
                    while (int.TryParse(Console.ReadLine(), out numMonth) == false || numMonth.ToString().Length > 2 || numMonth <= 0 || numMonth > 12)
                    {
                        Console.WriteLine("Invalid entry. Please enter only positive numbers and two digit month");
                    }

                    int numYear = 0;
                    Console.Write("Please enter two (2) digit card expiration year (YY):  ");
                    while (int.TryParse(Console.ReadLine(), out numYear) == false || numYear.ToString().Length != 2 || numYear < 0)
                    {
                        Console.WriteLine("Invalid entry. Please enter only positive numbers and two digit year Please also ensure the card is still valid.");
                    }

                    //date validation
                    if (numYear < GetCurrentYearAbb())
                    {
                        Console.WriteLine("Card is expired.");
                        cardValidate = false;
                    }
                    else if (numYear == GetCurrentYearAbb())
                    {
                        if (numMonth < GetCurrentMonth())
                        {
                            Console.WriteLine("Card is expired.");
                            cardValidate = false;
                        }
                    }
                } while (!cardValidate);
                Console.Write("Enter your 3 digit CVV code:  ");
                int cvv = 0;
                while (int.TryParse(1 + Console.ReadLine(), out cvv) == false || cvv.ToString().Substring(1).Length != 3 || cvv < 0)
                {
                    Console.WriteLine("Invalid entry. Please enter a positive 3 digit number");
                }
                string cvvStr = cvv.ToString().Substring(1);

            }
            Console.WriteLine("Card Accepted! Thank you, please come again.");

        }
    }
}
