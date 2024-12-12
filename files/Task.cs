namespace files;

public class Task
{
    public Task(string taskName, Department toDepartment)
    {
        Name = taskName;
        ToDepartment = toDepartment;
    }

    public string Name { get; set; }

    public Department ToDepartment { get; set; }
}