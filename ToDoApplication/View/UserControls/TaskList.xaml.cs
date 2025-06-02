using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Win32;
using ToDoApplication.Engines;

namespace ToDoApplication.View.UserControls;

public partial class TaskList : UserControl
{
    private ViewSession taskSession;
    private TaskItem taskItem;
    public string taskNameText
    {
        get
        {
            return TBlockTaskName.Text;
        }
        set
        {
            TBlockTaskName.Text = value;
        }
    }

    public string taskDescText
    {
        get
        {
            return TBlockTaskDesc.Text;
        }
        set
        {
            TBlockTaskDesc.Text = value;
        }
    }

    public string taskDateText
    {
        get
        {
            return TBlockTaskDate.Text;
        }
        set
        {
            TBlockTaskDate.Text = value;
        }
    }

    public void btn_InvokeDelete(Object sender, RoutedEventArgs e)
    {
        taskSession.RemoveTask(taskItem);
        var parent = this.Parent as StackPanel;
        parent.Children.Remove(this);
        Console.WriteLine($"Task --{taskNameText}-- Deleted\n \n");
    }

    public void btn_InvokeComplete(object sender, RoutedEventArgs e)
    {
        taskSession.CompleteTask(taskItem);
        var parent = this.Parent as StackPanel;
        parent.Children.Remove(this);
        Console.WriteLine($"Task --{taskNameText}-- Marked Complete\n \n");
    }

    public TaskList(TaskItem task, ViewSession session)
    {
        InitializeComponent();
        taskItem = task;
        taskSession = session;
        taskNameText = task._itemName;
        taskDescText = task._itemDescription;
        taskDateText = task._dueDate;
    }
}