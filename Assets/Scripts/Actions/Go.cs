using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Actions/Go")]
public class Go : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (noun.Trim().Length == 0)
        {
            controller.currentText.text = "<color=#FF0000FF>" + "You must type an item name to perform this action!" + "</color>";
            return;
        }
        if (controller.player.ChangeLocation(noun))
        {
            controller.DisplayLocation();
        }
        else
        {
            if (controller.player.currentLocation.locationName.ToLower() == "chapel")
            {
                Item snake = controller.player.currentLocation.FindItemByName("serpent");
                if (snake!=null && snake.itemEnabled)
                {
                    controller.currentText.text = "<color=#FF0000FF>" + "The snake has blocked all entraces in the chapel! You have to kill it!" + "</color>";
                }
            }
            else 
            {
                controller.currentText.text = "<color=#FF0000FF>" + "You can't go that way!" + "</color>";
            }
        }
    }
}
