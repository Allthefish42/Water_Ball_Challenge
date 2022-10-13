using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet_Default : MonoBehaviour
{

    private Rigidbody2D rb;
    public Collider2D coll;
    private Animator anim;
    public int bulletForce;
    private Vector3 shootDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // 为Rigidbody和Animator赋值
        rb.AddForce(new Vector2(shootDirection.x * bulletForce, shootDirection.y * bulletForce));
        Invoke("Time2Destory", 1f);
    }


    public void Setup(Vector3 shootDirection)
    {
        this.shootDirection = shootDirection;
    }

    void Update()
    {
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
        
    }

    private int num_Hit = 0;
    public int max_Hit;
    void Durability()
    {
        num_Hit += 1;
        if (num_Hit >= max_Hit)
        {
            anim.SetTrigger("isBallExplode");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Paper_Box")
        {
            Durability();
            collision.gameObject.GetComponent<Paper_Box>().HitCondition();
        }

       else if (collision.gameObject.tag == "Plastic_Box")
        {
            Durability();
            collision.gameObject.GetComponent<Plastic_Box>().HitCondition();
        }

       else if (collision.gameObject.tag == "Metal_Box")
        {
            Durability();
            collision.gameObject.GetComponent<Metal_Box>().HitCondition();
        }


    }

    public void DestoryBall()
    {
        Destroy(gameObject);
    }

    public void Time2Destory()
    {
        anim.SetTrigger("isBallExplode");
    }

}
