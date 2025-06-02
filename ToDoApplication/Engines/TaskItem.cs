using System.Diagnostics;

namespace ToDoApplication.Engines;

public class TaskItem
{
    public string _itemName { get; set; }
    public string _itemDescription { get; set; }
    public string _dueDate { get; set; }    
    public bool _itemStatus { get; set; }
    
    public TaskItem (string itemName, string itemDescription, string date) { _itemName = itemName; _itemDescription = itemDescription; _itemStatus = false; _dueDate = date; }

    public void RevertStatus()
    {
        _itemStatus = !_itemStatus;
    }
}