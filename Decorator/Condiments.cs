namespace StarbuzzCoffee
{
    public abstract class CondimentDescriptor : Beverage
    {
        public override abstract string Description { get; }
    }


    public class Milk : CondimentDescriptor
    {
        private Beverage beverage;

        public Milk(Beverage beverage) { this.beverage = beverage; }

        public override double Cost() => 0.10 + beverage.Cost();

        public override string Description { get => beverage.Description + ", Milk"; }
    }


    public class Mocha : CondimentDescriptor
    {
        private Beverage beverage;

        public Mocha(Beverage beverage) { this.beverage = beverage; }

        public override double Cost() => 0.20 + beverage.Cost();

        public override string Description { get => beverage.Description + ", Mocha"; }
    }


    public class Soy : CondimentDescriptor
    {
        private Beverage beverage;

        public Soy(Beverage beverage) { this.beverage = beverage; }

        public override double Cost() => 0.15 + beverage.Cost();

        public override string Description { get => beverage.Description + ", Soy"; }
    }


    public class Whip : CondimentDescriptor
    {
        private Beverage beverage;

        public Whip(Beverage beverage) { this.beverage = beverage; }

        public override double Cost() => 0.10 + beverage.Cost();

        public override string Description { get => beverage.Description + ", Whip"; }
    }
}