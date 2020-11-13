using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {

    public string levelToLoad;

    public string exitPoint;

    private LegionController theLegion;

	void Start () {

        theLegion = FindObjectOfType<LegionController>();		
	}
		
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player" || other.gameObject.name == "Legion")
        {
            //Application.LoadLevel(levelToLoad);
            SceneManager.LoadScene(levelToLoad);

            theLegion.startPoint = exitPoint;
        }
    }
}
