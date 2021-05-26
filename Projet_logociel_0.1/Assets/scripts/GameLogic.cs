using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameLogic : MonoBehaviour
{
    
    public GameObject[] pointspawn;
    public GameObject[] petitjoueurs;
    public int Vie;
    public void Spawn(GameObject petitbonhomme)
    {
        
        GameObject pointpawn = GetChoixSpawn(petitbonhomme);
        petitbonhomme.transform.position = pointpawn.transform.position;
        
    }
    GameObject GetRandompointspawn()
    {
        return pointspawn[Random.Range(0, pointspawn.Length)];
    }
    public GameObject VerifVie()
    {
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("petitbonhomme"))
        {
             
            //Debug.Log(i.name);
            Vie = GameObject.Find(i.name).GetComponent<VieScore>().GetVie(i);

            Debug.Log(Vie);
            if (Vie <= 0)
            {
                Debug.Log("mort");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                return i;

            }
            
        }
        return null ;
    }

    GameObject GetChoixSpawn(GameObject playerDeath)
    {
        //Debug.Log(playerDeath);
        if (playerDeath != null)
        {


            float[] minSqrDistances = new float[pointspawn.Length];
            for (int i = 0; i < pointspawn.Length; i++)
            {
                float min = Mathf.Infinity;
                for (int j = 0; j < petitjoueurs.Length; j++)
                {
                    float sqrDistance = (petitjoueurs[j].transform.position - pointspawn[i].transform.position).sqrMagnitude;
                    if (sqrDistance < min)
                    {
                        min = sqrDistance;
                    }
                    minSqrDistances[i] = min;
                }

            }
            float max = minSqrDistances[0];
            int maxIndex = 0;
            for (int i = 1; i < minSqrDistances.Length; i++)
            {
                if (max < minSqrDistances[i])
                {
                    max = minSqrDistances[i];
                    maxIndex = i;
                }
            }
            return pointspawn[maxIndex];

        }
        return null;
    }

    public GameObject GetKiller(GameObject joueur)
    {
        if(joueur.name == "rouge")
        {
            GameObject killer = GameObject.Find("gris");
            return killer;
        }
        else
        {
            GameObject killer = GameObject.Find("rouge");
            return killer;
        }
    }

    
    
}
