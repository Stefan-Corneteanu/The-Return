using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Actions/Get")]
public class Get : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        foreach (Item item in controller.player.currentLocation.items)
        {
            if (item.itemEnabled && item.itemName == noun)
            {
                if (item.playerCanTake)
                {
                    controller.player.inventory.Add(item);
                    controller.player.currentLocation.items.Remove(item);
                    controller.currentText.text = "You take the " + noun;
                    return;
                }
                else
                {
                    controller.currentText.text = "<color=#FF0000FF>" + "You cannot take the " + noun + "</color>";
                    return;
                }
            }
        }

        if (noun.Trim().Length == 0)
        {
            controller.currentText.text = "<color=#FF0000FF>" + "You must type an item name to perform this action!" + "</color>";
        }
        else
        {
            controller.currentText.text = "<color=#FF0000FF>" + "There is no " + noun + " here!" + "</color>";
        }
        
    }
}
