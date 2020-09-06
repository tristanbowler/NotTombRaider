using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GamepadsManager : MonoBehaviour
{


    [Header("REFERENCES")]
    public GamepadController  leftGamepad;
    public GamepadController rightGamepad;

    public void Start()
    {
        int highestConnectedGamepad;
        try
        {
            highestConnectedGamepad = Hinput.gamepad
                .Where(gamepad => gamepad.isConnected)
                .Select(gamepad => gamepad.index)
                .Max();

            if (highestConnectedGamepad != 1)
            {
                Debug.LogError("Two gamepads must be connected");
            }
        }
        catch
        {
            Debug.LogError("There was an error sensing for gamepads.");
            return;
        }
    }

    



}
