using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject button;
    private void Start()
    {
        button.transform.DOScale(1.1f, 0.5f).SetId("button").SetLoops(-1,LoopType.Yoyo);
        DOTween.Play("button");
    }
    public void LaunchGame()
    {
        SceneManager.LoadScene("Game");
    }
}
