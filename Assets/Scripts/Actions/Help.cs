using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Help")]
public class Help : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        switch (noun)
        {
            case "":
                {
                    controller.currentText.text = "Type a verb followed by a noun (e.g. \"Go North\")";
                    controller.currentText.text += "\nAllowed commands";
                    controller.currentText.text += "\nGo, Examine, Get, Give, Use, Inventory, Read, Say, TalkTo, ObserveLocation, Help, Quit";
                    controller.currentText.text += "\nFor more details on a command type help [command]";
                    break;
                }
            case "help":
                {
                    controller.currentText.text = "Type help for general help";
                    controller.currentText.text += "\nOr help [command] to find out more about a command";
                    break;
                }
            case "go":
                {
                    controller.currentText.text = "Move the player in a given direction";
                    controller.currentText.text += "\nAcceptable directions: North, South, East, West";
                    controller.currentText.text += "\nExample: Go North";
                    controller.currentText.text += "<color=#FF0000FF>"+"\nNot all directions will always be available!"+"</color>";
                    break;
                }
            case "get":
                {
                    controller.currentText.text = "Take an item from the location and puts it in your inventory";
                    controller.currentText.text += "\nExample: Get Staff";
                    break;
                }
            case "inventory":
                {
                    controller.currentText.text = "Display the items in your inventory";
                    break;
                }
            case "examine":
                {
                    controller.currentText.text = "Examine an item in your inventory";
                    controller.currentText.text += "\nExample: Examine Staff";
                    break;
                }
            case "use":
                {
                    controller.currentText.text = "Use an item in your inventory";
                    controller.currentText.text += "\nExample: Use Staff";
                    break;
                }
            case "talkto":
                {
                    controller.currentText.text = "Initiate a conversation with an item in the current location.";
                    controller.currentText.text += "\nExample: TalkTo Ferryman";
                    controller.currentText.text += "<color=#FF0000FF>" + "\nNot all items will answer back" + "</color>";
                    break;
                }
            case "say":
                {
                    controller.currentText.text = "Say some words, every item in the room will hear them";
                    controller.currentText.text += "\nExample: Say Hello";
                    break;
                }
            case "give":
                {
                    controller.currentText.text = "Give an item to anyone from the current location that accepts it";
                    controller.currentText.text += "\nExample: Give Staff";
                    break;
                }
            case "observelocation":
                {
                    controller.currentText.text = "Get the current location's description";
                    break;
                }
            case "read":
                {
                    controller.currentText.text = "Look for a readable item in the inventory and current location and read it";
                    controller.currentText.text += "\nExample: Read Staff";
                    break;
                }
            case "quit":
                {
                    controller.currentText.text = "Type \"quit\" to quit the game";
                    break;
                }
            default:
                {
                    controller.currentText.text = "<color=#FF0000FF>"+"Invalid command! Type help to see the allowed commands"+ "</color>";
                    break;
                }
        }
 
    }
}
