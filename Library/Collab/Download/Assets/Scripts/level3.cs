using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3 : MonoBehaviour {

    public bool interactable = true;

    private void OnMouseDown()
    {
        if(!interactable) return;
        transform.position = new Vector3(0f , 0.18f , 5f);
        GetComponent<puzzleelement>().completed = true;
        interactable = false;
    }
}
