using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{

    public GameObject player;
    [SerializeField] float MinX = -30;
    [SerializeField] float MaxX = 200;

    //float interpSpeed;

    Vector3 targetPos;

    void LateUpdate()
    {
        float x = player.transform.position.x;
        if (x < MinX)
            x = MinX;
        else if (x > MaxX)
            x = MaxX;

        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
