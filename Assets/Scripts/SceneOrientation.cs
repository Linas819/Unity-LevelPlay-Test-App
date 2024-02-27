using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOrientation : MonoBehaviour
{
    public bool portrait;
    void Awake()
    {
        if (portrait == true)
            Screen.orientation = ScreenOrientation.Portrait;
        else
            Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}