using System;
using StarbuzzCoffee;

class Program
{
    private static void PrintBeverage(Beverage beverage)
    {
        Console.WriteLine(beverage.Description + ": £" + $"{beverage.Cost():F2}");
    }


    private static void PrintParsedBeverage(Beverage beverage)
    {
        string decription = OrderParser.parse(beverage.Description);
        Console.WriteLine(decription + ": £" + $"{beverage.Cost():F2}");
    }


    public static void Main(string[] argv)
    {
        Beverage beverage1 = new Espresso();
        PrintBeverage(beverage1);
        PrintParsedBeverage(beverage1);

        Beverage beverage2 = new DarkRoast();
        beverage2 = new Mocha(beverage2);
        beverage2 = new Mocha(beverage2);
        beverage2 = new Whip(beverage2);
        PrintBeverage(beverage2);
        PrintParsedBeverage(beverage2);

        Beverage beverage3 = new HouseBlend();
        beverage3 = new Soy(beverage3);
        beverage3 = new Mocha(beverage3);
        beverage3 = new Whip(beverage3);
        beverage3 = new Soy(beverage3);
        PrintBeverage(beverage3);
        PrintParsedBeverage(beverage3);

        Beverage beverage4 = new Milk(new Decaf());
        PrintBeverage(beverage4);
        PrintParsedBeverage(beverage4);

        Beverage beverage5 = new HouseBlend();
        beverage5 = new Milk(beverage5);
        beverage5 = new Milk(beverage5);
        beverage5 = new Milk(beverage5);
        PrintBeverage(beverage5);
        PrintParsedBeverage(beverage5);
    }
}
