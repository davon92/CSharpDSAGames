# CSharpDSAGames

A terminal-based C# project designed to showcase fundamental understanding of **Data Structures**, **Algorithms**, and their application in **game-inspired mini projects**. Built for developers looking to solidify their knowledge and impress technical reviewers, especially in **game development studios**.

---

## 🎯 Project Goals

- ✅ Master core C# concepts outside of Unity
- ✅ Implement foundational **DSA (Data Structures & Algorithms)**
- ✅ Build interactive **console games** using algorithmic logic
- ✅ Showcase clean code and problem-solving in a developer-friendly repo

---

## 📁 Structure

```bash
CSharpDSAGames/
├── DataStructures/     # Stacks, Queues, Lists, Trees, etc.
├── Algorithms/         # Sorting, Searching, Recursion, etc.
├── Games/              # Terminal-based games using DS/A logic
├── Program.cs          # Entry point with menu interface
├── README.md           # This file
├── .github/
│   └── ISSUE_TEMPLATES/  # Tasks for GitHub Issues
```

---

## 🚀 Getting Started

### Run the project:

```bash
cd CSharpDSAGames
 dotnet run
```

> Requires [.NET 6 SDK+](https://dotnet.microsoft.com/en-us/download) installed.

### Menu:

```
Welcome to CSharpDSAGames!

1. Data Structures
2. Algorithms
3. Games
4. Exit
```

---

## 🧠 Modules Overview

### Data Structures

> ✅ = Complete | 🔄 = In Progress | 📝 = Planned

| Structure          | Status | Description |
|--------------------|--------|-------------|
| Stack              | ✅ | Data structure that follows the **LIFO** principle (Last In First Out), used for undo systems, backtracking, parsing. |
| Queue              | ✅ | Data structure that follows the **FIFO** principle (First In First Out), used for task scheduling, turn management, real-time systems. |
| Linked List        | 🔄 | A linear collection where each element (node) points to the next; allows efficient insertions and deletions anywhere. |
| Doubly Linked List | 📝 | A linked list where each node points both to the next and the previous node, enabling efficient two-way traversal. |
| Trees              | 📝 | A hierarchical structure where each node has children, used for representing relationships like filesystems, decision trees, and scene graphs. |
| Graphs             | 📝 | A flexible collection of nodes connected by edges; models complex networks like maps, quests, and AI behavior. |
| Heaps              | 📝 | A special binary tree that maintains a specific order (min-heap or max-heap); used for efficient priority scheduling and pathfinding. |
| Tries              | 📝 | A tree-like data structure that stores strings by character; optimized for fast word lookup, autocomplete, and spell-checking. |

### Algorithms
> ✅ = Complete | 🔄 = In Progress | 📝 = Planned

| Algorithm           | Status | Description |
|---------------------|--------|-------------|
| Linear Search       | 🔄 | Simple scan through elements to find a match (no sorting required). |
| Binary Search       | 📝 | Efficient search on sorted arrays, repeatedly dividing search space by half. |
| Bubble Sort         | 📝 | Simple sorting algorithm that repeatedly swaps adjacent elements if out of order. |
| Insertion Sort      | 📝 | Builds a sorted array one element at a time by inserting into the correct position. |
| Selection Sort      | 📝 | Repeatedly selects the minimum (or maximum) element and places it at the correct position. |
| Merge Sort          | 📝 | Divide-and-conquer sorting algorithm that splits arrays and merges them back sorted. |
| Quick Sort          | 📝 | Divide-and-conquer sorting that selects a pivot and partitions elements around it. |
| Recursion Basics    | 📝 | Writing functions that call themselves; core for divide-and-conquer problems. |
| Depth-First Search (DFS) | 📝 | Traverses trees or graphs deeply before backtracking; typically implemented with recursion or a stack. |
| Breadth-First Search (BFS) | 📝 | Traverses trees or graphs level by level; typically implemented with a queue. |
| Dijkstra's Algorithm | 📝 | Finds the shortest path between nodes in a graph with non-negative edge weights. |
| A* Pathfinding      | 📝 | Optimized shortest path algorithm using heuristics; widely used in games for AI navigation. |

-

### Games

- Stack Games: 
  - Stack Room Escape
  - Stack RPG Battle
- Queue Games:
  - Queue Boss Rush

---

---

## 📎 License

MIT

