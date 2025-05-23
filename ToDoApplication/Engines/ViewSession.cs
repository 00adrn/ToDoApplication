using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Windows.Documents;
using ToDoApplication.Engines;

namespace ToDoApplication.View;

public class ViewSession: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler?  PropertyChanged;
    public ObservableCollection<TaskItem> tasks {get; set;}
    public int taskCount {get; set;}
    
    public ViewSession()
    {
        taskCount = 0;
        tasks = new ObservableCollection<TaskItem>();
    }
    
    public void AddTask(string title, string description, string date)
    {
        Console.WriteLine($"Added task {title}, date:{date}, description:{description}");
        tasks.Add(new TaskItem(title, description, date));
        Console.WriteLine("\nCurrent Tasks:");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"Task #{i+1} Name: {tasks[i]._itemName}");
            Console.WriteLine($"Description: {tasks[i]._itemDescription}");
            Console.WriteLine($"Due Date: {tasks[i]._dueDate}");
        }
        taskCount++;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(tasks)));
    }
}