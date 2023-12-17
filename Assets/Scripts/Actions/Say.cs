using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Say")]
public class Say : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (SayToItem(controller, controller.player.currentLocation.items, noun))
        {
            return;
        }

        if (noun.Trim().Length == 0)
        {
            controller.currentText.text = "<color=#FF0000FF>" + "You must type an item name to perform this action!" + "</color>";
        }
        else
        {
            controller.currentText.text = "<color=#FF0000FF>" + noun + " echoes in the void with no response!" + "</color>";
        }
    }

    private bool SayToItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (controller.player.CanTalkToItem(item))
            {
                if (item.InteractWith(controller, "say", noun))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
