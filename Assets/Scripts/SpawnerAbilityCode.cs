using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAbilityCode : MonoBehaviour
{
   public float sayac;
    int randomsay�;
    public GameObject grow, �nv�s�ble, clone, stone;
    public bool isspawn;
    BoxCollider2D bx;
    private void Start()
    {
        sayac = 0;
        bx=GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (isspawn)
        {
            sayac+=Time.deltaTime;
            bx.enabled = false;
            if (sayac >= 7)
            {
                abilityclone();
            }
        }
    }

    void abilityclone()
    {
        randomsay� = Random.Range(1, 4);
        switch (randomsay�)
        {
            case 1:
                Instantiate(grow,this.gameObject.transform.position,Quaternion.identity);
                bx.enabled = true;
                isspawn = false;
                sayac = 0;
                break;
            case 2:
                Instantiate(�nv�s�ble, this.gameObject.transform.position, Quaternion.identity);
                bx.enabled = true;
                isspawn = false;
                sayac = 0;
                break;
            case 3:
                Instantiate(stone, this.gameObject.transform.position, Quaternion.identity);
                bx.enabled = true;
                isspawn = false;
                sayac = 0;
                break;
        }
    }
}
