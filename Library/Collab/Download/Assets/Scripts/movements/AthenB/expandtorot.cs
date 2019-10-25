using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expandtorot : MonoBehaviour
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
        transform.localScale = new Vector3(transform.localScale.x , newscale , 0f);

        if(newscale >= maxsize)
        {
            Color correctColor = new Color();
            ColorUtility.TryParseHtmlString("#FFFF56" , out correctColor);
            GetComponent<SpriteRenderer>().color = correctColor;

            Invoke("ActivateRot" , 1.0f);
            expanded = true;
            active = false;
        }
    }

    void ActivateRot()
    {
        GetComponent<linerot>().enabled = true;
    }
}
