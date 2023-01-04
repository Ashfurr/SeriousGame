using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCamera : MonoBehaviour
{
    [SerializeField] Vector3 MortarAim;
    [SerializeField] Vector3 BoardAim;
    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject joystick;
    [SerializeField] CinemachineVirtualCamera ActualCam;
    [SerializeField] GameObject Knife;
    public int isMashing;

    public GameObject tmpItem;

    Vector3 OriginPosition;
    private void Start()
    {
        OriginPosition = this.transform.position;
    }
    public void SelectMortar()
    {
        isMashing = 1;
        ActualCam.transform.DOLocalMove(MortarAim, 0.5f);
        tmpItem.GetComponent<InventoryItemController>().SpawnOnSmash();


    }
    public void SelectBoard()
    {
        isMashing=2;
        ActualCam.transform.DOLocalMove(BoardAim, 0.5f);
        tmpItem.GetComponent<InventoryItemController>().SpawnOnCut();
        Knife.transform.DOLocalMove(new Vector3(0.192000002f, 0.275999993f, -0.379999995f),0.5f);
        Knife.transform.DOLocalRotate(new Vector3(22.2968559f, 273.808502f, 95.0603561f),0.5f);
    }
    public void ResetCam()
    {
        if (isMashing == 2)
        {
            Knife.transform.DOLocalMove(new Vector3(0.0380199663f, 0.0353978984f, 0.0640460253f), 0.5f);
            Knife.transform.DOLocalRotate(new Vector3(7.56951809f, 194.021011f, 1.88406742f), 0.5f);
        }
        isMashing=0;
        ActualCam.transform.DOMove(OriginPosition, 0.5f);
        joystick.SetActive(false);
    }
}
