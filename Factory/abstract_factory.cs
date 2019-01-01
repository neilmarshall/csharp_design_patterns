using System;

namespace GangOfFour.Creational
{
    public interface IVegPizza
    {
        void Prepare();
    }

    public interface INonVegPizza
    {
        void Serve();
    }

    public class DeluxeVeggiePizza : IVegPizza
    {
        public void Prepare()
        {
            Console.WriteLine("Preparing DeluxeVeggiePizza");
        }
    }

    public class ChickenPizza : INonVegPizza
    {
        public void Serve()
        {
            Console.WriteLine("ChickenPizza is served with Chicken on DeluxeVeggiePizza");
        }
    }

    public class MexicanVegPizza : IVegPizza
    {
        public void Prepare()
        {
            Console.WriteLine("Preparing MexicanVegPizza");
        }
    }

    public class HamPizza : INonVegPizza
    {
        public void Serve()
        {
            Console.WriteLine("HamPizza is served with Chicken on MexicanVegPizza");
        }
    }

    public interface IPizzaFactory
    {
        IVegPizza CreateVegPizza();
        INonVegPizza CreateNonVegPizza();
    }

    public class IndianPizzaFactory : IPizzaFactory
    {
        public IVegPizza CreateVegPizza() => new DeluxeVeggiePizza();

        public INonVegPizza CreateNonVegPizza() => new ChickenPizza();
    }

    public class USPizzaFactory : IPizzaFactory
    {
        public IVegPizza CreateVegPizza() => new MexicanVegPizza();

        public INonVegPizza CreateNonVegPizza() => new HamPizza();
    }

    public static class PizzaStore
    {
        public static void MakePizza()
        {
            IPizzaFactory indian_pizza_factory = new IndianPizzaFactory();
            IPizzaFactory us_pizza_factory = new USPizzaFactory();
            IPizzaFactory[] factories = { indian_pizza_factory, us_pizza_factory };
            foreach (IPizzaFactory factory in factories)
            {
                IVegPizza veg_pizza = factory.CreateVegPizza();
                veg_pizza.Prepare();
                INonVegPizza non_veg_pizza = factory.CreateNonVegPizza();
                non_veg_pizza.Serve();
            }
        }
    }

    #if (FACTORY == false) && (ABSTRACT_FACTORY == true)
    class MainProgram
    {
        static void Main(string[] args)
        {
            PizzaStore.MakePizza();
        }
    }
    #endif
}