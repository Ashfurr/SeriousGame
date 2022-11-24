using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    [SerializeField] GameObject customerPrefab;
    [SerializeField] Transform[] paths;
    [SerializeField] float[] timePaths;

    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject uiCustomer;

    Image patologie;
    GameObject actualCustomer = null;
    private void Awake()
    {
        patologie = uiCustomer.GetComponent<Image>();
    }

    public void newCustomer()
    {
        actualCustomer = Instantiate(customerPrefab, paths[0]);
        Sequence customerPath = DOTween.Sequence().SetId("path").OnComplete(imagePatologie);
        for (int i = 1; i < paths.Length; i++)
        {

            customerPath.Append(actualCustomer.transform.DOMove(new Vector3(paths[i].position.x, 1.85f, paths[i].position.z), timePaths[i]));
        }
        DOTween.Play("path");
    }
    private void imagePatologie()
    {
        patologie.DOFade(0.8f, 0.5f).SetId("custText");
        DOTween.Play("custText");
    }
}
