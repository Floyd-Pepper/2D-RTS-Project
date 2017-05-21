using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            CharactersManager.ProcessClickOnBackground(1);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            CharactersManager.ProcessClickOnBackground(0);
        }
    }
}
