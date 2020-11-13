using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpFloatingText : MonoBehaviour {

    public float moveSpeed;
    public Text levelUpText;
    	
	void Start () {
		
	}
		
	void Update () {
        levelUpText.text = "LEVEL UP!";
        transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);

    }
}
