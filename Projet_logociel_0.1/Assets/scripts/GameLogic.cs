using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    
    public GameObject[] pointspawn;
    public GameObject[] petitjoueurs;

    public void Spawn(GameObject petitbonhomme)
    {
        GameObject pointpawn = GetChoixSpawn();
        petitbonhomme.transform.position = pointpawn.transform.position;
    }
    GameObject GetRandompointspawn()
    {
        return pointspawn[Random.Range(0, pointspawn.Length)];
    }
    GameObject GetChoixSpawn()
    {
        float[] minSqrDistances = new float[pointspawn.Length];
        for (int i=0; i < pointspawn.Length; i++)
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
        float max =minSqrDistances[0];
        int maxIndex=0;
        for(int i=1; i<minSqrDistances.Length; i++)
        {
            if (max < minSqrDistances[i])
            {
                max = minSqrDistances[i];
                maxIndex = i;
            }
        }
        return pointspawn[maxIndex];
    }
}
