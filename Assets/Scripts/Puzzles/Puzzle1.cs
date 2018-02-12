using UnityEngine;
using UnityEngine.UI;

public class Puzzle1 : MonoBehaviour {

    public Canvas puzzleCanvas;
    /*Button answerA;
    Button answerB;
    Button answerC;*/
    TextMesh prompt;
    TextMesh options;

    int correctAnswer;

	// Use this for initialization
	void Start () {
        /*answerA = GameObject.Find("AnswerA").GetComponent<Button>();
        answerB = GameObject.Find("AnswerB").GetComponent<Button>();
        answerC = GameObject.Find("AnswerC").GetComponent<Button>();*/
        prompt = GameObject.Find("Prompt").GetComponent<TextMesh>();
        options = GameObject.Find("Options").GetComponent<TextMesh>();
        
        correctAnswer = 1;

        //puzzleCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            Answer(1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            Answer(2);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            Answer(3);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        puzzleCanvas.gameObject.SetActive(true);

        prompt.text = "_ _ _ _ _ _ _ _ _ will burn.";
        options.text = "1.) lndgwekeo\n2.) bssiradum\n3.) plcaakfjs";

        //answerA.onClick.AddListener(() => { Answer(1); });
        //answerB.onClick.AddListener(() => { Answer(2); });
        //answerC.onClick.AddListener(() => { Answer(3); });

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnTriggerExit(Collider other)
    {
        puzzleCanvas.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Answer(int a)
    {
        if (correctAnswer == a)
            Correct();
        else
            Incorrect();
    }

    void Correct()
    {
        prompt.text = "KNOWLEDGE will burn";
        //answerA.gameObject.SetActive(false);
        //answerB.gameObject.SetActive(false);
        //answerC.gameObject.SetActive(false);

        options.text = "1.) LNOGWEKED";

        float timer = 0f;
        float duration = 2f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            //fadeImage.color = Color.Lerp(startColor, endColor, timer / duration);
            //yield return null;
        }

        puzzleCanvas.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }

    void Incorrect()
    {
        
    }
}
