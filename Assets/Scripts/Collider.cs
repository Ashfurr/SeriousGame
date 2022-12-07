using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
   public bool isActivated=false;

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.gameObject.tag == "pillon")
        {       
            isActivated = true;
            GameObject.Find("Player").GetComponent<Smash>().SetColliderTouch();
        }
    }
}
