using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coins")
        {
            Pool.instance.ReturnCoinToPool(other.gameObject);
            print("catch");
        }
        else if (other.gameObject.tag == "Bomb")
        {
            Pool.instance.ReturnBombToPool(other.gameObject);
        }
    }
}
