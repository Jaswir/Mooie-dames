using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class hud : MonoBehaviour {


	// Use this for initialization
	void Start () {

        int level = SceneManager.GetActiveScene().buildIndex + 1;
        transform.GetChild(0).GetComponent<Text>().text = level + "/25";

    }
	
}
