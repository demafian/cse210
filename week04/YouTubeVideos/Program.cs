using YouTubeVideos;

// SETUP: Creating a list to store our Video objects (Class Composition).
List<Video> videos = new List<Video>();

// CREATION: Initializing objects and adding comments via the public gateway.
Video v1 = new Video("C# Abstraction for Beginners", "TechWithTim", 600);
v1.AddComment(new Comment("User123", "Great explanation!"));
v1.AddComment(new Comment("CoderGirl", "This helped me pass my quiz."));
v1.AddComment(new Comment("DevGuy", "Can you explain Interfaces next?"));
videos.Add(v1);

Video v2 = new Video("Top 10 PC Builds 2026", "HardwareHeaven", 1200);
v2.AddComment(new Comment("GamerPro", "The RGB on the third one is insane."));
v2.AddComment(new Comment("BudgetBuilder", "Wait, $5000 is a budget build?"));
v2.AddComment(new Comment("TechSupport", "Ensure your PSU has enough wattage!"));
videos.Add(v2);

Video v3 = new Video("Homemade Sourdough Bread", "BakerBetty", 900);
v3.AddComment(new Comment("Foodie", "My crust turned out perfect!"));
v3.AddComment(new Comment("KitchenNoob", "Do I have to use a Dutch oven?"));
v3.AddComment(new Comment("BreadLover", "Nothing beats fresh bread."));
videos.Add(v3);

// OUTPUT: Using the Video class's behavior to generate the report.
Console.WriteLine("--- YouTube Product Awareness Tracking ---\n");

foreach (Video video in videos)
{
    video.DisplayVideoDetails();
}

Console.WriteLine("End of Report.");