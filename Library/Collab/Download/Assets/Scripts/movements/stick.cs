using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stick : MonoBehaviour {

    public Vector3 lockposition;
    public bool available;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!available) return;

        other.transform.position = lockposition;
        other.GetComponent<move>().interactable = false;

        //Destroys connection points
        Destroy(GetComponent<Collider2D>());
        GetComponent<puzzleelement>().completed = true;
        available = false;

    }
}
