// This is challenge work for the "C# Players Guide"
// This is for the level 32 "Lists of Commands" challenge
// This is an update to the Level 26 "The Old Robot" Challenge and Level 27  "Robotic Interface" Challenge 
// The goal is to change the array to a list

// Make MyLittleRobot from Robot
Robot MyLittleRobot = new Robot();

int UserChoice;

//OverEngineered Menu 
while(true)
{
     
    Console.WriteLine("Welcome to the 'My Little Robot' proving grounds");
    Console.WriteLine("Type Exit to end command input");
    Console.WriteLine("Type Enter to add a new command");
    string NextAction = Console.ReadLine().ToLower();
    if (NextAction == "exit") break;
    else
    {
        do
        {
            Console.WriteLine("Welcome to the 'My Little Robot' proving grounds");
            Console.WriteLine("Please select commands from the menu for this test cycle");
            Console.WriteLine("*********************************************************");
            Console.WriteLine("MENU:");
            Console.WriteLine("1) ON    --- Powers on My Little Robot");
            Console.WriteLine("2) OFF   --- Powers off My Little Robot");
            Console.WriteLine("3) NORTH --- Moves My Little Robot 1 pace North:");
            Console.WriteLine("4) SOUTH --- Moves My Little Robot 1 pace South:");
            Console.WriteLine("5) EAST  --- Moves My Little Robot 1 pace East:");
            Console.WriteLine("6) WEST  --- Moves My Little Robot 1 pace West:");
            Console.WriteLine("*********************************************************");
            UserChoice = Convert.ToInt32(Console.ReadLine());
            if (UserChoice != 1 && UserChoice != 2 && UserChoice != 3 && UserChoice != 4 && UserChoice != 5 && UserChoice != 6)
            {
                Console.WriteLine($"The selection you made: {UserChoice} was not valid");
                Console.WriteLine("Press any key to try again");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"You selected command number: {UserChoice}");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        } while (UserChoice != 1 && UserChoice != 2 && UserChoice != 3 && UserChoice != 4 && UserChoice != 5 && UserChoice != 6);

        //switch to get command to store in Command array
        
        IRobotCommand MyCommmand = UserChoice switch
        {
            1 => new OnCommand(),
            2 => new OffCommand(),
            3 => new NorthCommand(),
            4 => new SouthCommand(),
            5 => new EastCommand(),
            6 => new WestCommand(),
        };
        MyLittleRobot.Commands.Add(MyCommmand);
    }
    
}
//Execute run method in robot
MyLittleRobot.Run();
Console.ReadKey();

public interface IRobotCommand
{
    void Run(Robot robot);

}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y++;
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y--;
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X--;
    }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X++;
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public List<IRobotCommand?> Commands { get; } = new List<IRobotCommand?>();

    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}
