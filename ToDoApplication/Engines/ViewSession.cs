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
    public ObservableCollection<TaskItem> completedTasks {get; set;}
    public int taskCount {get; set;}
    
    public ViewSession()
    {
        taskCount = 0;
        completedTasks = new ObservableCollection<TaskItem>();
        tasks = new ObservableCollection<TaskItem>();
    }
    
    public TaskItem AddTask(string title, string description, string date)
    {
        Console.WriteLine($"Added task {title}, date:{date}, description:{description}");
        TaskItem newTask = new TaskItem(title, description, date);
        tasks.Add(newTask);
        Console.WriteLine("\nCurrent Tasks:");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"Task #{i+1} Name: {tasks[i]._itemName}");
            Console.WriteLine($"Description: {tasks[i]._itemDescription}");
            Console.WriteLine($"Due Date: {tasks[i]._dueDate}\n \n");
        }
        taskCount++;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(tasks)));
        return newTask;
    }

    public void RemoveTask(TaskItem removedTask)
    {
        foreach (TaskItem task in tasks)
        {
            if (task == removedTask)
            {
                tasks.Remove(task);
                break;
            }
        }
    }

    public void CompleteTask(TaskItem removedTask)
    {
        foreach (TaskItem task in tasks)
        {
            if (task == removedTask)
            {
                completedTasks.Add(task);
                tasks.Remove(task);
                break;
            }
        }
        
        
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(completedTasks)));
    }
}