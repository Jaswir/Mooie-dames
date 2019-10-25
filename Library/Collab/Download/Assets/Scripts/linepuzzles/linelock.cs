using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linelock : MonoBehaviour
{

    public Vector3 lockposition;
    public float validrotation;
    public bool chainconnection = false;
    public bool connected;
    public bool completeshape = false;
    public bool secondvalid = false;
    public float validownrotation;
    public GameObject shape;
    public GameObject[] shapeComponents;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(connected) return;
        if(other.tag == "clickable") return;


        Transform father = other.transform.parent;


        if((int)father.transform.eulerAngles.z != validrotation) return;
        if(secondvalid && (int)transform.eulerAngles.z != validownrotation) return;
        father.GetComponent<level9>().draggable = false;
        Color correctColor = new Color();
        ColorUtility.TryParseHtmlString("#38A0E0" , out correctColor);
        father.GetComponent<SpriteRenderer>().color = correctColor;
        father.position = lockposition;      
        connected = true;

       

        //Destroys connection points
        Destroy(GetComponent<Collider2D>());
        Destroy(other.GetComponent<Collider2D>());
        Destroy(father.GetComponent<Collider2D>());

        if(GetComponent<puzzleelement>() != null) GetComponent<puzzleelement>().completed = true;

        //Activate others connection points
        if(chainconnection)
        {
             father.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = true;
             father.GetChild(1).GetComponent<BoxCollider2D>().isTrigger = true;
        }

        if(completeshape)
        {
            shape.SetActive(true);

            //Destroy all parts of shape
            foreach(GameObject shapeComponent in shapeComponents)
            {
                Destroy(shapeComponent);
            }
        }
    }

}