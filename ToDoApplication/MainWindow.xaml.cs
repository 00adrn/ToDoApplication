using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using ToDoApplication.View;
using ToDoApplication.View.UserControls;

namespace ToDoApplication;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged
{
    private ViewSession _viewSession = new ViewSession();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }
    public event PropertyChangedEventHandler?  PropertyChanged;

    private void TextBox_GainFocus(object sender, RoutedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        if (textBox.Text == (string)textBox.Tag)
        {
            textBox.Text = "";
            textBox.Foreground = Brushes.Black;
        }
    }

    private void TextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        if (textBox.Text == null || textBox.Text == "")
        {
            textBox.Text = (string)textBox.Tag;
            textBox.Foreground = Brushes.Gray;
        }
    }

    private void btn_CreateTask(object sender, RoutedEventArgs e)
    {
        _viewSession.AddTask(TaskMake.taskText, TaskMake.descriptionText, TaskMake.dateText);
        var newTaskListItem = new TaskList();
        newTaskListItem.taskNameText = TaskMake.taskText;
        newTaskListItem.taskDescText = TaskMake.descriptionText;
        newTaskListItem.taskDateText = TaskMake.dateText;
        SPTasks.Children.Add(newTaskListItem);
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("_viewSession"));
    }
}