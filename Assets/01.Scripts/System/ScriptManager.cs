using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager
{
    private static ScriptManager _instance;

    public static ScriptManager Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = new ScriptManager();
            }
            return _instance;
        }
    }
}


