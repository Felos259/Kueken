using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grube : MonoBehaviour
{

    public Kueken player;

    private void OnTriggerEnter(Collider other)
    {
        //Kueken player = other.gameObject.GetComponent<Kueken>();
        //if (player == null)
          //  return;
        //player.GetComponent<PolygonCollider2D>().enabled = true;
        player.Die();
        System.Console.WriteLine("now");
    }
}
