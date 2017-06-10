using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableCharacter : MonoBehaviour {

    //states
    bool _Idle = true;
    private bool _IsSelected = false;
    public bool IsSelected
    {
        get { return _IsSelected; }
        set { _IsSelected = value; }
    }

    public enum Action { ATTACK, CHOP, NONE };
    protected Action _Action = Action.NONE;

    public enum Type { PEASENT, WARRIOR };
    public Type _Type;

    //characteristics
    protected int _Speed = 5;
    protected int _Life = 100;

    SpriteRenderer _SpriteRenderer;

    Vector2 _Destination;

	protected void Start () {
        _SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected void Update () {
        DiscoverMap();
        if (!_Idle)
            MoveToPosition(_Destination);
    }

    public void SetCurrentAction(Action action)
    {
        _Action = action;
    }

    public void MoveToPosition(Vector2 destination)
    {
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), destination) <= 1.0f)
        {
            _Idle = true;
            return;
        }    
        float step = _Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destination, step);
    }

    public void SetDestinationPosition(Vector2 destination)
    {
        _Destination = destination;
        _Idle = false;
        float directionSign = destination.x - transform.position.x;
        if ((directionSign > 0 && _SpriteRenderer.flipX) || (directionSign < 0 && !_SpriteRenderer.flipX))
            FlipSprite();
    }

    protected virtual void ProcessClickOnBackground()
    {

    }

    public void FlipSprite()
    {
        if (_SpriteRenderer.flipX)
            _SpriteRenderer.flipX = false;
        else
            _SpriteRenderer.flipX = true;
    }

    void OnGUI()
    {
        if (_IsSelected)
        {
            // Selection box
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            Rect rect = Utils.GetScreenRect(new Vector3(pos.x - 30.0f, pos.y - 30.0f, pos.z), new Vector3(pos.x + 30.0f, pos.y + 30.0f, pos.z));
            Utils.DrawScreenRectBorder(rect, 2, Color.green);
        }
    }

    private void DiscoverMap()
    {
        int posX = (int)transform.position.x;
        int posY = (int)transform.position.y;
        FogOfWar.DiscoverTiles(posX, posY);
    }
}
