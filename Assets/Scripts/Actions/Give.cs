using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Actions/Give")]
public class Give : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (!controller.player.HasItemByName(noun))
        {
            controller.currentText.text = "<color=#FF0000FF>" + "You do not have any " + noun + " in your inventory!" + "</color>";
            return;
        }

        if (GiveToItem(controller, controller.player.currentLocation.items, noun))
        {
            return;
        }

        if (noun.Trim().Length == 0)
        {
            controller.currentText.text = "<color=#FF0000FF>" + "You must type an item name to perform this action!" + "</color>";
        }
        else
        {
            controller.currentText.text = "<color=#FF0000FF>" + "Nobody in " + controller.player.currentLocation.locationName.ToLower() + " wants your "
        + noun + "</color>";
        }
        
    }

    private bool GiveToItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (controller.player.CanGiveToItem(item))
            {
                if (item.InteractWith(controller, "give", noun))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
