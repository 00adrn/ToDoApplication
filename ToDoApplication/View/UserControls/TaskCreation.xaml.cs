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

    public string nameText
    {
        get
        {
            return TBoxEnterTaskName.Text;
        }
        set
        {
            TBoxEnterTaskName.Text = value;
        }
    }
    
    public string dateText
    {
        get
        {
            
            if(DBoxDate.SelectedDate == null) return null;
            string dateString = DBoxDate.SelectedDate.ToString();
            return dateString.Substring(0, dateString.Length - 12);
        }
        set
        {
            DBoxDate.SelectedDate = DateTime.Parse(value);
        }
    }
    
    public string descriptionText
    {
        get
        {
            return TBoxDescription.Text;
        }
        set
        {
            TBoxDescription.Text = value;
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

    private void DatePicker_SelectedDateChanged(object sender, RoutedEventArgs e)
    {
        if (dateText != null)
        {
            DBoxDate.Foreground = Brushes.Black;
        }
        else
        {
            DBoxDate.Foreground = Brushes.Gray;
        }
    }

    public void ResetInputs()
    {
        TBoxEnterTaskName.Text = (string)TBoxEnterTaskName.Tag;
        TBoxEnterTaskName.Text = (string)TBoxEnterTaskName.Tag;
        TBoxEnterTaskName.Foreground = Brushes.Gray;
        
        TBoxDescription.Text = (string)TBoxDescription.Tag;
        TBoxDescription.Text = (string)TBoxDescription.Tag;
        TBoxDescription.Foreground = Brushes.Gray;

        DBoxDate.SelectedDate = null;
    } 
    
}