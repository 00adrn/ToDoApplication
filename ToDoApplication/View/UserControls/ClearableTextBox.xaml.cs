using System.Windows;
using System.Windows.Controls;

namespace ToDoApplication.View.UserControls;

public partial class ClearableTextBox : UserControl
{
    public ClearableTextBox()
    {
        InitializeComponent();
    }

    private void btn_Clear(object sender, RoutedEventArgs e)
    {
        txtInput.Clear();
        txtInput.Focus();
    }
}