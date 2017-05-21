using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourcesManager {

    private static int _Wood = 0;
    private static int _Gold = 0;

    public static int Wood
    {
        get { return _Wood; }
        set
        {
            _Wood = value;
            ResourceGUI.SetWoodAmount(value);
        }
    }

    public static int Gold
    {
        get { return _Gold; }
        set
        {
            _Gold = value;
            ResourceGUI.SetGoldAmount(value);
        }
    }

}
