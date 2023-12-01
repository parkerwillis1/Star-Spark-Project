using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcoroutines : MonoBehaviour {

	public GameObject init;
	public GameObject endit;
	public GameObject loseitobj;
	public static UIcoroutines instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject); if it should persist across scenes
        }
        else
        {
            Debug.LogError("Two UI scripts in scene!");
        }

        StartCoroutine(initialFade());

        // Deactivate game over UI at the start
        loseitobj.SetActive(false);
    }


    IEnumerator initialFade(){
		yield return new WaitForSeconds(3f);
		init.SetActive(false);

	}
	
	bool ending;
	public void GameOver(bool lose){
		if(!ending && !lose){
			StartCoroutine(win());
		}

		if(!ending && lose){
			StartCoroutine(loseit());
		}
	}

    IEnumerator loseit()
    {
        ending = true;
        loseitobj.SetActive(true);
        //yield return new WaitForSeconds(5f);

        // Activate the GameOverMenu
        GameOverMenu gameOverMenu = FindObjectOfType<GameOverMenu>();
        if (gameOverMenu != null)
        {
            gameOverMenu.ShowGameOverMenu();
        }

        // Wait while the game is paused (time scale is 0)
        yield return new WaitWhile(() => Time.timeScale == 0);

        // Once the time scale is no longer 0 (game is resumed or restarted), deactivate the menu
        loseitobj.SetActive(false);
        ending = false;
    }



    IEnumerator win(){
		ending = true;
		endit.SetActive(true);
		yield return new WaitForSeconds(5f);
		endit.SetActive(false);
		//ending = false;
	}
}