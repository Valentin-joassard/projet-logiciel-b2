using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public Vector2 velocity=new Vector2(0.0f,0.0f);
    public GameObject petitbonhomme;
    public Vector2 offset=new Vector2(0.0f,0.0f);
    private GameObject playerDeath = null;

    void Update(){
        Vector2 currentPosition = new Vector2(transform.position.x,transform.position.y);
        Vector2 newPosition = currentPosition + velocity * Time.deltaTime;
        Debug.DrawLine(currentPosition + offset,newPosition+ offset,Color.red);
        RaycastHit2D[] hits= Physics2D.LinecastAll(currentPosition + offset,newPosition + offset);
        foreach (RaycastHit2D hit in hits){
            GameObject other= hit.collider.gameObject;
            if(other!= petitbonhomme){
                if (other.CompareTag("petitbonhomme")){
                    

                    name = other.name;
                    GameObject.Find(name).GetComponent<VieScore>().GererVie(other);
                    
                    playerDeath=GameObject.Find("Gamelogic").GetComponent<GameLogic>().VerifVie();
                    
                    GameObject.Find("Gamelogic").GetComponent<GameLogic>().Spawn(other,playerDeath);
                    Destroy(gameObject);
                    
                    Debug.Log(other.name);
                    break;
                }
                if (other.CompareTag("wall")){
                    Destroy(gameObject);
                    break;
                }
            }

            
        }
        transform.position=newPosition;
    }
}
