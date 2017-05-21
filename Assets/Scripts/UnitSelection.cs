using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    bool isSelecting = false;
    Vector3 mousePosition1;

    public bool IsWithinSelectionBounds(MovableCharacter gameObject)
    {
        if (!isSelecting)
            return false;

        var v1 = Camera.main.ScreenToViewportPoint(mousePosition1);
        var v2 = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        var min = Vector3.Min(v1, v2);
        var max = Vector3.Max(v1, v2);
        min.z = Camera.main.nearClipPlane;
        max.z = Camera.main.farClipPlane;
        var bounds = new Bounds();
        bounds.SetMinMax(min, max);

        return bounds.Contains(Camera.main.WorldToViewportPoint(gameObject.transform.position));
    }

    void Update()
    {
        // If we press the left mouse button, save mouse location and begin selection
        if (Input.GetMouseButtonDown(0))
        {
            isSelecting = true;
            mousePosition1 = Input.mousePosition;
        }
        // If we let go of the left mouse button, end selection
        if (Input.GetMouseButtonUp(0))
            isSelecting = false;

        if(isSelecting)
        {
            foreach(MovableCharacter character in CharactersManager.Characters)
            {
                bool isWithinSelectionBounds = IsWithinSelectionBounds(character);
                if(isWithinSelectionBounds)
                {
                    // select character and draw rectangle on it
                    CharactersManager.AddToSelectedCharacters(character);
                }
            }
        }
    }

    void OnGUI()
    {
        if (isSelecting)
        {
            // Selection box
            var rect = Utils.GetScreenRect(mousePosition1, Input.mousePosition);
            Utils.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
            Utils.DrawScreenRectBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));
        }
    }
}
