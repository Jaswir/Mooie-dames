using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level1 : MonoBehaviour {

    BoxCollider2D bc;
    public bool draggable = true;
    public float alphaDelta = 0.03f;

    void OnMouseDrag()
    {
        if(!draggable) return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 5;
        transform.position = mousePos;
    }


    private void Update()
    {
        if(draggable)
        {
            bc = gameObject.GetComponent<BoxCollider2D>();
            Collider2D[] overlap = Physics2D.OverlapAreaAll(bc.bounds.min , bc.bounds.max);
            if(overlap.Length > 3)
            {
                transform.position = new Vector3(0.02f , 0.28f);
                draggable = false;
                GetComponent<puzzleelement>().completed = true;
            }
        }

    }
}
