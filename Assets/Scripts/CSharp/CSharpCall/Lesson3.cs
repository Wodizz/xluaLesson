using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3_CallLua : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.Instance.Init();
        LuaManager.Instance.DoString("require('Main')");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
