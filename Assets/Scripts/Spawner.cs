using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject flowerRef;
    [SerializeField] GameObject flowerPrefab;
    Vector3 flowerPlace;

    private void Start()
    {
        flowerPlace = flowerRef.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (flowerRef == null)
        {
            flowerRef=Instantiate(flowerPrefab, flowerPlace,flowerPrefab.transform.rotation);

        }
    }
}
