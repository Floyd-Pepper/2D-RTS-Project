using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuilding : Building {

	// Use this for initialization
	new void Start () {
        base.Start();
        BuildingsGUI.BuildingPanel = GameObject.Find("BuildingPanel");
        BuildingsGUI.BuildingPanel.SetActive(false);
    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}

    private void OnMouseOver()
    {
        // select only one character
        if (Input.GetMouseButtonDown(0))
        {
            BuildingsGUI.BuildingPanel.SetActive(true);
        }
    }
}
