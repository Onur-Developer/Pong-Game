using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class top : MonoBehaviour
{
    public AudioClip sekme,powerup,growsound,freeze,ınvsound,canon,goalsound;
    ParticleSystem pgreen;
    ParticleSystem.MainModule md;
    Animator goalanimator, g2, g3, g4, g5, g6, g7;
    SpawnerAbilityCode sac;
    SpawnerAbilityCode2 sac2;
    SpawnerAbilityCode3 sac3;
    SpawnerAbilityCode4 sac4;
    SpawnerCode spawner;
    oyun oy;
    SpriteRenderer spritetop;
    Image growımage, ınvısıbleımage;
    GameObject player1, player2, groww, ınvısıbleob;
    public GameObject spawnerability, spawnerability2, spawnerability3, spawnerability4;
    Transform tsplayer1, tsplayer2;
    RectTransform tsgrowımage;
    public Rigidbody2D rbtop, rbplayer1, rbplayer2;
    public float speed = 5f;
    public Text player1text, player2text;
    public int pscore1, pscore2 = 0, growingint, ınvısıbleint, stoneint;
    float x, y;
    bool isplayer1, growing, ınvısıble, stone;
    BoxCollider2D bxplayer1, bxplayer2;

    private void Awake()
    {
        pgreen = gameObject.GetComponentInChildren<ParticleSystem>();
        md = pgreen.main;
        goalanimator = GameObject.Find("solduvar").GetComponent<Animator>();
        g2 = GameObject.Find("sagduvar").GetComponent<Animator>();
        g3 = GameObject.Find("üstduvar").GetComponent<Animator>();
        g4 = GameObject.Find("altduvar").GetComponent<Animator>();
        g5 = GameObject.Find("ortanokta").GetComponent<Animator>();
        spawnerability = GameObject.Find("SpawnerAbility");
        spawnerability2 = GameObject.Find("SpawnerAbility (1)");
        spawnerability3 = GameObject.Find("SpawnerAbility (2)");
        spawnerability4 = GameObject.Find("SpawnerAbility (3)");
        sac = spawnerability.GetComponent<SpawnerAbilityCode>();
        sac2 = spawnerability2.GetComponent<SpawnerAbilityCode2>();
        sac3 = spawnerability3.GetComponent<SpawnerAbilityCode3>();
        sac4 = spawnerability4.GetComponent<SpawnerAbilityCode4>();
        spawner = GameObject.Find("Spawner").GetComponent<SpawnerCode>();
        oy = GameObject.Find("player1").GetComponent<oyun>();
        spritetop = GetComponent<SpriteRenderer>();
        //  groww = GameObject.Find("GrowImage");
        // growımage = groww.GetComponent<Image>();
        //  ınvısıbleob = GameObject.Find("InvısıbleImage");
        //  ınvısıbleımage = GameObject.Find("InvısıbleImage").GetComponent<Image>();
        //  tsgrowımage = GameObject.Find("GrowImage").GetComponent<RectTransform>();
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");
        tsplayer1 = player1.GetComponent<Transform>();
        tsplayer2 = player2.GetComponent<Transform>();
        rbtop = GetComponent<Rigidbody2D>();
        //  player1text = GameObject.Find("player1tx").GetComponent<Text>();
        // player2text = GameObject.Find("player2tx").GetComponent<Text>();
        bxplayer1 = player1.GetComponent<BoxCollider2D>();
        bxplayer2 = player2.GetComponent<BoxCollider2D>();
        rbplayer1 = player1.GetComponent<Rigidbody2D>();
        rbplayer2 = player2.GetComponent<Rigidbody2D>();
        Invoke("TopKontrol", 4);
    }
    void Start()
    {
        g6 = oy.goaltext.GetComponent<Animator>();
        g7 = oy.goaltext2.GetComponent<Animator>();
        oy.stoneımage.SetActive(false);
        oy.cloneballımage.SetActive(false);
        oy.groww.SetActive(false);
        // groww.SetActive(false);
        oy.ınvısıbleob.SetActive(false);
        // ınvısıbleob.SetActive(false);
        growing = false;
        ınvısıble = false;
    }

    public void TopKontrol()
    {
        if (!ınvısıble)
        {
            rbplayer1.position = new Vector2(-6.84f, 0);
            rbplayer2.position = new Vector2(7.1f, 0);
            bxplayer1.isTrigger = false;
            bxplayer2.isTrigger = false;
            spritetop.color = Color.white;
        }
        if (!growing)
        {
            tsplayer1.localScale = new Vector3(1f, 1f, 1f);
            tsplayer2.localScale = new Vector3(1f, 1f, 1f);
        }
        if (!stone)
        {
            oy.ismoving1 = true;
            oy.ismoving2 = true;
            oy.splayer1.color = Color.green;
            oy.splayer2.color = Color.red;
        }
        goalanimator.SetBool("Player1goal", false);
        goalanimator.SetBool("Player2goal", false);
        g2.SetBool("Player1goal", false);
        g2.SetBool("Player2goal", false);
        g3.SetBool("Player1goal", false);
        g3.SetBool("Player2goal", false);
        g4.SetBool("Player1goal", false);
        g4.SetBool("Player2goal", false);
        g5.SetBool("Player1goal", false);
        g5.SetBool("Player2goal", false);
        oy.goaltext.SetActive(false);
        oy.goaltext2.SetActive(false);
        speed = 5f;
        x = Random.Range(0, 2) == 0 ? -1 : 1;
        y = Random.Range(0, 2) == 0 ? -1 : 1;
        rbtop.velocity = new Vector2(x * speed, y * speed);
    }
   void dds()
    {
        Destroy(this.gameObject);
    }
    void Update()
    {
        // player1text.text = pscore1.ToString();
        // player2text.text = pscore2.ToString();

        if (growing)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                switch (growingint)
                {
                    case 1:
                        GetComponent<AudioSource>().PlayOneShot(growsound);
                        tsplayer1.localScale = new Vector3(1f, 2.5f, 1f);
                        oy.groww.SetActive(false);
                        // groww.SetActive(false);
                        growing = false;
                        break;
                    case 2:
                        GetComponent<AudioSource>().PlayOneShot(growsound);
                        tsplayer2.localScale = new Vector3(1f, 2.5f, 1f);
                        oy.groww.SetActive(false);
                        //  groww.SetActive(false);
                        growing = false;
                        break;
                }
            }
        }
        if (ınvısıble)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                switch (ınvısıbleint)
                {
                    case 1:
                        GetComponent<AudioSource>().PlayOneShot(ınvsound);
                        oy.ınvısıbleob.SetActive(false);
                        // ınvısıbleob.SetActive(false);
                        ınvısıble = false;
                        bxplayer2.isTrigger = true;
                        spritetop.color = Color.green;
                        break;
                    case 2:
                        GetComponent<AudioSource>().PlayOneShot(ınvsound);
                        oy.ınvısıbleob.SetActive(false);
                        // ınvısıbleob.SetActive(false);
                        ınvısıble = false;
                        bxplayer1.isTrigger = true;
                        spritetop.color = Color.red;
                        break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            spawner.isclone = true;
        }
        if (stone)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                switch (stoneint)
                {
                    case 1:
                        GetComponent<AudioSource>().PlayOneShot(freeze);
                        oy.stoneımage.SetActive(false);
                        oy.ismoving2 = false;
                        oy.splayer2.color = Color.yellow;
                        stone = false;
                        break;
                    case 2:
                        GetComponent<AudioSource>().PlayOneShot(freeze);
                        oy.stoneımage.SetActive(false);
                        oy.ismoving1 = false;
                        oy.splayer1.color = Color.yellow;
                        stone = false;
                        break;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sol"))
        {
            GetComponent<AudioSource>().PlayOneShot(canon);
            GetComponent<AudioSource>().PlayOneShot(goalsound);
            oy.goaltext.SetActive(true);
            oy.goaltext2.SetActive(true);
            goalanimator.SetBool("Player2goal", true);
            g2.SetBool("Player2goal", true);
            g3.SetBool("Player2goal", true);
            g4.SetBool("Player2goal", true);
            g5.SetBool("Player2goal", true);
            g6.SetBool("Player2goal", true);
            g7.SetBool("Player2goal", true);
            oy.pscore2++;
            rbtop.simulated = false;
            spritetop.enabled = false;
           /* rbtop.velocity = new Vector2(0, 0);
            rbtop.position = new Vector2(0, 0); */
            spawner.isclone = true;
            md.startColor = Color.red;
            md.startSpeed = 100;
            pgreen.Play();
            Invoke("dds", 5);
           // Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Sag"))
        {
            GetComponent<AudioSource>().PlayOneShot(canon);
            GetComponent<AudioSource>().PlayOneShot(goalsound);
            oy.goaltext.SetActive(true);
            oy.goaltext2.SetActive(true);
            goalanimator.SetBool("Player1goal", true);
            g2.SetBool("Player1goal", true);
            g3.SetBool("Player1goal", true);
            g4.SetBool("Player1goal", true);
            g5.SetBool("Player1goal", true);
            g6.SetBool("Player1goal", true);
            g7.SetBool("Player1goal", true);
            oy.pscore1++;
            rbtop.simulated = false;
            spritetop.enabled = false;
            /* rbtop.velocity = new Vector2(0, 0);
             rbtop.position = new Vector2(0, 0); */
            spawner.isclone = true;
            md.startSpeed = 100;
            pgreen.Play();
            Invoke("dds", 5);
            //  Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Player1"))
        {
            isplayer1 = true;
            GetComponent<AudioSource>().PlayOneShot(sekme);
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            isplayer1 = false;
            GetComponent<AudioSource>().PlayOneShot(sekme);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grow"))
        {
            GetComponent<AudioSource>().PlayOneShot(powerup);
            Destroy(collision.gameObject);
            growing = true;
            if (isplayer1)
            {
                growingint = 1;
                oy.groww.SetActive(true);
                // groww.SetActive(true);
                oy.growımage.color = Color.green;
                // growımage.color = Color.green;
                oy.tsgrowımage.transform.position = new Vector2(68.6f, 1000);
                // tsgrowımage.transform.position = new Vector2(68.6f, 1000);
            }
            else
            {
                growingint = 2;
                oy.groww.SetActive(true);
                // groww.SetActive(true);
                oy.growımage.color = Color.red;
                // growımage.color = Color.red;
                oy.tsgrowımage.transform.position = new Vector2(1850, 1000);
                // tsgrowımage.transform.position = new Vector2(1850, 1000);
            }
        }
        else if (collision.gameObject.CompareTag("Invısıble"))
        {
            GetComponent<AudioSource>().PlayOneShot(powerup);
            Destroy(collision.gameObject);
            ınvısıble = true;
            if (isplayer1)
            {
                ınvısıbleint = 1;
                oy.ınvısıbleob.SetActive(true);
                // ınvısıbleob.SetActive(true);
                oy.ınvısıbleımage.color = Color.green;
                // ınvısıbleımage.color = Color.green;
                oy.ınvısıbleob.transform.position = new Vector2(150f, 1000);
                // ınvısıbleob.transform.position = new Vector2(150f, 1000);
            }
            else
            {
                ınvısıbleint = 2;
                oy.ınvısıbleob.SetActive(true);
                // ınvısıbleob.SetActive(true);
                oy.ınvısıbleımage.color = Color.red;
                // ınvısıbleımage.color = Color.red;
                oy.ınvısıbleob.transform.position = new Vector2(1770, 1000);
                // ınvısıbleob.transform.position = new Vector2(1770, 1000);
            }
        }
        else if (collision.gameObject.CompareTag("Cloneball"))
        {
            GetComponent<AudioSource>().PlayOneShot(powerup);
            Destroy(collision.gameObject);
            oy.cloneballımage.SetActive(true);
            oy.cloneballımage.transform.position = new Vector2(1000, 1000);
        }
        else if (collision.gameObject.CompareTag("Stone"))
        {
            GetComponent<AudioSource>().PlayOneShot(powerup);
            Destroy(collision.gameObject);
            stone = true;
            if (isplayer1)
            {
                stoneint = 1;
                oy.stoneımage.SetActive(true);
                oy.stoneımagee.color = Color.green;
                oy.stoneımage.transform.position = new Vector2(250, 1000);
            }
            else
            {
                stoneint = 2;
                oy.stoneımage.SetActive(true);
                oy.stoneımagee.color = Color.red;
                oy.stoneımage.transform.position = new Vector2(1700, 1000);
            }
        }
        if (collision.gameObject.CompareTag("spawnerr"))
        {
            sac.isspawn = true;
        }
        else if (collision.gameObject.CompareTag("spawnerr2"))
        {
            sac2.isspawn = true;
        }
        else if (collision.gameObject.CompareTag("spawnerr3"))
        {
            sac3.isspawn = true;
        }
        else if (collision.gameObject.CompareTag("spawnerr4"))
        {
            sac4.isspawn = true;
        }
    }
}
