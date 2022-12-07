using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiScript : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera[] cams;
    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject cookingOption;
    public int activeScene = 0;
    PlayerController playerController;
    gameManager gm;
    private void Start()
    {
        gm = gameManager.GetComponent<gameManager>();
        playerController=GameObject.Find("Player").GetComponent<PlayerController>();
        cams[0].Priority = 20;
        cams[1].Priority = 10;
        cams[2].Priority = 10;
    }
    private void Update()
    {
        
    }
    public void nextCam()
    {
      
        if (activeScene < 2)
        {
            activeScene++;
            for (int i = 0; i < cams.Length; i++)
            {
                if (i == activeScene)
                {
                    cams[i].Priority = 20;
                    
                }
                else
                {
                    cams[i].Priority = 10;
                }
            }
        }
        else
        {
            activeScene = 0;
            for (int i = 0; i < cams.Length; i++)
            {
                if (i == activeScene)
                {
                    cams[i].Priority = 20;
                }
                else
                {
                    cams[i].Priority = 10;
                }
            }

            
        }
        gm.SetActiveCam(activeScene);
        StartCoroutine(ActivaveCookingOption());


    }
    public void previousCam()
    {
        
        if (activeScene > 0)
        {
            activeScene--;
            for (int i = 0; i < cams.Length; i++)
            {
                if (i == activeScene)
                {
                    cams[i].Priority = 20;
                    
                }
                else
                {
                    cams[i].Priority = 10;
                }
            }
        }
        else
        {
            activeScene = 2;
            for (int i = 0; i < cams.Length; i++)
            {
                
                if (i == activeScene)
                {
                    cams[i].Priority = 20;
                }
                else
                {
                    cams[i].Priority = 10;
                }
            }
            
        }
        gm.SetActiveCam(activeScene);
        StartCoroutine(ActivaveCookingOption());


    }
    IEnumerator ActivaveCookingOption()
    {
       
        if(activeScene == 2)
        {
            yield return new WaitForSeconds(1.5f);
            if (activeScene == 2)
            {
                cookingOption.SetActive(true);
            }
        }
        else
        {
            cookingOption.SetActive(false);
        }
    }


}
