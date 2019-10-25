using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class placeable : MonoBehaviour
{

    public bool placed = false;
    public bool ispuzzlement;


    void OnMouseDrag()
    { 
        if(placed) return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 5;
        transform.position = mousePos;
    }


    public void SetPlaced()
    {
        placed = true;
        if(ispuzzlement) GetComponent<puzzleelement>().completed = true;
    }
 
}
