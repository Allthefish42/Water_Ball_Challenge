using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GunController : MonoBehaviour
{
    private Rigidbody2D rb; //前面加上[SerializeField]可在界面中显示，记得将刚体选项中contrants中z轴选上以避免螺旋升天
    private Animator anim;
    public Collider2D gunPoint;
    [SerializeField] private Transform pfBullet_Default;
    private int updateRate = 10;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // 为Rigidbody和Animator赋值
        Time.timeScale = 1f;
    }

    // FixedUpdate is called 50 times per second
    void FixedUpdate()
    {
        Aim();
        updateRate += 1;
        int fireRate = updateRate % 5;
        if (fireRate == 0)
        {
            updateRate = 0;
            AutoShoot();
        }
    }

    void AutoShoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        Shoot(aimDirection);

    }

    void Aim()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = 360 - Mathf.Atan2(aimDirection.x, aimDirection.y) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    void Shoot(Vector3 aimDirection)
    {
        Transform bulletTransform = Instantiate(pfBullet_Default, gunPoint.bounds.center, Quaternion.identity);
        Vector3 shootDirection = new Vector3 (aimDirection.x, aimDirection.y, 0).normalized;
        bulletTransform.GetComponent<Bullet_Default>().Setup(shootDirection);
    }





}

