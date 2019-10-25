using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour {

    public bool interactable;
    void OnMouseDrag()
    {
        if(!interactable) return;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 5;
        transform.position = mousePos;
    }

}
