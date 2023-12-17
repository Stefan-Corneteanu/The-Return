using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Actions/Read")]
public class Read : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        //check item in player's current location
        if (ReadItem(controller, controller.player.currentLocation.items, noun))
        {
            return;
        }

        //check item in player's inventory
        if (ReadItem(controller, controller.player.inventory, noun))
        {
            return;
        }

        if (noun.Trim().Length == 0)
        {
            controller.currentText.text = "<color=#FF0000FF>" + "You must type an item name to perform this action!" + "</color>";
        }
        else
        {
            controller.currentText.text = "<color=#FF0000FF>" + "There is no " + noun + " around here!" + "</color>";
        }
        
    }

    private bool ReadItem(GameController controller, List<Item> items, string itemName)
    {
        foreach (Item item in items)
        {
            if (item.itemName == itemName)
            {
                if (controller.player.CanReadItem(item) && item.InteractWith(controller, "read"))
                {
                    return true;
                }
                controller.currentText.text = "<color=#FF0000FF>" + "You cannot read the " + itemName + "!</color>";
                return true;
            }
        }
        return false;
    }
}
