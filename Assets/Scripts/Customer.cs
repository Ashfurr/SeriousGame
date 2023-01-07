using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    [SerializeField] GameObject customerPrefab;
    [SerializeField] GameObject mortar;
    [SerializeField] Transform[] paths;
    [SerializeField] float[] timePaths;

    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject uiCustomerImage;
    [SerializeField] GameObject uiCustomerText;
    [SerializeField] GameObject NextQuest;

    [SerializeField] string[] Quests;

    Image patologie;
    Text patologieText;
    string ActualQuest;
    GameObject actualCustomer = null;
    //tuto
    [SerializeField] GameObject tutoArrow;
    [SerializeField] GameObject tutoButtonGarden;
    [SerializeField] GameObject tutoButtonBook;
    [SerializeField] GameObject tutoFinger;
    [SerializeField] GameObject tutoBook;
    [SerializeField] GameObject tutoButtonInventory;
    bool tuto = false;
    bool buttonlock = false;
    bool buttonlock1 = false;
    bool buttonlock2 = false;
    bool buttonlock3 = false;
    private void Awake()
    {
        patologie = uiCustomerImage.GetComponent<Image>();
        patologieText = uiCustomerText.GetComponent<Text>();
    }
    private void Start()
    {
        newCustomer();
        StartCoroutine(Tuto1(2));
    }
    public void ButtonTuto()
    {
        if (buttonlock == false)
        {
            buttonlock = true;
            StartCoroutine(Tuto2(0.2f));
        }

    }
    public void ButtonTutoGarden()
    {
        if (buttonlock1 == false)
        {
            buttonlock1 = true;
            StartCoroutine(Tuto3Garden());
        }
    }
    public void Tuto4Garden()
    {
        if (buttonlock2 == false)
        {
            buttonlock2 = true;
            StartCoroutine(Tuto4Gardendelay());
        }    
       

    }
    public void tuto5Arrow()
    {
        if (buttonlock3 == false)
        {
            buttonlock3 = true;
            tutoArrow.SetActive(true);
            tutoFinger.SetActive(false);
        }
    }
    public void tuto6()
    {
        if (tuto == true)
        {
            StartCoroutine(tuto6Delay());
        }
    }
    public string GetActualQuest()
    {
        return ActualQuest;
    }

    public void newCustomer()
    {
        if (actualCustomer == null)
        {


            actualCustomer = Instantiate(customerPrefab, paths[0].position, Quaternion.Euler(0, 90, 0));
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
        patologieText.text = Quests[0];
        ActualQuest = patologieText.text;
    }
    public void QuestAchieved()
    {
        tutoFinger.SetActive(false);
        NextQuest.SetActive(true);
        print("oui");
        Sequence customerPath = DOTween.Sequence().SetId("path2").OnComplete(() => { Destroy(actualCustomer); });
        for (int i = paths.Length - 1; i >= 0; i--)
        {

            customerPath.Append(actualCustomer.transform.DOMove(new Vector3(paths[i].position.x, paths[0].position.y, paths[i].position.z), timePaths[i]));
        }
        DOTween.Play("path2");
        patologie.DOFade(0f, 0.5f).SetId("custText2");
        DOTween.Play("custText2");
        uiCustomerText.SetActive(false);
        Quests[0] = "AgastacheSmash";
        mortar.SetActive(true);
        tutoButtonGarden.SetActive(true);
        newCustomer();

    }
    IEnumerator Tuto1(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        tutoArrow.SetActive(true);
        tutoArrow.transform.DOScale(1.5f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetId("tuto1");
        DOTween.Play("tuto1");
        yield return new WaitForSeconds(0.5f);


        //Time.timeScale = 0;
        tutoArrow.SetActive(true);

        tutoArrow.transform.DOLocalMove(new Vector3(-3.000021f, -665.0001f, 0f), 1).SetId("tuto");
        tutoArrow.transform.DORotate(new Vector3(0, 0, -270), 1f).SetId("tuto");
        DOTween.Play("tuto");
        yield return new WaitForSeconds(1);
        tutoButtonBook.SetActive(true);
    }
    IEnumerator Tuto2(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        tutoArrow.transform.DOLocalMove(new Vector3(-60, -277, 0f), 0.5f).SetId("tuto1");
        tutoArrow.transform.DORotate(new Vector3(0, 0, -180), 0.5f).SetId("tuto");
        DOTween.Play("tuto1");
        yield return new WaitForSeconds(0.8f);
        tutoArrow.transform.DOLocalMove(new Vector3(-60, -505, 0f), 0.5f).SetId("tuto1.5");
        DOTween.Play("tuto1.5");
        yield return new WaitForSeconds(0.8f);
        tutoButtonGarden.SetActive(true);
        tutoArrow.transform.DOLocalMove(new Vector3(275, -665.0001f, 0f), 0.5f).SetId("tuto");
        tutoArrow.transform.DORotate(new Vector3(0, 0, -270), 0.5f).SetId("tuto");
    }
    IEnumerator Tuto3Garden()
    {
        yield return new WaitForSeconds(1.5f);
        tutoBook.SetActive(false);
        tutoButtonGarden.SetActive(false);
        tutoArrow.SetActive(false);
        tutoFinger.SetActive(true);
        tutoFinger.transform.DOScale(1.1f, 0.2f).SetLoops(2, LoopType.Yoyo).SetId("tuto3");
        tutoFinger.transform.DOLocalMove(new Vector3(53, 163, 0f), 1).SetLoops(-1, LoopType.Restart).SetId("tuto3");
        DOTween.Play("tuto3");
    }
    IEnumerator Tuto4Gardendelay()
    {
        DOTween.Kill("tuto3");
        tutoFinger.SetActive(true);
        tutoButtonInventory.SetActive(true);
        tutoFinger.transform.DOLocalMove(new Vector3(-238, -828, 0f), 1f).SetId("tutoG");

        DOTween.Play("tutoG");
        yield return new WaitForSeconds(1.2f);

        tutoFinger.transform.DOLocalMove(new Vector3(-238, -471, 0f), 0.5f).SetLoops(-1, LoopType.Restart).SetId("tutoG2");
        DOTween.Play("tutoG2");
        tutoButtonGarden.SetActive(true);
        tuto = true;
    }
    IEnumerator tuto6Delay()
    {
        DOTween.Kill("tutoG");
        DOTween.Kill("tutoG2");
        tutoButtonGarden.SetActive(false);
        yield return new WaitForSeconds(1);
        tutoFinger.SetActive(true);
        tutoFinger.transform.localPosition = new Vector3(-238, 36, 0);
        tutoFinger.transform.DOScale(1.1f, 0.2f).SetLoops(-1, LoopType.Yoyo).SetId("tuto6");
        DOTween.Play("tuto6");

    }
}
