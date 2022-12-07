using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutting : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    [SerializeField] int cutDistance = 1000;
    [SerializeField] GameObject Knife;
    [SerializeField] GameObject spawnCook;
    [SerializeField] List<Vector3> cutCoord = new List<Vector3> { };
    gameManager gm;
    SpawnCookingOption sco;
    private GameObject objToCut = null;
    private Vector2 startPos;
    private Vector2 endPos;
    float distanceScreen;
    bool isCutting;
    int compCut = 1;
    public GameObject GetObjToCut()
    {
        return objToCut;
    }
    public void SetObjToCut(GameObject obj)
    {
        objToCut = obj;
    }
    private void Start()
    {
        gm = gameManager.GetComponent<gameManager>();
        sco = spawnCook.GetComponent<SpawnCookingOption>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.GetActiveCam() == 2 && objToCut != null && sco.GetIsCutting())
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startPos = Input.GetTouch(0).position;
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endPos = Input.GetTouch(0).position;
                distanceScreen = Vector2.Distance(startPos, endPos);

            }
            if (distanceScreen > cutDistance && !isCutting)
            {

                isCutting = true;
                cut();
            }
        }
    }
    void cut()
    {
        Sequence cutting = DOTween.Sequence();
        cutting.Append(Knife.transform.DOMove(cutCoord[compCut], 0.5f).SetLoops(2, LoopType.Yoyo));
        cutting.Append(Knife.transform.DOMove(cutCoord[compCut + 1], 1f));
        cutting.Play();
        cutting.OnComplete(() => { isCutting = false; distanceScreen = 0; cutting.Kill(); });
        if (compCut < 7)
        {
            compCut += 2;
        }
        else
        {
            compCut = 1;
            Item Item = objToCut.GetComponent<ItemController>().item;
            InventoryManager.Instance.Add(Item);
            Destroy(objToCut);
            objToCut = null;
        };

    }
}
