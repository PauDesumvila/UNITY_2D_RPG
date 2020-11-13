using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegionStartPoint : MonoBehaviour {

    private LegionController theLegion;
    private CameraController theCamera;

    public Vector2 startDirection;

    public string pointName;
    	
	void Start () {
        theLegion = FindObjectOfType<LegionController>();

        if(theLegion.startPoint == pointName)
        {
            theLegion.transform.position = transform.position;
            // keep direction when changing areas
            theLegion.lastMove = startDirection;

            theCamera = FindObjectOfType<CameraController>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }        
	}
		
	void Update () {
		
	}
}
