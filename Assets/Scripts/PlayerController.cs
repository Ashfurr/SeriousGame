using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float flowerDistance;
    [SerializeField] int currentcam=0;
    [SerializeField] List<Vector3> cutCoord= new List<Vector3> { } ;
    
    private GameObject flowerSelected;
    private GameObject objToCut=null;
    private Vector2 startPos;
    private Vector2 endPos;
    private bool plop = false;

    [SerializeField] GameObject Knife;
    [SerializeField] int cutDistance;
    float distanceScreen;
    bool isCutting;
    int compCut = 1;
    public void SetActivecam(int cam)
    {
        currentcam = cam;
    }
    public void SetObjToCut(GameObject obj)
    {
        objToCut = obj;
    }
    public GameObject GetObjToCut()
    {
        return objToCut;
    }
    void Update()
    {
        if (currentcam == 1)
        {

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {

                    if (hit.collider.tag == "flower")
                    {
                        print("je touche la fleur");
                        flowerSelected = hit.collider.gameObject;
                        startPos = Input.GetTouch(0).position;
                    }
                }
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && flowerSelected != null)
            {
                print("je lui pisse dessus");
                endPos = Input.GetTouch(0).position;
                float distance = Vector2.Distance(startPos, endPos);
                if (distance > flowerDistance && !plop)
                {

                    plop = true;
                    harvestPlant();

                }
            }

        }
        if (currentcam==2 && objToCut!=null)
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
    private void harvestPlant()
    {
           
        flowerSelected.transform.DOMoveY(1f, 1f).SetId("harvest").SetEase(Ease.OutElastic).OnComplete(destroyPlant);
        DOTween.Play("harvest");
    }
    private void destroyPlant()
    {
        Item Item = flowerSelected.GetComponent<ItemController>().item;
        InventoryManager.Instance.Add(Item);
        Destroy(flowerSelected);
        flowerSelected = null;
        plop = false;
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
