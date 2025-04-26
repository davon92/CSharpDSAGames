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
        
        Console.WriteLine("Select an Action: 1: Fight | 2: Steal an item | 3: Use a Skill | 4: Use a Health Potion | 5: Undo Last Action | 6: Redo Last Action");
        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                var damage = _rng.Next(1, 11);
                _monsterHealth -= damage;
                CheckPlayerAction(new CombatAction { ActionType = ActionType.Attack, AttackTarget = "Monster",Value = damage});
                break;
            case "2":
                var goldAmount = _rng.Next(0, 15);
                CheckPlayerAction(new CombatAction { ActionType = ActionType.Steal, AttackTarget = "Monster",Value = goldAmount});
                break;
            case "3":
                var skillDamage = _rng.Next(1, 21);
                _monsterHealth -= skillDamage;
                CheckPlayerAction(new CombatAction { ActionType = ActionType.Skill, AttackTarget = "Monster",Value = skillDamage});
                break;
            case "4":
                var healValue = _rng.Next(1, 9);
                _playerHealth += healValue;
                CheckPlayerAction(new CombatAction { ActionType = ActionType.Item, AttackTarget = "Self",Value = healValue});
                break;
            case "5":
                ApplyUndoAction(_combatHistory.Undo());
                
                Console.WriteLine($"Player Undoes Last Action");
                break;
            case "6":
                ApplyRedoAction(_combatHistory.Redo());
                Console.WriteLine($"Player Redoes Last Action");
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

    public void ApplyRedoAction(CombatAction action)
    {
        switch (action.ActionType)
        {
            case ActionType.Attack:
                _monsterHealth -= action.Value;
                break;
            case ActionType.Steal:
                break;
            case  ActionType.Skill:
                _monsterHealth -= action.Value;
                break;
            case ActionType.Item:
                _playerHealth += action.Value;
                break;
        }
        Console.WriteLine($"Player Reused {action.ActionType} on {action.AttackTarget} for {action.Value}");
        
        _turnTracker = TurnTracker.Monster;
    }

    public void ApplyUndoAction(CombatAction action)
    {
        switch (action.ActionType)
        {
            case ActionType.Attack:
                _monsterHealth += action.Value;
                break;
            case ActionType.Steal:
                break;
            case ActionType.Skill:
                _monsterHealth += action.Value;
                break;
            case ActionType.Item:
                _playerHealth -= action.Value;
                break;
        }
        
        Console.WriteLine($"Player Undid his {action.ActionType} on {action.AttackTarget} for {action.Value}");
        _turnTracker = TurnTracker.Player;
    }

    public void CheckPlayerAction(CombatAction action)
    {
        switch (action.ActionType)
        {
            case ActionType.Attack:
                Console.WriteLine($"Player {action.ActionType}'ed {action.AttackTarget} for {action.Value}");
                _combatHistory.RecordCombatAction(action);
                break;
            case ActionType.Steal:
                Console.WriteLine($"Player {action.ActionType} From {action.AttackTarget} for {action.Value}");
                _combatHistory.RecordCombatAction(action);
                break;
            case  ActionType.Skill:
                Console.WriteLine($"Player Uses a {action.ActionType} attack On {action.AttackTarget} for {action.Value}");
                _combatHistory.RecordCombatAction(action);
                break;
            case ActionType.Item:
                Console.WriteLine($"Player Uses a Healing {action.ActionType} on {action.AttackTarget} for {action.Value}");
                _combatHistory.RecordCombatAction(action);
                break;
        }
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