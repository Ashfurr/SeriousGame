using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField] Customer customerScript;
    [SerializeField] GameObject player;
    GameObject vt;
    [SerializeField] int timeBeforeActiveCam;
    [SerializeField] GameObject uiCustomer;
    int activeCam =0;
    
    private void Start()
    {
        vt.transform.DORotate
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
        if(activeCam != 0)
        {
            uiCustomer.SetActive(false);
        }
        else
        {
            uiCustomer.SetActive(true);
        }
    }
    public void newCustomer()
    {
        customerScript.newCustomer();
    }
}
