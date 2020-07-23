using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    private bool isClick = false;
    public float maxDis = 1.5f;
    public float smooth = 3f;

    [HideInInspector]
    public SpringJoint2D sp;
    protected Rigidbody2D rg;

    public LineRenderer right;
    public Transform rightPos;
    public LineRenderer left;
    public Transform leftPos;

    public GameObject boom;
    private TestMyTrial myTrial;

    private bool canMove = true;


    public AudioClip select;
    public AudioClip fly;

    private bool isFly = false;

    public Sprite hurt;
    private SpriteRenderer render;
    private void Awake()
    {

         sp = GetComponent<SpringJoint2D>();
         rg = GetComponent<Rigidbody2D>();
         myTrial = GetComponent<TestMyTrial>();
         render = GetComponent<SpriteRenderer>();
    }
    // 鼠标按下
    private void OnMouseDown()
    {
        if (canMove)
        {
            AudioPlay(@select);
            isClick = true;
            rg.isKinematic = true;
        }
    }
    // 鼠标抬起
    private void OnMouseUp()
    {
        if (canMove)
        {
            isClick = false;
            rg.isKinematic = false;

            StartCoroutine(Fly());
            //Invoke("Fly2", 0.1f);

            //禁用划线
            left.enabled = false;
            right.enabled = false;

            canMove = false;
        }
    }

    private void Update()
    {

        if (isClick) {
            Debug.Log("-----isClick------");
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position -= new Vector3(0,0, Camera.main.transform.position.z);

            // 位置限定
            if (Vector3.Distance(transform.position, rightPos.position)>maxDis) {
                // 单位化向量
                Vector3 pos = (transform.position - rightPos.position).normalized;
                pos *= maxDis;
                transform.position = pos + rightPos.position;
            }

            line();
        }

        //相机跟随
        float posX = transform.position.x;
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position,
            new Vector3(Mathf.Clamp(posX,0,15),Camera.main.transform.position.y, Camera.main.transform.position.z),
            smooth * Time.deltaTime
        );



        if (isFly)
        {
            if (Input.GetMouseButtonDown(0))
            {
                showSkill();
            }

        }
    }


    void line()
    {

        left.enabled = true;
        right.enabled = true;

        
        right.SetPosition(0,rightPos.position);
        right.SetPosition(1, transform.position);

        left.SetPosition(0, leftPos.position);
        left.SetPosition(1, transform.position);
    }



   IEnumerator  Fly()
   {
        isFly = true;
        AudioPlay(fly);
        yield return new WaitForSeconds(0.1f);
        myTrial.StartTrails();

        sp.enabled = false;
        
        yield return  new WaitForSeconds(5f);
        Next();
        
        yield return null;
    }

    void  Fly2()
    {
        sp.enabled = false;
    }


    // 下一只小鸟飞出
    void Next()
    {
        GameManger._instance.birds.Remove(this);
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        
        GameManger._instance.NextBird();
    }



    public void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }



    private void OnCollisionEnter2D(Collision2D other)
    {

        isFly = false;
        myTrial.ClearTrails();
        Hurt();
    }

    public virtual void showSkill()
    {
        isFly = false;
    }

    public void Hurt()
    {
        render.sprite = hurt;
    }

}

