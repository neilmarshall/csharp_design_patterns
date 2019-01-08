namespace StarbuzzCoffee
{
    public abstract class Beverage
    {
        public virtual string Description { get; protected set; }

        public abstract double Cost();
    }


    public class HouseBlend : Beverage
    {
        public HouseBlend() { Description = "House Blend"; }

        public override double Cost() => 0.89;
    }


    public class DarkRoast : Beverage
    {
        public DarkRoast() { Description = "Dark Roast"; }

        public override double Cost() => 0.99;
    }


    public class Decaf : Beverage
    {
        public Decaf() { Description = "Decaf"; }

        public override double Cost() => 1.05;
    }


    public class Espresso : Beverage
    {
        public Espresso() { Description = "Espresso"; }

        public override double Cost() => 1.99;
    }
}