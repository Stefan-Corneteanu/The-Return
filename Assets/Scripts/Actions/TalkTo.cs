using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Actions/TalkTo")]
public class TalkTo : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (TalkToItem(controller, controller.player.currentLocation.items, noun))
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

    private bool TalkToItem(GameController controller, List<Item> items, string itemName)
    {
        foreach (Item item in items)
        {
            if (item.itemName == itemName)
            {
                if (controller.player.CanTalkToItem(item))
                {
                    if (item.itemEnabled && item.InteractWith(controller, "talkto"))
                    {
                        return true;
                    }
                }
                else
                {
                    continue;
                }
                controller.currentText.text = "<color=#FF0000FF>" + "The " + itemName + " does not respond" + "</color>";
                return true;
            }
        }
        return false;
    }
}
