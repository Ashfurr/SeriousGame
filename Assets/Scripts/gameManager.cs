using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField] Customer customerScript;
    [SerializeField] GameObject player;
    [SerializeField] int timeBeforeActiveCam;
    int activeCam ;
    
    private void Start()
    {
        
    }
    public int GetActiveCam()
    {
        return activeCam;
    }

    public void SetActiveCam(int cam)
    {
        StartCoroutine(DelayCam(cam));
    }
    IEnumerator DelayCam(int cam)
    {
        yield return new WaitForSeconds(timeBeforeActiveCam);
        activeCam = cam;
        player.GetComponent<PlayerController>().SetActivecam(cam);
        print(cam);
    }
    public void newCustomer()
    {
        customerScript.newCustomer();
    }
}
