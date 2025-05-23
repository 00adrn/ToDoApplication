using System.Windows.Controls;
using Microsoft.Win32;
using ToDoApplication.Engines;

namespace ToDoApplication.View.UserControls;

public partial class TaskList : UserControl
{
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

    public int taskNum
    {
        get;
        set;
    }

    public TaskList(ViewSession session)
    {
        InitializeComponent();
        TaskItem task = session.tasks[session.tasks.Count - 1];
        taskNameText = task._itemName;
        taskDescText = task._itemDescription;
        taskDateText = task._dueDate;
        taskNum = session.taskCount - 1;
    }
}