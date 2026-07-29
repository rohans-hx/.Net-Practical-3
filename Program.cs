using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_3
{
    class Expense
    {
        public int ExpenseID;
        public string Category;
        public double Amount;
        public string PaymentMode;
        public DateTime ExpenseDate;

        public Expense()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Expense Tracking Module");
            Console.WriteLine("-----------------------");
        }

        public void AddExpense()
        {
            Console.Write("Enter Expense ID: ");
            ExpenseID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Expense Category: ");
            Category = Console.ReadLine();

            Console.Write("Enter Expense Amount: ");
            Amount = Convert.ToDouble(Console.ReadLine());

            if (Amount <= 0)
            {
                throw new Exception("Amount must be greater than zero.");
            }

            Console.Write("Enter Payment Mode (Cash, UPI, Card): ");
            PaymentMode = Console.ReadLine();

            ExpenseDate = DateTime.Now;

            Console.WriteLine("Expense Added Successfully!!\n");

        }

        public void DisplayExpense()
        {
            Console.WriteLine("====================");
            Console.WriteLine("Expense ID: " + ExpenseID);
            Console.WriteLine("Expense Category: " + Category);
            Console.WriteLine("Expense Amount: " + Amount);
            Console.WriteLine("Payment Mode: " + PaymentMode);
            Console.WriteLine("Expense Date: " + ExpenseDate);
            Console.WriteLine("====================");
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Expense> e = new List<Expense>();

            void menu()
            {
                Console.WriteLine("----------Menu----------");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. View All Expense");
                Console.WriteLine("3. View total Expense");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
            }

            try
            {
                
                while (true)
                {
                    menu();
                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        Expense exp = new Expense();
                        exp.AddExpense();
                        e.Add(exp);
                    }
                    else if (choice == 2)
                    {
                        if (e.Count == 0)
                        {
                            Console.WriteLine("No Expenses Found!!");
                        }
                        else
                        {
                            foreach (Expense exp in e)
                            {
                                exp.DisplayExpense();
                            }
                        }
                    }
                    else if (choice == 3)
                    {
                        double total = 0;
                        foreach (Expense exp in e)
                        {
                            total += exp.Amount;
                        }
                        Console.WriteLine("Total Expenses: " + total);
                    }
                    else if (choice == 4)
                    {
                        Console.WriteLine("Exiting....!!!");
                        return;
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! Enter Numeric Choice only");
            }
        }
    }
}