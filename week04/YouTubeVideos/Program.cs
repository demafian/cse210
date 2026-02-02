using YouTubeVideos;

// 1. SETUP: Create a list to act as our "Database." 
// We are telling the program to prepare a shelf that will only hold Video objects.
List<Video> videos = new List<Video>();

// 2. CREATION: Building our first Video object.
// Here we call the Constructor. We pass the title, author, and length as "raw materials."
Video v1 = new Video("C# Abstraction for Beginners", "TechWithTim", 600);

// 3. INTERACTION: Linking Comments to the Video.
// We create a 'new Comment' and immediately pass it into the Video's 'AddComment' gateway.
// This demonstrates encapsulation: the Video manages its own list internally.
v1.AddComment(new Comment("User123", "Great explanation!"));
v1.AddComment(new Comment("CoderGirl", "This helped me pass my quiz."));
v1.AddComment(new Comment("DevGuy", "Can you explain Interfaces next?"));

// 4. STORAGE: Saving the completed Video object into our main list.
videos.Add(v1);

// --- (Repeated logic for Video 2 and 3) ---

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

// 5. OUTPUT: Iterating through our data to show the user.
// The outer loop picks up one Video at a time from our "videos" list.
foreach (var video in videos)
{
    // Accessing Public Properties (Title, Author, Length) directly to print them.
    Console.WriteLine($"Title: {video.Title}");
    Console.WriteLine($"Author: {video.Author}");
    Console.WriteLine($"Length: {video.Length} seconds");

    // We ask the video for its "Comment Count" via a Method instead of looking at the list directly.
    Console.WriteLine($"Comments ({video.GetCommentCount()}):");

    // 6. NESTED LOOP: Drilling down into the internal data.
    // We ask the 'video' to provide its list of comments, then we loop through that sub-list.
    foreach (var comment in video.GetComments())
    {
        // For every comment found, we print the Name and Text properties.
        Console.WriteLine($"- {comment.Name}: {comment.Text}");
    }

    // A simple visual break to separate the videos in the console output.
    Console.WriteLine(new string('-', 40));
}