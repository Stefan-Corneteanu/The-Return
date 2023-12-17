using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public string locationName;

    [TextArea]
    public string description;

    public Connection[] connections;

    public List<Item> items = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetConnetionsText()
    {
        string result = "";
        foreach (Connection con in connections)
        {
            if (con.connectionEnabled)
            {
                result += con.description+"\n";
            }
        }
        return result;
    }

    public Connection GetConnection(string connectionNoun)
    {
        foreach (Connection con in connections)
        {
            if (con.connectionName.ToLower() == connectionNoun.ToLower())
            {
                return con;
            }
        }
        return null;
    }

    public string GetItemsText()
    {

        List<Item> enabledItems = items.FindAll(delegate (Item item) 
        {
            return item.itemEnabled;
        });

        if (enabledItems.Count == 0)
        {
            return "";
        }

        string res = "You see ";
        for (int i = 0; i < enabledItems.Count; i++)
        {
            res += enabledItems[i].description;
            if (i != enabledItems.Count - 1)
            {
                res += ", ";
            }
            if (i == enabledItems.Count - 2)
            {
                res += "and ";
            }
        }
        res += "\n";
        return res;
    }

    public Item FindItemByName(string name)
    {
        foreach (Item item in items)
        {
            if (item.itemName.ToLower() == name.ToLower() && item.itemEnabled)
            {
                return item;
            }
        }
        return null;
    }
}
