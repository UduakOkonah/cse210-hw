// EXCEEDING REQUIREMENT: Added calorie calculation for each activity to enhance tracking.
// The GetSummary method now includes calories burned in the output for each activity.

using System;
using System.Collections.Generic;

namespace FitnessApp
{
    
    // Base class for all activities
    public abstract class Activity
    {
        private DateTime date;
        private int minutes;

        public Activity(DateTime date, int minutes)
        {
            this.date = date;
            this.minutes = minutes;
        }

        // Properties
        public DateTime Date => date;
        public int Minutes => minutes;

        // Virtual methods for derived classes to override
        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();
        
        // New abstract method for calorie calculation
        public abstract double GetCaloriesBurned();

        // Summary method, may use methods defined in derived classes
        public string GetSummary()
        {
            return $"{Date.ToString("dd MMM yyyy")} {GetType().Name} ({Minutes} min): Distance {GetDistance():0.0} km, " +
                   $"Speed {GetSpeed():0.0} kph, Pace {GetPace():0.0} min per km, Calories Burned: {GetCaloriesBurned():0.0} kcal";
        }
    }

    // Derived class for Running activity
    public class Running : Activity
    {
        private double distance;

        public Running(DateTime date, int minutes, double distance) : base(date, minutes)
        {
            this.distance = distance;
        }

        public override double GetDistance()
        {
            return distance;
        }

        public override double GetSpeed()
        {
            return (distance / Minutes) * 60;
        }

        public override double GetPace()
        {
            return Minutes / distance;
        }

        // Extra: Calorie calculation for running
        public override double GetCaloriesBurned()
        {
            return Minutes * 11.4;  // Approximate calories burned per minute for running
        }
    }

    // Derived class for Cycling activity
    public class Cycling : Activity
    {
        private double speed;

        public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
        {
            this.speed = speed;
        }

        public override double GetDistance()
        {
            return (speed * Minutes) / 60;
        }

        public override double GetSpeed()
        {
            return speed;
        }

        public override double GetPace()
        {
            return 60 / speed;
        }

        // Extra: Calorie calculation for cycling
        public override double GetCaloriesBurned()
        {
            return Minutes * 8.5;  // Approximate calories burned per minute for cycling
        }
    }

    // Derived class for Swimming activity
    public class Swimming : Activity
    {
        private int laps;

        public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
        {
            this.laps = laps;
        }

        public override double GetDistance()
        {
            return laps * 50 / 1000.0;
        }

        public override double GetSpeed()
        {
            return (GetDistance() / Minutes) * 60;
        }

        public override double GetPace()
        {
            return Minutes / GetDistance();
        }

        // Extra: Calorie calculation for swimming
        public override double GetCaloriesBurned()
        {
            return Minutes * 7.0;  // Approximate calories burned per minute for swimming
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creating instances of each activity type
            var running = new Running(new DateTime(2022, 11, 3), 30, 4.8);
            var cycling = new Cycling(new DateTime(2022, 11, 3), 45, 18.0);
            var swimming = new Swimming(new DateTime(2022, 11, 3), 20, 30);

            // List of activities
            List<Activity> activities = new List<Activity> { running, cycling, swimming };

            // Display summaries for each activity
            foreach (var activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}