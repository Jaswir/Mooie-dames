using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class level25 : MonoBehaviour {

    public int colIndex = 0;
    public Text text;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject colobj = collision.gameObject;
        colobj.transform.position = transform.position;
        colobj.GetComponent<drag>().interactable = false;
        colobj.GetComponent<puzzleelement>().completed = true;

        colIndex++;

        switch(colIndex)
        {
            case 1:
                text.text += "Piece ";
                break;
            case 2:
                text.text += "by piece";
                break;
            case 3:
                text.text += "\n you have solved";
                break;
            case 4:
                text.text += "\n this puzzle";
                break;
            case 5:
                text.text += "\n till finally";
                break;
            case 6:
                text.text += "\n no pieces";
                break;
            case 7:
                text.text += "\n are left";
                break;
        }

    }
}
