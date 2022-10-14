using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Open_Scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        loadLevel1();
    }

    // Update is called once per frame
    void Update()
    {
        loadLevel1();
    }

    private void loadLevel1 ()    
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Level01");
        }

    }
}
