using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;

    [TextArea]
    public string description;

    public bool playerCanTake;
    public bool itemEnabled = true;
    public bool playerCanTalkTo = false;
    public bool playerCanGiveTo = false;
    public bool playerCanRead = false;

    public Interaction[] interactions;

    public Item targetItem = null;

    public bool InteractWith(GameController controller,string actionKeyword, string noun="")
    {
        foreach (Interaction interaction in interactions)
        {
            if (interaction.action.keyword == actionKeyword)
            {
                if (noun != "" && noun.ToLower() != interaction.textToMatch.ToLower())
                {
                    continue;
                }
                foreach (Item disableItem in interaction.itemsToDisable)
                {
                    disableItem.itemEnabled = false;
                }
                foreach (Item enableItem in interaction.itemsToEnable)
                {
                    enableItem.itemEnabled = true;
                }
                foreach (Connection disableCon in interaction.connectionsToDisable)
                {
                    disableCon.connectionEnabled = false;
                }
                foreach (Connection enableCon in interaction.connectionsToEnable)
                {
                    enableCon.connectionEnabled = true;
                }

                controller.currentText.text = interaction.response;
                if (interaction.teleportDestination != null)
                {
                    controller.player.TeleportTo(interaction.teleportDestination);
                }
                controller.DisplayLocation(true);
                return true;
            }
        }
        return false;
    }
}
