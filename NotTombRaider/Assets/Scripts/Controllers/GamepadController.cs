using HinputClasses;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using XInputDotNetPure;

// Hinput class handling the visuals of a gamepad in the Example Scene.
public class GamepadController : MonoBehaviour
{
    [Header("OPTIONS")]
    public int index;
    public float stickDistance;
    public bool showTestingUI;

    [Header("STICK")]
    private Vector3 StickStartPosition;

    public float stickVertical { get; private set; }
    public float stickHorizontal { get; private set; }


    [Header("REFERENCES")]
    public GameObject testingUI;
    public GameObject leftStick;
    public GameObject connectedButton;
    [Space]
    public GameObject GreenHighlight;
    public GameObject RedHighlight;
    public GameObject BlueHighlight;
    public GameObject BlackHighlight;
    public GameObject WhiteHighlightLeft;
    public GameObject WhiteHighlightRight;

    [Header("EVENTS")]
    public UnityEvent GreenPressed;
    public UnityEvent RedPressed;
    public UnityEvent BluePressed;
    public UnityEvent BlackPressed;
    public UnityEvent WhiteLeftPressed;
    public UnityEvent WhiteRightPressed;




    private Gamepad gamepad { get { return Hinput.gamepad[index]; } }

    private void Start()
    {
        StickStartPosition = leftStick.transform.localPosition;
        testingUI.SetActive(showTestingUI);
    }

    private void Update()
    {
        if (showTestingUI)
        {
            UpdateStickPositions();
            UpdateAllButtonHighlights();
            CheckAllEvents();
        }
        else
        {
            UpdateStickPositions();
            CheckAllEvents();
        }
        
    }

    public bool CheckA()
    {
        if (gamepad.A.simplePress.pressed)
        {
            return true;
        }
        return false;
    }

    public bool CheckB()
    {
        if (gamepad.B.simplePress.pressed)
        {
            return true;
        }
        return false;
    }

    public bool CheckX()
    {
        if (gamepad.X.simplePress.pressed)
        {
            return true;
        }
        return false;
    }

    public bool CheckY()
    {
        if (gamepad.Y.simplePress.pressed)
        {
            return true;
        }
        return false;
    }


    private void CheckAllEvents()
    {
        CheckButtonEvent(gamepad.rightBumper, WhiteRightPressed);
        CheckButtonEvent(gamepad.leftBumper, WhiteLeftPressed);
        CheckButtonEvent(gamepad.Y, BlackPressed);
        CheckButtonEvent(gamepad.X, BluePressed);
        CheckButtonEvent(gamepad.B, RedPressed);
        CheckButtonEvent(gamepad.A, GreenPressed);
    }

    private void CheckButtonEvent(Pressable button, UnityEvent buttonEvent)
    {
        if (button.simplePress.pressed)
        {
            buttonEvent.Invoke();
        }
    }


    private void UpdateStickPositions()
    {
        stickVertical =  gamepad.leftStick.vertical;
        stickHorizontal = gamepad.leftStick.horizontal;
    }

    

    private void UpdateAllButtonHighlights()
    {
        connectedButton.SetActive(gamepad.isConnected);

        if (gamepad.isConnected)
        {
            leftStick.transform.localPosition = StickStartPosition + gamepad.leftStick.worldPositionCamera * stickDistance;

            UpdateButtonHighLight(gamepad.rightBumper, WhiteHighlightRight);
            UpdateButtonHighLight(gamepad.leftBumper, WhiteHighlightLeft);
            UpdateButtonHighLight(gamepad.Y, BlackHighlight);
            UpdateButtonHighLight(gamepad.X, BlueHighlight);
            UpdateButtonHighLight(gamepad.B, RedHighlight);
            UpdateButtonHighLight(gamepad.A, GreenHighlight);

        }
    }

    private void UpdateButtonHighLight(Pressable button, GameObject go)
    {
        if (button.simplePress.pressed)
        {
            go.SetActive(true);
        }
        else
        {
            go.SetActive(false);
        }
    } 
}
