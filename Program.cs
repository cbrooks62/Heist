//Print the message "Plan Your Heist!".
using System.Data;

Console.WriteLine("*-*-*-*-*-*-*-*-*");
Console.WriteLine(" Plan your Heist!");
Console.WriteLine("*-*-*-*-*-*-*-*-*");
Console.WriteLine("");

// Prompt the user to enter the difficulty level of the bank
Console.Write("Enter the difficulty level of the bank: ");
int bankDifficultyLevel = int.Parse(Console.ReadLine());

//Create a way to store a single team member. A team member will have a name, a skill Level and a courage factor. The skill Level will be a positive integer and the courage factor will be a decimal between 0.0 and 2.0.
List<TeamMember> teamMembers = new List<TeamMember>();

while (true)
{
    // public TeamMember(string name, int skillLevel, double courageFactor)
    Console.WriteLine("Enter team member's name (leave blank if finished with team): ");
    string Name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(Name))
    {
        break;
    }
    //Prompt the user to enter a team member's skill level and save that skill level with the name.
    Console.Write("Enter the team member's skill level (use a positive integer): ");
    int SkillLevel = int.Parse(Console.ReadLine());
    //Prompt the user to enter a team member's courage factor and save that courage factor with the name.
    Console.Write("Enter the team member's courage factor (a decimal between 0.0 and 2.0): ");
    double CourageFactor = double.Parse(Console.ReadLine());

    // Create a new team member and add it to the list
    TeamMember teamMember = new TeamMember(Name, SkillLevel, CourageFactor);
    teamMembers.Add(teamMember);

    //Display the team member's information.
    // Console.WriteLine($"Team Member: {Name}. Their skill level is {SkillLevel} with a courage factor of {CourageFactor}.");

};
//Display a message containing the number of members of the team.
Console.WriteLine($"Number of team members: {teamMembers.Count}");


Random random = new Random();
int totalTeamSkillLevel = 0;

//Sum the skill levels of the team. Save that number.
foreach (TeamMember teamMember in teamMembers)
{
    totalTeamSkillLevel += teamMember.SkillLevel;
}

//After the user enters the team information, prompt them to enter the number of trial runs the program should perform.
Console.Write("Enter the number of trial runs: ");
int numberOfTrials = int.Parse(Console.ReadLine());

int successfulRuns = 0;
int failedRuns = 0;


for (int i = 1; i <= numberOfTrials; i++)
{
    //Create a random number between -10 and 10 for the heist's luck value.
    int luckValue = random.Next(-10, 11);
    int bankDifficultyLevelWithLuck = bankDifficultyLevel + luckValue;

    // Compare the team's skill level with the bank's difficulty level (including luck) and increment the appropriate counter
    if (totalTeamSkillLevel >= bankDifficultyLevelWithLuck)
    {
        Console.WriteLine($"Trial {i}: Heist Successful!");
        successfulRuns++;
    }
    else
    {
        Console.WriteLine($"Trial {i}: Heist Failed!");
        failedRuns++;
    }
    Console.WriteLine($"Bank Difficulty: {bankDifficultyLevelWithLuck}");
}

/* Before displaying the success or failure message, display a report that shows.
 The team's combined skill level
 The bank's difficulty level */
Console.WriteLine($"Total skill level of the team: {totalTeamSkillLevel}");

// Display the report showing the number of successful and failed runs
Console.WriteLine("\nHeist Report:");
Console.WriteLine($"Successful Runs: {successfulRuns}");
Console.WriteLine($"Failed Runs: {failedRuns}");
