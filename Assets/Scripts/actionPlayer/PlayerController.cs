using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float flowerDistance;
    [SerializeField] int currentcam=0;
    [SerializeField] GameObject buttonInventory;
    [SerializeField] GameObject imagefinger;
    private GameObject flowerSelected;
    private bool tuto=true;
    private Vector2 startPos;
    private Vector2 endPos;
    private bool plop = false;

    public void SetActivecam(int cam)
    {
        currentcam = cam;
    }

    
    void Update()
    {
        if (currentcam == 1)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !plop)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "flower")
                    {   
                        imagefinger.SetActive(false);
                        flowerSelected = hit.collider.gameObject;
                        startPos = Input.GetTouch(0).position;
                    }
                }
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && flowerSelected != null &&  !plop)
            {               
                endPos = Input.GetTouch(0).position;
                float distance = Vector2.Distance(startPos, endPos);
                if (distance > flowerDistance)
                {
                    plop = true;
                    Item Item = flowerSelected.GetComponent<ItemController>().item;
                    InventoryManager.Instance.Add(Item);
                    harvestPlant();
                }
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
        Destroy (flowerSelected);
        
        plop = false;
        buttonInventory.transform.DOScale(1.1f, 0.2f).SetLoops(2, LoopType.Yoyo).SetId("juice");
        DOTween.Play("juice");
        if (tuto == true)
        {
            tuto = false;
            GameObject.Find("GameManager").GetComponent<Customer>().Tuto4Garden();
        }


    }

}
