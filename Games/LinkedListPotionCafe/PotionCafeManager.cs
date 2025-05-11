using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpDSAGames.Games
{
    public class PotionCafeManager
    {
        private PotionRecipeManager _potionManager = new();
        private DS_LinkedList<string> _currentPotion = new();
        private Potion _targetPotion;
        private string _currentHint;
        private bool _gameRunning = true;

        private int _customersServed = 0;
        private const int _maxCustomers = 20;
        private int _correctPotions = 0;

        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Potion Cafe");
            Console.WriteLine("In this game, you will craft magical potions for weary travelers and mysterious strangers.");
            Console.WriteLine("Listen carefully to what each customer says — their words contain clues about what potion they need.");
            Console.WriteLine("Consult your Potion Book to find the correct recipe and use your skills to brew it.");
            Console.WriteLine("Build each potion using precise ingredient order — one mistake could ruin the brew!");

            Console.WriteLine("A mysterious customer approaches...");
            _potionManager.DisplayPotionBook();

            while (_customersServed < _maxCustomers)
            {
                StartCustomerInteraction();
            }

            Console.WriteLine("The day is over. You served 20 customers!");
            Console.WriteLine($"You brewed {_correctPotions} correct potion(s) out of {_maxCustomers}.");

            if (_correctPotions == _maxCustomers)
            {
                Console.WriteLine("PERFECT! You're a master alchemist. The entire village praises your name!");
            }
            else if (_correctPotions >= 15)
            {
                Console.WriteLine("Excellent work! Most of your customers left happy.");
            }
            else if (_correctPotions >= 10)
            {
                Console.WriteLine("Not bad. You have potential, but there's room to improve.");
            }
            else
            {
                Console.WriteLine("Uh-oh... many customers left dissatisfied. Better brush up on your recipes.");
            }
        }

        private void StartCustomerInteraction()
        {
            _currentPotion = new DS_LinkedList<string>();

            _currentHint = _potionManager.GetRandomHint();
            _targetPotion = _potionManager.GetPotionByHint(_currentHint);

            Console.WriteLine($" A new customer enters...");
            Console.WriteLine($"Customer says: \"{_currentHint}\"");

            bool customerDone = false;

            while (!customerDone)
            {
                ShowOptions();
                var input = Console.ReadLine();
                customerDone = HandleInput(input);
            }

            _customersServed++;
        }

        private void ShowOptions()
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Add Ingredient");
            Console.WriteLine("2. Insert Ingredient At Position");
            Console.WriteLine("3. Remove Ingredient");
            Console.WriteLine("4. Remove All of Ingredient");
            Console.WriteLine("5. Reverse Potion");
            Console.WriteLine("6. View Current Potion");
            Console.WriteLine("7. View Potion Book");
            Console.WriteLine("8. Submit Potion");
            Console.WriteLine("9. Exit");
            Console.Write("Choice: ");
        }

        private bool HandleInput(string input)
        {
            switch (input)
            {
                case "1":
                    Console.Write("Ingredient to Add: ");
                    _currentPotion.Add(Console.ReadLine());
                    break;
                case "2":
                    Console.Write("Ingredient to Insert: ");
                    var ingredient = Console.ReadLine();
                    Console.Write("Position to Insert At: ");
                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        _currentPotion.InsertAt(index,ingredient);
                    }
                    break;
                case "3":
                    Console.Write("Ingredient to Remove: ");
                    _currentPotion.Remove(Console.ReadLine());
                    break;
                case "4":
                    Console.Write("Ingredient to Remove All Of: ");
                    _currentPotion.RemoveAll(Console.ReadLine());
                    break;
                case "5":
                    _currentPotion.Reverse();
                    Console.WriteLine("Potion reversed.");
                    break;
                case "6":
                    Console.WriteLine("Current Potion:");
                    _currentPotion.PrintAll();
                    break;
                case "7":
                    _potionManager.DisplayPotionBook();
                    break;
                case "8":
                    SubmitPotion();
                    return true;
                case "9":
                    _customersServed = _maxCustomers;
                    _gameRunning = false;
                    return true;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
            return false;
        }

        private void SubmitPotion()
        {
            var brewed = _currentPotion.ToList();
            var target = _targetPotion.Ingredients.Select(i => i.Name).ToList();

            if (brewed.SequenceEqual(target))
            {
                Console.WriteLine("The customer takes a sip and smiles. You brewed the perfect potion!");
                _correctPotions++;
            }
            else
            {
                Console.WriteLine("The customer frowns. \"This isn't what I asked for...\"");
                Console.WriteLine("They leave, disappointed.");
                Console.WriteLine($"Expected: {string.Join(", ", target)}");
                Console.WriteLine($"Yours:    {string.Join(", ", brewed)}");
            }
        }
    }
}
