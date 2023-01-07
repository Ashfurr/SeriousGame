using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField] Customer customerScript;
    [SerializeField] GameObject player;

    [SerializeField] int timeBeforeActiveCam;
    [SerializeField] GameObject uiCustomer;
    [SerializeField] GameObject Mortar;
    [SerializeField] GameObject Board;
    [SerializeField] public  GameObject finger;
    int activeCam =0;
    public bool tuto = true;
    

    public int GetActiveCam()
    {
        return activeCam;
    }
    public void StartCookTween()
    {
        if (tuto == false)
        {
            Mortar.SetActive(true);    
            Mortar.transform.DOScale(1.5f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetId("mortar");
            DOTween.Play("mortar");
        }
        Board.transform.DOScale(0.4f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetId("board");
        DOTween.Play("board");

    }
    public void StopTweenCook()
    {
        if (DOTween.IsTweening("mortar"))
        {
            DOTween.Kill("mortar");
            
        }
        if (DOTween.IsTweening("board"))
        {
            DOTween.Kill("board");
            if (tuto == true)
            {
                finger.SetActive(true);
                finger.transform.DOLocalMove(new Vector3(-238, -628, 0), 0.5f).SetLoops(-1, LoopType.Restart).SetId("cut");
            }
               
        }
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
