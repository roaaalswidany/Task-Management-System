الدنيا فيها قمرين..
قمر في السماء والأخر هي مشرفة المشروع

class Task
{
public string Name { get; set; } // اسم المهمة (مثال: "إنهاء التقرير")
public int Priority { get; set; } // الأولوية (1 = عالية، 2 = متوسطة، 3 = منخفضة)
public DateOnly DateAdded { get; set; } // تاريخ إضافة المهمة (مثال: 2024-05-20)

    // Constructor: دالة تُنشئ مهمة جديدة عند استدعائها
    public Task(string name, int priority, DateOnly date)
    {
        Name = name;        // تخزين اسم المهمة
        Priority = priority;// تخزين الأولوية
        DateAdded = date;   // تخزين التاريخ
    }

}
وظيفته: تخزين بيانات المهمة (الاسم، الأولوية، : عند إنشاء مهمة مثل Task("دراسة الخوارزميات", 1, new DateOnly(2024,5,20))، يتم تخزينها ككائن.

1.2. كلاس LinkedList (القائمة المرتبطة للمهام المكتملة)
class LinkedList
{
public class Node // العقدة (عنصر في القائمة المرتبطة)
{
public Task Data { get; set; } // تحوي بيانات المهمة
public Node Next { get; set; } // مؤشر للعنصر التالي

        public Node(Task data) // Constructor للعقدة
        {
            Data = data; // تخزين المهمة
            Next = null; // لا يوجد عنصر تالي بعد (يُضاف لاحقاً)
        }
    }

    public Node head; // رأس القائمة (أول عنصر)

    // دالة إضافة مهمة مكتملة إلى القائمة
    public void Add(Task task)
    {
        Node newNode = new Node(task); // إنشاء عقدة جديدة

        if (head == null) // إذا كانت القائمة فارغة:
            head = newNode; // تصبح العقدة الجديدة هي الرأس
        else // إذا كانت تحتوي عناصر:
        {
            Node current = head;
            while (current.Next != null) // البحث عن نهاية القائمة
                current = current.Next;
            current.Next = newNode; // إضافة العقدة الجديدة في النهاية
        }
    }

    // دالة عرض المهام المكتملة
    public void DisplayCompleteTask()
    {
        Node current = head;
        while (current != null) // التكرار حتى نهاية القائمة
        {
            // طباعة بيانات المهمة حسب أولويتها
            if (current.Data.Priority == 1)
                Console.WriteLine($"مهمة عالية: {current.Data.Name}");
            else if (current.Data.Priority == 2)
                Console.WriteLine($"مهمة متوسطة: {current.Data.Name}");
            else
                Console.WriteLine($"مهمة منخفضة: {current.Data.Name}");

            current = current.Next; // الانتقال إلى المهمة التالية
        }
    }

}
وظيفته:

- تخزين المهام المكتملة في قائمة مرتبطة (كل مهمة تشير إلى التي تليها).
- عند نقل مهمة من "المهام النشطة" إلى "المكتملة"، تُحذف من المصفوفة وتُضاف هنا.

  1.3. كلاس QueueTask (قائمة الانتظار للمهام العاجلة)

class QueueTask
{
public static Task[] tasks = new Task[100]; // مصفوفة ثابتة (حجمها 100 مهمة)
public static int countQ = 0; // عدد المهام العاجلة الحالي

    // دالة إضافة مهمة عاجلة (تضاف في النهاية)
    public static void Enqueue(Task task)
    {
        tasks[countQ] = task; // تخزين المهمة في الموقع الحالي
        countQ++; // زيادة العداد
    }

    // دالة عرض المهام العاجلة (تُعرض حسب ترتيب الإضافة)
    public void DisplayingUrgentTasks()
    {
        for (int i = 0; i < countQ; i++)
        {
            Console.WriteLine($"مهمة عاجلة ({i+1}): {tasks[i].Name}");
        }
    }

    // دالة إنشاء مهمة عاجلة (تسأل المستخدم عن التفاصيل)
    public void UrgentTaskQueue()
    {
        Console.Write("اسم المهمة العاجلة: ");
        string name = Console.ReadLine();

        Console.Write("الأولوية (1-عاجلة، 2-متوسطة، 3-عادية): ");
        int priority = int.Parse(Console.ReadLine());

        Console.Write("التاريخ (yyyy-mm-dd): ");
        DateOnly date = DateOnly.Parse(Console.ReadLine());

Task newTask = new Task(name, priority, date);
Enqueue(newTask); // إضافتها إلى قائمة الانتظار
}
}
وظيفته:

- إدارة المهام العاجلة بنظام FIFO (أول مهمة تُضاف هي أول مهمة تُعرض).
- المهام تُخزن في مصفوفة ثابتة (حجمها 100).

  1.4. الكلاس الرئيسي `Program`

class Program
{
static Task[] Tasks = new Task[100]; // مصفوفة المهام النشطة
static int taskCount = 0; // عدد المهام الحالي
static QueueTask urgentQueue = new QueueTask(); // كائن المهام العاجلة

    static void Main(string[] args)
    {
        LinkedList completedTasks = new LinkedList(); // قائمة المهام المكتملة
        bool isRunning = true;

        while (isRunning) // حلقة البرنامج الرئيسية
        {

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: AddTask(); break;
                case 2: DisplayTasks(); break;
                case 3: DeleteTask(); break;
                case 4: SortByPriority(); break;
                case 5: SortByDate(); break;
                case 6: CompleteTask(completedTasks); break;
                case 7: completedTasks.DisplayCompleteTask(); break;
                case 8: urgentQueue.UrgentTaskQueue(); break;
                case 9: urgentQueue.DisplayingUrgentTasks(); break;
                case 0: isRunning = false; break;
                default: break;
            }
        }
    }

وظيفته :
الدالة الرئيسية Main:
تقرأ القائمة الرئيسية وتقرأ اختيار المستخدم وتنفذ الوظيفة المطلوبة

الدوال المساعدة :
مثل انشاء مهمة جديدة واضافتها للمصفوفة, حذف مهمة من المصفوفة, ترتيب المهمام حسب الاولولية باستخدام bubble sorts, الانتقال من المهمة النشطة الى المكتملة

الخلاصة :
الهدف من المشروع هو ادارة المهمام االيومية (to do list)
المميزات :
عرض واضافة وحذف المهام وفرزها حسب الاولوية او التاريخ ونقل المهام المكتملة الى قائمة منفصلة واخيرا معالجة المهام المهمة بنظام اول دخل هو اول خرج
