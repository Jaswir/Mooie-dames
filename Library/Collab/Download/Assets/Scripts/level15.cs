using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level15 : MonoBehaviour {

    public bool boxcollidergone = false;
    public GameObject blackSquare;
    public bool isPuzzleelement;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(boxcollidergone) return;

        BoxCollider2D [] nochildrencolliders = GetComponentsInChildren<BoxCollider2D>();
        if(nochildrencolliders.Length == 0)
        {


            //Activates black square
            boxcollidergone = true;
            blackSquare.SetActive(true);

            if(isPuzzleelement)
                blackSquare.GetComponent<puzzleelement>().completed = true;

            //Destroys all lines
            Destroy(GameObject.Find("linestatic"));
            foreach(GameObject gob in GameObject.FindGameObjectsWithTag("clickable"))
                Destroy(gob);
        }
    }
}
