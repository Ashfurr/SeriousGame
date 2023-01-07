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
            switch (item.itemType)
            {
                case Item.ItemType.Agastache:
                    activeCam = gm.GetActiveCam();
                    gm.StartCookTween();
                    spawnCookOption.SetActive(true);
                    camScript.GetComponent<AimCamera>().tmpItem = this.gameObject;
                    GameObject.Find("Ui/Inventory").SetActive(false);
                    gm.finger.SetActive(false);
                    break;
                case Item.ItemType.Weed:
                    activeCam = gm.GetActiveCam();
                    gm.StartCookTween();
                    spawnCookOption.SetActive(true);
                    camScript.GetComponent<AimCamera>().tmpItem = this.gameObject;
                    GameObject.Find("Ui/Inventory").SetActive(false);
                    break;
                case Item.ItemType.Champi:
                    activeCam = gm.GetActiveCam();
                    gm.StartCookTween();
                    spawnCookOption.SetActive(true);
                    camScript.GetComponent<AimCamera>().tmpItem = this.gameObject;
                    GameObject.Find("Ui/Inventory").SetActive(false);
                    break;
                case Item.ItemType.Sunflower:
                    activeCam = gm.GetActiveCam();
                    gm.StartCookTween();
                    spawnCookOption.SetActive(true);
                    camScript.GetComponent<AimCamera>().tmpItem = this.gameObject;
                    GameObject.Find("Ui/Inventory").SetActive(false);
                    break;
                    default:
                    break;
            }
        }
       
    }

   public void SpawnOnSmash()
    {
        GameObject obj=null;
        switch (item.itemType)
        {
            case Item.ItemType.Agastache:
                obj = Instantiate(spawnableObject.Find(x => x.name == "AgastacheSmash"), new Vector3(-6.95870018f, 1.14100003f, -11.5030003f), Quaternion.Euler(0, 0, 90));
                obj.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
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
                obj = Instantiate(spawnableObject.Find(x => x.name == "AgastacheCut"), new Vector3(-7.0302f, 0.808000028f, -11.1370001f), Quaternion.Euler(90, 0, 90));
                obj.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
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
