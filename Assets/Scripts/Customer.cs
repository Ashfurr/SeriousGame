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
    string ActualQuest;
    GameObject actualCustomer = null;
    private void Awake()
    {
        patologie = uiCustomerImage.GetComponent<Image>();
        patologieText = uiCustomerText.GetComponent<Text>();
    }
    public string GetActualQuest()
    {
        return ActualQuest;
    }

    public void newCustomer()
    {
        if (actualCustomer == null)
        {


            actualCustomer = Instantiate(customerPrefab, paths[0].position,Quaternion.Euler(0,90,0));
            actualCustomer.name = "Customer";
            Sequence customerPath = DOTween.Sequence().SetId("path").OnComplete(() => { imagePatologie(); uiCustomerText.SetActive(true); });
            for (int i = 1; i < paths.Length; i++)
            {

                customerPath.Append(actualCustomer.transform.DOMove(new Vector3(paths[i].position.x, paths[0].position.y, paths[i].position.z), timePaths[i]));
            }
            DOTween.Play("path");
        }
        
    }
    private void imagePatologie()
    {
        int RandomNumber = Random.Range(0, Quests.Length);
        patologie.DOFade(0.8f, 0.5f).SetId("custText");
        DOTween.Play("custText");
        patologieText.text = Quests[RandomNumber];
        ActualQuest = patologieText.text;
    }
    public void QuestAchieved()
    {
        print("oui");
        Sequence customerPath = DOTween.Sequence().SetId("path2").OnComplete(()=> { Destroy(actualCustomer); });
        for (int i = paths.Length-1; i >=0; i--)
        {

            customerPath.Append(actualCustomer.transform.DOMove(new Vector3(paths[i].position.x, paths[0].position.y, paths[i].position.z), timePaths[i]));
        }
        DOTween.Play("path2");
        patologie.DOFade(0f, 0.5f).SetId("custText2");
        DOTween.Play("custText2");
        uiCustomerText.SetActive(false);
    }
}
