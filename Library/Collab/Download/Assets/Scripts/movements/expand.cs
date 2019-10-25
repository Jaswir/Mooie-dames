using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expand : MonoBehaviour {

    public float minsize;
    public float maxsize;

    public float expansiondelta;
    public float expansion;
    public bool active = false;
    public bool expanded = false;


    private void OnMouseDown()
    {
        if(expanded) return;
        active = true;
    }

    // Update is called once per frame
    void Update () {

        if(!active) return;
        var newscale = Mathf.Lerp(minsize , maxsize , expansion);
        expansion += expansiondelta * Time.deltaTime;
        transform.localScale = new Vector3(newscale , newscale , 0f);

        if(newscale >= maxsize)
        {
            GetComponent<puzzleelement>().completed = true;
            expanded = true;
            active = false;
        }


	}
}
