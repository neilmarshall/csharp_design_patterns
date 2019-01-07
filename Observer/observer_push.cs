using System;
using System.Collections.Generic;

namespace Observer_Push
{
    public interface ISubject
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    public interface IObserver
    {
        void Update(double temperature, double humidity, double pressure);
    }

    public interface IDisplayElement
    {
        void Display(); 
    }

    public class WeatherData : ISubject
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
            var temperature = GetTemperature();
            var humidity = GetHumidity();
            var pressure = GetPressure();

            foreach (var observer in observers)
                observer.Update(temperature, humidity, pressure);
        }

        private double GetTemperature() => 80.0;
        private double GetHumidity() => 0.65;
        private double GetPressure() => 10.0;
    }

    public class CurrentConditionsDisplay : IObserver, IDisplayElement
    {
        public CurrentConditionsDisplay(ISubject subject)
        {
            subject.RegisterObserver(this);
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            Console.WriteLine($"temperature={temperature:F1}F, humidity={humidity:P1}");
            Display();
        }

        public void Display() { Console.WriteLine("CurrentConditionsDisplay :: display()"); }
    }

    public class StatisticsDisplay : IObserver, IDisplayElement
    {
        public StatisticsDisplay(ISubject subject)
        {
            subject.RegisterObserver(this);
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            Console.WriteLine($"temperature={temperature:F1}F, pressure={(int)pressure:D} bars");
            Display();
        }

        public void Display() => Console.WriteLine("StatisticsDisplay :: display()");
    }

    public class ForecastDisplay : IObserver, IDisplayElement
    {
        public ForecastDisplay(ISubject subject)
        {
            subject.RegisterObserver(this);
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            Console.WriteLine($"humidity={humidity:P1}, pressure={(int)pressure:D} bars");
            Display();
        }

        public void Display() => Console.WriteLine("ForecastDisplay :: display()");
    }

    #if PUSH
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("<--- Observer :: PUSH --->");

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