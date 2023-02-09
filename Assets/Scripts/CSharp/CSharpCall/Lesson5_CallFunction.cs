using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;

// 无参无返回值的委托
public delegate void CustomCall();

// 有参有返回值的委托
// 必须加特性不然Xlua不认
// 该特性 在Xlua命名空间中 必须点击外部生成脚本 去生成对应的CSharp代码
[CSharpCallLua]
public delegate int CustomCallInt(int i);

[CSharpCallLua]
public delegate int CustomOutCallInt(int i, out int j, out string s, out bool w);

[CSharpCallLua]
public delegate int CustomRefCallInt(int i, ref int j, ref string s, ref bool w);

// 变长参数的类型 根据实际情况来指定
[CSharpCallLua]
public delegate void CustomParamsCall(string a, params int[] args);

public class Lesson5_CallFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.Instance.Init();
        LuaManager.Instance.DoLuaFile("Main");

        // 无参无返回值的获取
        // 利用委托去获取
        CustomCall call = LuaManager.Instance.Global.Get<CustomCall>("testFun1");
        call();

        // unity和C#自带的也行
        UnityAction u_action = LuaManager.Instance.Global.Get<UnityAction>("testFun1");
        Action s_action = LuaManager.Instance.Global.Get<Action>("testFun1");

        // Xlua提供的一种方式 一般不用
        LuaFunction luaFunction = LuaManager.Instance.Global.Get<LuaFunction>("testFun1");
        luaFunction.Call();

        // 有参有返回值
        CustomCallInt call2 = LuaManager.Instance.Global.Get<CustomCallInt>("testFun2");
        call2(5);

        Func<int,int> f_call2 = LuaManager.Instance.Global.Get<Func<int,int>>("testFun2");
        f_call2(3);

        // 有参多返回值
        // 使用ref或者out去传值
        CustomOutCallInt call3 = LuaManager.Instance.Global.Get<CustomOutCallInt>("testFun3");
        int a;
        string b;
        bool c;
        Debug.Log("多返回值的第一个值" + call3(100, out a, out b, out c));

        // 用ref记得先赋值
        CustomRefCallInt r_call3 = LuaManager.Instance.Global.Get<CustomRefCallInt>("testFun3");
        int a1 = 0;
        string b1 = "";
        bool c1 = false;
        Debug.Log("多返回值的第一个值" + r_call3(100, ref a1, ref b1, ref c1));

        // 使用luafunction
        // 官方建议最好别用 会产生垃圾
        LuaFunction lf2 = LuaManager.Instance.Global.Get<LuaFunction>("testFun3");
        object[] objs = lf2.Call(50);
        for (int i = 0; i < objs.Length; i++)
        {
            Debug.Log("第" + i + "个返回值是" + objs[i]);
        }

        // 变长参数
        CustomParamsCall p_Call = LuaManager.Instance.Global.Get<CustomParamsCall>("testFun4");
        p_Call("卧底", 1, 23, 9, 9342, 324, 43);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
