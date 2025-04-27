# 🛡️ RPG Battle Stack Game

A terminal-based RPG battle system built in C# to showcase data structure mastery — specifically the **Stack** — applied in real-world undo/redo gameplay mechanics.

---

## 🎯 Project Purpose

- Demonstrate understanding of **Stacks** (LIFO) with Undo/Redo systems.
- Apply core C# programming skills outside of Unity.
- Build a complete mini-game with modular and scalable architecture.
- Serve as a technical portfolio piece for mid-to-senior C# roles, especially in game development.

---

## 🕹️ Gameplay Overview

- **Player** and **Monster** each have health.
- Player can choose to:
    - **Attack** (deal random damage)
    - **Steal** (steal resources)
    - **Use a Skill** (high damage)
    - **Use a Health Potion** (heal self)
    - **Undo** their last move
    - **Redo** a previously undone move
- Monster attacks or heals randomly each turn.
- First to reach 0 health loses.

---

## 🧠 Key Learning Features

- ✅ Custom **CombatAction** object recorded to Undo/Redo stacks.
- ✅ `CombatHistory` system using `Stack<CombatAction>`.
- ✅ Full Undo/Redo support for player actions.
- ✅ Turn management system.
- ✅ Health caps and flow control.
- ✅ Clean C# architecture with separation of concerns.

---

## 🚀 Running the Game

Make sure you have [.NET 6 SDK+](https://dotnet.microsoft.com/en-us/download) installed.

```bash
git clone https://github.com/YOUR-USERNAME/CSharpDSAGames.git
cd CSharpDSAGames
dotnet run
