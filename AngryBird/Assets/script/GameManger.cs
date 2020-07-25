using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManger : MonoBehaviour
{
    public List<bird> birds;
    public List<pig> pig;

    public static GameManger _instance;

    public GameObject win;
    public GameObject lose;
    private Vector3 orignalPos;
    public GameObject[] starts;

    private int startNum = 0;

    private int totalNum = 10;
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
                lose.SetActive(true);
            }
            

        }
        else
        {
            // win
            win.SetActive(true);
        }
    }

   public void showStarter()
   {
       StartCoroutine("show");
   }

   IEnumerator show()
   {
       for (; startNum < birds.Count+1; startNum++)
       {
           if (startNum>=starts.Length)
           {

               break;
           }

           yield return new WaitForSeconds(0.2f);
           starts[startNum].SetActive(true);
       }
       print("--startNum--:"+startNum);
   }



   public void Replay()
   {
       SaveData();
       SceneManager.LoadScene(2);

   }
   public void Home()
   {
       SaveData();
       SceneManager.LoadScene(1);
   }

   public void SaveData()
   {

       if (startNum > PlayerPrefs.GetInt(PlayerPrefs.GetString("nowLevel")))
       {
           PlayerPrefs.SetInt(PlayerPrefs.GetString("nowLevel"),startNum);
       }

       // 存储所有星星个数
       int sum = 0;

       for (int i = 1; i < totalNum; i++)
       {
           //
           sum += PlayerPrefs.GetInt("level"+i.ToString());
       }

       PlayerPrefs.SetInt("totalNum", sum);
   }
}
