using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Actions/ObserveLocation")]
public class ObserveLocation : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        controller.DisplayLocation();
    }
}
