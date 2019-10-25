using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expandtodrag : MonoBehaviour
{

    public float minsize;
    public float maxsize;

    public float expansiondelta;
    public float expansion;
    public bool active = false;
    public bool expanded = false;

    private void Start()
    {
        minsize = transform.localScale.x;
    }

    private void OnMouseDown()
    {
        if(expanded) return;
        active = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(!active) return;
        var newscale = Mathf.Lerp(minsize , maxsize , expansion);
        expansion += expansiondelta * Time.deltaTime;
        transform.localScale = new Vector3(newscale , newscale , 0f);

        if(newscale >= maxsize)
        {
            Destroy(GetComponent<BoxCollider2D>());
            GetComponent<puzzleelement>().completed = true;
            expanded = true;
            active = false;
        }


    }
}
