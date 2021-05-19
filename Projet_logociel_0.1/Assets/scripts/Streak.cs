using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streak : MonoBehaviour
{
    public void UpdateStreak(GameObject joueur)
    {
        if (joueur.name == "rouge")
        {
            int streakRouge = GameObject.Find("JoueurController1").GetComponent<JoueurController1>().streak;
            streakRouge += 1;
            int streakGris = GameObject.Find("JoueurController2").GetComponent<JoueurController2>().streak;
            streakGris = 0;
        }
        if (joueur.name == "gris")
        {
            int streakGris = GameObject.Find("JoueurController2").GetComponent<JoueurController2>().streak;
            streakGris += 1;
            int streakRouge = GameObject.Find("JoueurController1").GetComponent<JoueurController1>().streak;
            streakRouge = 0;
        }
    }

    public void UpdateScore(GameObject joueur)
    {
        int streakRouge = GameObject.Find("JoueurController1").GetComponent<JoueurController1>().streak;
        int scoreRouge = GameObject.Find("JoueurController1").GetComponent<JoueurController1>().score;
        int streakGris = GameObject.Find("JoueurController2").GetComponent<JoueurController2>().streak;
        int scoreGris = GameObject.Find("JoueurController2").GetComponent<JoueurController2>().score;
        if (streakRouge > 0)
        {
            scoreRouge += 50 * streakRouge;
            Debug.Log(scoreRouge);
        }
        if (streakGris > 0)
        {
            scoreGris += 50 * streakGris;
        }

    }
}
