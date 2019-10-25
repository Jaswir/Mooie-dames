using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class linedrag : MonoBehaviour
{

    BoxCollider2D bc;
    public bool draggable = true;
    public bool ispuzzlement;
    public int overlapamount;

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
            if(overlap.Length > overlapamount)
            {
                Transform element = overlap[0].gameObject.transform.parent;
                transform.position = element.GetComponent<linelock>().lockposition;
                if(ispuzzlement) GetComponent<puzzleelement>().completed = true;
                draggable = false;

            }
        }

    }
}
