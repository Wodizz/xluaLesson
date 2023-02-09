using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Lua没有办法直接访问C# 先从C#调用lua之后 再由lua编写
/// </summary>
public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.Instance.Init();
        LuaManager.Instance.DoLuaFile("Main");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
