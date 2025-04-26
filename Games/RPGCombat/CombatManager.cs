namespace CSharpDSAGames.Games;

public enum TurnTracker
{
    Player,Monster
}

public class CombatManager
{
    private Random _rng = new Random();
    
    private CombatHistory _combatHistory = new CombatHistory();
    private int _playerHealth = 100;
    private int _playerMaxHealth = 100;
    
    private int _monsterHealth = 100;
    private int _monsterMaxHealth = 100;
    
    private TurnTracker _turnTracker = new();
    private bool _gameOver = false;
    
    public void StartBattle()
    {
        // Battle loop will go here
        switch (SetTurnOrder())
        {
            case 0:
                _turnTracker = TurnTracker.Player;
                break;
            case 1:
                _turnTracker = TurnTracker.Monster;
                break;
        }

        while (!_gameOver)
        {
            if (_turnTracker == TurnTracker.Monster)
            {
                MonstersTurn();
            }
            else
            {
                PlayersTurn();
            }
        }
    }

    public void PlayersTurn()
    {
        if (_playerHealth == 0)
        {
            Console.WriteLine("Player is Defeated");
            _gameOver = true;
        }
        
        Console.WriteLine("Player's Health: " + _playerHealth);
        Console.WriteLine("Monsters's Health: " + _monsterHealth);
        
        Console.WriteLine("Select an Action: 1: Fight, 2: Steal an item ,3: Use a Skill,4: Use an Item");
        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Console.WriteLine("Player attacks  " + _playerHealth);
                break;
            case "2":
                Console.WriteLine("Player attacks  " + _playerHealth);
                break;
            case "3":
                Console.WriteLine("Player attacks  " + _playerHealth);
                break;
            case "4":
                Console.WriteLine("Player attacks  " + _playerHealth);
                break;
            default: Console.WriteLine("Not a valid Answer");
                break;
        }
        
        if (_playerHealth > _playerMaxHealth)
        {
            _playerHealth = _playerMaxHealth;
        }
    }

    public void MonstersTurn()
    {
        if (_monsterHealth == 0)
        {
            Console.WriteLine("Monster is Defeated");
            _gameOver = true;
        }

        var option = _rng.Next(0, 2);
        switch (option)
        {
            
            case 0:
                var damage = _rng.Next(1, 12);
                Console.WriteLine("Monster Attacks for {damage}");
                _playerHealth -= damage;
                break;
            case 1:
                var health = _rng.Next(1, 10);
                Console.WriteLine("Monster Heals for {health}");
                _monsterHealth += health;
                break;
        }
        
        if (_monsterHealth > _monsterMaxHealth)
        {
            _monsterHealth = _monsterMaxHealth;
        }
        
    }
    
    public int SetTurnOrder()
    {
        return _rng.Next(0,2);
    }
}