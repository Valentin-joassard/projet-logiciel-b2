using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class postScore : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        if(GameObject.Find("Gamelogic").GetComponent<GameLogic>().winner != null)
        {
            WWWForm form = new WWWForm();
            form.AddField("name", GameObject.Find("Gamelogic").GetComponent<GameLogic>().winner.name);   //une donnée est ajoutée ici
            form.AddField("score", GameObject.Find("Gamelogic").GetComponent<GameLogic>().winner.GetComponent<StreakScore>().GetScore());

            using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/bddProjet/postScore.php", form))
            {
                yield return www.SendWebRequest();// on attend le retour (réponse) du serveur web !

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log("Form upload complete!");
                }
            }
        }
        
    }
}
