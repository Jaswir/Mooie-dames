using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl5switcher : MonoBehaviour {

    public shift[] order;

	public void performswitch(orderplace ord, swipedirection sw_dir)
    {
        switch(ord)
        {
            case orderplace.U:

                if(sw_dir == swipedirection.Down) MU();
                else DU();
                break;

            case orderplace.M:

                if(sw_dir == swipedirection.Down) MD();
                else MU();     
                break;

            case orderplace.D:

                if(sw_dir == swipedirection.Down) DU();
                else MD();
                break;
        }

        foreach(shift shift in order)
        {
            shift.CheckCompleted();
        }
    }

    void DU()
    {
        shift prev2 = order[2];
        Vector3 prevPos = prev2.transform.position;

        order[2].gameObject.transform.position = order[0].gameObject.transform.position;
        order[2].ord = orderplace.U;
        order[2] = order[0];

        order[0].gameObject.transform.position = prevPos;
        order[0].ord = orderplace.D;
        order[0] = prev2;
    }

    void MU()
    {
        shift prev0 = order[0];
        Vector3 prevPos = prev0.transform.position;

        order[0].gameObject.transform.position = order[1].gameObject.transform.position;
        order[0].ord = orderplace.M;
        order[0] = order[1];

        order[1].gameObject.transform.position = prevPos;
        order[1].ord = orderplace.U;
        order[1] = prev0;
    }

    void MD()
    {
        shift prev1 = order[1];
        Vector3 prevPos = prev1.transform.position;

        order[1].gameObject.transform.position = order[2].gameObject.transform.position;
        order[1].ord = orderplace.D;
        order[1] = order[2];

        order[2].gameObject.transform.position = prevPos;
        order[2].ord = orderplace.M;
        order[2] = prev1;
    }
}
