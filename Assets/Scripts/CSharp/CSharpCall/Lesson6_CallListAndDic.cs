using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson6_CallListAndDic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.Instance.Init();
        LuaManager.Instance.DoLuaFile("Main");

        // 同一类型list
        // 浅拷贝 不会改变lua中的原表
        List<int> i_list = LuaManager.Instance.Global.Get<List<int>>("testList");
        for (int i = 0; i < i_list.Count; i++)
        {
            Debug.Log(i_list[i]);
        }
        Debug.Log("**********************");
        // 不指定类型
        List<object> o_list = LuaManager.Instance.Global.Get<List<object>>("testList2");
        for (int i = 0; i < o_list.Count; i++)
        {
            Debug.Log(o_list[i]);
        }
        Debug.Log("**********************");

        // 固定类型dic
        Dictionary<string, int> si_dic = LuaManager.Instance.Global.Get<Dictionary<string, int>>("testDic");
        foreach (var item in si_dic)
        {
            Debug.Log("键：" + item.Key + "值：" + item.Value);
        }

        Debug.Log("**********************");
        Dictionary<object, object> oo_Dic = LuaManager.Instance.Global.Get<Dictionary<object, object>>("testDic2");
        foreach (var item in oo_Dic)
        {
            Debug.Log("键：" + item.Key + "值：" + item.Value);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
