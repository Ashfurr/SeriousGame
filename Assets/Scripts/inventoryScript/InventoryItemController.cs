using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    public Item item;

     GameObject spawnCookCut;
     GameObject spawnCookSmash;
     GameObject spawnCookOption;

    [SerializeField] List<GameObject> spawnableObject = new List<GameObject>();

    Cutting playerControllerCut;
    Smash playerControllerSmash;
    gameManager gm;
    Customer ct;
    int activeCam=0;
    private void Start()
    {
        spawnCookCut = GameObject.Find("spawnObjCut");
        spawnCookSmash = GameObject.Find("spawnObjSmash");
        spawnCookOption = GameObject.Find("SpawnCookingOption");
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
        ct = GameObject.Find("GameManager").GetComponent<Customer>();
        playerControllerCut = GameObject.Find("Player").GetComponent<Cutting>();
        playerControllerSmash = GameObject.Find("Player").GetComponent<Smash>();
        
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
        print(spawnableObject.Find(x => x.name == "AgastacheSmash"));
        activeCam = gm.GetActiveCam();
        
        GameObject obj = null;
        if (activeCam==2 && playerControllerCut.GetObjToCut()==null && spawnCookOption.GetComponent<SpawnCookingOption>().GetIsCutting() )
        {
            SpawnOnCut(obj);
        }
        if(activeCam==2 &&  playerControllerSmash.GetObjToSmash()==null&& !spawnCookOption.GetComponent<SpawnCookingOption>().GetIsCutting())
        {
            SpawnOnSmash(obj);
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
    void SpawnOnSmash(GameObject obj)
    {
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
    void SpawnOnCut(GameObject obj)
    {

        switch (item.itemType)
        {
            case Item.ItemType.Agastache:
                obj = Instantiate(spawnableObject.Find(x => x.name == "AgastacheCut"), spawnCookCut.transform.position, Quaternion.Euler(0, 0, 90));
                obj.transform.localScale = new Vector3(2, 2, 2);
                playerControllerCut.SetObjToCut(obj);
                RemoveItem();
                break;
            case Item.ItemType.Weed:
                obj = Instantiate(spawnableObject.Find(x => x.name == "WeedCut"), spawnCookCut.transform.position, Quaternion.Euler(0, 0, 90));
                playerControllerCut.SetObjToCut(obj);
                RemoveItem();
                break;
            case Item.ItemType.Champi:
                obj = Instantiate(spawnableObject.Find(x => x.name == "ChampiCut"), spawnCookCut.transform.position, Quaternion.Euler(0, 0, 90));
                playerControllerCut.SetObjToCut(obj);
                RemoveItem();
                break;
            case Item.ItemType.Sunflower:
                obj = Instantiate(spawnableObject.Find(x => x.name == "SunflowerCut"), spawnCookCut.transform.position, Quaternion.Euler(0, 0, 90));
                obj.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                playerControllerCut.SetObjToCut(obj);
                RemoveItem();
                break;
        }

    }
}
