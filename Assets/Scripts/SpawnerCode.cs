using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCode : MonoBehaviour
{
    public GameObject top;
    public bool isclone;


    private void Update()
    {
        if (isclone)
        {
            clone();
        }
    }
    void clone()
    {
        Instantiate(top,this.gameObject.transform.position,Quaternion.identity);
        isclone = false;
    }
}
