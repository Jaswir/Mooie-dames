using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grayarea : MonoBehaviour {

    public bool Filled;
    public string shapetype;

    public bool filled {
        get
        {
            return Filled;
        }
        set
        {
           Filled = value;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "touchhull") return;

        Transform colParent = collision.transform.parent;

        //Detects whether placed piece matches the gray area type
        string colshapetype = collision.gameObject.GetComponent<SpriteRenderer>().sprite.name;
        bool correcttype = shapetype == colshapetype;

        ///No -> place back at startposition
        if(!correcttype) {
            colParent.GetComponent<placeable>().Reset();
            return;
        }

        ///Otherwise place
    
        //places
        colParent.position = transform.position;
        colParent.GetComponent<select>().Deactivate();
        colParent.GetComponent<placeable>().SetPlaced();

        //Destroys boxcolliders
        Destroy(collision.gameObject.GetComponent<BoxCollider2D>());
        Destroy(GetComponent<BoxCollider2D>());

        filled = true;
    }
}
