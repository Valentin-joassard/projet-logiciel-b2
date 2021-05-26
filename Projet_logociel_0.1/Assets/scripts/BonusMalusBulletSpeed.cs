using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMalusBulletSpeed : MonoBehaviour
{
    public float speed = 3.0f;

    public void SpeedDown()
    {
        speed = 2.0f;
    }

    public void SpeedUp()
    {
        speed = 4.0f;
    }

    public void SpeedReset()
    {
        speed = 3.0f;
    }
}
