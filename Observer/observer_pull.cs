using System;
using System.Collections.Generic;

namespace Observer_Pull
{
    public interface ISubject
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    public interface IObserver
    {
        void Update();
    }

    public interface IDisplayElement
    {
        void Display();
    }

    public interface ITemperatureMonitor
    {
        double GetTemperature { get; }
    }

    public interface IHumidityMonitor
    {
        double GetHumidity { get; }
    }

    public interface IPressureMonitor
    {
        double GetPressure { get; }
    }

    public class WeatherData : ISubject, ITemperatureMonitor, IHumidityMonitor, IPressureMonitor
    {
        private List<IObserver> observers;

        public WeatherData()
        {
            observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver o) => observers.Add(o);

        public void RemoveObserver(IObserver o) => observers.Remove(o);

        public void NotifyObservers()
        {
            foreach (var observer in observers)
                observer.Update();
        }

        public double GetTemperature { get => 75.0; }
        public double GetHumidity { get => 0.40; }
        public double GetPressure { get => 12.0; }
    }

    public class CurrentConditionsDisplay : IObserver, IDisplayElement
    {
        private readonly ITemperatureMonitor temperatureMonitor;
        private readonly IHumidityMonitor humidityMonitor;

        public CurrentConditionsDisplay(ISubject subject)
        {
            subject.RegisterObserver(this);
            temperatureMonitor = (ITemperatureMonitor)subject;
            humidityMonitor = (IHumidityMonitor)subject;
        }

        public void Update()
        {
            var temperature = temperatureMonitor.GetTemperature;
            var humidity = humidityMonitor.GetHumidity;
            Console.WriteLine($"temperature={temperature:F1}F, humidity={humidity:P1}");
            Display();
        }

        public void Display() { Console.WriteLine("CurrentConditionsDisplay :: display()"); }
    }

    public class StatisticsDisplay : IObserver, IDisplayElement
    {
        private readonly ITemperatureMonitor temperatureMonitor;
        private readonly IPressureMonitor pressureMonitor;

        public StatisticsDisplay(ISubject subject)
        {
            subject.RegisterObserver(this);
            temperatureMonitor = (ITemperatureMonitor)subject;
            pressureMonitor = (IPressureMonitor)subject;
        }

        public void Update()
        {
            var temperature = temperatureMonitor.GetTemperature;
            var pressure = pressureMonitor.GetPressure;
            Console.WriteLine($"temperature={temperature:F1}F, pressure={(int)pressure:D} bars");
            Display();
        }

        public void Display() => Console.WriteLine("StatisticsDisplay :: display()");
    }

    public class ForecastDisplay : IObserver, IDisplayElement
    {
        private readonly IHumidityMonitor humidityMonitor;
        private readonly IPressureMonitor pressureMonitor;

        public ForecastDisplay(ISubject subject)
        {
            subject.RegisterObserver(this);
            humidityMonitor = (IHumidityMonitor)subject;
            pressureMonitor = (IPressureMonitor)subject;
        }

        public void Update()
        {
            var humidity = humidityMonitor.GetHumidity;
            var pressure = pressureMonitor.GetPressure;
            Console.WriteLine($"humidity={humidity:P1}, pressure={(int)pressure:D} bars");
            Display();
        }

        public void Display() => Console.WriteLine("ForecastDisplay :: display()");
    }

    #if PULL
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("<--- Observer :: PULL --->");

            WeatherData weatherData = new WeatherData();

            CurrentConditionsDisplay currentConditionsDisplay = new CurrentConditionsDisplay(weatherData);
            StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherData);
            ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData);

            weatherData.NotifyObservers();

            weatherData.RemoveObserver(currentConditionsDisplay);
            weatherData.RemoveObserver(statisticsDisplay);
            weatherData.RemoveObserver(forecastDisplay);
        }
    }
    #endif
}