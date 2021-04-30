using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region singleton

    public static PlayerManager instance;

    private void awake()
    {
        instance = this;
    }

    #endregion   

    public GameObject Player;
    
    
  

}
