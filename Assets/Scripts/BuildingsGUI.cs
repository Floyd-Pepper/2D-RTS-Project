using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class BuildingsGUI {

    private static GameObject _BuildingPanel;
    public static GameObject BuildingPanel
    {
        get { return _BuildingPanel; }
        set { _BuildingPanel = value; }
    }
}
