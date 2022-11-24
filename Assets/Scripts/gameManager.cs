using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField] Customer customerScript;
    
    private void Start()
    {
        
    }
    public void newCustomer()
    {
        customerScript.newCustomer();
    }
}
