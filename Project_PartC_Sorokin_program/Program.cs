using Project_partB_Sorokin_program;
using System;
using static System.Formats.Asn1.AsnWriter;
class Program
{
    static void Main(string[] args)
    {
        Necklace necklace = new Necklace();
        bool running = true;

        // Підписка на події
        necklace.StoneAdded += (sender, stone) => Console.WriteLine($"Added: {stone.GetDetails()}");
        necklace.StoneRemoved += (sender, stone) => Console.WriteLine($"Removed: {stone.GetDetails()}");


        while (running)
        {
            Console.WriteLine("\n*** Gemstone Necklace Management ***");
            Console.WriteLine("1. Add a Gemstone");
            Console.WriteLine("2. Remove a Gemstone");
            Console.WriteLine("3. Display Necklace Details");
            Console.WriteLine("4. Sort Stones by Value");
            Console.WriteLine("5. Find Stones by Color");
            Console.WriteLine("6. Display Total Value of Stones");
            Console.WriteLine("7. Execute Action for Each Stone");
            Console.WriteLine("8. Filter Stones by Weigh");
            Console.WriteLine("9. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());


            switch (choice)
            {
                case 1:

                    //Console.Write("Enter gemstone type (1 for Precious, 2 for SemiPrecious): ");
                    //int stoneType = Convert.ToInt32(Console.ReadLine());

                    int stoneType;
                    bool isValidType;
                    do
                    {
                        Console.Write("Enter gemstone type (1 for Precious, 2 for SemiPrecious): ");
                        isValidType = int.TryParse(Console.ReadLine(), out stoneType) && (stoneType == 1 || stoneType == 2);
                        if (!isValidType)
                        {
                            Console.WriteLine("Invalid type, please enter 1 for Precious or 2 for SemiPrecious.");
                        }
                    } while (!isValidType);

                    //Console.Write("Enter gemstone weight (in carats): ");
                    //double weight = Convert.ToDouble(Console.ReadLine());

                    double weight;
                    bool isValidWeight;
                    do
                    {
                        Console.Write("Enter gemstone weight (in carats): ");
                        isValidWeight = double.TryParse(Console.ReadLine(), out weight) && weight > 0;
                        if (!isValidWeight)
                        {
                            Console.WriteLine("Invalid weight, please enter a positive number.");
                        }
                    } while (!isValidWeight);

                    //Console.Write("Enter gemstone price: ");
                    //decimal price = Convert.ToDecimal(Console.ReadLine());

                    decimal price;
                    bool isValidPrice;
                    do
                    {
                        Console.Write("Enter gemstone price: ");
                        isValidPrice = decimal.TryParse(Console.ReadLine(), out price) && price > 0;

                        if (!isValidPrice)
                        {
                            Console.WriteLine("Invalid price, please enter a positive number.");
                        }
                    } while (!isValidPrice);


                    //Console.Write("Enter gemstone color: ");
                    //string color = Console.ReadLine();
                    string color;
                    bool isValidColor;
                    do
                    {
                        Console.Write("Enter gemstone color: ");
                        color = Console.ReadLine();
                        isValidColor = !string.IsNullOrWhiteSpace(color) && color.All(char.IsLetter);

                        if (!isValidColor)
                        {
                            Console.WriteLine("Invalid color, please enter a valid color name (without numbers).");
                        }
                    } while (!isValidColor);

                    if (stoneType == 1)
                    {
                        Console.WriteLine("Select the type of precious gemstone:");
                        foreach (var name in Enum.GetNames(typeof(PreciousGemstoneName)))
                        {
                            Console.WriteLine(name);
                        }
                        PreciousGemstoneName gemstoneName = (PreciousGemstoneName)Enum.Parse(typeof(PreciousGemstoneName), Console.ReadLine());


                        //Console.Write("Enter gemstone clarity (1-10): ");
                        //int clarity = Convert.ToInt32(Console.ReadLine());


                        //    PreciousStone preciousStone = new PreciousStone(gemstoneName, weight, price, color, clarity);
                        //    necklace.AddStone(preciousStone);

                        int clarity;
                        do
                        {
                            Console.Write("Enter gemstone clarity (1-10): ");
                            clarity = Convert.ToInt32(Console.ReadLine());
                        } while (clarity < 1 || clarity > 10);

                        PreciousStone preciousStone = new PreciousStone(gemstoneName, weight, price, color, clarity);
                        necklace.AddStone(preciousStone);
                    }
                    else if (stoneType == 2)
                    {
                        Console.WriteLine("Select the type of semiprecious gemstone:");
                        foreach (var name in Enum.GetNames(typeof(SemiPreciousGemstoneName)))
                        {
                            Console.WriteLine(name);
                        }
                        SemiPreciousGemstoneName gemstoneName = (SemiPreciousGemstoneName)Enum.Parse(typeof(SemiPreciousGemstoneName), Console.ReadLine());

                        //Console.Write("Enter gemstone hardness (1-10): ");
                        //int hardness = Convert.ToInt32(Console.ReadLine());

                        //SemiPreciousStone semiPreciousStone = new SemiPreciousStone(gemstoneName, weight, price, color, hardness);
                        //necklace.AddStone(semiPreciousStone);

                        int hardness;
                        do
                        {
                            Console.Write("Enter gemstone hardness (1-10): ");
                            hardness = Convert.ToInt32(Console.ReadLine());
                        } while (hardness < 1 || hardness > 10);

                        SemiPreciousStone semiPreciousStone = new SemiPreciousStone(gemstoneName, weight, price, color, hardness);
                        necklace.AddStone(semiPreciousStone);
                    }
                    else
                    {
                        Console.WriteLine("Invalid gemstone type.");
                    }

                    break;
                case 2:
                    Console.Write("Enter the name of the gemstone to remove: ");
                    string nameToRemove = Console.ReadLine();

                    bool isRemoved = RemoveGemstone(necklace, nameToRemove);
                    if (isRemoved)
                    {
                        Console.WriteLine($"Gemstone '{nameToRemove}' was removed from the necklace.");
                    }
                    else
                    {
                        Console.WriteLine($"Gemstone '{nameToRemove}' not found in the necklace.");
                    }
                    break;
                case 3:
                    Console.WriteLine(necklace.ToString());
                    break;
                case 4:
                    necklace.SortByValue();
                    Console.WriteLine("Necklace sorted by value.");
                    break;
                case 5:
                    Console.Write("Enter the color of gemstones to find: ");
                    string colorToFind = Console.ReadLine();

                    var foundStones = FindStonesByColor(necklace, colorToFind);
                    if (foundStones.Any())
                    {
                        Console.WriteLine($"Found the following gemstones with color {colorToFind}:");
                        foreach (var stone in foundStones)
                        {
                            Console.WriteLine(stone.GetDetails());
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No gemstones found with color {colorToFind}.");
                    }
                    break;
                case 6:
                    // Вивід загальної вартості каменів у намисті
                    decimal totalValue = necklace.AggregateValues(stone => stone.GetValue());
                    Console.WriteLine($"Total value of all stones: {totalValue}");
                    break;
                case 7:
                    Console.Write("Enter the name of the stone type to display details for all matching stones: ");
                    string stoneTypeName = Console.ReadLine();
                    var stonesToDisplay = necklace.GetStones().Where(stone => stone.GetName().Equals(stoneTypeName, StringComparison.OrdinalIgnoreCase)).ToList();

                    if (stonesToDisplay.Any())
                    {
                        Action<IGemstone> displayAction = stone => Console.WriteLine(stone.GetDetails());
                        stonesToDisplay.ForEach(displayAction);
                    }
                    else
                    {
                        Console.WriteLine("No stones of this type were found.");
                    }
                    break;
                case 8:
                    Console.Write("Enter minimum weight for stones to find: ");
                    double minWeight = Convert.ToDouble(Console.ReadLine());
                    var heavyStones = necklace.FilterStones(stone => stone.GetWeight() >= minWeight);
                    foreach (var stone in heavyStones)
                    {
                        Console.WriteLine(stone.GetDetails());
                    }
                    break;
                case 9:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }


    private static void AddGemstone(Necklace necklace, int stoneType, string name, double weight, decimal price, string color, int additionalProperty)
    {
        if (stoneType == 1)
        {
            PreciousStone preciousStone = new PreciousStone((PreciousGemstoneName)Enum.Parse(typeof(PreciousGemstoneName), name), weight, price, color, additionalProperty);
            necklace.AddStone(preciousStone);
        }
        else if (stoneType == 2)
        {
            SemiPreciousStone semiPreciousStone = new SemiPreciousStone((SemiPreciousGemstoneName)Enum.Parse(typeof(SemiPreciousGemstoneName), name), weight, price, color, additionalProperty);
            necklace.AddStone(semiPreciousStone);
        }
    }


    private static bool RemoveGemstone(Necklace necklace, string name)
    {
        IGemstone stoneToRemove = necklace.GetStones().FirstOrDefault(stone => stone.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));

        if (stoneToRemove != null)
        {
            necklace.RemoveStone(stoneToRemove);
            return true;
        }
        else
        {
            return false;
        }
    }


    private static List<IGemstone> FindStonesByColor(Necklace necklace, string color)
    {
        return necklace.FindStonesByColor(color);
    }
}



