namespace CSharpDSAGames.Games;

public class CombatHistory
{
    private Stack<CombatAction> _undoStack = new ();
    private Stack<CombatAction> _redoStack = new ();

    public CombatAction Undo()
    {
        if (IsEmpty(_undoStack))
        {
            throw new Exception("No action to undo");
        }
        
        var Action = _undoStack.Pop();
        _redoStack.Push(Action);
        Console.WriteLine("Undoing Last Move Preformed");
        return Action;
    }

    public CombatAction Redo()
    {
        if (IsEmpty(_redoStack))
        {
            throw new Exception("No action to redo");
        }
        
        var Action = _redoStack.Pop();
        _undoStack.Push(Action);
        Console.WriteLine("Redoing Last Move Preformed");
        return Action;
    }

    public CombatAction PeekLastAction()
    {
       var LastAction = _undoStack.Peek();
       Console.WriteLine($"Last Move Preformed{LastAction.ActionType} on {LastAction.AttackTarget}");
       return LastAction;
    }

    public void RecordCombatAction(CombatAction action)
    {
        _undoStack.Push(action);
        _redoStack.Clear();
        Console.WriteLine("Recording Move Preformed");
    }

    public bool IsEmpty(Stack<CombatAction> stack)
    {
        return stack.Count == 0;
    }
    
    
}