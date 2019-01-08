using System;

namespace CommandPattern
{
    class Light
    {
        private readonly string name;

        public Light(string name) => this.name = name;

        public void On() => Console.WriteLine($"{name} is on");

        public void Off() => Console.WriteLine($"{name} is off");
    }

    class LightOn : ICommand
    {
        private Light light;

        public LightOn(Light light) => this.light = light;

        public void Execute() => light.On();
    }

    class LightOff : ICommand
    {
        private Light light;

        public LightOff(Light light) => this.light = light;

        public void Execute() => light.Off();
    }
}
