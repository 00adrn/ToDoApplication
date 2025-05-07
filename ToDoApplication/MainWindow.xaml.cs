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
using ToDoApplication.View;

namespace ToDoApplication;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private ViewSession _viewSession = new ViewSession();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = _viewSession;
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

    private void btn_Create(object sender, RoutedEventArgs e)
    {
        _viewSession.AddTask("Test Task", "This is a test task", 20251002);
    }
}