using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogsquare : MonoBehaviour {

    public GameObject[] squares;
    public int next = 0;
    public bool interactable;

    private void OnMouseDown()
    {
        if(!interactable) return;

        //position hop
        transform.position = squares[next].transform.position;

        //activate next square
        squares[next].SetActive(true);
        Color correctColor;
        ColorUtility.TryParseHtmlString("#38A0E0" , out correctColor);
        squares[next].GetComponent<SpriteRenderer>().color = correctColor;

       
        next++;

        if(next > squares.Length - 1)
        {       
            GetComponent<puzzleelement>().completed = true;
            interactable = false;
        }

    }
}
