using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    public Item item;

    [SerializeField] GameObject spawnCook;

    [SerializeField] List<GameObject> spawnableObject = new List<GameObject>();

    PlayerController playerController;
    gameManager gm;
    int activeCam=0;
    private void Start()
    {
        spawnCook = GameObject.Find("CuttingBoard");
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
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
        print(gm.GetActiveCam());
        if(activeCam==2)
        {
            switch (item.itemType)
            {
                case Item.ItemType.Agastache:
                    Instantiate(spawnableObject.Find(x => x.name == "Agastache"), spawnCook.transform.position,Quaternion.Euler(0,0,90));
                    RemoveItem();
                    break;
                case Item.ItemType.Weed:
                    Instantiate(spawnableObject.Find(x => x.name == "Weed"), spawnCook.transform.position, Quaternion.Euler(0, 0, 90));
                    RemoveItem();
                    break;
                case Item.ItemType.Champi:
                    Instantiate(spawnableObject.Find(x => x.name == "Champi"), spawnCook.transform.position, Quaternion.Euler(0, 0, 90));
                    RemoveItem();
                    break;
                case Item.ItemType.Sunflower:
                    Instantiate(spawnableObject.Find(x => x.name == "Sunflower"), spawnCook.transform.position, Quaternion.Euler(0, 0,90));
                    RemoveItem();
                    break;
            }
        }
    }
}
