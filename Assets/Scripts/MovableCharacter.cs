using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableCharacter : MonoBehaviour {

    bool _Idle = true;
    private bool _IsSelected = false;
    public bool IsSelected
    {
        get { return _IsSelected; }
        set { _IsSelected = value; }
    }

    int _Speed = 5;

    SpriteRenderer _SpriteRenderer;

    Vector2 _Destination;

	// Use this for initialization
	protected void Start () {
        _SpriteRenderer = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    protected void Update () {
        DiscoverMap();
        if (!_Idle)
            MoveToPosition(_Destination);
    }

    public void MoveToPosition(Vector2 destination)
    {
        float step = _Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destination, step);
        if (new Vector2(transform.position.x, transform.position.y) == destination)
            _Idle = true;
    }

    public void SetDestinationPosition(Vector2 destination)
    {
        _Destination = destination;
        _Idle = false;
        float directionSign = destination.x - transform.position.x;
        if ((directionSign > 0 && _SpriteRenderer.flipX) || (directionSign < 0 && !_SpriteRenderer.flipX))
            FlipSprite();
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
