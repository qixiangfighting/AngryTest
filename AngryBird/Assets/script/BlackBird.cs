using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : bird
{
   public List<pig> blocks = new List<pig>();


    // 进入触发区
    private void OnTriggerEnter2D(Collider2D collosion)
    {

        if (collosion.gameObject.tag == "Enemy")
        {
            blocks.Add(collosion.gameObject.GetComponent<pig>());
        }
    }

    private void OnTriggerExit2D(Collider2D collosion)
    {

        if (collosion.gameObject.tag == "Enemy")
        {
            blocks.Remove(collosion.gameObject.GetComponent<pig>());
        }
    }

    public override void showSkill()
    {
        base.showSkill();

        if (blocks.Count > 0 && blocks !=null)
        {

            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].Dead();
            }
        }

        onClear();
    }

    void onClear()
    {
        rg.velocity = Vector3.zero;
        Instantiate(boom, transform.position, Quaternion.identity);

        render.enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
    }


    protected override void Next()
    {
        GameManger._instance.birds.Remove(this);
        Destroy(gameObject);
        GameManger._instance.NextBird();
    }
}
