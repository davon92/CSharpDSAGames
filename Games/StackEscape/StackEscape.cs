using DataStructures;

namespace CSharpDSAGames.Games
{

    public class Room
    {
        public int RoomNumber { get; set; }
        public bool LeftDoor;
        public bool RightDoor;
        public bool CenterDoor;
    }
    
    public class StackEscape
    {
        private Random _rng = new Random();
        private Room[] _rooms = new Room[10];
        private DS_Stack<Room> _roomUndoStack = new DS_Stack<Room>();
        private DS_Stack<Room> _roomRedoStack = new DS_Stack<Room>();
        private bool _undoPerformed = false;
        
        private Room _currentRoom;
        private int _nextRoomIndex = 0;
        private int _movesMade = 0;
        
        public void StartGame()
        {
            CreateNewRoomSet();
            Console.WriteLine("Welcome to Stack Escape");
            Console.WriteLine("Your Goal is to ...Well.. Escape");
            Console.WriteLine("You will choose between three rooms");
            Console.WriteLine("Try to make it to the exit with as few moves as possible");
            Console.WriteLine("You are allowed to undo or redo your previous action");
            Console.WriteLine("GoodLuck");
            while (_nextRoomIndex < _rooms.Length - 1)
            {
                ChooseARoom();
            }
            
            Console.WriteLine("You Found The Exit");
            EndGame();
            
        }

        private void CreateNewRoomSet()
        {
            for (int i = 0; i < 9; i++)
            {
                Room room = new();
                int correctDoor = _rng.Next(0, 3);
                switch (correctDoor)
                {
                    case 0:
                        room.LeftDoor = true;
                        room.RightDoor = false;
                        room.CenterDoor = false;
                        break;
                    case 1:
                        room.LeftDoor = false;
                        room.RightDoor = false;
                        room.CenterDoor = true;
                        break;
                    case 2:
                        room.LeftDoor = false;
                        room.RightDoor = true;
                        room.CenterDoor = false;
                        break;
                }

                room.RoomNumber = i;
                _rooms[i] = room;
            }
            _currentRoom = _rooms[0];
        }

        private void ChooseARoom()
        {
            Console.WriteLine($"You are in Room {_currentRoom.RoomNumber}");
            Console.WriteLine("Choose A Room To Enter:");
            Console.WriteLine("1: Left Room | 2: Center Room | 3: Right Room | 4: Go Back | 5: Repeat Choice | 6: Check Previous Room Number | 7: Check Next Room Number" );
            var input = Console.ReadLine();
            
            switch (input)
            {
                case "1": CheckRoom(_currentRoom.LeftDoor); break;
                case "2": CheckRoom(_currentRoom.CenterDoor); break;
                case "3": CheckRoom(_currentRoom.RightDoor); break;
                case "4": Undo(); break;
                case "5": Redo(); break;
                case "6": PeekUndo(); break;
                case "7": PeekRedo(); break;
                default: Console.WriteLine("Not an Option"); break;
            }
        }

        private void CheckRoom(bool option)
        {
            if (option)
            {
                if (_undoPerformed)
                {
                    Clear();
                    _undoPerformed = false;
                }
                Console.WriteLine("You Found the Next Room");
                _roomUndoStack.Push(_currentRoom);
                _nextRoomIndex = (_nextRoomIndex + 1) % _rooms.Length;
                _currentRoom = _rooms[_nextRoomIndex];
                
            }
            else
            {
                Console.WriteLine("You Found an Dead End");
            }
            _movesMade++;
        }
        
        private void PeekUndo()
        {
            if (!_roomUndoStack.IsEmpty())
            {
                var undoPeek= _roomUndoStack.Peek();
                Console.WriteLine($"This will take you to room {undoPeek.RoomNumber}");
            }
        }
        
        private void Undo()
        {
            if (!_roomUndoStack.IsEmpty())
            {
                _roomRedoStack.Push(_currentRoom); // Save current to redo
                _currentRoom = _roomUndoStack.Pop(); // Go back to previous room
                _nextRoomIndex = _currentRoom.RoomNumber;
                _undoPerformed = true;
                _movesMade--;
            }
            else
            {
                Console.WriteLine("Nothing to undo!");
            }
        }

        private void PeekRedo()
        {
            if (!_roomRedoStack.IsEmpty())
            {
               var redoPeek= _roomRedoStack.Peek();
               Console.WriteLine($"This will take you to room {redoPeek.RoomNumber}");
            }
        }
        
        private void Redo()
        {
            if (!_roomRedoStack.IsEmpty())
            {
                _roomUndoStack.Push(_currentRoom); // Save current for undo
                _currentRoom = _roomRedoStack.Pop(); // Redo the next room
                _nextRoomIndex = _currentRoom.RoomNumber;
                _movesMade++;
            }
            else
            {
                Console.WriteLine("Nothing to redo!");
            }
        }

        private void Clear()
        {
            _roomRedoStack.Clear();
        }

        private void EndGame()
        {
            Console.WriteLine($"You Made it To The End in {_movesMade} : Moves");
            Console.WriteLine("Congratulations!");
        }
    }
}