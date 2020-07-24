using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pig : MonoBehaviour
{
    public float maxSpeed = 10;
    public float minSpeed = 4;
    private SpriteRenderer render;
    public Sprite hurt;

    public GameObject boom;
    public GameObject score;

    public bool isPig = false;

    public AudioClip hurtClip;
    public AudioClip dead;
    public AudioClip birdCollision;

    private void Awake()
    {

        render = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioPlay(birdCollision);
            // collision.transform.GetComponent<bird>().Hurt();
        }

        if (collision.relativeVelocity.magnitude > maxSpeed)
        {
            Dead();
        }
        else if (collision.relativeVelocity.magnitude > minSpeed && collision.relativeVelocity.magnitude < maxSpeed)
        {
            render.sprite = hurt;
            AudioPlay(hurtClip);
        }
        else {

        }
    }

   public void Dead()
    {
        if (isPig)
        {
            GameManger._instance.pig.Remove(this);
        }

        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);

        GameObject go = Instantiate(score, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        Destroy(go, 1.5f);

        AudioPlay(dead);
    }

    /**
     * 1. 给物体加上AudioSource 组件和直接 AudioSource 静态方法使用播放的区别
     *
     */
    public void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
