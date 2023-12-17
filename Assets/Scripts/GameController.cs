using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Player player;
    public InputField textEntryField;
    public Text logText;
    public Text currentText;
    public Action[] actions;
    private List<string> cmdHistory = new List<string>();
    private int cmdHistoryIdx = -1;

    [TextArea]
    public string introText;
    // Start is called before the first frame update
    void Start()
    {
        logText.text = introText;
        DisplayLocation();
        textEntryField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            cmdHistoryIdx++;
            if (cmdHistoryIdx < cmdHistory.Count)
            {
                textEntryField.text = cmdHistory[cmdHistoryIdx];
            }
            else
            {
                cmdHistoryIdx = cmdHistory.Count;
                textEntryField.text = "";
                
            }
            textEntryField.ActivateInputField();
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            cmdHistoryIdx--;
            if (cmdHistoryIdx >= 0)
            {
                textEntryField.text = cmdHistory[cmdHistoryIdx];
            }
            else
            {
                cmdHistoryIdx = -1;
                textEntryField.text = "";
            }
            textEntryField.ActivateInputField();
        }
    }

    public void DisplayLocation(bool additive=false)
    {
        string description = player.currentLocation.description+"\n";
        description += player.currentLocation.GetConnetionsText();
        description += player.currentLocation.GetItemsText();
        if (additive)
        {
            currentText.text +="\n" + description;
        }
        else
        {
            currentText.text = description;
        }
    }

    public void OnTextEntered()
    {
        LogCurrentText();
        ProcessInput(textEntryField.text);
        cmdHistory.Insert(0, textEntryField.text);
        cmdHistoryIdx = -1;
        textEntryField.text = "";
        textEntryField.ActivateInputField();
    }

    void LogCurrentText()
    {
        logText.text += "\n\n";
        logText.text += currentText.text;

        logText.text += "\n\n";
        logText.text += "<color=#64CC33FF>"+textEntryField.text+"</color>";
    }

    void ProcessInput(string input)
    {
        input = input.ToLower();
        string[] words = input.Split(null,2);

        foreach(Action action in actions)
        {
            if (action.keyword.ToLower() == words[0])
            {
                if (words.Length > 1)
                {
                    action.RespondToInput(this, words[1].Trim());
                }
                else
                {
                    action.RespondToInput(this, "");
                }
                return;
            }
        }


        currentText.text = "Nothing happens! (Having trouble? Type \"Help\")";
    }
}
