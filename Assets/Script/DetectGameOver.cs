using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class DetectGameOver : MonoBehaviour
{
    [SerializeField] GameObject PlayerLastHP;
    [SerializeField] GameObject EnemyLastHP;
    [SerializeField] GameObject WinText;
    [SerializeField] GameObject LoseText;
    [SerializeField] GameObject RetryButton;
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject timetext;
    public void retryButtonOnClickListener()
    {
        PlayerLastHP.SetActive(true);
        EnemyLastHP.SetActive(true);
        Time.timeScale = 1;
        SceneManager.LoadScene("Demon Quest GamePlay");
    }
    // Update is called once per frame
    void Update()
    {   
        if(PlayerLastHP.activeSelf)
        {
            //continue           
        }
        else
        {
            timetext.SetActive(false);
            Panel.SetActive(true);
            Time.timeScale = 0;
            LoseText.SetActive(true);
            RetryButton.SetActive(true);
        }
        if(EnemyLastHP.activeSelf)
        {
            //continue           
        }
        else
        {
            timetext.SetActive(false);
            Panel.SetActive(true);
            Time.timeScale = 0;
            WinText.SetActive(true);
            RetryButton.SetActive(true);
        }
    }
}
