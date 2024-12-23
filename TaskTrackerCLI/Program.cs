using TaskTrackerCLI.Services;

namespace TaskTrackerCLI;

class Program
{
    static void Main(string[] args)
    {
        FileRepository repository = new FileRepository(@"DB\data.json");
        AppTaskService appTaskService = new AppTaskService(repository);

        Console.WriteLine("1. Add new task;");
        Console.WriteLine("2. Update task;");
        Console.WriteLine("3. Delete task;");
        Console.WriteLine("4. List tasks;");

        int input = Convert.ToInt32(Console.ReadLine());
        switch (input)
        {
            case 1:
                Console.WriteLine("Enter new task description...");
                string description = Console.ReadLine();
                try
                {
                    appTaskService.AddTask(description);
                    Console.WriteLine("New task successfully added");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            case 2:
                Console.WriteLine("Enter task id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter new description: ");
                string newDescription = Console.ReadLine();
                try
                {
                    appTaskService.UpdateTask(id, newDescription);
                    Console.WriteLine($"Task with id {id} successfully updated");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            case 3:
                Console.WriteLine("Enter task id: ");
                id = Convert.ToInt32(Console.ReadLine());
                try
                {
                    appTaskService.DeleteTask(id);
                    Console.WriteLine($"Task with id {id} successfully deleted");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
        }
    }
}
