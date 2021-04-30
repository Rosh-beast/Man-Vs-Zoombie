using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetTimmer : MonoBehaviour
{
    public float Timer = 20;
     //private TextMesh timer;


      void Start()
    {
       // timer = GetComponent<TextMesh>();   
    }
    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;

        //timer.text = Timer.ToString("f2");

        if(Timer == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
