using System.Diagnostics;

namespace ToDoApplication.Engines;

public class ListItem
{
    public string _itemName
    {
        get { return _itemName; } set { _itemName = value; }
    }

    public string _itemDescription
    {
        get { return _itemDescription;} set { _itemDescription = value; }
    }

    public bool _itemStatus
    {
        get { return _itemStatus; } set { _itemStatus = value; }
    }

    public ListItem (string itemName, string itemDescription) { _itemName = itemName; _itemDescription = itemDescription; _itemStatus = false; }

    public void RevertStatus()
    {
        if (_itemStatus) { _itemStatus = false; }
        else { _itemStatus = true; }
    }
}