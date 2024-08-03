using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameoverscript : MonoBehaviour
{
    public Text tx;
    Button yenýdenoynabutton, anamenubutton, cýkýsbutton;

    private void Awake()
    {
        yenýdenoynabutton=GameObject.Find("Bastanbasla").GetComponent<Button>();
        anamenubutton = GameObject.Find("AnaMenü").GetComponent<Button>();
        cýkýsbutton=GameObject.Find("Cýkýs").GetComponent<Button>();
        yenýdenoynabutton.onClick.AddListener(yenidenoyna);
        anamenubutton.onClick.AddListener(anamenu);
        cýkýsbutton.onClick.AddListener(cýkýs);
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
    void cýkýs()
    {
        Application.Quit();
    }

}
