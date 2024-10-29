// Excedding requirement: This program implements a series of activities to promote relaxation, reflection, and positive thinking.
// It includes Breathing, Listing, and Reflection activities, each with a unique prompt and guided process.
using System;
using System.Collections.Generic;
using System.Threading;


public class Program
{
    public static void Main(string[] args)
    {
        // Example of running the activities.
        // You can adjust the flow as needed.

        BreathingActivity breathing = new BreathingActivity();
        breathing.SetDuration(30); // Set duration in seconds
        breathing.PerformActivity();

        ListingActivity listing = new ListingActivity();
        listing.SetDuration(30); // Set duration in seconds
        listing.PerformActivity();

        ReflectionActivity reflection = new ReflectionActivity();
        reflection.SetDuration(30); // Set duration in seconds
        reflection.PerformActivity();
    }
}

// Base Activity class
public class Activity
{
    protected string _activityName;
    protected string _description;
    protected int _duration;

    public void SetActivityName(string name)
    {
        _activityName = name;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public virtual void PerformActivity()
    {
        // This method will be overridden by the derived classes.
    }

    public void ShowStartingMessage()
    {
        Console.WriteLine($"\nStarting {_activityName}");
        Console.WriteLine(_description);
        Console.WriteLine($"Duration: {_duration} seconds");
    }

    public void ShowEndingMessage()
    {
        Console.WriteLine($"\nYou have completed the {_activityName}. Well done!");
    }

    // Show a spinner to indicate time passing (simple loading effect)
    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/"); 
            Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("-"); 
            Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("\\"); 
            Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("|"); 
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }
}

// Breathing Activity class
public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        SetActivityName("Breathing Activity");
        SetDescription("This activity will help you relax by guiding you through slow breathing.");
    }

    public override void PerformActivity()
    {
        // Show starting message
        ShowStartingMessage();

        // Perform breathing exercises for the specified duration
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("\nBreathe in...");
            ShowSpinner(4); // Breathe in for 4 seconds

            Console.WriteLine("Breathe out...");
            ShowSpinner(4); // Breathe out for 4 seconds
        }

        // Show ending message
        ShowEndingMessage();
    }
}

// Listing Activity class
public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        SetActivityName("Listing Activity");
        SetDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
    }

    public override void PerformActivity()
    {
        // Show starting message
        ShowStartingMessage();

        // Select a random prompt from the list
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.WriteLine("You have a few seconds to start thinking...");

        // Delay before starting to allow the user to prepare
        ShowSpinner(5);

        // Start the user input phase
        Console.WriteLine("\nStart listing as many things as you can:");
        List<string> userResponses = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string response = Console.ReadLine();
            if (!string.IsNullOrEmpty(response))
            {
                userResponses.Add(response);
            }
        }

        // Display how many items they listed
        Console.WriteLine($"\nYou listed {userResponses.Count} items.");

        // Show ending message
        ShowEndingMessage();
    }
}

// Reflection Activity class
public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        SetActivityName("Listing Activity");
        SetDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
    }

    public override void PerformActivity()
    {
        // Show starting message
        ShowStartingMessage();

        // Select a random prompt from the list
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.WriteLine("You have a few seconds to start thinking...");

        // Delay before starting to allow the user to prepare
        ShowSpinner(5);

        // Start the user input phase
        Console.WriteLine("\nStart listing as many things as you can:");
        List<string> userResponses = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            // Read user input and store responses
            string response = Console.ReadLine();
            if (!string.IsNullOrEmpty(response))
            {
                userResponses.Add(response);
            }
        }

        // Display how many items they listed
        Console.WriteLine($"\nYou listed {userResponses.Count} items.");

        // Show ending message
        ShowEndingMessage();
    }
}

}