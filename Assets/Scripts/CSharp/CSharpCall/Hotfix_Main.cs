using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;
[Hotfix]
public class HotFixTest
{
    public HotFixTest()
    {
        Debug.Log("HotFixTest构造函数");
    }

    public void PrintLog(string log)
    {
        Debug.Log(log);
    }

    ~HotFixTest()
    {

    }
}

[Hotfix]
public class HotFixTest2<T>
{
    public void Test(T str)
    {
        Debug.Log(str);
    }
}


//  用于测试热更新的主脚本
[Hotfix]
public class Hotfix_Main : MonoBehaviour
{
    HotFixTest hotFixTest;

    public int[] array = new int[] { 1, 2, 3, 4, 5, 6 }; 

    // 属性
    public int Age
    {
        get;
        set;
    }

    // 索引器
    public int this[int index]
    {
        get
        {
            return array[index];
        }
        set
        {
            array[index] = value;
        }
    }

    event UnityAction eventTest;


    // Start is called before the first frame update
    void Start()
    {
        LuaManager.Instance.Init();
        LuaManager.Instance.DoLuaFile("Main");
        Debug.Log(Add(5, 6));
        PrintLog("卧底");

        hotFixTest = new HotFixTest();
        hotFixTest.PrintLog("测试打印喵");

        //StartCoroutine(TestCoroutine());

        Age = 100;
        Debug.Log(Age);

        //this[0] = 100;
        //Debug.Log(this[1000]);

        eventTest += TestFunction;
        eventTest -= TestFunction;

        HotFixTest2<string> t1 = new HotFixTest2<string>();
        t1.Test("vedfe");

        HotFixTest2<int> t2 = new HotFixTest2<int>();
        t2.Test(1000);
    }

    IEnumerator TestCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("C#协程打印一次");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestFunction()
    {

    }

    public int Add(int a, int b)
    {
        return 0;
    }

    public static void PrintLog(string log)
    {
        Debug.Log("测试打印");
    }
}
