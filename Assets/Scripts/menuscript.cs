using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuscript : MonoBehaviour
{
    Animator panelan�m,htpan�m;
    float sayac;
    bool issayac;
    Slider loadingslider;

    private void Awake()
    {
        htpan�m=GameObject.Find("howtoplaypanel").GetComponent<Animator>();
        loadingslider=GameObject.Find("Slider").GetComponent<Slider>();
        sayac = 0f;
        issayac = false;
        panelan�m=GameObject.Find("loadingpanel").GetComponent<Animator>();
    }
    public void basla()
    {
        panelan�m.SetBool("loadinganim", true);
        issayac=true;
    }
    public void howtoplay()
    {
        htpan�m.SetBool("htp", true);
    }
    public void ok()
    {
        htpan�m.SetBool("htp", false);
    }
    public void qu�t()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (issayac)
        {
            loadingslider.value = sayac;
            sayac +=Time.deltaTime;
            if (sayac > 15)
            {
                SceneManager.LoadScene("Oyun");
            }
        }
    }
}
