using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Inventory")]
public class Inventory : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {

        List<Item> enabledItems = controller.player.inventory.FindAll(delegate (Item item)
        {
            return item.itemEnabled;
        });

        if (enabledItems.Count == 0)
        {
            controller.currentText.text = "Your inventory is currently empty.";
            return;
        }

        string res = "You have ";

        for (int i = 0; i < enabledItems.Count; i++)
        {
            res += "a " + enabledItems[i].itemName;
            if (i != enabledItems.Count - 1)
            {
                res += ", ";
            }
            if (i == enabledItems.Count - 2)
            {
                res += "and ";
            }
        }

        controller.currentText.text = res;
    }
}
