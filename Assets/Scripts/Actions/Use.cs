using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Actions/Use")]
public class Use : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        //use item in player's current location
        if (UseItem(controller, controller.player.currentLocation.items, noun))
        {
            return;
        }

        //use item in player's inventory
        if (UseItem(controller, controller.player.inventory, noun))
        {
            return;
        }

        if (noun.Trim().Length == 0)
        {
            controller.currentText.text = "<color=#FF0000FF>" + "You must type an item name to perform this action!" + "</color>";
        }
        else
        {
            controller.currentText.text = "<color=#FF0000FF>" + "There is no " + noun + " to use" + "</color>";
        }   
    }

    private bool UseItem(GameController controller, List<Item> items, string itemName)
    {
        foreach (Item item in items)
        {
            if (item.itemName == itemName)
            {
                if (controller.player.CanUseItem(item))
                {
                    if (item.itemName.ToLower()=="staff" && controller.player.currentLocation.locationName.ToLower()=="chapel" && controller.player.currentLocation.FindItemByName("serpent").itemEnabled)
                    {
                        controller.player.currentLocation.description = @"A dark ruined chapel. In the centre of a dark stone room a smashed statue, the plinth and lower half
of a robed figure. A giant dead snake lies on the floor, decapitated by your staff, golden coins spewing out of its neck";
                    }
                    if (item.itemEnabled && item.InteractWith(controller, "use"))
                    {
                        return true;
                    }
                }
                else if (!item.itemEnabled)
                {
                    continue;
                }

                controller.currentText.text = "<color=#FF0000FF>" + "There's no use for the " + itemName + "</color>";
                return true;
            }
        }
        return false;
    }
}
