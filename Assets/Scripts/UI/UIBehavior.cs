using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class UIBehavior : MonoBehaviour {

    Button startButton;
    Button quitButton;

	// Use this for initialization
	void Start () {
        /*Debug.Log("Start adding listeners...");

        startButton = GameObject.Find("Start Button").GetComponent<Button>();
        if (startButton == null)
            Debug.Log("NULL 1");
        startButton.onClick.AddListener(StartGame);

        quitButton = GameObject.Find("Quit Button").GetComponent<Button>();
        if (quitButton == null)
            Debug.Log("NULL 2");
        quitButton.onClick.AddListener(QuitGame);

        Debug.Log("Finished adding listeners...");*/

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartGame()
    {
        GameObject.Find("GameManager").GetComponent<GameManaging>().Fade("texting");
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
