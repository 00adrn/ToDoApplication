using System.Windows.Controls;
using ToDoApplication.Engines;

namespace ToDoApplication.View.UserControls;

public partial class CompletedTask : UserControl
{
    public string taskName
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

    public CompletedTask()
    {
        InitializeComponent();
    }
}