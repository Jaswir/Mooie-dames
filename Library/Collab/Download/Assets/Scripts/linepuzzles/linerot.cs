using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linerot : MonoBehaviour {

    public bool cornerselected = false;
    public bool correctlyrotated = false;
    public float targetrotation;
    public float targetrotation2;
    public float rotBias = 1.0f;
    public bool isPuzzelment;

	// Use this for initialization
	void Start () {

        if(targetrotation < 0) targetrotation += 360;

        targetrotation2 = targetrotation - 180;
        if(targetrotation2 < 0) targetrotation2 += 360;
	}
	
	// Update is called once per frame
	void Update () {

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

        float minboundary2 = Mathf.Abs(targetrotation2) - rotBias;
        float maxboundary2 = Mathf.Abs(targetrotation2) + rotBias;

        bool rot2achieved = rotabs >= minboundary2 && rotabs <= maxboundary2;

        if(rot1achieved || rot2achieved)
        {
            correctlyrotated = true;
            transform.rotation = Quaternion.Euler(new Vector3(0f , 0f , targetrotation));
            Color correctColor = new Color();
            ColorUtility.TryParseHtmlString("#F63939" , out correctColor);
            GetComponent<SpriteRenderer>().color = correctColor;
            if(isPuzzelment) GetComponent<puzzleelement>().completed = true;

            Invoke("SetDraggable", 1.0f); 
        }

    }

    void SetDraggable()
    {
        if(GetComponent<linedrag>() != null)
        {
            GetComponent<linedrag>().draggable = true;
        }
        //else
        if(GetComponent<level9>() != null)
         GetComponent<level9>().draggable = true;


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
