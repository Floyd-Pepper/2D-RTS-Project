using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private float _Speed = 10.0f;

    public bool _DisableCameraMovements = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!_DisableCameraMovements)
        {
            Vector2 camPos = transform.position;
            if (Input.mousePosition.x >= Screen.width)
            {
                camPos += new Vector2(_Speed * Time.deltaTime, 0);
            }
            else if (Input.mousePosition.x <= 0.0f)
            {
                camPos += new Vector2(-_Speed * Time.deltaTime, 0);
            }
            if (Input.mousePosition.y >= Screen.height)
            {
                camPos += new Vector2(0, _Speed * Time.deltaTime);
            }
            else if (Input.mousePosition.y <= 0.0f)
            {
                camPos += new Vector2(0, -_Speed * Time.deltaTime);
            }
            transform.position = new Vector3(camPos.x, camPos.y, transform.position.z);
        }
    }
}
