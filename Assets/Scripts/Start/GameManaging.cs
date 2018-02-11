using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManaging : MonoBehaviour {

    float timer = 0f;
    float duration = 3f;
    Color startColor = Color.clear;
    Color endColor = Color.black;
    public Image fadeImage;

    Button startButton;
    Button quitButton;
    GameObject titleText;

    // Use this for initialization
    void Start () {
        //DontDestroyOnLoad(this);
        //DontDestroyOnLoad(fadeImage.transform.parent);
        StartCoroutine(fadeOutToStart());

        startButton = GameObject.Find("Start Button").GetComponent<Button>();
        quitButton = GameObject.Find("Quit Button").GetComponent<Button>();
        titleText = GameObject.Find("Title Text");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void Fade(string level)
    {
        StartCoroutine(fadeToNewLevel(level));
    }

    IEnumerator fadeToNewLevel(string levelName)
    {
        fadeImage.transform.SetAsFirstSibling();
        //fadeImage.gameObject.SetActive(true);
        while (timer < duration)
        {
            timer += Time.deltaTime;
            fadeImage.color = Color.Lerp(startColor, endColor, timer / duration);
            yield return null;
        }
        fadeImage.color = endColor;

        LoadScene(levelName);
        timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            fadeImage.color = Color.Lerp(endColor, startColor, timer / duration);
            yield return null;
        }
        fadeImage.color = startColor;
        fadeImage.transform.SetAsLastSibling();

        //fadeImage.transform.parent.gameObject.SetActive(false);
        //fadeImage.gameObject.SetActive(false);
        yield return null;
    }

    IEnumerator fadeOutToStart()
    {
        fadeImage.color = endColor;

        timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            fadeImage.color = Color.Lerp(endColor, startColor, timer / duration);
            yield return null;
        }
        fadeImage.color = startColor;

        //startButton.transform.SetAsFirstSibling();
        //quitButton.transform.SetAsFirstSibling();

        Destroy(fadeImage.gameObject);

        //fadeImage.transform.parent.gameObject.SetActive(false);
        yield return null;
    }



    public void StartGame()
    {
        //GameObject.Find("GameManager").GetComponent<GameManaging>().Fade("texting");
        LoadScene("texting");
        DeactivateUI();

        Debug.Log("Starting...");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        DeactivateUI();

        Debug.Log("Quitting...");
    }

    public void ResetGame()
    {
        Fade("title");

        ActivateUI();
    }

    void DeactivateUI()
    {
        startButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        titleText.SetActive(false);
    }

    void ActivateUI()
    {
        startButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        titleText.SetActive(true);
    }
}
