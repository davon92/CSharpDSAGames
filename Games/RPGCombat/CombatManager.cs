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
            
            CheckPlayerHealth();
            CheckMonsterHealth();
        }
    }

    public void PlayersTurn()
    {
        Console.WriteLine("Player's Health: " + _playerHealth);
        Console.WriteLine("Monsters's Health: " + _monsterHealth);
        
        Console.WriteLine("Select an Action: 1: Fight, 2: Steal an item ,3: Use a Skill,4: Use an Health Potion");
        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                var damage = _rng.Next(1, 11);
                Console.WriteLine($"Player Attacks for {damage}");
                _monsterHealth -= damage;
                break;
            case "2":
                Console.WriteLine("Player Steals Money From Monster" );
                break;
            case "3":
                var skillDamage = _rng.Next(1, 21);
                Console.WriteLine($"Player Uses a skilled attack {skillDamage}");
                _monsterHealth -= skillDamage;
                break;
            case "4":
                var healValue = _rng.Next(1, 9);
                Console.WriteLine($"Player Heals for {healValue}");
                _playerHealth += healValue;
                break;
            default: Console.WriteLine("Not a valid Answer");
                break;
        }
        
        if (_playerHealth > _playerMaxHealth)
        {
            _playerHealth = _playerMaxHealth;
        }

        _turnTracker = TurnTracker.Monster;
    }

    public void CheckMonsterHealth()
    {
        if (_monsterHealth <= 0)
        {
            Console.WriteLine("Monster is Defeated");
            _gameOver = true;
        }
    }
    
    public void CheckPlayerHealth()
    {
        if (_playerHealth <= 0)
        {
            Console.WriteLine("Player is Defeated");
            _gameOver = true;
        }
    }

    public void MonstersTurn()
    {
        var option = _rng.Next(0, 2);
        switch (option)
        {
            
            case 0:
                var damage = _rng.Next(1, 12);
                Console.WriteLine($"Monster Attacks for {damage}");
                _playerHealth -= damage;
                break;
            case 1:
                var health = _rng.Next(1, 10);
                Console.WriteLine($"Monster Heals for {health}");
                _monsterHealth += health;
                break;
        }
        
        if (_monsterHealth > _monsterMaxHealth)
        {
            _monsterHealth = _monsterMaxHealth;
        }
        
        _turnTracker = TurnTracker.Player;
    }
    
    public int SetTurnOrder()
    {
        return _rng.Next(0,2);
    }
}