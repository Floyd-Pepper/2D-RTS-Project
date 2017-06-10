using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peasant : MovableCharacter {

    private GameObject _BaseBuilding;

    // CHOP
    private Tree _TreeToChop = null;
    private float _TimeChoping = 0.0f; 

	// Use this for initialization
	new void Start () {
        base.Start();
        _Type = Type.PEASENT;
        CharactersManager.Characters.Add(this);
        _BaseBuilding = GameObject.FindGameObjectWithTag("BaseBuilding");
    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();
        if(_Action == Action.CHOP)
        {
            Chop();      
        }
	}

    public void StartChop(Tree tree)
    {
        _Action = Action.CHOP;
        _TreeToChop = tree;
        SetDestinationPosition(tree.transform.position);
    }

    private void Chop()
    {
        if (_TreeToChop)
        {
            if (Vector2.Distance(transform.position, _TreeToChop.transform.position) <= 1.0f)
            {
                _TimeChoping += Time.deltaTime;
                if(_TimeChoping >= 5.0f)
                {
                    _TimeChoping = 0.0f;
                    PutRessourcesToBase();
                }
            }
            else if(Vector2.Distance(transform.position, _BaseBuilding.transform.position) <= 1.0f)
            {
                ResourcesManager.Wood += 10;
                SetDestinationPosition(_TreeToChop.transform.position);
            }
        }
    }

    private void PutRessourcesToBase()
    {
        SetDestinationPosition(_BaseBuilding.transform.position);
    }

    private void OnMouseOver()
    {
        // select only one character
        if (Input.GetMouseButtonDown(0))
        {
            CharactersManager.DeselectAllCharacters();
            CharactersManager.AddToSelectedCharacters(this);
        }
    }
}
