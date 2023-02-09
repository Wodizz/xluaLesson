using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

// 接口中不允许出现成员变量 所以用属性去接收
// 接口要加特性
// 接口和类一样 其中属性与方法多了少了不影响
[CSharpCallLua]
public interface ICSharpCallInterface
{
    int testInt { get; set; }
    float testFloat { get; set; }
    bool testBool { get; set; }
    System.Action testFunc { get; set; }
    string testString { get; set; }

    void Test();
}

public class Lesson8_CallInterface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.Instance.Init();
        LuaManager.Instance.DoLuaFile("Main");
        ICSharpCallInterface obj = LuaManager.Instance.Global.Get<ICSharpCallInterface>("testClass");
        Debug.Log(obj.testString);
        obj.testFunc();

        // 接口是引用拷贝
        // 修改接口对象的值 lua中的值也会变
        obj.testString = "卧底";
        ICSharpCallInterface obj2 = LuaManager.Instance.Global.Get<ICSharpCallInterface>("testClass");
        Debug.Log(obj2.testString);


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
