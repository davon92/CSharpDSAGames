---
name: Stack Escape - Stack Game Milestone
about: Track progress and document the Stack Escape game built with DS_Stack<T>
title: "[Milestone] Stack Escape"
labels: [milestone, game, stack]
assignees: davon92
---

## 🎮 Stack Escape

A terminal-based C# game that demonstrates how to use a custom stack (DS_Stack<T>) for undo/redo mechanics.

---

### ✅ Features Implemented

- [x] Player can move through 10 rooms using 3-door logic (only one is correct).
- [x] Custom `DS_Stack<T>` used to implement:
  - [x] `Push()` to track visited rooms
  - [x] `Pop()` for Undo and Redo
  - [x] `Clear()` to reset redo path after new choice
  - [x] `Peek()` to preview undo/redo state
- [x] Game loop continues until the player reaches the final room.
- [x] Tracks number of moves made.
- [x] Fully interactive and replayable from the console.

---

### 🧠 Concepts Demonstrated

- Stack data structure: LIFO behavior
- Game state rollback (Undo/Redo)
- Randomized puzzle generation
- Input handling and loop control in a console app

---

### 🪜 Next Steps (Optional Polish)

- [ ] Add save/load or checkpoints
- [ ] Visual map or breadcrumb trail
- [ ] Replace static rooms with dynamic dungeon crawler layout
- [ ] Add traps, keys, or other stack-related game mechanics

---

### 📸 Screenshot / Demo

_Add a screenshot or terminal recording of gameplay here._

---

### 📂 Location in Repo

```bash
/Games/StackEscape.cs
/DataStructures/DS_Stack.cs
```

---

### 🔗 Link this issue to:
- Milestone: `Core DSA Games`
- Project: `CSharpDSAGames`

