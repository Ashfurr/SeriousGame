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
    [SerializeField] GameObject uiCustomerImage;
    [SerializeField] GameObject uiCustomerText;

    [SerializeField] string[] Quests;

    Image patologie;
    Text patologieText;
    GameObject actualCustomer = null;
    private void Awake()
    {
        patologie = uiCustomerImage.GetComponent<Image>();
        patologieText = uiCustomerText.GetComponent<Text>();
    }
    public string GetActualQuest()
    {
        return Quests[0];
    }

    public void newCustomer()
    {
        actualCustomer = Instantiate(customerPrefab, paths[0]);
        Sequence customerPath = DOTween.Sequence().SetId("path").OnComplete(()=> { imagePatologie(); uiCustomerText.SetActive(true); });
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
        patologieText.text = Quests[0];
    }
    public void QuestAchieved()
    {
        Sequence customerPath = DOTween.Sequence().SetId("path2");
        for (int i = paths.Length-1; i >=0; i--)
        {

            customerPath.Append(actualCustomer.transform.DOMove(new Vector3(paths[i].position.x, 1.85f, paths[i].position.z), timePaths[i]));
        }
        DOTween.Play("path2");
        patologie.DOFade(0f, 0.5f).SetId("custText2");
        DOTween.Play("custText2");
        uiCustomerText.SetActive(false);
    }
}
