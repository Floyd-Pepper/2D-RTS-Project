using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovableCharacter {

    // Use this for initialization
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    public void TakeDamages(int amount)
    {
        _Life -= amount;
        if(_Life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("click");
            foreach (MovableCharacter character in CharactersManager.SelectedCharacters)
            {
                character.SetDestinationPosition(transform.position);
                if(character._Type == Type.WARRIOR)
                {
                    Warrior warrior = (Warrior)character;
                    warrior.SetTarget(this);
                }   
            }
        }
    }
}
