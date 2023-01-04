using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutting : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject Knife;
    [SerializeField] List<Vector3> cutCoord = new List<Vector3> { };
    gameManager gm;
    private GameObject objToCut = null;
    private Vector2 startPos;
    private Vector2 endPos;
    float distanceScreen;
    public bool isCutting;
    int compCut = 0;
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
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void cut()
    {
       
        if (compCut < 3)
        {
            Sequence cutting = DOTween.Sequence();
            cutting.Append(Knife.transform.DOLocalMove(new Vector3(cutCoord[compCut].x, 0.077f, cutCoord[compCut].z), 0.5f).SetLoops(2, LoopType.Yoyo));     
            cutting.Append(Knife.transform.DOLocalMove(cutCoord[compCut + 1], 0.2f));
            cutting.Play();
            cutting.OnComplete(() => { isCutting = false; distanceScreen = 0; cutting.Kill(); });
            compCut ++;
        }
        else
        {
            Knife.transform.DOLocalMove(cutCoord[compCut], 0.2f).SetId("last");
            DOTween.Play("last");
            compCut = 0;

            Item Item = objToCut.GetComponent<ItemController>().item;
            InventoryManager.Instance.Add(Item);
            Destroy(objToCut);
            objToCut = null;
            GameObject.Find("Camera/firstCam").GetComponent<AimCamera>().ResetCam();
        };

    }
}
