using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class general : MonoBehaviour {

    public bool fade = false;
    public float alphaDelta = 0.03f;

    public puzzleelement[] puzzlements;

    // Use this for initialization
    void Start () {

        GameObject hudPrefab = Resources.Load<GameObject>("Prefabs/HUD");
        Instantiate(hudPrefab);
	}
	
	// Update is called once per frame
	void Update () {

        LevelNavigation();

        CheckPuzzleCompleted();

        if(!fade) return;
        List<GameObject> tofade = new List<GameObject>(GameObject.FindGameObjectsWithTag("fade"));
        tofade.AddRange(GameObject.FindGameObjectsWithTag("clickable"));

        //Fade
        foreach(GameObject go in tofade)
        {
            SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
            Color curCol = sr.color;
            curCol.a -= alphaDelta * Time.deltaTime;
            sr.color = curCol;

            //Scene switch upon fade out
            if(curCol.a <= 0.0f)
            {
                fade = false;
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                if(SceneManager.sceneCountInBuildSettings > nextSceneIndex)
                {
                    SceneManager.LoadScene(nextSceneIndex);
                }
            }
        }
    }

    void CheckPuzzleCompleted()
    {
        if(fade) return;

        bool puzzlecompleted = true;
        foreach(puzzleelement puzzlement in puzzlements)
        {
            if(!puzzlement.completed) puzzlecompleted = false;
        }

        if(puzzlecompleted) fade = true;

    }

    void LevelNavigation()
    {
        //level up
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }

        //level down
        if(Input.GetKeyDown(KeyCode.Menu))
        {
            int prevSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
            SceneManager.LoadScene(prevSceneIndex);
        }
    }
}
