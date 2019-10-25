using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select : MonoBehaviour {

    public bool selected = false;
    public bool active = true;
    public bool big;
    public float scalefactor;
    public float maxScale;
    public float minScale;

 
    public float t = 0;
    public float tDelta;
    

	// Use this for initialization
	void Start () {
        minScale = transform.localScale.x;
        maxScale = minScale * scalefactor;

    }

    private void OnMouseExit()
    {
        if(!active) return;
        selected = true;
    }

    private void OnMouseEnter()
    {
        if(!active) return;
        selected = true;
    }

    public void Deactivate()
    {   
        active = false;
        //Only shrink when big, don't expand!
        if(big) selected = true;
    }

    // Update is called once per frame
    void Update () {

        if(!selected) return;
        //Decide whether to shrink or expand
        float min = minScale;
        float max = maxScale;
        if(big)
        {
            min = maxScale;
            max = minScale;
        }

        //Resize lerp
        Vector3 curscale = transform.localScale;
        float nextscale = Mathf.Lerp(min , max , t);
        curscale.x = nextscale;
        curscale.y = nextscale;
        transform.localScale = curscale;

        t += tDelta * Time.deltaTime;
        if(t >= 1)
        {
            selected = !selected;
            big = !big;
            t = 0;
        }

    }
}
