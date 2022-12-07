using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    public Item item;

    [SerializeField] GameObject spawnCook;

    [SerializeField] List<GameObject> spawnableObject = new List<GameObject>();

    Cutting playerControllerCut;
    gameManager gm;
    Customer ct;
    int activeCam=0;
    private void Start()
    {
        spawnCook = GameObject.Find("spawnObjCut");
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
        ct = GameObject.Find("GameManager").GetComponent<Customer>();
        playerControllerCut = GameObject.Find("Player").GetComponent<Cutting>();
    }
    public void SetCurrentCam(int cam)
    {
        StartCoroutine(DelayCam(1, cam));
    }
    IEnumerator DelayCam(int second, int cam)
    {
        yield return new WaitForSeconds(second);
        activeCam = cam;
    }

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }
    public void AddItem(Item NewItem)
    {
        item = NewItem;
    }
    public void UseItem()
    {
        activeCam = gm.GetActiveCam();
        
        GameObject obj = null;
        if (activeCam==2 && playerControllerCut.GetObjToCut()==null)
        {
            
            switch (item.itemType)
            {
                case Item.ItemType.Agastache:
                    obj=Instantiate(spawnableObject.Find(x => x.name == "AgastacheCut"), spawnCook.transform.position,Quaternion.Euler(0,0,90));
                    obj.transform.localScale = new Vector3(2,2,2);
                    playerControllerCut.SetObjToCut(obj);
                    RemoveItem();
                    break;
                case Item.ItemType.Weed:
                    obj = Instantiate(spawnableObject.Find(x => x.name == "WeedCut"), spawnCook.transform.position, Quaternion.Euler(0, 0, 90));
                    playerControllerCut.SetObjToCut(obj);
                    RemoveItem();
                    break;
                case Item.ItemType.Champi:
                    obj = Instantiate(spawnableObject.Find(x => x.name == "ChampiCut"), spawnCook.transform.position, Quaternion.Euler(0, 0, 90));
                    playerControllerCut.SetObjToCut(obj);
                    RemoveItem();
                    break;
                case Item.ItemType.Sunflower:
                    obj = Instantiate(spawnableObject.Find(x => x.name == "SunflowerCut"), spawnCook.transform.position, Quaternion.Euler(0, 0,90));
                    obj.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                    playerControllerCut.SetObjToCut(obj);
                    RemoveItem();
                    break;
            }
        }
        if(activeCam==0)
        {
            print(item.name + ct.GetActualQuest());
            if (item.itemName == ct.GetActualQuest())
            {
                
                ct.QuestAchieved();
                RemoveItem();
            }
        }
    }
}
