using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class oyun : MonoBehaviour
{
    public AudioClip duduk;
    Button pausebuttonn, oyunadonn,bastanbaslabutton,anamenubutton,cıkısbutton;
    public GameObject d1, d2,auu,pausepanel;
    Animator anim,pauseanim;
    public Image growımage, ınvısıbleımage, stoneımagee;
    public RectTransform tsgrowımage;
    public Text player1text, player2text, matchtimetext;
    public int pscore1, pscore2 = 0;
    float matchtime;
    public SpriteRenderer splayer1, splayer2;
    public bool ismoving1, ismoving2;
    BoxCollider2D bd1, bd2;
    public AudioSource au;

    public GameObject player1, player2, groww, ınvısıbleob, cloneballımage, stoneımage, goaltext, goaltext2;
    public Rigidbody2D rgb1, rgb2;
    public float speed = 10f;

    private void Awake()
    {
        cıkısbutton=GameObject.Find("Cıkıs").GetComponent<Button>();
        anamenubutton=GameObject.Find("AnaMenü").GetComponent<Button>();
        bastanbaslabutton=GameObject.Find("Bastanbasla").GetComponent<Button>();
        pausebuttonn = GameObject.Find("PauseButton").GetComponent<Button>();
        oyunadonn = GameObject.Find("OyunaDevamButton").GetComponent<Button>();
        cıkısbutton.onClick.AddListener(cıkıs);
        anamenubutton.onClick.AddListener(anamenu);
        bastanbaslabutton.onClick.AddListener(bastanbasla);
        pausebuttonn.onClick.AddListener(pausebutton);
        oyunadonn.onClick.AddListener(oyunadon);
        pausepanel = GameObject.Find("PausePanel");
        pauseanim=pausepanel.GetComponent<Animator>();
        au = auu.GetComponent<AudioSource>();
        bd1=d1.GetComponent<BoxCollider2D>();
        bd2 = d2.GetComponent<BoxCollider2D>();
        anim =GameObject.Find("Matchisover").GetComponent<Animator>();
        matchtimetext = GameObject.Find("Matchtime").GetComponent<Text>();
        matchtime = 150;
        goaltext = GameObject.Find("GoalText");
        goaltext2 = GameObject.Find("GoalText2");
        goaltext.SetActive(false);
        goaltext2.SetActive(false);
        ismoving1 = true;
        ismoving2 = true;
        //cloneballımage = GameObject.Find("CBImage");
        stoneımage = GameObject.Find("StoneImage");
        stoneımagee = stoneımage.GetComponent<Image>();
        player1text = GameObject.Find("player1tx").GetComponent<Text>();
        player2text = GameObject.Find("player2tx").GetComponent<Text>();
        groww = GameObject.Find("GrowImage");
        ınvısıbleımage = GameObject.Find("InvısıbleImage").GetComponent<Image>();
        growımage = groww.GetComponent<Image>();
        ınvısıbleob = GameObject.Find("InvısıbleImage");
        tsgrowımage = GameObject.Find("GrowImage").GetComponent<RectTransform>();
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");
        splayer1 = player1.GetComponent<SpriteRenderer>();
        splayer2 = player2.GetComponent<SpriteRenderer>();
        rgb1 = player1.GetComponent<Rigidbody2D>();
        rgb2 = player2.GetComponent<Rigidbody2D>();
        pausepanel.transform.localScale = Vector2.zero;
    }
    void pausebutton()
    {
        pausebuttonn.interactable = false;
        pauseanim.SetBool("panelopen", true);
        Invoke("timestop", 0.5f);
    }
    void oyunadon()
    {
        pausebuttonn.interactable = true;
        pauseanim.SetBool("panelopen", false);
        Time.timeScale = 1f;
    }
    void bastanbasla()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Oyun");
    }
    void anamenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    void cıkıs()
    {
        Application.Quit();
    }
    void timestop()
    {
        Time.timeScale = 0f;
    }
    void Update()
    {
        if (ismoving1)
        {
            rgb1.velocity = Vector2.up * Input.GetAxisRaw("Vertical2") * speed;
        }
        if (ismoving2)
        {
            rgb2.velocity = Vector2.up * Input.GetAxisRaw("Vertical") * speed;
        }
        player1text.text = pscore1.ToString();
        player2text.text = pscore2.ToString();
        matchtimetext.text = "Maçın Bitmesine Kalan Süre: " + (int)matchtime+" Saniye";
        matchtime -= Time.deltaTime;
        if (matchtime <= 0)
        {
            GetComponent<AudioSource>().PlayOneShot(duduk);
            au.enabled = false;
            PlayerPrefs.SetInt("Player1", pscore1);
            PlayerPrefs.SetInt("Player2", pscore2);
            bd1.enabled = false;
            bd2.enabled = false;
            anim.SetTrigger("Tetikleme");
            matchtime = 0;
            Invoke("gameover", 5);
        }
    }
    void gameover()
    {
        SceneManager.LoadScene("GameOver");
    }
}
