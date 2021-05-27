using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class affichageScore : MonoBehaviour
{
    public Text score;
    public GameObject joueur;
    // Start is called before the first frame update
    void Start()
    {
        score.text = joueur.GetComponent<StreakScore>().GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = joueur.GetComponent<StreakScore>().GetScore().ToString();
    }
}
