using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MingZhuTicketReservationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nMingji Reservation Program:\n");
            int[,] seatNumber = new int[4, 4]
            {{11,12,13,14},
             {21,22,23,24},
             {31,32,33,34},
             {41,42,43,44}};
            bool[,] seatAvailable = new bool[4, 4];
            string[,] customerName = new string[4, 4];
            string seats = "";
            string reserveSeat = "";
            string option = "";

            do
            {
                Console.WriteLine("1.Display available seating");
                Console.WriteLine("2.Reserve / add a seat for a customer");
                Console.WriteLine("3.Remove a reservation(by customer name)");
                Console.WriteLine("4.Remove a reservation(by seat number / code)");
                Console.WriteLine("5.Test load(all seats) to capacity");
                Console.WriteLine("6.Exit Menu / End program.\n");
                Console.Write("Choose one option:");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1"://display seats
                        Console.WriteLine("-------------------------------------------------------------------------------------------\n");
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if (seatAvailable[i, j])
                                {
                                    seats += "*Taken Seat" + (i + 1) + (j + 1) + ":" + customerName[i, j] + "\t";
                                }
                                else
                                {
                                    seats += "*Available Seat " + seatNumber[i, j] + "\t";
                                }
                            }

                            seats += "\n";
                        }
                        Console.WriteLine(seats);
                        Console.WriteLine("-------------------------------------------------------------------------------------------\n");

                        break;
                    case "2"://reserve seat if seats are not reserved already
                        bool testLoad()
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                for (int j = 0; j < 4; j++)
                                {
                                    if (seatAvailable[i, j] == false)
                                    {
                                        return false;
                                    }
                                }
                            }

                            return true;
                        }

                        if (testLoad())//cannot reserve seat after user choose option 5
                        {
                            Console.WriteLine("No seats left, please come earlier next time!");
                        }
                        else
                        {
                            Console.Write("What's your name:");
                            string name = Console.ReadLine();
                            Console.Write("Enter seat number to reserve:");
                            reserveSeat = Console.ReadLine();
                            char a = reserveSeat[0];
                            char b = reserveSeat[1];
                            int i = (int)char.GetNumericValue(a) - 1;
                            int j = (int)char.GetNumericValue(b) - 1;
                            try
                            {
                                if (seatAvailable[i, j])
                                {
                                    Console.Write("Sorry, this seat is not available, please choose another seat number:");
                                    reserveSeat = Console.ReadLine();
                                    a = reserveSeat[0];
                                    b = reserveSeat[1];
                                    i = (int)char.GetNumericValue(a) - 1;
                                    j = (int)char.GetNumericValue(b) - 1;
                                    seatAvailable[i, j] = true;
                                    customerName[i, j] = name;
                                }
                                else
                                {
                                    seatAvailable[i, j] = true;
                                    customerName[i, j] = name;
                                }
                            }
                            catch (Exception)
                            {
                                Console.Write("Please enter above seat number:");
                                reserveSeat = Console.ReadLine();
                                a = reserveSeat[0];
                                b = reserveSeat[1];
                                i = (int)char.GetNumericValue(a) - 1;
                                j = (int)char.GetNumericValue(b) - 1;
                                seatAvailable[i, j] = true;
                                customerName[i, j] = name;
                            }
                        }
                        Console.WriteLine();
                        break;
                    case "3"://remove reservation by user name
                        Console.Write("Enter user name to remove reservation:");
                        reserveSeat = Console.ReadLine();
                        try
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                for (int j = 0; j < 4; j++)
                                {
                                    if (customerName[i, j] == reserveSeat)
                                    {

                                        seatAvailable[i, j] = false;
                                    }


                                }
                            }
                        }
                        catch (Exception)
                        {
                            Console.Write("please enter correct user name:");
                            reserveSeat = Console.ReadLine();
                            for (int i = 0; i < 4; i++)
                            {
                                for (int j = 0; j < 4; j++)
                                {
                                    if (customerName[i, j] == reserveSeat)
                                    {
                                        seatAvailable[i, j] = false;
                                    }
                                }
                            }
                        }
                        break;
                    case "4"://remove reservation by seat number
                        try
                        {
                            Console.Write("Enter seat number to remove reservation:");
                            reserveSeat = Console.ReadLine();
                            char a = reserveSeat[0];
                            char b = reserveSeat[1];
                            int i = (int)char.GetNumericValue(a) - 1;
                            int j = (int)char.GetNumericValue(b) - 1;
                            seatAvailable[i, j] = false;
                        }
                        catch (Exception)
                        {
                            Console.Write("Please enter correct seat number:");
                            reserveSeat = Console.ReadLine();
                            char a = reserveSeat[0];
                            char b = reserveSeat[1];
                            int i = (int)char.GetNumericValue(a) - 1;
                            int j = (int)char.GetNumericValue(b) - 1;
                            seatAvailable[i, j] = false;
                        }
                        break;
                    case "5"://reserve all seats--testing
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                customerName[i, j] = "Test Load";
                                seatAvailable[i, j] = true;
                            }
                        }
                        break;
                    default:
                        break;
                }
            } while (option != "6");//keep showing main manue if user choose not exit
        
        }
    }
}
