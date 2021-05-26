using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pause : MonoBehaviour
{

    private bool Stop=false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("imgPause").GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("start"))
        {
            Stop = !Stop;
            if (Stop)
            {
                Time.timeScale = 0;
                GameObject.Find("rouge").GetComponent<JoueurController1>().enabled = false;
                GameObject.Find("gris").GetComponent<JoueurController2>().enabled = false;
                GameObject.Find("imgPause").GetComponent<Image>().enabled = true;

            }
            else
            {
                Time.timeScale = 1;
                GameObject.Find("rouge").GetComponent<JoueurController1>().enabled = true;
                GameObject.Find("gris").GetComponent<JoueurController2>().enabled = true;
                GameObject.Find("imgPause").GetComponent<Image>().enabled = false;
            }
        }
    }
}
