using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObjectDestructor: MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }

}
