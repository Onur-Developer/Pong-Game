using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameoverscript : MonoBehaviour
{
    public Text tx;
    Button yen�denoynabutton, anamenubutton, c�k�sbutton;

    private void Awake()
    {
        yen�denoynabutton=GameObject.Find("Bastanbasla").GetComponent<Button>();
        anamenubutton = GameObject.Find("AnaMen�").GetComponent<Button>();
        c�k�sbutton=GameObject.Find("C�k�s").GetComponent<Button>();
        yen�denoynabutton.onClick.AddListener(yenidenoyna);
        anamenubutton.onClick.AddListener(anamenu);
        c�k�sbutton.onClick.AddListener(c�k�s);
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
    void c�k�s()
    {
        Application.Quit();
    }

}
