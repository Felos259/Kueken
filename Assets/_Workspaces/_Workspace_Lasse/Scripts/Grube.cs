using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grube : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Kueken player = other.gameObject.GetComponent<Kueken>();
        if (player == null)
            return;
        player.GetComponent<PolygonCollider2D>().enabled = true;
    }
}
