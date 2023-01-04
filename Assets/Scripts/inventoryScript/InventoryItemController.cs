using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    public Item item;

     GameObject spawnCookCut;
     GameObject spawnCookSmash;
     GameObject camScript;
     [SerializeField] GameObject spawnCookOption;

    [SerializeField] List<GameObject> spawnableObject = new List<GameObject>();

    Cutting playerControllerCut;
    Smash playerControllerSmash;
    gameManager gm;
    Customer ct;
    int activeCam=0;
    private void Start()
    {
        camScript = GameObject.Find("Camera/firstCam");
        spawnCookCut = GameObject.Find("spawnObjCut");
        spawnCookSmash = GameObject.Find("spawnObjSmash");
        spawnCookOption = GameObject.Find("Ui/ScreenInterractible/CookingOption");
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
        ct = GameObject.Find("GameManager").GetComponent<Customer>();
        playerControllerCut = GameObject.Find("Player").GetComponent<Cutting>();
        playerControllerSmash = GameObject.Find("Player").GetComponent<Smash>();
        
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
        if (activeCam == 0 && item.itemName == ct.GetActualQuest())
        {
            ct.QuestAchieved();
            RemoveItem();
        }
        else
        {
            activeCam = gm.GetActiveCam();
            gm.StartCookTween();
            spawnCookOption.SetActive(true);
            camScript.GetComponent<AimCamera>().tmpItem = this.gameObject;
            GameObject.Find("Ui/Inventory").SetActive(false);
        }
 
        
    }

   public void SpawnOnSmash()
    {
        GameObject obj=null;
        switch (item.itemType)
        {
            case Item.ItemType.Agastache:
                obj = Instantiate(spawnableObject.Find(x => x.name == "AgastacheSmash"), spawnCookSmash.transform.position, Quaternion.Euler(0, 0, 0));
                obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                playerControllerSmash.SetObjToSmash(obj);
                RemoveItem();
                break;
            case Item.ItemType.Weed:
                obj = Instantiate(spawnableObject.Find(x => x.name == "WeedSmash"), spawnCookSmash.transform.position, Quaternion.Euler(0, 0, 0));
                obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                playerControllerSmash.SetObjToSmash(obj);
                RemoveItem();
                break;
            case Item.ItemType.Champi:
                obj = Instantiate(spawnableObject.Find(x => x.name == "ChampiSmash"), spawnCookSmash.transform.position, Quaternion.Euler(0, 0, 0));
                obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                playerControllerSmash.SetObjToSmash(obj);
                RemoveItem();
                break;
            case Item.ItemType.Sunflower:
                obj = Instantiate(spawnableObject.Find(x => x.name == "SunflowerSmash"), spawnCookSmash.transform.position, Quaternion.Euler(0, 0, 0));
                obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                playerControllerSmash.SetObjToSmash(obj);
                RemoveItem();
                break;
        }

    }
    public void SpawnOnCut()
    {
        GameObject obj = null;
        switch (item.itemType)
        {
            case Item.ItemType.Agastache:
                obj = Instantiate(spawnableObject.Find(x => x.name == "AgastacheCut"), spawnCookCut.transform.position, Quaternion.Euler(90, 0, 0));
                obj.transform.localScale = new Vector3(1, 1, 1);
                playerControllerCut.SetObjToCut(obj);
                RemoveItem();
                break;
            case Item.ItemType.Weed:
                obj = Instantiate(spawnableObject.Find(x => x.name == "WeedCut"), spawnCookCut.transform.position, Quaternion.Euler(90, 0, 0));
                playerControllerCut.SetObjToCut(obj);
                RemoveItem();
                break;
            case Item.ItemType.Champi:
                obj = Instantiate(spawnableObject.Find(x => x.name == "ChampiCut"), spawnCookCut.transform.position, Quaternion.Euler(90, 0, 0));
                playerControllerCut.SetObjToCut(obj);
                RemoveItem();
                break;
            case Item.ItemType.Sunflower:
                obj = Instantiate(spawnableObject.Find(x => x.name == "SunflowerCut"), spawnCookCut.transform.position, Quaternion.Euler(90, 0, 90));
                obj.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                playerControllerCut.SetObjToCut(obj);
                RemoveItem();
                break;
        }

    }
}
