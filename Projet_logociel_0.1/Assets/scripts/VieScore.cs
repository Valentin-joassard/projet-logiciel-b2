using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VieScore : MonoBehaviour
{
    public int vie;
    public void GererVie(GameObject petitbonhomme)
    {
        vie-=1;
        AffichageVie();
    }
    public int GetVie(GameObject petitbonhomme)
    {
        return vie;
    }

    public void AffichageVie()
    {

        if ( GameObject.Find("rouge").GetComponent<VieScore>().vie == 2) {
            

            GameObject.Find("red3").GetComponent<Image>().enabled = false;
        }

        if (GameObject.Find("rouge").GetComponent<VieScore>().vie == 1)
        {
            GameObject.Find("red2").GetComponent<Image>().enabled = false;
        }

        if (GameObject.Find("rouge").GetComponent<VieScore>().vie == 0)
        {
            GameObject.Find("red1").GetComponent<Image>().enabled = false;
        }

        if (GameObject.Find("gris").GetComponent<VieScore>().vie == 2)
        {
            GameObject.Find("gris3").GetComponent<Image>().enabled = false;
        }

        if (GameObject.Find("gris").GetComponent<VieScore>().vie == 1)
        {
            GameObject.Find("gris2").GetComponent<Image>().enabled = false;
        }

        if (GameObject.Find("gris").GetComponent<VieScore>().vie == 0)
        {
            GameObject.Find("gris1").GetComponent<Image>().enabled = false;
        }


    }
}