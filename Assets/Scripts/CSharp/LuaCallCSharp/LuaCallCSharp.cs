using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

#region 自定义类
public class Test
{
    public void Speak(string str)
    {
        Debug.Log(str);
    }
}
#endregion


#region 自定义命名空间
namespace Wodi
{
    public class Test2
    {
        public void Speak(string str)
        {
            Debug.Log(str);
        }
    }
}
#endregion


#region 自定义枚举测试
public enum E_MyEnum
{
    Idle,
    Move,
    Attack,
}
#endregion


#region 数组 List 字典
public class Lesson3
{
    public int[] array = new int[] { 1, 2, 3, 4, 5 };

    public List<int> list = new List<int>();

    public Dictionary<string, int> dic = new Dictionary<string, int>();
}


#endregion


#region lua调用拓展方法

// 如果想要在lua中用拓展方法 必须在工具类前加特性
// 建议在lua中使用的类 都加上该特性 可以提升性能 因为xlua是通过反射机制去调用 效率较低 提前编译提升性能
[XLua.LuaCallCSharp]
public static class Tools
{
    public static void Move(this Lesson4 lesson4)
    {
        Debug.Log("移动");
    }
}

public class Lesson4
{
    public string name = "卧底";
    public void Speak(string str)
    {
        Debug.Log(str);
    }

    public static void Eat()
    {
        Debug.Log("吃");
    }
}

#endregion

#region lua调用ref 和 out

public class Lesson5
{
    public int RefFunction(int a, ref int b, ref int c)
    {
        b = a + 1;
        c = a - 1;
        return 100;
    }

    public int OutFunction(int a, out int b, out int c)
    {
        b = a + 2;
        c = a - 2;
        return 200;
    }

    public int RefAndOutFuction(int a, out int b, ref int c)
    {
        b = a * 10;
        c *= 20;
        return 300;
    }
}

#endregion

#region 重载函数

public class Lesson6
{
    public int CalC()
    {
        return 100;
    }

    public int CalC(int a)
    {
        return a + 1;
    }

    public int CalC(int a, int b)
    {
        return a + b;
    }

    public float CalC(float a)
    {
        return a + .1f;
    }
}

#endregion

#region 委托和事件
public class Lesson7
{

    public UnityAction del;

    public event UnityAction Event;

    public void InvokeEvent()
    {
        if (Event != null)
        {
            Event();
        }
    }

    public void ClearEvent()
    {
        Event = null;
    }
}

#endregion

#region 二维数组遍历

public class Lesson8
{
    public int[,] array = new int[2, 3]
    {
        {1,2,3},
        {4,5,6}
    };

}
#endregion

#region 判空

// 拓展方法 为object拓展一个方法
[XLua.LuaCallCSharp]
public static class Lesson9
{
    // 拓展为Object判空的方法 因为lua没法比较null和nil
    public static bool IsNull(this UnityEngine.Object obj)
    {
        return obj == null;
    }
}

#endregion

#region 系统类型加特性

public static class Lesson10
{
    [XLua.CSharpCallLua]
    public static List<Type> csharpCallLua = new List<Type>()
    {
        // onValueChanged是个UnityEvent<float> 给UnityAction<float>加也行
        typeof(UnityAction<float>)
    };


    [XLua.LuaCallCSharp]
    // 也可以用这种方法去给lua调用的类型批量添加特性
    public static List<Type> luaCallCsharp = new List<Type>()
    {
        typeof(GameObject),
        typeof(Rigidbody)
    };
}

#endregion

#region 调用泛型方法

public class Lesson12
{
    public interface ITest { }

    public class TestFather
    {

    }

    public class TestChild : TestFather, ITest
    {

    }

    public void TestFun1<T>(T a, T b) where T:TestFather
    {
        Debug.Log("有参数有约束的泛型方法");
    }

    public void TestFun2<T>(T a)
    {
        Debug.Log("有参数无约束的泛型方法");
    }

    public void TestFun3<T>() where T : TestFather
    {
        Debug.Log("无参数有约束的泛型方法");
    }

    public void TestFun4<T>(T a) where T : ITest
    {
        Debug.Log("有参数有约束为接口的泛型方法");
    }
}

#endregion



public class LuaCallCSharp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
