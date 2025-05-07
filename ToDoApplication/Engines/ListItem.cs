using System.Diagnostics;

namespace ToDoApplication.Engines;

public class TaskItem
{
    public string _itemName
    {
        get { return _itemName; } set { _itemName = value; }
    }
    
    public string _itemDescription
    {
        get { return _itemDescription;} set { _itemDescription = value; }
    }
    
    public int _dueDate { get; set; }    
    public bool _itemStatus
    {
        get { return _itemStatus; } set { _itemStatus = value; }
    }
    
    public TaskItem (string itemName, string itemDescription, int date) { _itemName = itemName; _itemDescription = itemDescription; _itemStatus = false; _dueDate = date; }

    public void RevertStatus()
    {
        _itemStatus = !_itemStatus;
    }
}