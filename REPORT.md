Project Title: Task Management System (To-Do List)

Overview: This project is a simple task management system designed to help users manage their daily tasks effectively. It allows the user to add, delete, view, and sort tasks, as well as handle urgent and completed tasks using data structures like arrays, linked lists, and queues.


---

1. Class: Task

Purpose: Represents a single task with:

Name: the task name (e.g., "Finish the report")

Priority: (1 = High, 2 = Medium, 3 = Low)

DateAdded: the date the task was created



Task study = new Task("Study Algorithms", 1, new DateOnly(2024,5,20));


---

2. Class: LinkedList (Completed Tasks)

Purpose: Stores completed tasks in a linked list structure.

When a task is marked as completed, it's removed from the active list and added here.


Main functions:

Add(Task task): adds a completed task to the list.

DisplayCompleteTask(): displays completed tasks grouped by priority.



---

3. Class: QueueTask (Urgent Tasks Queue)

Purpose: Manages urgent tasks using a FIFO queue.

Tasks are stored in a fixed-size array (max 100).


Main functions:

Enqueue(Task task): adds an urgent task to the queue.

DisplayingUrgentTasks(): shows all urgent tasks in the order added.

UrgentTaskQueue(): allows the user to input a new urgent task.



---

4. Class: Program (Main Class)

Purpose: The main program loop that interacts with the user.

Stores all active tasks in a fixed-size array.

Offers options to:

Add/delete/display/sort tasks

Mark tasks as completed

Handle urgent tasks

Exit the program




---

Features Summary:

Add, delete, and view tasks

Sort tasks by priority or date

Move completed tasks to a separate list

Handle urgent tasks using a queue (FIFO)

Simple console-based interface




