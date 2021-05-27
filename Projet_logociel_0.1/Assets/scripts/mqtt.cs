using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using System;
using System.Collections.Generic;

//[Serializable]
//public class Jsonmessage
//{
//    public string stick;
//    public string player;
//    public string button;
//    public string evenenement;
//}

public class mqtt : MonoBehaviour
{

    public List<String> PlayersId;

    private MqttClient client;
    private string message;

    // Use this for initialization
    //void Start()
    //{
    //    // create client instance 
    //    client = new MqttClient(IPAddress.Parse("51.158.79.224"), 1883, false, null);

    //    // register to message received 
    //    client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;



    //    string clientId = Guid.NewGuid().ToString();
    //    client.Connect(clientId);

    //    client.Subscribe(new string[] { "maxence/command" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
    //    //Jsonmessage jsoncommand = JsonUtility.FromJson<Jsonmessage>(message.ToString());


    //    //Debug.Log(message.ToString());
    //    //Debug.Log(jsoncommand.player);
    //    // subscribe to the topic "/home/temperature" with QoS 2 
    //    //client.Subscribe(new string[] { "/connect" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });






    //}
    //void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    //{

    //    //Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));
    //    message = System.Text.Encoding.UTF8.GetString(e.Message);
    //    //message = "{\"stick\": \"C\", \"player\": \"bac2\"}";
    //    //Debug.Log(message);
    //    Jsonmessage jsoncommand = JsonUtility.FromJson<Jsonmessage>(message);

    //    //Debug.Log("player" + jsoncommand.player);
    //    //Debug.Log("stick"+ jsoncommand.stick);
    //    //Debug.Log("button" +jsoncommand.button);
    //    //Debug.Log("evenement" + jsoncommand.evenenement);
        


    //    if (e.Topic == "/connect")
    //    {
    //        connectToJoyStick(e);
    //    }
    //}

    string client_received(MqttMsgPublishEventArgs e)
    {
        message = (e.Message).ToString();
        return message;
    }

    void connectToJoyStick(MqttMsgPublishEventArgs e)
    {
        PlayersId.Add(System.Text.Encoding.UTF8.GetString(e.Message));

        int Id = PlayersId.Count;

        Debug.Log(Id);

        client.Publish("JoystickValentinMaxence/" + System.Text.Encoding.UTF8.GetString(e.Message), System.Text.Encoding.UTF8.GetBytes(Id.ToString()), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(20, 40, 80, 20), "Level 1"))
        {
            client.Publish("hello/world", System.Text.Encoding.UTF8.GetBytes("YO LES REUFS"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        }
    }
    // Update is called once per frame
    void Update()
    {



    }


}