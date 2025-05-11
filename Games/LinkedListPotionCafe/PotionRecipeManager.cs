using DataStructures;

namespace CSharpDSAGames.Games
{
    public class PotionRecipeManager
    {
        private List<Potion> _potions = new();
        private Random _rng = new();
        public PotionRecipeManager()
        {
            LoadPotions();
        }
        
        private void LoadPotions()
        {
            _potions.Add(new Potion
            {
                Name = "Healing Potion",
                Description = "Restores the user's health.",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Water" },
                    new Ingredient { Name = "Herb" },
                    new Ingredient { Name = "Redroot" }
                },
                Hints = new List<string>
                {
                    "The warrior needs something to recover.",
                    "A rugged fighter asks for something restorative."
                }
            });
            _potions.Add(new Potion
            {
                Name = "Mana Potion",
                Description = "Restores magical energy.",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Water" },
                    new Ingredient { Name = "Glowcap" },
                    new Ingredient { Name = "Azureleaf" }
                },
                Hints = new List<string>
                {
                    "The mage needs a mana boost.",
                    "A wizard requests a recharge."
                }
            });
            _potions.Add(new Potion
            {
                Name = "Strength Potion",
                Description = "Temporarily increases the user's physical power.",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Redroot" },
                    new Ingredient { Name = "Embervine" },
                    new Ingredient { Name = "Bloodpetal" }
                },
                Hints = new List<string>
                {
                    "The knight needs something to crush enemies.",
                    "A brawler demands something to increase muscle power."
                }
            });
            _potions.Add(new Potion
            {
                Name = "Dexterity Elixir",
                Description = "Enhances speed, reflexes, and agility.",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Feathergrass" },
                    new Ingredient { Name = "Lightfoot Dew" },
                    new Ingredient { Name = "Windroot" }
                },
                Hints = new List<string>
                {
                    "A customer whispers about moving swiftly and silently.",
                    "The rogue needs help dodging and weaving."
                }
            });
            _potions.Add(new Potion
            {
                Name = "Antidote",
                Description = "Cures most poisons and venoms.",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Milkcap" },
                    new Ingredient { Name = "Greencap" },
                    new Ingredient { Name = "Silverfern" }
                },
                Hints = new List<string>
                {
                    "A traveler feels sick after a bite.",
                    "Someone needs help surviving a venomous wound."
                }
            });
            _potions.Add(new Potion
            {
                Name = "Fire Resistance Potion",
                Description = "Protects the user against heat and flames.",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Water" },
                    new Ingredient { Name = "Embervine" },
                    new Ingredient { Name = "Ashleaf" }
                },
                Hints = new List<string>
                {
                    "A blacksmith seeks protection from heat.",
                    "Someone fears walking through flames."
                }
            });
            _potions.Add(new Potion
            {
                Name = "Regeneration Elixir",
                Description = "Heals over time. Gentler than a full healing potion.",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Herb" },
                    new Ingredient { Name = "Redroot" },
                    new Ingredient { Name = "Milkcap" }
                },
                Hints = new List<string>
                {
                    "Someone asks for something to slowly recover.",
                    "A merchant needs something for long journeys."
                }
            });
            _potions.Add(new Potion
            {
                Name = "Night Vision Draught",
                Description = "Allows the user to see in complete darkness.",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Glowcap" },
                    new Ingredient { Name = "Nightshade" },
                    new Ingredient { Name = "Bat Wing" }
                },
                Hints = new List<string>
                {
                    "A hunter seeks something to see through the night.",
                    "The ranger mentions needing to spot beasts in the dark."
                }
            });
            _potions.Add(new Potion
            {
                Name = "Stone Skin Brew",
                Description = "Temporarily hardens the user’s skin like stone.",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Silverfern" },
                    new Ingredient { Name = "Bloodpetal" },
                    new Ingredient { Name = "Ashleaf" }
                },
                Hints = new List<string>
                {
                    "A guard wants to feel indestructible.",
                    "A miner needs something to endure falling rocks."
                }
            });
            _potions.Add(new Potion
            {
                Name = "Invisibility Tonic",
                Description = "Renders the drinker temporarily unseen.",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Windroot" },
                    new Ingredient { Name = "Nightshade" },
                    new Ingredient { Name = "Feathergrass" }
                },
                Hints = new List<string>
                {
                    "The thief wants to vanish without a trace.",
                    "Someone says they need to pass unseen."
                }
            });

        }

        public string GetRandomHint()
        {
            if (_potions.Count == 0) return string.Empty;

            var potion = _potions[_rng.Next(_potions.Count)];
            return potion.Hints[_rng.Next(potion.Hints.Count)];
        }

        public Potion GetPotionByHint(string hint)
        {
            return _potions.FirstOrDefault(p => p.Hints.Contains(hint));
        }

        public void DisplayPotionBook()
        {
            Console.WriteLine("📖 === Potion Recipe Book ===\n");

            foreach (var potion in _potions)
            {
                Console.WriteLine($"Potion: {potion.Name}");
                Console.WriteLine($"Description: {potion.Description}");
                Console.WriteLine("Ingredients:");

                foreach (var ingredient in potion.Ingredients)
                {
                    Console.WriteLine($"   - {ingredient.Name}");
                }

                Console.WriteLine(new string('-', 40));
            }

            Console.WriteLine();
        }
    }
}