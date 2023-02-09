using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallLuaClass
{
    // 变量名字必须与lua一样
    public int testInt;
    public float testFloat;
    public bool testBool;
    // 函数用对应委托装
    public System.Action testFunc;
    public string testString;
    // 这个变量名也要一样
    public CallLuaInnerClass testInnerClass;


    public void Test()
    {

    }
}

public class CallLuaInnerClass
{
    public int testInnerInt;
}

public class Lesson7_CallClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.Instance.Init();
        LuaManager.Instance.DoLuaFile("Main");

        CallLuaClass obj = LuaManager.Instance.Global.Get<CallLuaClass>("testClass");
        Debug.Log(obj.testString);
        obj.testFunc();

        // 测试内部类
        Debug.Log(obj.testInnerClass.testInnerInt);

        // 同样也是值拷贝 不会改变lua中的内容
        obj.testString = "测试";
        Debug.Log(obj.testString);

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
