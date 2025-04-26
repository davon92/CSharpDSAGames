namespace CSharpDSAGames.Games;

public enum ActionType
{
    Attack,
    Steal,
    Skill,
    Item
}
public class CombatAction
{
    public ActionType ActionType { get; set; }
    public string AttackTarget { get; set; }
    public int Value { get; set; }
}