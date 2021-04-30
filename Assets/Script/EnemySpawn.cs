using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public int Xpos;
    public int Zpos;
    public int enemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while(enemyCount < 5)
        {
            Xpos = Random.Range(-18 ,-21);
            Zpos = Random.Range(18,9);

            Instantiate(Enemy, new Vector3(Xpos ,-2, Zpos),Quaternion.identity);
            yield return new WaitForSeconds(1.0f);

        }
    }

   
}
