using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager
{
    static GunManager _instance;

    static public GunManager Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = new GunManager();

            }
            return _instance;
        }
    }

  

    


}


