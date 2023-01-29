using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Part 1 
namespace Assignment1
{
    internal class Program
    {
        enum MyChoices
        {
            Chillies,
            Tomatoes,
            Apples,
            MilkBags
        }

        static void Menu()
        {
            var values = Enum.GetValues(typeof(MyChoices));


            foreach (MyChoices choice2 in values)
            {

                Console.WriteLine("Enter {0} ", choice2, "to add");

            }
            Console.WriteLine("");
            Console.WriteLine("Enter Done to see the final value");
            Console.WriteLine("");
            Console.WriteLine("Enter your choice");
        }

        static void Welcome()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("   Welcome to the store");
            Console.WriteLine("We have the following items");
            Console.WriteLine("-----------------------------");
        }

        static double ValidateWeightOrBag(Boolean isWeight)
        {

            while (true)
            {
                if (isWeight)
                {
                    Console.WriteLine("Insert weight");
                    try
                    {
                        double value = double.Parse(Console.ReadLine());
                        if (value <= 0)
                        {
                            Console.WriteLine("Invalid choice insert a positive number");
                            continue;
                        }
                        else
                        {
                            return value;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid choice insert a number");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Number of bags");
                    try
                    {
                        int value = int.Parse(Console.ReadLine());
                        if (value <= 0)
                        {
                            Console.WriteLine("Invalid choice insert a positive number");
                            continue;
                        }
                        else
                        {
                            return value;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid choice insert an integer");
                        continue;
                    }

                }



            }

        }


        static void Main(string[] args)
        {
            double chillies = 1.29;
            double tomatoes = 1.45;
            double apples = 1.75;
            double milk = 6.54;
            double subtotal = 0;
            double subtotalChillies = 0;
            double subtotalTomatoes = 0;
            double subtotalApples = 0;
            double subtotalMilk = 0;

            double totalChillies = 0;
            double totalTomatoes = 0;
            double totalApples = 0;
            double totalMilk = 0;
            double totalSceneCardPoint = 0;
            double storeBagsCost = 0;
            double storeBagsValue = 0.50;
            double hstTax = 0.13;




            String choice;
            bool keepRunning;
            MyChoices choices = new MyChoices();


            do
            {
                Welcome();
                Menu();
                try
                {
                    choice = Console.ReadLine();
                    keepRunning = false;
                }
                catch (Exception err)
                {
                    Console.WriteLine("Invalid choice {0}", err.Message);
                    keepRunning = true;
                    continue;
                }

                if (choice == "done" && totalChillies == 0 && totalTomatoes == 0 && totalApples == 0 && totalMilk == 0)
                {
                    Console.Clear();
                    Console.WriteLine("!!! You have not selected any item !!!");
                    Console.WriteLine("");
                    keepRunning = true;
                } else
                {
                    if (choice == "done")
                    {
                        Console.Clear();
                        Console.WriteLine("Do you have a scene card? (yes/no)");
                        string sceneCard = Console.ReadLine();

                        while (sceneCard != "yes" && sceneCard != "no")
                        {
                            Console.WriteLine("Invalid choice");
                            Console.WriteLine("Do you have a scene card? (yes/no)");
                            sceneCard = Console.ReadLine();
                        }

                        if (sceneCard == "yes")
                        {
                            subtotalChillies = 90 * (totalChillies * chillies) / 100;
                            subtotalTomatoes = 90 * (totalTomatoes * tomatoes) / 100;
                            subtotalApples = 90 * (totalApples * apples) / 100;
                            subtotalMilk = totalMilk * (milk - 0.54);
                            totalSceneCardPoint = (totalChillies + totalTomatoes + totalApples) * 20;
                            subtotal = subtotalChillies + subtotalTomatoes + subtotalApples + subtotalMilk;
                        }
                        else if (sceneCard == "no")
                        {
                            subtotalChillies += totalChillies * chillies;
                            subtotalTomatoes += totalTomatoes * tomatoes;
                            subtotalApples += totalApples * apples;
                            subtotalMilk += totalMilk * milk;
                            subtotal = subtotalChillies + subtotalTomatoes + subtotalApples + subtotalMilk;
                        }

                        Console.WriteLine("Do you want to buy bags? (yes/no)");
                        string bags = Console.ReadLine();

                        while (bags != "yes" && bags != "no")
                        {
                            Console.WriteLine("Invalid choice");
                            Console.WriteLine("Do you want to buy bags? (yes/no)");
                            bags = Console.ReadLine();
                        }

                        if (bags == "yes")
                        {
                            Console.WriteLine("How many bags do you want?");
                            int storeBagsAmount = int.Parse(Console.ReadLine());
                            storeBagsCost = storeBagsAmount * storeBagsValue;
                            subtotal += storeBagsCost;
                        }


                        Console.Clear();

                        if (totalMilk > 0)
                        {
                            Console.WriteLine(MyChoices.MilkBags);
                            Console.WriteLine("$" + subtotalMilk);
                            Console.WriteLine("");
                        }
                        if (totalChillies > 0)
                        {
                            Console.WriteLine(MyChoices.Chillies);
                            Console.WriteLine("$" + subtotalChillies);
                            Console.WriteLine("");
                        }
                        Console.WriteLine("");
                        if (totalTomatoes > 0)
                        {
                            Console.WriteLine(MyChoices.Tomatoes);
                            Console.WriteLine("$" + subtotalTomatoes);
                            Console.WriteLine("");
                        }
                        if (totalApples > 0)
                        {
                            Console.WriteLine(MyChoices.Apples);
                            Console.WriteLine("$" + subtotalApples);
                            Console.WriteLine("");
                        }
                        Console.WriteLine("----------------");

                        Console.WriteLine("");
                        Console.WriteLine("Store Bags Cost $" + storeBagsCost);
                        Console.WriteLine("");
                        Console.WriteLine("Subtotal Price $" + subtotal);
                        Console.WriteLine("HST Amount $" + (subtotal * hstTax).ToString("N2"));
                        Console.WriteLine("");
                        Console.WriteLine("Grand Total $" + (subtotal * hstTax + subtotal).ToString("N2"));
                        Console.WriteLine("Total Scene Points Earnerd " + totalSceneCardPoint);
                        keepRunning = false;
                    }


                    else
                    {


                        bool next = true;

                        switch (choice.ToLower())
                        {
                            case "chillies":
                            case "chillie":
                                choices = MyChoices.Chillies;
                                break;
                            case "tomatoes":
                            case "tomatoe":
                                choices = MyChoices.Tomatoes;
                                break;
                            case "apples":
                            case "apple":
                                choices = MyChoices.Apples;
                                break;
                            case "milkbags":
                            case "milk":
                                choices = MyChoices.MilkBags;
                                break;
                            default:
                                next = false;
                                keepRunning = true;
                                Console.Clear();
                                Console.WriteLine("invalid choice");
                                break;
                        }


                        if (next)
                        {
                            keepRunning = true;
                            switch (choices)
                            {
                                case MyChoices.Chillies:
                                    Console.WriteLine("You chose " + MyChoices.Chillies.ToString() + " " + chillies + "$ per lb");
                                    totalChillies += ValidateWeightOrBag(true);
                                    Console.Clear();
                                    Console.WriteLine("You last chose is " + MyChoices.Chillies.ToString());
                                    break;
                                case MyChoices.Tomatoes:
                                    Console.WriteLine("You chose " + MyChoices.Tomatoes.ToString() + " " + tomatoes + "$ per lb");
                                    totalTomatoes += ValidateWeightOrBag(true);
                                    Console.Clear();
                                    Console.WriteLine("You last chose is " + MyChoices.Tomatoes.ToString());
                                    break;
                                case MyChoices.Apples:
                                    Console.WriteLine("You chose " + MyChoices.Apples.ToString() + " " + apples + "$ per lb");
                                    totalApples += ValidateWeightOrBag(true);
                                    Console.Clear();
                                    Console.WriteLine("You last chose is " + MyChoices.Apples.ToString());
                                    break;
                                case MyChoices.MilkBags:
                                    Console.WriteLine("You chose " + MyChoices.MilkBags.ToString() + " " + milk + "$ per bag");
                                    totalMilk += ValidateWeightOrBag(false);
                                    Console.Clear();
                                    Console.WriteLine("You last chose is " + MyChoices.MilkBags.ToString());
                                    break;
                                default:
                                    break;
                            }
                        }

                    }
                }





            } while (keepRunning);

        }
    }
}
