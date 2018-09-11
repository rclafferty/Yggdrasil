using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.IO;

public class TextManagerBehavior : MonoBehaviour {

    [SerializeField]
    GameObject sendTextPrefab;
    [SerializeField]
    GameObject receiveTextPrefab;

    Text nameText;
    Text phoneText;

    private float lastTextY = 0.0f;

    List<string> texts;
    private int numberOfTextsDisplayed;

    // Use this for initialization
    void Start() {
        nameText = GameObject.Find("FriendNameText").GetComponent<Text>();
        phoneText = GameObject.Find("FriendNumberText").GetComponent<Text>();
        texts = new List<string>();

        using (StreamReader sr = new StreamReader("Assets/Scripts/Texting/Texting2/texts.txt"))
        {
            string name_line = sr.ReadLine();
            string[] parts_name = name_line.Split(':');
            nameText.text = parts_name[1];

            string phone_line = sr.ReadLine();
            string[] parts_phone = phone_line.Split(':');
            phoneText.text = parts_phone[1];

            while (!sr.EndOfStream)
            {
                texts.Add(sr.ReadLine());
            }
        }

        numberOfTextsDisplayed = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            NextMessage();
        }
	}

    void NextMessage()
    {
        if (texts.Count == 0)
        {
            GameObject.Find("SceneManager").GetComponent<SceneControllerBehavior>().Load("inside");
            return;
        }

        string textLine = texts[0];
        texts.RemoveAt(0);
        string[] textParts = textLine.Split(';');
        char deliveryDirection = textParts[0][0];
        string time = textParts[1];
        string message = textParts[2];

        int numTexts = 0;
        numTexts = numberOfTextsDisplayed;
        GameObject objectToUse = null;
        string parentName = "";
        float yToUse = 0;
        float xToUse = 0;

        if (deliveryDirection == 'S')
        {
            objectToUse = sendTextPrefab;
            parentName = "SendTextsGroup";
            xToUse = 1230.0f;
            // (message_width / 2) + panel_offset ......... or something like that.
            // THERE IS A WAY TO DYNAMICALLY PROGRAM THIS
        }
        else
        {
            objectToUse = receiveTextPrefab;
            parentName = "ReceiveTextsGroup";
            xToUse = 530.0f;
            // (message_width / 2) + panel_offset ......... or something like that.
            // THERE IS A WAY TO DYNAMICALLY PROGRAM THIS
        }


        if (numTexts == 0)
        {
            yToUse = 900.0f;
        }
        else
        {
            yToUse = lastTextY - 68.0f;
        }

        Vector3 position = new Vector3(xToUse, yToUse, 0);

        GameObject newText = UnityEngine.UI.Text.Instantiate(objectToUse, GameObject.Find(parentName).transform, false);
        newText.transform.position = position;

        Text textMessage;// = newText.GetComponentInChildren<Text>();
        GameObject[] array_messages = GameObject.FindGameObjectsWithTag("Message");
        GameObject messageObject = array_messages[array_messages.Length - 1];
        textMessage = messageObject.GetComponent<Text>();
        Debug.Log("textMessage = " + textMessage.name);
        textMessage.text = message;

        Text messageTime;// = textMessage.GetComponentInChildren<Text>();
        GameObject[] array = GameObject.FindGameObjectsWithTag("Time");
        GameObject timeObject = array[array.Length - 1];
        messageTime = timeObject.GetComponent<Text>();

        Debug.Log("messageTime = " + messageTime.name);
        messageTime.text = time;

        lastTextY = yToUse;
        numberOfTextsDisplayed++;
    }
}
