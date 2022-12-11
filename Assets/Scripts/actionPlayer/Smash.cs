using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    [SerializeField] Joystick controller;
    [SerializeField] float width;
    [SerializeField] GameObject spawnCook;
    [SerializeField] float maxItemHeight;
    private GameObject objToSmash = null;
    gameManager gm;
    SpawnCookingOption sco;
    Transform bowl;
    GameObject pillon;
    GameObject bowlCouvercle;
    int compteurTour;
    bool collidertouch = false;
    bool isSmashing=false;

    public GameObject GetObjToSmash()
    {
        return objToSmash;
    }
    public void SetObjToSmash(GameObject obj)
    {
        objToSmash = obj;
        ;
    }
    public void SetColliderTouch()
    {
        if (compteurTour <= 2)
        {
            if (!collidertouch)
            {
                GameObject[] colliderbowl = GameObject.FindGameObjectsWithTag("collider");
                int tempColliderTouch = 0;
                foreach (GameObject col in colliderbowl)
                {
                    if (col.GetComponent<Collider>().isActivated == true)
                    {
                        tempColliderTouch++;
                        if (tempColliderTouch == 4)
                        {
                            collidertouch = true;

                        }
                    };
                }

            }
            else
            {
                collidertouch = false;
                GameObject[] colliderbowl = GameObject.FindGameObjectsWithTag("collider");
                foreach (GameObject col in colliderbowl)
                {
                    col.GetComponent<Collider>().isActivated = false;
                }
                compteurTour++;
            }
        }
        else
        {
            Item Item = objToSmash.GetComponent<ItemController>().item;
            InventoryManager.Instance.Add(Item);
            Destroy(objToSmash);
            objToSmash = null;
            compteurTour = 0;
        }
       
    }

    public void SetSmashSpawn()
    {
        bowl = GameObject.Find("bowl").GetComponent<Transform>();
        pillon = GameObject.Find("pillon");
    }
    // Start is called before the first frame update
    void Start()
    {
        gm = gameManager.GetComponent<gameManager>();
        sco = spawnCook.GetComponent<SpawnCookingOption>();
    }


    void Update()
    {
        if(objToSmash != null && objToSmash.transform.position.y>maxItemHeight)
        {
            objToSmash.transform.position = new Vector3(objToSmash.transform.position.x, objToSmash.transform.position.y-0.01f, objToSmash.transform.position.z);
        }
        if (gm.GetActiveCam() == 2 && !sco.GetIsCutting() && objToSmash!=null)
        {
  
            float x = bowl.position.x + Mathf.Sin(controller.Direction.x) * width;
            float z = bowl.position.z + Mathf.Sin(controller.Direction.y) * width;
            float y = bowl.position.y + 0.5f;
            pillon.transform.position = new Vector3(x, y, z);
        }

    }
}
