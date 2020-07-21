using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public List<bird> birds;
    public List<pig> pig;

    public static GameManger _instance;
    private Vector3 orignalPos;
    private void Awake()
    {
        _instance = this;
        if (birds.Count>0)
        {
            orignalPos = birds[0].transform.position;  
        }

       
    }

    private void Start()
    {
        Initialized();
    }

    private void Initialized()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if (i == 0)
            {
                birds[0].transform.position = orignalPos;
                birds[i].enabled = true;
                birds[i].sp.enabled = true;
            }
            else
            {
                birds[i].enabled = false;
                birds[i].sp.enabled = false;  
            }
        }
    }

   public void NextBird()
    {
        if (pig.Count > 0 )
        {
            if (birds.Count>0)
            {
                // 下一只小鸟飞
                Initialized();
            }
            else
            {
                //fail
            }
            

        }
        else
        {
            // win
        }
    }
}
