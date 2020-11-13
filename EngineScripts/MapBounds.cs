using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBounds : MonoBehaviour {

    // update map bounds when changing area

    private BoxCollider2D bounds;
    private CameraController theCamera;
    	
	void Start () {
        bounds = GetComponent<BoxCollider2D>();
        theCamera = FindObjectOfType<CameraController>();
        theCamera.SetBounds(bounds);
		
	}
}
