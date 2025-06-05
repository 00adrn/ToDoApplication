using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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

    public bool completedListIsEmpty { get { if (completedTasks.Count == 0) { return true; } else { return false; } }
        private set { }
    }
    
    public bool taskListIsEmpty { get { if (tasks.Count == 0) { return true; } else { return false; } }
        private set { }
    }

    public ViewSession()
    {
        taskCount = 0;
        completedTasks = new ObservableCollection<TaskItem>();
        tasks = new ObservableCollection<TaskItem>();
        //opening file
        try
        {
            StreamReader fileRead = new StreamReader("taskDB.txt");
            string readTask = fileRead.ReadLine();
            string[] taskInfo = readTask.Split('|');
            AddTask(taskInfo[0], taskInfo[1], taskInfo[2]);
            fileRead.Close();
        }
        catch
        {
            Console.Write("Path not found");
        }
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
        if (tasks.Count == 1) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(taskListIsEmpty)));}
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(tasks)));
        return newTask;
    }

    public void RemoveTask(TaskItem removedTask)
    {
        tasks.Remove(removedTask);
        if (tasks.Count == 0) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(taskListIsEmpty)));}
    }

    public void CompleteTask(TaskItem removedTask)
    {
        removedTask._completeDate = "Completed " + DateTime.Now.ToString("MM/dd/yyyy");
        completedTasks.Add(removedTask);
        tasks.Remove(removedTask);
        if (tasks.Count == 0) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(taskListIsEmpty)));}
        if(completedTasks.Count == 1) {PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(completedListIsEmpty)));}
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(completedTasks)));
    }
}