using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Documents;
using ToDoApplication.Engines;

namespace ToDoApplication.View;

public class ViewSession: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler?  PropertyChanged;
    public ObservableCollection<TaskItem> tasks {get; set;}
    public ObservableCollection<TaskItem> completedTasks {get; set;}
    public double maxHeight { get; private set; }
    public double maxWidth { get; private set; }


    public bool completedListIsEmpty { get { if (completedTasks.Count == 0) { return true; } else { return false; } }
        private set { }
    }
    
    public bool taskListIsEmpty { get { if (tasks.Count == 0) { return true; } else { return false; } }
        private set { }
    }

    public ViewSession()
    {
        maxHeight = SystemParameters.WorkArea.Height;
        maxWidth = SystemParameters.WorkArea.Width;
        
        completedTasks = new ObservableCollection<TaskItem>();
        tasks = new ObservableCollection<TaskItem>();
        //opening file
        try
        {
            using (StreamReader fileRead = new StreamReader(GetDataPath()))
            {
                string? lineRead;
                string[] parsedInfo;
                while ((lineRead = fileRead.ReadLine()) != null)
                {
                    parsedInfo = lineRead.Split('|');
                    if (parsedInfo[3] == "inprogress")
                    {
                        AddTask(parsedInfo[0], parsedInfo[1], parsedInfo[2]);
                    } else if (parsedInfo[3] == "completed")
                    {
                        completedTasks.Add(new TaskItem(parsedInfo[0], parsedInfo[1], parsedInfo[2]));
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.Write("Path not found");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
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
        if (tasks.Count == 1) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(taskListIsEmpty)));}
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(tasks)));
        return newTask;
    }

    public void RemoveTask(TaskItem removedTask)
    {
        tasks.Remove(removedTask);
        UpdateTaskDB(removedTask, false);
        if (tasks.Count == 0) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(taskListIsEmpty)));}
    }

    public void CompleteTask(TaskItem removedTask)
    {
        removedTask._completeDate = "Completed " + DateTime.Now.ToString("MM/dd/yyyy");
        completedTasks.Add(removedTask);
        tasks.Remove(removedTask);
        UpdateTaskDB(removedTask, true);
        if (tasks.Count == 0) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(taskListIsEmpty)));}
        if(completedTasks.Count == 1) {PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(completedListIsEmpty)));}
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(completedTasks)));
    }

    private string GetDataPath()
    {
        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "taskDB.txt");
    }

    public void WriteTask(string title, string description, string date)
    {
        try
        {
            using (StreamWriter fileWrite = new StreamWriter(GetDataPath(), true))
            {
                fileWrite.WriteLine(title + '|' + description + '|' + date + '|' + "inprogress");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void UpdateTaskDB(TaskItem updatedTask, bool completed)
    {
        
        List<string[]> readLines = new List<string[]>();
        string? readLine;
        using (StreamReader fileRead = new StreamReader(GetDataPath()))
            while ((readLine = fileRead.ReadLine()) != null){ readLines.Add(readLine.Split('|'));}

        for (int i = 0; i < readLines.Count; i++)
        {
            if (readLines[i][0] == updatedTask._itemName && readLines[i][3] == "inprogress")
            {
                if(completed) { readLines[i][3] = "completed";}
                else {readLines.RemoveAt(i);}
                break;
            }
        }
        using (StreamWriter fileWrite = new StreamWriter(GetDataPath()))
            for (int i = 0; i < readLines.Count; i++) { fileWrite.WriteLine(readLines[i][0]+"|"+readLines[i][1]+"|"+readLines[i][2]+"|"+readLines[i][3]); }
    }
}