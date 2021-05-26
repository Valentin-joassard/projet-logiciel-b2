using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class getScore : MonoBehaviour
{
    public Text scoreBoardText;
    private string name;
    private string score;

    void Start()
    {
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/bddProjet/getScore.php");
        yield return www.SendWebRequest();
        if (www.isHttpError || www.isNetworkError)
        {
            Debug.Log("Connection to the Database failed !");
        }
        else
        {
            string s = www.downloadHandler.text;

            for (int i = 0; i + 1 < s.Split('-').Length && i < 20; i += 2)
            {
                name = s.Split('-')[i];
                score = s.Split('-')[i + 1];

                name = name.Replace("Pseudo: ", "");
                score = score.Replace("Score: ", "");
                score = score.Replace("<br>", "");
                scoreBoardText.text += name + " | " + score + Environment.NewLine;
            }
        }
    }
}

