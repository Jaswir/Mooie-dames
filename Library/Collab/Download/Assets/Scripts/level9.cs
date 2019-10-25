using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level9 : MonoBehaviour
{

    BoxCollider2D bc;
    public bool draggable = true;

    void OnMouseDrag()
    {
        if(!draggable) return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 5;
        transform.position = mousePos;
    }


}
