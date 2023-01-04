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
    int activeCam =0;
    

    public int GetActiveCam()
    {
        return activeCam;
    }
    public void StartCookTween()
    {
        Mortar.transform.DOScale(1.5f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetId("mortar");
        Board.transform.DOScale(0.4f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetId("board");
        DOTween.Play("mortar");
        DOTween.Play("board");

    }
    public void StopTweenCook()
    {
        if (DOTween.IsTweening("mortar"))
        {
            DOTween.Kill("mortar");
            DOTween.Kill("board");
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
