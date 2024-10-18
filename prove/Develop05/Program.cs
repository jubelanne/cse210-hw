using System;
using System.Threading;

// Base class for all activities
class Activity {
    protected string name, description;
    protected int duration;

    public Activity(string name, string description) {
        this.name = name;
        this.description = description;
    }

    public void Start() {
        Console.WriteLine($"{name}: {description}");
        Console.Write("Enter duration (in seconds): ");
        // Validate duration input
        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0) {
            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }
        Console.WriteLine("Prepare to begin...");
        PauseWithAnimation(3);
    }

    public void End() {
        Console.WriteLine($"Well done! You've completed the {name} for {duration} seconds.");
        PauseWithAnimation(3);
    }

    protected void PauseWithAnimation(int seconds) {
        for (int i = 0; i < seconds; i++) {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

// Derived class for Breathing Activity
class BreathingActivity : Activity {
    public BreathingActivity() : base("Breathing Activity", "Relax by breathing in and out slowly.") { }

    public void Perform() {
        Start();
        for (int i = 0; i < duration / 4; i++) {
            Console.WriteLine("Breathe in...");
            PauseWithAnimation(2);
            Console.WriteLine("Breathe out...");
            PauseWithAnimation(2);
        }
        End();
    }
}

// Derived class for Reflection Activity
class ReflectionActivity : Activity {
    string[] prompts = { "Think of a time you stood up for someone.", "Think of a time you did something difficult." };
    string[] questions = { "Why was this meaningful?", "What did you learn from it?" };

    public ReflectionActivity() : base("Reflection Activity", "Reflect on times of strength and resilience.") { }

    public void Perform() {
        Start();
        Random rand = new Random();
        Console.WriteLine(prompts[rand.Next(prompts.Length)]);
        for (int i = 0; i < duration / 5; i++) {
            Console.WriteLine(questions[rand.Next(questions.Length)]);
            PauseWithAnimation(5);
        }
        End();
    }
}

// Derived class for Listing Activity
class ListingActivity : Activity {
    string[] prompts = { "List people you appreciate.", "List your personal strengths." };

    public ListingActivity() : base("Listing Activity", "List as many positive things as possible.") { }

    public void Perform() {
        Start();
        Random rand = new Random();
        Console.WriteLine(prompts[rand.Next(prompts.Length)]);
        int count = 0;
        DateTime end = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < end) {
            Console.Write("Enter an item: ");
            Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You listed {count} items!");
        End();
    }
}

// Main program class
class Program {
    static void Main(string[] args) {
        while (true) {
            Console.WriteLine("Choose an activity:\n1. Breathing\n2. Reflection\n3. Listing\n4. Quit");
            string choice = Console.ReadLine();
            
            // Ensure valid input
            Activity activity = choice switch {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                _ => null
            };

            if (activity == null && choice == "4") {
                Console.WriteLine("Goodbye!");
                break;
            } else if (activity != null) {
                activity.Perform();
            } else {
                Console.WriteLine("Invalid option. Please select again.");
            }
        }
    }
}
