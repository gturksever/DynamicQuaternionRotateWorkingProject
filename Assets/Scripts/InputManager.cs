using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static bool canMove;

    private void Update()
    {
        InputController();
    }

    public void InputController()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            canMove = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            canMove = false;
        }
    }
}
