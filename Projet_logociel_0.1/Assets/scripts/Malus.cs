using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malus : MonoBehaviour
{
    private bool nerfGris = false;
    private bool nerfRouge = false;

    void Start()
    {
        StartCoroutine(ResetBuffRouge());
        StartCoroutine(ResetBuffGris());
    }
    void Update()
    {
        StartCoroutine(ResetBuffRouge());
        StartCoroutine(ResetBuffGris());
    }
    IEnumerator ResetBuffGris()
    {
        if (nerfGris)
        {
            yield return new WaitForSeconds(5);
            GameObject.Find("gris").GetComponent<BonusMalusBulletSpeed>().SpeedReset();
            nerfGris = false;
        }
    }

    IEnumerator ResetBuffRouge()
    {
        if (nerfRouge)
        {
            yield return new WaitForSeconds(5);
            GameObject.Find("rouge").GetComponent<BonusMalusBulletSpeed>().SpeedReset();
            nerfRouge = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "rouge")
        {
            nerfRouge = true;
            GameObject.Find("rouge").GetComponent<BonusMalusBulletSpeed>().SpeedDown();
        }

        if (collision.gameObject.name == "gris")
        {
            nerfGris = true;
            GameObject.Find("gris").GetComponent<BonusMalusBulletSpeed>().SpeedDown();
        }
    }
}
