using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MovableCharacter
{

    private Enemy _Target = null;

    private int _AttackValue = 25;
    private float _AttackTimer = 0.0f;

    // Use this for initialization
    new void Start()
    {
        base.Start();
        _Type = Type.WARRIOR;
        CharactersManager.Characters.Add(this);
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (_Action == Action.ATTACK)
        {
            Attack();
        }
    }

    void Attack()
    {
        if(_Target != null)
        {
            if (Vector2.Distance(transform.position, _Target.transform.position) <= 1.0f)
            {
                _AttackTimer += Time.deltaTime;
                if (_AttackTimer >= 1.5f)
                {
                    _AttackTimer = 0.0f;
                    _Target.TakeDamages(_AttackValue);
                }        
            }
        }
    }

    protected override void ProcessClickOnBackground()
    {
        _Action = Action.NONE;
    }


    public void SetTarget(Enemy target)
    {
        _Target = target;
        _Action = Action.ATTACK;
        SetDestinationPosition(target.transform.position);
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
