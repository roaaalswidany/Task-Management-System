// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic; 
using System.Linq;

class Task
{
    public string Name { get; set; } // اسم المهمة
    public int Priority { get; set; } // 3=الاولوية عالية=1 ومتوسطة=2 ومنخفضة
    public DateOnly DateAdded { get; set; } // تاريخ اضافة المهمة
    // انشاء مهمة جديدة
    public Task(string name, int priority, DateOnly date)
    {
        Name = name; // تخزين اسم المهمة
        Priority = priority; // تخزين الاولوية
        DateAdded = date; // تخزين التاريخ
    }
}
class LinkedList
{
    public class Node // العقدة (عنصر في القائمة المرتبطة)
    {
        public Task Data { get; set; } // تحوي بيانات مهمة
        public Node Next { get; set; } // مؤشر للعنصر التاالي
        public Node(Task data) // للعقدة
        {
            Data = data; // تخزين المهمة
            Next = null; // لا يوجد عنصر تالي (يضاف لاحقا)
        }
    }

    public Node head;
    // اضافة مهمة الى القائمة
    public void Add(Task task)
    {
        Node newNode = new Node(task);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null) // البحث عن نهاية القائمة 
            {
                current = current.Next;
            }
            current.Next = newNode; // اضافة العقدة الجديدة في النهاية
        }
    }

    public void DisplayCompleteTask() // عرض المهام
    {
        Node current = head;
        while (current != null) // يكرر حتى نهاية القائمة
        {
            // الطباعة حسب الاولوية 
            if (current.Data.Name == null)
            {
                Console.WriteLine("No Tasks Her");
                break;
            }
            int i = 0;
            if (current.Data.Priority == 1)
            {
                Console.WriteLine($"Task{i + 1}\nTask Name:{current.Data.Name} \t Task Priority:{"Hight"}\t  Task Date:{current.Data.DateAdded}");
                current = current.Next; i++;
                continue;
            }
            if (current.Data.Priority == 2)
            {
                Console.WriteLine($"Task{i + 1}\nTask Name:{current.Data.Name} \t Task Priority:{"Meduim"}\tTask Date:{current.Data.DateAdded}");
                current = current.Next; // الانتقال الى المهمة التاالية
                i++;
                continue;
            }
            else
            {
                Console.WriteLine($"Task{i + 1}\nTask Name:{current.Data.Name}\t Task Priority:{"Low"}\t  Task Date:{current.Data.DateAdded}");
                current = current.Next; i++;
                continue;
            }
        }
    }
}
class QueueTask
{
    public static Task[] tasks = new Task[100];
    public static int countR = 0; // اضافة المهام المهمة
// اضافة مهمة هامة تضاف في النهاية
    public static void Enqueue(Task task)
    {
        tasks[countR] = task; // تخزين المهام المهمة الحالية
        countR++; // زيادة العداد
        Console.WriteLine("Task Add Completed!");
    }
    // عرض المهام المهمة حسب ترتيب الاضافة
    public void DisplayingUrgentTasks()
    {

        Console.WriteLine("Displaying urgent tasks:\n");
        for (int i = 0; i < countR; i++)
        {
            if (tasks[i] == null)
            {
                Console.WriteLine("No Tasks");
                break;
            }
            if (tasks[i].Priority == 1)
            {
                Console.WriteLine($"Task{i + 1}\n Task Name:{tasks[i].Name} \t Task Priority:{"Hight"}\t  Task Date:{tasks[i].DateAdded}");
                continue;
            }
            if (tasks[i].Priority == 2)
            {
                Console.WriteLine($"Task{i + 1}\nTask Name:{tasks[i].Name} \t Task Priority:{"Meduim"}\t  Task Date:{tasks[i].DateAdded}");
                continue;
            }
            if (tasks[i].Priority == 3)
            {
                Console.WriteLine($"Task{i + 1}\nTask Name:{tasks[i].Name} \t Task Priority:{"LOW"}\t  Task Date:{tasks[i].DateAdded}");
                continue;
            }
            else
            {
                Console.WriteLine("------------------");
                Console.WriteLine("No Tasks Her");
                Console.WriteLine("------------------");
                break;
            }
        }
    }
// انشاء مهام مهمة يسأل المستخدم عن التفاصيل
    public void UrgentTaskQueue()
    {
        QueueTask Queue = new QueueTask();
        Console.Write("Enter Task Name:");
        string taskName = Console.ReadLine();
        Console.Write("Ente:");
        Console.Write("1-Hight ,2-Meduim ,3-Low");
        int priority = int.Parse(Console.ReadLine());
        Console.Write("Enter Your Date");
        Console.Write($"Enter date added for Task (yyyy-mm-dd): ");
        DateOnly date;
        while (!DateOnly.TryParse(Console.ReadLine(), out date))
        {
            Console.WriteLine("Invalid  date, Please enter the date in yyyy-mm-dd format.");
        }
        Task QueueTask = new Task(taskName, priority, date);
        Enqueue(QueueTask); // اضافتها الى قائمة الانتظار 
    }
}
class Program

{
    static Task[] Tasks = new Task[100]; // المهام النشطة
     static int taskCount = 0; // عدد المهام الحالي
    static QueueTask queueTask = new QueueTask(); // كائن المهام المهمة

    static void Main(string[] args)
    {
        LinkedList taskList = new LinkedList(); // قائمة المهام المكتملة
        bool isRunning = true;
        while (isRunning) // الحلقة الرئيسية
        {
            Console.WriteLine("TASK MANGER");
            Console.WriteLine("1-Adding a new task.");
            Console.WriteLine("2-Displaying all tasks.");
            Console.WriteLine("3-Deleting a task.");
            Console.WriteLine("4-Sorting tasks by priority.");
            Console.WriteLine("5-Sorting tasks by date.");
            Console.WriteLine("6-Completing a task (moving the task from the active tasks list to the completed tasks list).");
            Console.WriteLine("7-Displaying completed Tasks.");
            Console.WriteLine("8-Adding an urgent Task.");
            Console.WriteLine("9-Displaying urgent Tasks.");
            Console.WriteLine("10-Exit");
            Console.Write("Select Mission:");
            int select = int.Parse(Console.ReadLine());

            switch (select)
            {
                case 1: AddTask(); break;
                case 2:
                    if (taskCount == 0) { Console.WriteLine("No Tasks"); break; }
                    DisplayTasks(); break;
                case 3: DeleteTask(); break;
                case 4: SortingBuble(); break;
                case 5: QuickSort(Tasks, 0, taskCount - 1); break;
                case 6:
                    Console.WriteLine("------------------------------------------------------");
                    Console.Write("Enter Number of Task To Move:");
                    int i = int.Parse(Console.ReadLine());
                    taskList.Add(Tasks[i]);
                    DeletTAskFromArray(i);
                    break;
                case 7:
                    Console.WriteLine("----------------------------------------\n");
                    Console.WriteLine("Completed Tasks:");
                    taskList.DisplayCompleteTask();
                    Console.WriteLine("----------------------------------\n");
                    break;
                case 8:
                    queueTask.UrgentTaskQueue();
                    break;
                case 9:
                    queueTask.DisplayingUrgentTasks();

                    break;
                case 10:
                    y_f = false;
                    break;

                default:
                    Console.WriteLine("Wrong input! please input corect number");
                    break;
            }
        }
    }
    static void AddTask()
    {
        Console.WriteLine("ADD TASKS");
        Console.Write("Task name :  ");
        string taskName = Console.ReadLine();

        Console.Write("1-Hight ,2-Meduim ,3-Low");
        int priority = int.Parse(Console.ReadLine());
        Console.Write("Enter Your Date");
        Console.Write($"Enter date added for Task (yyyy-mm-dd): ");
        DateOnly date;
        while (!DateOnly.TryParse(Console.ReadLine(), out date))
        {
            Console.WriteLine("Invalid date format. Please enter the date in yyyy-mm-dd format.");
        }
        if (taskCount < Tasks.Length)
        {
            Tasks[taskCount] = new Task(taskName, priority, date);
            taskCount++;
            Console.WriteLine("----------------------------\n");
            Console.WriteLine("Task ADD Complet Successfuly\n");
            Console.WriteLine("-----------------------------------\n");
        }
        else
        {
            Console.WriteLine("Out Of Memory!\n");
        }
    }
    public static void DisplayTasks()
    {
        Console.WriteLine("\n ALL TASKS :\n");
        for (int i = 0; i < taskCount; i++)
        {
            if (Tasks[i] == null)
            {
                break;
            }
            if (Tasks[i].Priority == 1)
            {
                Console.WriteLine($"Task{i + 1}\n Task Name:{Tasks[i].Name} \t Task Priority:{"Hight"}\t  Task Date:{Tasks[i].DateAdded}");
                continue;
            }
            if (Tasks[i].Priority == 2)
            {
                Console.WriteLine($"Task{i + 1}\nTask Name:{Tasks[i].Name} \t Task Priority:{"Meduim"}\t  Task Date:{Tasks[i].DateAdded}");
                continue;
            }
            if (Tasks[i].Priority == 3)
            {
                Console.WriteLine($"Task{i + 1}\nTask Name: {Tasks[i].Name}  \t Task Priority: {"LOW"} \t  Task Date:{Tasks[i].DateAdded}");
                continue;
            }
            else
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("No tasks her");
                Console.WriteLine("--------------------");
                break;
            }
        }
    }
    static void DeleteTask()

    {
        Console.WriteLine("DELET tASKS");
        Console.Write("Enter number of task you want to delet:");
        int TAskNum = int.Parse(Console.ReadLine());
        if (TAskNum >= 0)
        {
            for (int i = TAskNum; i <= taskCount - 1; i++)
            {
                Tasks[i] = Tasks[i + 1];
                Tasks[taskCount - 1] = null;
                taskCount--;
                Console.WriteLine("Delet task succesfuly");
            }
        }
        else
        {
            Console.WriteLine("Wrong input");
        }
    }

static void SortingBubble()
{
    for (int i = 0; i < taskCount - 1; i++)
    {
        bool swapped = false;
        for (int j = 0; j < taskCount - i - 1; j++)
        {
            if (Tasks[j].Priority > Tasks[j + 1].Priority)
            {
                Task temp = Tasks[j];
                Tasks[j] = Tasks[j + 1];
                Tasks[j + 1] = temp;
                swapped = true;
            }
        }
        if (!swapped)
        {
            break;
        }
    }
    Console.WriteLine("Tasks sorted by priority");
}

    static void QuickSort(Task[] Tasks, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(Tasks, low, high);
            QuickSort(Tasks, low, pi - 1);
            QuickSort(Tasks, pi + 1, high);
        }
    }
    static int Partition(Task[] Tasks, int low, int high)
    {
        DateOnly pivot = Tasks[high].DateAdded;
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (Tasks[j].DateAdded <= pivot)
            {
                i++;
                Task temp = Tasks[i];
                Tasks[i] = Tasks[j];
                Tasks[j] = temp;
            }
        }

        Task Temp = Tasks[i + 1];
        Tasks[i + 1] = Tasks[high];
        Tasks[high] = Temp;
        return i + 1;
    }
    static void DeletTAskFromArray(int Remove)
    {
        if (Remove < 0 || Remove >= taskCount){
            Console.WritLine ("Invalid task number");
            return;
        }
        for (int i = Remove; i < taskCount - 1; i++){
            Tasks[i] = Tasks[i+1];
        }
        Tasks[taskCount - 1] = null;
        taskCount--;
         Console.WritLine ("Task deleted successfully");
    }
}
