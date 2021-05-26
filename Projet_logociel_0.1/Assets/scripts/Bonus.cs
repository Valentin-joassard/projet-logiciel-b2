using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private bool buffGris = false;
    private bool buffRouge = false;
    public bool isVisible = true;

    void Start()
    {
        StartCoroutine(ResetBuffRouge());
        //StartCoroutine(SpawnBonus());
        StartCoroutine(ResetBuffGris());
    }
    void Update()
    {
        StartCoroutine(ResetBuffRouge());
        //StartCoroutine(SpawnBonus());
        StartCoroutine(ResetBuffGris());
    }
    IEnumerator ResetBuffGris()
    {
        if (buffGris)
        {
            yield return new WaitForSeconds(5);
            GameObject.Find("gris").GetComponent<BonusMalusBulletSpeed>().SpeedReset();
            buffGris = false;
            Debug.Log("buff fini");
        }
    }

    IEnumerator ResetBuffRouge()
    {
        if (buffRouge)
        {
            yield return new WaitForSeconds(5);
            GameObject.Find("rouge").GetComponent<BonusMalusBulletSpeed>().SpeedReset();
            buffRouge = false;
            Debug.Log("buff fini");
        }
        
    }
    //Spawn aleatoire des bonus a faire
    //IEnumerator SpawnBonus()
    //{
    //    if (!isVisible)
    //    {
    //        GameObject newBonus = GameObject.Find("bonus");
    //        Destroy(GameObject.Find("bonus"));
    //        newBonus.transform.position = new Vector2(0.63f, 0.73f);
    //        yield return new WaitForSeconds(5);
    //        Instantiate(newBonus, newBonus.transform.position, Quaternion.identity);
    //        isVisible = true;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "rouge")
        {
            buffRouge = true;
            GameObject.Find("rouge").GetComponent<BonusMalusBulletSpeed>().SpeedUp();
            Debug.Log("iouzfghez");
            isVisible = false;
        }

        if (collision.gameObject.name == "gris")
        {
            buffGris = true;
            GameObject.Find("gris").GetComponent<BonusMalusBulletSpeed>().SpeedUp();
            isVisible = false;
        }
    }
}
