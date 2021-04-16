using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VieScore : MonoBehaviour
{
    public int vie;
    public void GererVie(GameObject petitbonhomme)
    {

        vie = vie - 1;

    }
    public int GetVie(GameObject petitbonhomme)
    {
        return vie;
    }
}