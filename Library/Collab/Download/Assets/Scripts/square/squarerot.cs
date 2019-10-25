using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squarerot : MonoBehaviour
{

    public bool cornerselected = false;
    public bool correctlyrotated = false;
    public float targetrotation;
    public float targetrotation2;
    public float rotBias = 1.0f;

    // Use this for initialization
    void Start()
    {
        targetrotation2 = targetrotation - 180;
    }

    // Update is called once per frame
    void Update()
    {

        if(correctlyrotated) return;

        if(cornerselected)
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.rotation = Quaternion.LookRotation(Vector3.forward , mousePosition - transform.position);
        }

        //Checks whether rotation is achieved
        float rotabs = transform.rotation.eulerAngles.z;
        float minboundary = targetrotation - rotBias;
        float maxboundary = targetrotation + rotBias;
        bool rot1achieved = rotabs >= minboundary && rotabs <= maxboundary;

        float minboundary2 = targetrotation2 - rotBias;
        float maxboundary2 = targetrotation2 + rotBias;

        bool rot2achieved = rotabs >= minboundary2 && rotabs <= maxboundary2;

        if(rot1achieved || rot2achieved)
        {
            correctlyrotated = true;
            transform.rotation = Quaternion.Euler(new Vector3(0f , 0f , targetrotation));
            if(GetComponent<placeable>() != null)
            {
                Color correctColor;
                ColorUtility.TryParseHtmlString("#F63939" , out correctColor);
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = correctColor;
                Invoke("ActivatePlace" , 1.0f);
                return;
            }
            if(GetComponent<puzzleelement>() != null) GetComponent<puzzleelement>().completed = true;
          
        }

    }

    void ActivatePlace()
    {
        GetComponent<placeable>().placed = false;
    }

    private void OnMouseDown()
    {
        cornerselected = true;
    }

    private void OnMouseUp()
    {
        cornerselected = false;
    }
}
