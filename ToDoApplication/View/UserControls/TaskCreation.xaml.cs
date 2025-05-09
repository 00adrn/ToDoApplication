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

namespace ToDoApplication.View.UserControls;

public partial class TaskCreation : UserControl
{
    public TaskCreation()
    {
        InitializeComponent();
    }

    public string taskText
    {
        get
        {
            return tboxTaskName.Text;
        }
        set
        {
            tboxTaskName.Text = value;
        }
    }
    
    public string dateText
    {
        get
        {
            return tboxDate.Text;
        }
        set
        {
            tboxDate.Text = value;
        }
    }
    
    public string descriptionText
    {
        get
        {
            return tboxDescription.Text;
        }
        set
        {
            tboxDescription.Text = value;
        }
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

    private void DateBox_Changed(object sender, RoutedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        
        if (textBox.Text.Length == 2 || textBox.Text.Length == 5)
        {
            textBox.Text += '/';
        }
        if (textBox.Text.Length > 10)
        {
            textBox.Text = textBox.Text.Substring(0, 10);
        }
        
        textBox.CaretIndex = textBox.Text.Length;
    }
}