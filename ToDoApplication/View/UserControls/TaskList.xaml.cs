using System.Windows.Controls;

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

    public TaskList()
    {
        InitializeComponent();
    }
}