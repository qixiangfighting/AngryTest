using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
   public void destory()
   {
      Debug.Log("----call destory----");
      Destroy(gameObject);
   }

}
