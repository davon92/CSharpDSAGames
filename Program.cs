using CSharpDSAGames.Games;
class Program
{
    static int Main(string[] args)
    {
        Console.WriteLine("Welcome to CSharpDSAGames!");
        ChooseType();
        
        return 0;
    }

    static void ChooseType()
    {
        Console.WriteLine("What would you like to see?:");
        Console.WriteLine("1. Data Structres");
        Console.WriteLine("2. Algorithms");
        string input = Console.ReadLine();
        
        switch (input)
        {
            case "1":
                ChooseDataStructureGame();
                break;
            case "2":
                break;
            default:
                Console.Write("Option Not Found");
                ChooseType();
                break;
        }
    }

    static void ChooseDataStructureGame()
    {
        Console.WriteLine("Choose A Game:");
        Console.WriteLine("1. Stack Escape");
        Console.WriteLine("2. RPG 1Battle");
        
        string input = Console.ReadLine();
        
        switch (input)
        {
            case "1":
                StackEscape stackEscape = new StackEscape();
                stackEscape.StartGame();
                break;
            case "2":
                CombatManager rpgBattle = new CombatManager();
                rpgBattle.StartBattle();
                break;
            default:
                Console.Write("Option Not Found");
                ChooseType();
                break;
        }
    }
}
