using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//using System.Diagnostics;
using System;
using System.IO;

public class TextingController : MonoBehaviour
{

    GameObject screen;
    AudioSource ding;

    public Material text2;

    int num_dings;

    bool isAxisInUse;

    /*private void Awake()
    {
        String filepath = @"C:/Program Files (x86)/Epic Games/Launcher/Portal/Binaries/Win64/EpicGamesLauncher.exe";
        Process unreal = new Process();
        unreal.StartInfo.FileName = filepath;// "EpicGamesLauncher.exe";
        //unreal.StartInfo.Arguments = filepath;
        unreal.Start();
    }*/

    // Use this for initialization
    void Start()
    {
        num_dings = -1;
        isAxisInUse = false;

        screen = GameObject.Find("Screen");
        ding = this.GetComponentInChildren<AudioSource>();
        screen.SetActive(false); // hide
        Ding();

        //System.Threading.Thread.Sleep(1000);
        screen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Fire") > 0)
        {
            if (!isAxisInUse)
            {
                isAxisInUse = true;
                Ding();
            }
        }
        if (Input.GetAxis("Fire") == 0)
        {
            isAxisInUse = false;
        }
    }

    void Ding()
    {
        if (num_dings == -1)
        {
            AudioSource.PlayClipAtPoint(ding.clip, Vector3.zero);
            System.Threading.Thread.Sleep(1000);
        }
        else if (num_dings == 0)
        {
            AudioSource.PlayClipAtPoint(ding.clip, Vector3.zero);

            /*Shader s = new Shader();
            screen.GetComponent<MeshRenderer>().material = Resources.Load("Textchat2", typeof(Material)) as Material;
            System.Threading.Thread.Sleep(1000);*/

            screen.GetComponent<MeshRenderer>().material = text2;
        }
        else
        {
            SceneManager.LoadScene("inside");
        }

        num_dings++;
        Debug.Log(num_dings);
    }
}
