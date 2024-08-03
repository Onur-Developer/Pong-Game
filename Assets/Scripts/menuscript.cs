using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuscript : MonoBehaviour
{
    Animator panelaným,htpaným;
    float sayac;
    bool issayac;
    Slider loadingslider;

    private void Awake()
    {
        htpaným=GameObject.Find("howtoplaypanel").GetComponent<Animator>();
        loadingslider=GameObject.Find("Slider").GetComponent<Slider>();
        sayac = 0f;
        issayac = false;
        panelaným=GameObject.Find("loadingpanel").GetComponent<Animator>();
    }
    public void basla()
    {
        panelaným.SetBool("loadinganim", true);
        issayac=true;
    }
    public void howtoplay()
    {
        htpaným.SetBool("htp", true);
    }
    public void ok()
    {
        htpaným.SetBool("htp", false);
    }
    public void quýt()
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
