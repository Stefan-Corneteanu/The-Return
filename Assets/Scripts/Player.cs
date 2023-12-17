using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Location currentLocation;
    public List<Item> inventory = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool ChangeLocation(string connectionNoun)
    {
        Connection con = currentLocation.GetConnection(connectionNoun);
        if (con != null)
        {
            if (con.connectionEnabled)
            {
                currentLocation = con.location;
                return true;
            }
        }
        return false;
    }

    public void TeleportTo(Location destination)
    {
        this.currentLocation = destination;
    }

    internal bool CanGiveToItem(Item item)
    {
        return item.itemEnabled && item.playerCanGiveTo && currentLocation.items.Contains(item);
    }

    internal bool CanReadItem(Item item)
    {
        return item.itemEnabled && item.playerCanRead;
    }

    internal bool CanTalkToItem(Item item)
    {
        return item.itemEnabled && item.playerCanTalkTo && currentLocation.items.Contains(item);
    }

    internal bool CanUseItem(Item item)
    {
        return item.targetItem == null 
            || (inventory.Contains(item.targetItem) && item.targetItem.itemEnabled) 
            || (currentLocation.items.Contains(item.targetItem) && item.targetItem.itemEnabled);
    }

    public bool HasItemByName(string name)
    {
        foreach (Item item in inventory)
        {
            if (item.itemName.ToLower() == name.ToLower() && item.itemEnabled)
            {
                return true;
            }
        }
        return false;
    }
}
