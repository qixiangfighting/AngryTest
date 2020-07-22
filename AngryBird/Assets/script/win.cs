using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour
{

    // 动画播放完毕 展示星星
    public void show()
    {
        GameManger._instance.showStarter();
    }
}
