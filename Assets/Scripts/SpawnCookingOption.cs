using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCookingOption : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject knife;
    [SerializeField] GameObject[] cookingOptions;
    [SerializeField] GameObject player;
    gameManager gm;
    GameObject currentCooking ;
    GameObject tempObj ;
    int swap = 0;
    bool isCutting = true;
    public bool GetIsCutting()
    {
        return isCutting;
    }
    private void Start()
    {
        gm = gameManager.GetComponent<gameManager>();
        currentCooking = cookingOptions[swap];
        tempObj=Instantiate(currentCooking, transform.position, Quaternion.Euler(new Vector3(0, 90, 0)));
    }
    public void ChangeCookingOption()
    {
        if (player.GetComponent<Cutting>().GetObjToCut() == null)
        {


            if (swap == 0)
            {
                swap = 1;
                knife.SetActive(false);
                isCutting = false;
                
            }
            else
            {
                swap = 0;
                knife.SetActive(true);
                isCutting = true;
            }
            Destroy(tempObj);
            currentCooking = cookingOptions[swap];
            tempObj=Instantiate(currentCooking, transform.position, Quaternion.Euler(new Vector3(0,90,0)));
            if (isCutting == false)
            {
                player.GetComponent<Smash>().SetSmashSpawn();
            }
        }
    }
}
