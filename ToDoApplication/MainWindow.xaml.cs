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
using ToDoApplication.Engines;
using ToDoApplication.View.UserControls;
using Path = System.Windows.Shapes.Path;

namespace ToDoApplication;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private ViewSession _viewSession = new ViewSession();
    public event PropertyChangedEventHandler?  PropertyChanged;
    public MainWindow()
    {
        InitializeComponent();
        DataContext = _viewSession;
        LoadTasks();
    }

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
        if (TaskMake.nameText == "Enter Task Name" || (TaskMake.dateText == null) || TaskMake.descriptionText == "Enter Description Here...")
        {
            return;
        }
        var newTaskListItem = new TaskList(_viewSession.AddTask(TaskMake.nameText, TaskMake.descriptionText, TaskMake.dateText), _viewSession);
        _viewSession.WriteTask(TaskMake.nameText, TaskMake.descriptionText, TaskMake.dateText);
        SPTasks.Children.Add(newTaskListItem);
        TaskMake.ResetInputs();
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("_viewSession"));
    }
    
    private void Window_MouseLeftClick(object sender, MouseButtonEventArgs e)
    {
        Console.WriteLine(TaskMake.dateText);
        DragMove();
    }

    private void Window_WindowClosed(object sender, EventArgs e)
    {
        Close();
    }

    private void Window_ToFullscreen(object sender, EventArgs e)
    {
        if (WindowState != WindowState.Maximized)
            WindowState = WindowState.Maximized;
        else
            WindowState = WindowState.Normal;
    }

    private void Window_Minimize(object sender, EventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void LoadTasks()
    {
        foreach (TaskItem task in _viewSession.tasks)
        {
            SPTasks.Children.Add(new TaskList(new TaskItem(task._itemName, task._itemDescription, task._dueDate), _viewSession));
            TaskMake.ResetInputs();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("_viewSession"));
        }
    }
}