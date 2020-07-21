using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMyTrial : MonoBehaviour
{
    public WeaponTrail myTrail;
    public TrailRenderer render;

    private float t = 0.033f;
    private float tempT = 0;
    private float animationIncrement = 0.003f;



    void Start()
    {
        // 默认没有拖尾效果
        // myTrail.SetTime(0.0f, 0.0f, 1.0f);
        render.enabled = false;
    }

    /// <summary>
    /// //开始进行拖尾
    /// </summary>
    public void StartTrails()
    {
        //设置拖尾时长
        // myTrail.SetTime(2.0f, 0.0f, 1.0f);
        
        // myTrail.StartTrail(0.5f, 0.4f);
        render.enabled = true;
    }
    /// <summary>
    /// //清除拖尾
    /// </summary>
    public void ClearTrails()
    {
        
        // myTrail.ClearTrail();
        render.enabled = false;
    }
}
