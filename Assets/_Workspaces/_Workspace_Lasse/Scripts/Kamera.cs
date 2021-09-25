using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{

    public GameObject player;
     
    //float interpSpeed;

    Vector3 targetPos;

    void LateUpdate()
    {

        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        //transform.position = Vector3.Lerp(transform.position, targetPos, interpSpeed);

    }
}
