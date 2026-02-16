# Eternal Quest - Design Documentation

## Project Overview

Eternal Quest is a goal-tracking system that applies **Inheritance** and **Polymorphism** to gamify personal growth. Users can create different types of goals, record progress, and earn points.

## Class Diagram Logic

The system is built on a base `Goal` class with specialized behaviors for different goal types.

## Design Decisions (Evaluation)

### 1. The GoalManager Class

**Benefit:** We use a `GoalManager` to achieve **Separation of Concerns**. By isolating the menu logic and file I/O from the data classes, the code is easier to maintain, debug, and expand.

### 2. Abstract vs. Virtual Methods

* **RecordEvent (Abstract):** There is no default way to record a goal. A `SimpleGoal` marks completion, while a `ChecklistGoal` increments a counter. Making this abstract forces each child to define its own unique logic.
* **GetDetailsString (Virtual):** We provide a default implementation `[ ] Name (Description)` in the base class. We only override it in `ChecklistGoal` to add the progress counter (e.g., `3/10`), saving us from rewriting code for the other goal types.

### 3. The Purpose of EternalGoal

Even though `EternalGoal` uses the same variables as the base class, it exists to provide unique **Behavior**. Its `IsComplete()` method is hardcoded to return `false`, ensuring it can be recorded indefinitely.

## Goal Types

| Type | Behavior |
| :--- | :--- |
| **Simple** | One-time completion. |
| **Eternal** | Never ends; points awarded every time. |
| **Checklist** | Requires multiple completions; awards a large bonus at the target. |

---
