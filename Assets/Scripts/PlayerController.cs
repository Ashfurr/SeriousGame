using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float flowerDistance;
    private GameObject flowerSelected;
    private Vector2 startPos;
    private Vector2 endPos;
    private bool plop = false;
    void Update()
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
}
