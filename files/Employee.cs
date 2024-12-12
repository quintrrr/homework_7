namespace files;

public class Employee
{
    public Employee(string name, string position, Department department)
    {
        Name = name;
        Job = position;
        Subordinates = new List<Employee>();
        Department = department;
    }

    public string Name { get; set; }

    public string Job { get; set; }

    public List<Employee> Subordinates { get; set; }

    public Department Department { get; set; }

    public bool assignTask(Task task, Employee to)
    {
        Console.WriteLine($"От {Name} даётся задача \"{task.Name}\" {to.Name}");
        if (task.ToDepartment == to.Department && Subordinates.Contains(to))
        {
            Console.WriteLine($"{to.Name} берёт задачу \"{task.Name}\"\n");
            return true;
        }

        Console.WriteLine($"{to.Name} не берёт задачу \"{task.Name}\"\n");
        return false;
    }
}