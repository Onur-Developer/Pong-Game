using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameoverscript : MonoBehaviour
{
    public Text tx;
    Button yenıdenoynabutton, anamenubutton, cıkısbutton;

    private void Awake()
    {
        yenıdenoynabutton=GameObject.Find("Bastanbasla").GetComponent<Button>();
        anamenubutton = GameObject.Find("AnaMenü").GetComponent<Button>();
        cıkısbutton=GameObject.Find("Cıkıs").GetComponent<Button>();
        yenıdenoynabutton.onClick.AddListener(yenidenoyna);
        anamenubutton.onClick.AddListener(anamenu);
        cıkısbutton.onClick.AddListener(cıkıs);
    }
    void Start()
    {
        tx.text = "        " + PlayerPrefs.GetInt("Player1") + "     " + "-" + "     " + PlayerPrefs.GetInt("Player2");
    }
    void yenidenoyna()
    {
        SceneManager.LoadScene("Oyun");
    }
    void anamenu()
    {
        SceneManager.LoadScene("Menu");
    }
    void cıkıs()
    {
        Application.Quit();
    }

}
