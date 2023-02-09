using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4_CallVariable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.Instance.Init();
        LuaManager.Instance.DoLuaFile("Main"); 

        // 使用Lua解析器的Global 去获取全局变量
        int testNumber = LuaManager.Instance.Global.Get<int>("testNumber");
        Debug.Log("testNumber:" + testNumber);

        // 改变lua中的值
        LuaManager.Instance.Global.Set("testNumber", 55);
        int testNumber2 = LuaManager.Instance.Global.Get<int>("testNumber");
        Debug.Log("testNumber:" + testNumber2);

        bool testBool = LuaManager.Instance.Global.Get<bool>("testBool");
        Debug.Log("testBool:" + testBool);

        float testFloat = LuaManager.Instance.Global.Get<float>("testFloat");
        Debug.Log("testFloat:" + testFloat);

        string testString = LuaManager.Instance.Global.Get<string>("testString");
        Debug.Log("testString:" + testString);

        // 无法直接获取本地局部变量
        int testLocalNumber = LuaManager.Instance.Global.Get<int>("testLocalNumber");
        Debug.Log("testLocalNumber:" + testLocalNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
