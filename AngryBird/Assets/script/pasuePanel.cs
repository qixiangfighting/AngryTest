using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pasuePanel : MonoBehaviour
{
    private Animator anim;

    public GameObject button;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    /**
     * 1. 先播放动画
     * 2. 再暂停
     *
     */
    public void Pause()
    {
        Debug.Log("------call Pause-----------");
        anim.SetBool("isPause", true);
        button.SetActive(false);
    }

    public void Pause2()
    {
        Debug.Log("------call Pause-----------");
        anim.SetBool("isPause", true);
        button.SetActive(false);
    }

    public void Home()
    {
        Time.timeScale = 1;
        Debug.Log("------call Home-----------");
        SceneManager.LoadScene(1);
    }


    public void Retry()
    {
        Time.timeScale = 1;
        Debug.Log("------call Retry-----------");
        SceneManager.LoadScene(2);
    }

    // 点击了继续按钮
    public void Resume()
    {
        Debug.Log("------call Resume-----------");
        Time.timeScale = 1;
        anim.SetBool("isPause", false);
    }

    /**
     *  pasue动画播放完调用
     *
     */
    public void PauseAnimEnd()
    {
        Time.timeScale = 0;
    }

    /**
     *  resuem动画播放完调用
     *
     */
    public void ResumeAnimEnd()
    {
        button.SetActive(true);
    }
}