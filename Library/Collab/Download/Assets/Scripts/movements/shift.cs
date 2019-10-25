using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum orderplace { U, M, D };
public enum swipedirection { Up, Down };

public class shift : MonoBehaviour
{

    public Vector3 startPos;
    public bool selected = false;

    public float swipeMin = 50f;


    public orderplace ord;
    public orderplace targetord;
    

    private void OnMouseDown()
    {
        selected = true;
        startPos = Input.mousePosition;
        startPos.z = 5f;
    }

    private void OnMouseUp()
    {
        selected = false;
        float directionY = (startPos - Input.mousePosition).y;

        swipedirection sw_dir = swipedirection.Down;
        if(directionY <= -swipeMin) sw_dir = swipedirection.Up;   
        Camera.main.GetComponent<lvl5switcher>().performswitch(ord, sw_dir);
    }

    public void CheckCompleted()
    {
        GetComponent<puzzleelement>().completed = targetord == ord;
    }
}