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
                }
                else
                {
                    Console.WriteLine("Number of bags");
                }


                try
                {
                    double value = double.Parse(Console.ReadLine());
                    return value;
                }
                catch (Exception err)
                {
                    Console.WriteLine("Invalid choice " + err.Message);
                    continue;
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
            double milkBag = 0;
            double storeBagsCost = 0;
            int storeBagsAmount = 0;



            String choice = "";
            bool keepRunning = true;
            MyChoices choices = new MyChoices();
            Welcome();

            do
            {
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

                if (choice == "done")
                {
                    Console.Clear();
                    Console.WriteLine("Do you have a scene card?");
                    string sceneCard = Console.ReadLine();

                    while (sceneCard != "yes" && sceneCard != "no")
                    {
                        Console.WriteLine("Invalid choice");
                        Console.WriteLine("Do you have a scene card?");
                        sceneCard = Console.ReadLine();
                    }

                    if (sceneCard == "yes")
                    {
                        subtotalChillies = 90 * (totalChillies* chillies) / 100;
                        subtotalTomatoes = 90 * (totalTomatoes* tomatoes) / 100;
                        subtotalApples = 90 * (totalApples* apples) / 100;
                        subtotalMilk = totalMilk* (milk-0.54);
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

                    Console.WriteLine("Do you want to buy bags?");
                    string bags = Console.ReadLine();

                    while (bags != "yes" && bags != "no")
                    {
                        Console.WriteLine("Invalid choice");
                        Console.WriteLine("Do you want to buy bags?");
                        bags = Console.ReadLine();
                    }

                    if (bags == "yes")
                    {
                        Console.WriteLine("How many bags do you want?");
                        storeBagsAmount = int.Parse(Console.ReadLine());
                        storeBagsCost = storeBagsAmount * 0.50;
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
                    }  Console.WriteLine("");
                    if (totalTomatoes > 0)
                    {
                        Console.WriteLine(MyChoices.Tomatoes);
                        Console.WriteLine("$" + subtotalMilk);
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
                    Console.WriteLine("HST Amount $" + subtotal * 0.13);
                    Console.WriteLine("");
                    Console.WriteLine("Grand Total $" + (subtotal * 0.13 + subtotal));
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
                                break;
                            case MyChoices.Tomatoes:
                                Console.WriteLine("You chose " + MyChoices.Tomatoes.ToString() + " " + tomatoes + "$ per lb");
                                totalTomatoes += ValidateWeightOrBag(true);
                                break;
                            case MyChoices.Apples:
                                Console.WriteLine("You chose " + MyChoices.Apples.ToString() + " " + apples + "$ per lb");
                                totalApples += ValidateWeightOrBag(true);
                                break;
                            case MyChoices.MilkBags:
                                Console.WriteLine("You chose " + MyChoices.MilkBags.ToString() + " " + milk + "$ per bag");
                                totalMilk += ValidateWeightOrBag(false);
                                break;
                            default:
                                break;
                        }
                    }

                }


            } while (keepRunning);

        }
    }
}
