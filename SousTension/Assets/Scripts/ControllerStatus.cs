using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerStatus : MonoBehaviour {

    public bool playstationController, xboxController, keyboard;
    public string[] currentControllers;
    public float controllerCheckTimer = 2;
    public float controllerCheckTimerOG = 2;

    private int keyboardCode = 0;
    private int xboxCode = 1;
    private int psCode = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ControllerCheck();
    }

    public int ControllerCheck()
    {
        System.Array.Clear(currentControllers, 0, currentControllers.Length);
        System.Array.Resize<string>(ref currentControllers, Input.GetJoystickNames().Length);
        int numberOfControllers = 0;
        for (int i = 0; i < Input.GetJoystickNames().Length; i++)
        {
            currentControllers[i] = Input.GetJoystickNames()[i].ToLower();
            if ((currentControllers[i] == "controller (xbox 360 for windows)" || currentControllers[i] == "controller (xbox 360 wireless receiver for windows)" || currentControllers[i] == "controller (xbox one for windows)"))
            {
                xboxController = true;
                keyboard = false;
                playstationController = false;
                Debug.Log("XboxController");
                return xboxCode;
            }
            else if (currentControllers[i] == "wireless controller")
            {
                playstationController = true; //not sure if wireless controller is just super generic but that's what DS4 comes up as.
                keyboard = false;
                xboxController = false;
                return psCode; 
            }
            else if (currentControllers[i] == "")
            {
                numberOfControllers++;

            }
        }
        if (numberOfControllers == Input.GetJoystickNames().Length)
        {
            keyboard = true;
            xboxController = false;
            playstationController = false;
            Debug.Log("Keyboard");
            return keyboardCode;
        }
        return 4;
    }
}
