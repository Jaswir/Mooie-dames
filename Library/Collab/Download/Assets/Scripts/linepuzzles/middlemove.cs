using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middlemove : MonoBehaviour
{

    public Vector3 middlePos;
    public Vector3 notMiddlePos;
    public bool isMiddle;

    private void Start()
    {
        GetComponent<puzzleelement>().completed = isMiddle;
    }

    private void OnMouseDown()
    {
        //Toggle middle and puzzlecompleted bool
        isMiddle = !isMiddle;
        GetComponent<puzzleelement>().completed = isMiddle;

        //Switches middle position
        if(isMiddle) transform.position = middlePos;
        else transform.position = notMiddlePos;
            
        
    }

}
