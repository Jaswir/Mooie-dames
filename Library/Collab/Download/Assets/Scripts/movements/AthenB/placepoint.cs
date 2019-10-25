using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placepoint : MonoBehaviour {

    public bool ispuzzlement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "touchhull") return;

        Transform colParent = collision.transform.parent;

        if(tag == "special" && colParent.localRotation.z != 1) return;
        if(colParent.transform.localRotation.z == 1 && tag != "special") return;


        if(colParent.GetComponent<expandtodrag>() != null)
        {
            colParent.GetComponent<expandtodrag>().expanded = false;
            Color correctColor = new Color();
            ColorUtility.TryParseHtmlString("#A1F13D" , out correctColor);
            collision.transform.GetComponent<SpriteRenderer>().color = correctColor;
        }
        if(colParent.GetComponent<expandtofit>() != null)
        {
            colParent.GetComponent<expandtofit>().expanded = false;
            colParent.GetComponent<expandtofit>().maxsize = transform.localScale.x;
            Color correctColor = new Color();
            ColorUtility.TryParseHtmlString("#A1F13D" , out correctColor);
            collision.transform.GetComponent<SpriteRenderer>().color = correctColor;
        }

        //places
        colParent.position = transform.position;
        colParent.GetComponent<placeable>().SetPlaced();

        //Destroys boxcolliders
        Destroy(collision.gameObject.GetComponent<BoxCollider2D>());
        if(colParent.GetComponent<expandtodrag>() == null && colParent.GetComponent<expandtofit>() == null)
            Destroy(colParent.gameObject.GetComponent<BoxCollider2D>());

        Destroy(GetComponent<BoxCollider2D>());

        if(ispuzzlement) GetComponent<puzzleelement>().completed = true;

    }

}
