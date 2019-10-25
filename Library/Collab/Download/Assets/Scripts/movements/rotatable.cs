using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatable : MonoBehaviour {

    public bool cornerselected = false;
    public bool correctlyrotated = false;
    public float rotBias = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(correctlyrotated) return;

        if(cornerselected)
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.rotation = Quaternion.LookRotation(Vector3.forward , mousePosition - transform.position);

            if(Mathf.Abs(transform.rotation.z) <= rotBias)
            {
                correctlyrotated = true;
                transform.rotation = Quaternion.LookRotation(Vector3.forward);
                GetComponent<puzzleelement>().completed = true;

            }
        }

   

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
