using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    [SerializeField] Joystick controller;
    [SerializeField] float width;
    [SerializeField] GameObject spawnCook;
    gameManager gm;
    SpawnCookingOption sco;
    Transform bowl;
    GameObject pillon;
    bool collidertouch = false;
    public void SetColliderTouch()
    {
        if(!collidertouch)
        {
            GameObject[] colliderbowl = GameObject.FindGameObjectsWithTag("collider");
            int tempColliderTouch=0;
            foreach (GameObject col in colliderbowl)
            {
                if(col.GetComponent<Collider>().isActivated == true)
                {
                    tempColliderTouch++;
                    if(tempColliderTouch == 4)
                    {
                        collidertouch = true;
                        print("j'ai tout touché");
                    }
                };
            }
            
        }
        else
        {
            collidertouch = false;
            GameObject[] colliderbowl = GameObject.FindGameObjectsWithTag("collider");
            foreach(GameObject col in colliderbowl)
            {
                col.GetComponent<Collider>().isActivated = false;
            }
            print("je reset");
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

    // Update is called once per frame
    void Update()
    {
        if (gm.GetActiveCam() == 2 && !sco.GetIsCutting())
        {
            float x = bowl.position.x + Mathf.Sin(controller.Direction.x) * width;
            float z = bowl.position.z + Mathf.Sin(controller.Direction.y) * width;
            float y = bowl.position.y + 0.5f;
            pillon.transform.position = new Vector3(x, y, z);
        }
    }
}
