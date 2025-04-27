using DataStructures;

namespace CSharpDSAGames.Games
{
    public class BossRush
    {
        private DS_Queue<Boss> _bossQueue = new ();
        private int _totalBosses = 5;
        private int _currentBoss = 0;
        private Random _rng = new();
        private List<String> _firstName = new() {"Dark", "Flame", "Iron", "Shadow"};
        private List<String> _lastname = new() {"Dragon", "Golem", "Phantom", "Beast"};
        private bool _bossesDefeated = false;
        
        public void StartGame()
        {
            for (int i = 0; i < _totalBosses; i++)
            {
                EnqueueRandomBosses();
            }
            
            BattleNextBoss();

            while (!_bossesDefeated)
            {
                CheckBattleQueue();
            }
        }

        private void EnqueueRandomBosses()
        {
             var  monsterFirstName = _rng.Next(0,_firstName.Count);
             var  monsterLastName = _rng.Next(0,_lastname.Count);
            _bossQueue.Enqueue(new Boss{Name = $"{_firstName[monsterFirstName]} {_lastname[monsterLastName]}", Health = 100});
        }

        private void BattleNextBoss()
        {
            if (CheckBattleQueue())
            {
                Console.WriteLine("All Bosses Defeated");
                _bossesDefeated = true;
                return;
            }
            
            var nextBoss = _bossQueue.Dequeue();
            Console.WriteLine($"Your Next Challenger is {nextBoss.Name}!");
            StartBattle(nextBoss);
        }

        private void StartBattle(Boss nextBoss = null)
        {
            Console.WriteLine("What will you do!");
            Console.WriteLine("Select an Action: 1: Punch | 2: Kick");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Boss has been defeated with a single punch");
                    break;
                case "2":
                    Console.WriteLine("Boss has been defeated with a single kick");
                    break;
                default:
                    Console.WriteLine("Boss has been defeated with a secret move");
                    break;
            }
            BattleNextBoss();
        }

        private bool CheckBattleQueue()
        {
            return _bossQueue.IsEmpty();
        }
    }
}

