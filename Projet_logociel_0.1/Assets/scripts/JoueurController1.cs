using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using System;
using System.Collections.Generic;

[Serializable]
public class JsonmessageStick
{
    public string stick;
    public string player;
}

[Serializable]
public class JsonmessageButton
{
    public string button;
    public string evenement;
}

public class JoueurController1 : MonoBehaviour
{
    public int joueurId=0;
    public Animator animator;
    public GameObject Cible;
    public GameObject projectilePrefab;
    public Rigidbody2D rb;
    private MqttClient clientStick = new MqttClient(IPAddress.Parse("51.158.79.224"), 1883, false, null);
    private MqttClient clientButton = new MqttClient(IPAddress.Parse("51.158.79.224"), 1883, false, null);
    public JsonmessageStick jsoncommandStick;
    public JsonmessageButton jsoncommandButton;

    void Start()
    {
        // create client instance 
        

        // register to message received 
        clientStick.MqttMsgPublishReceived += client_MqttMsgPublishReceivedStick;
        clientButton.MqttMsgPublishReceived += client_MqttMsgPublishReceivedButton;



        string clientId = Guid.NewGuid().ToString();
        string clientIdButton = Guid.NewGuid().ToString();
        clientStick.Connect(clientId);
        clientButton.Connect(clientIdButton);

        clientStick.Subscribe(new string[] { "maxence/stick" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        clientButton.Subscribe(new string[] { "maxence/button" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
    }

    void client_MqttMsgPublishReceivedStick(object sender,MqttMsgPublishEventArgs e)
    {
        //Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));
        string message = System.Text.Encoding.UTF8.GetString(e.Message);
        //message = "{\"stick\": \"C\", \"player\": \"bac2\"}";
        //Debug.Log(message);
        jsoncommandStick = JsonUtility.FromJson<JsonmessageStick>(message);

        //Debug.Log("player" + jsoncommand.player);
        //Debug.Log("stick" + jsoncommand.stick);
    }

    void client_MqttMsgPublishReceivedButton(object sender, MqttMsgPublishEventArgs e)
    {
        //Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));
        string message = System.Text.Encoding.UTF8.GetString(e.Message);
        //message = "{\"stick\": \"C\", \"player\": \"bac2\"}";
        //Debug.Log(message);
        jsoncommandButton = JsonUtility.FromJson<JsonmessageButton>(message);

        //Debug.Log("player" + jsoncommand.player);
        //Debug.Log("stick" + jsoncommand.stick);
        //Debug.Log("button" + jsoncommand.button);
        //Debug.Log("evenement" + jsoncommand.evenenement);
    }



    void Update()
    {
        //message = client.WillMessage;
        //Debug.Log(jsoncommand.player);
        //Debug.Log(message);
        //Vector3 mouvement = new Vector3(Input.GetAxis("MoveHorizontalRouge"), Input.GetAxis("MoveVerticalRouge"), 0.0f);
        Vector3 mouvement = Move(jsoncommandStick.stick);

        shoot(mouvement.x, mouvement.y);
        //Debug.Log(mouvement);
        //MoveCrossHairandShoot();
        animator.SetFloat("Horizontal", mouvement.x);
        animator.SetFloat("Vertical", mouvement.y);
        animator.SetFloat("Magnitude", mouvement.magnitude);

        rb.velocity = new Vector2(mouvement.x, mouvement.y);
    }
    
    //private void MoveCrossHairandShoot(){
    //    Vector3 aim=new Vector3(Input.GetAxis("AimHorizontalRouge"),Input.GetAxis("AimVerticalRouge"),0.0f);
    //    Vector2 shootingDirection = new Vector2(Input.GetAxis("AimHorizontalRouge"),Input.GetAxis("AimVerticalRouge")  );
    //    //Vector2 shootingDirection = new Vector2(rb.get)
    //    if (aim.magnitude>0.0f){
    //        Debug.Log("oui");
    //        aim*=0.8f;
    //        Cible.transform.localPosition=aim;
    //        Cible.SetActive(true);

    //        if (Input.GetButtonDown("FireRouge"))
    //        {
    //            GameObject projectile = Instantiate(projectilePrefab,transform.position, Quaternion.identity);
    //            projectile projectileScript=projectile.GetComponent<projectile>();
    //            projectileScript.velocity = shootingDirection;
    //            projectileScript.petitbonhomme=gameObject;
                
    //            projectile.transform.Rotate(0.0f,0.0f, Mathf.Atan2(shootingDirection.y,shootingDirection.x)*Mathf.Rad2Deg);
    //            Destroy(projectile,3.0f);
    //    }
    //    }
    //    else {
    //        Cible.SetActive(false);
    //    }

    //}

    private void shoot(float movementX, float movementY)
    {
        Vector2 shootingDirection = new Vector2(movementX, movementY);
        Vector3 aim = new Vector3(movementX, movementY, 0.0f);
        //Vector3 aim = new Vector3(1.0f,0.0f, 0.0f) ;
        float bulletSpeed = GameObject.Find("rouge").GetComponent<BonusMalusBulletSpeed>().speed;
        if (aim.magnitude > 0.0f)
        {

            aim *= 0.4f;
            Cible.transform.localPosition = aim;
            Cible.SetActive(true);
            Debug.Log(jsoncommandButton.button);
            //if (Input.GetButtonDown("FireRouge"))
            if (jsoncommandButton.button == "yellow" && jsoncommandButton.evenement == "down")
            {
                GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                projectile projectileScript = projectile.GetComponent<projectile>();
                projectileScript.velocity = shootingDirection * bulletSpeed;
                projectileScript.petitbonhomme = gameObject;

                projectile.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
                //projectile.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(1.0f, 0.0f) * Mathf.Rad2Deg);
                Destroy(projectile, 3.0f);
            }
        }
        else
        {
            Cible.SetActive(false);
        }
    }

    private Vector3 Move(string stick)
    {
        if (stick == "N")
        {
            return new Vector3(0.0f, 1.0f, 0.0f);
        }
        if (stick == "S")
        {
            return new Vector3(0.0f, -1.0f, 0.0f);
        }
        if (stick == "E")
        {
            return new Vector3(1.0f, 0.0f, 0.0f);
        }
        if (stick == "W")
        {
            return new Vector3(-1.0f, 0.0f, 0.0f);
        }
        if (stick == "NW")
        {
            return new Vector3(-1.0f, 1.0f, 0.0f);
        }
        if (stick == "NE")
        {
            return new Vector3(1.0f, 1.0f, 0.0f);
        }
        if (stick == "SW")
        {
            return new Vector3(-1.0f, -1.0f, 0.0f);
        }
        if (stick == "SE")
        {
            return new Vector3(1.0f, -1.0f, 0.0f);
        }
        return new Vector3(0.0f, 0.0f, 0.0f);
    }
}

