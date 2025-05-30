﻿using System.ComponentModel;
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
        if (TaskMake.nameText == "Enter Task Name" || TaskMake.dateText.Length != 10 || TaskMake.dateText == "MM/DD/YYYY" || TaskMake.descriptionText == "Enter Description Here...")
        {
            return;
        }
        _viewSession.AddTask(TaskMake.nameText, TaskMake.descriptionText, TaskMake.dateText);
        var newTaskListItem = new TaskList(_viewSession);
        SPTasks.Children.Add(newTaskListItem);
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("_viewSession"));
    }
    
}