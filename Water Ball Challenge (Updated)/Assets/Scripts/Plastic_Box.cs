using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plastic_Box : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    public int boxHP;
    private int boxFullHP;
    private int boxHalfHP;


    void Start()
    {
        boxFullHP = boxHP;
        boxHalfHP = boxFullHP / 2;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {

    }
    public void HitCondition()
    {
        boxHP -= 1;
        if (boxHP < (boxFullHP - 2) && boxHP > boxHalfHP)
        {
            anim.SetTrigger("isDamage");
        }
        else if (boxHP <= boxHalfHP && boxHP > 0)
        {
            anim.SetTrigger("isHeavyDamage");
        }
        if (boxHP <= 0)
        {
            anim.SetTrigger("isExplode");
        }
    }
    public void Destorybox()
    {
        Destroy(gameObject);
    }


}

