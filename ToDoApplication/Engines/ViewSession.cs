using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Windows.Documents;
using Engine;
using ToDoApplication.Engines;

namespace ToDoApplication.View;

public class ViewSession : BaseNotification
{
    public ObservableCollection<TaskItem> tasks {get; set;}
    
    public ViewSession()
    {
        tasks = new ObservableCollection<TaskItem>();
    }
    public void AddTask(string title, string description, string date)
    {
        tasks.Add(new TaskItem(title, description, date));
        Console.WriteLine($"Added task {title}, due {date}, description: \n {description}");
    }
}