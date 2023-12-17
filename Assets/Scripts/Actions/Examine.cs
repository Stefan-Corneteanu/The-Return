using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =("Actions/Examine"))]
public class Examine : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        //check item in player's current location
        if(CheckItem(controller, controller.player.currentLocation.items, noun))
        {
            return;
        }

        //check item in player's inventory
        if (CheckItem(controller, controller.player.inventory, noun))
        {
            return;
        }

        if (noun.Trim().Length == 0)
        {
            controller.currentText.text = "<color=#FF0000FF>" + "You must type an item name to perform this action!" + "</color>";
        }
        else
        {
            controller.currentText.text = "<color=#FF0000FF>" + "There is no " + noun + " around here" + "</color>";
        }
    }

    private bool CheckItem(GameController controller, List<Item> items, string itemName)
    {
        foreach(Item item in items)
        {
            if (item.itemName == itemName)
            {
                if (item.itemEnabled && item.InteractWith(controller, "examine"))
                {
                    return true;
                }
                controller.currentText.text = "<color=#FF0000FF>" + "There's nothing interesting about the " + itemName + "</color>";
                return true;
            }
        }
        return false;
    }
}
