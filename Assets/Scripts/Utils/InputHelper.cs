using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHelper
{

    public static bool GetStandardMoveMultiInputKeys()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) { return true; }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)) { return true; }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) { return true; }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)) { return true; }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) { return true; }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) { return true; }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow)) { return true; }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow)) { return true; }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)) { return true; }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow)) { return true; }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)) { return true; }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)) { return true; }

        return false;
    }

    public static bool GetStandardMoveUpDirection()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) { return true; }

        return false;
    }

    public static bool GetStandardMoveLeftDirection()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) { return true; }

        return false;
    }

    public static bool GetStandarMoveDownDirection()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { return true; }

        return false;
    }

    public static bool GetStandardMoveRightDirection()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { return true; }

        return false;
    }

}
