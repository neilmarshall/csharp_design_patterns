using System;

namespace CommandPattern
{
    class Stereo
    {
        private readonly string name;

        public Stereo(string name) => this.name = name;

        public void On() => Console.WriteLine($"{name} is on");

        public void Off() => Console.WriteLine($"{name} is off");

        public void SetCD(string cd) => Console.WriteLine($"{name} -- Setting CD to {cd}");

        public void AdjustVolume(int volume) => Console.WriteLine($"{name} -- Adjusting volume to {volume}");
    }

    class StereoOn : ICommand
    {
        private Stereo stereo;

        public StereoOn(Stereo stereo) => this.stereo = stereo;

        public void Execute()
        {
            stereo.On();
            stereo.SetCD("'One Week', by Barenaked Ladies");
            stereo.AdjustVolume(11);
        }
    }

    class StereoOff : ICommand
    {
        private Stereo stereo;

        public StereoOff(Stereo stereo) => this.stereo = stereo;

        public void Execute() => stereo.Off();
    }
}
