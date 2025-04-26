# 002 - Build Boss Rush Queue Game

---

## 🎯 Goal

Create a simple terminal-based boss battle game where bosses are **queued up** and fought in **FIFO** (First-In-First-Out) order.  
Apply the custom-built **DS_Queue<T>** data structure to manage the boss spawn and defeat order.

---

## 📋 Tasks

- [ ] Create `BossRushGame.cs` inside `/Games/QueueGames/`
- [ ] Create a simple `Boss` class (with Name, Health, maybe Power)
- [ ] Create a `DS_Queue<Boss>` for boss management
- [ ] Populate the queue with random bosses
- [ ] Dequeue bosses one at a time for battles
- [ ] Allow player to attack the current boss until defeated
- [ ] Print player and boss health at each turn
- [ ] Declare victory after all bosses are defeated

---

## 🧠 Learning Objectives

- Practice applying **Queues** (FIFO) in a real gameplay situation
- Understand dynamic queue management
- Simulate "boss waves" — a common game dev mechanic
- Reinforce DS_Queue<T> implementation by real usage

---

## 🚀 Success Criteria

- Bosses appear and are fought in the exact order they entered the queue.
- DS_Queue<T> is used properly for all queue operations.
- Battle loop runs until the queue is empty.
- Player wins after defeating all bosses.

---

## ⏳ Estimated Time

- 30–45 minutes after building DS_Queue<T>.

---

## 📎 Related Resources

- [Microsoft Docs - Queue<T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1)
- Related Project: Stack Escape Game (001)
