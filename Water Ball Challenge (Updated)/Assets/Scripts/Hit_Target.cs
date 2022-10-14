using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hit_Target : MonoBehaviour
{
    public GameObject Clear_Window;
   private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Bullet") {
            Time.timeScale = 0f;
            Clear_Window.SetActive(true);
            }
        }

}
