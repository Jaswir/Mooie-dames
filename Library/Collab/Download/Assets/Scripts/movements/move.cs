using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    public bool interactable = true;
    public Vector3 targetposition;

    private void OnMouseDown()
    {
        if(!interactable) return;

        transform.position = targetposition;
        GetComponent<puzzleelement>().completed = true;
        interactable = false;
  
    }
}
