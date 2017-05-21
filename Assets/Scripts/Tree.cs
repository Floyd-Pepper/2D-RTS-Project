using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

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
            foreach (Peasant character in CharactersManager.SelectedCharacters)
            {
                character.StartChop(this);
            }
        }
    }
}
