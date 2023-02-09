using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class Lesson9_CallLuaTable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.Instance.Init();
        LuaManager.Instance.DoLuaFile("Main");
        // 官方不建议用LuaTable 性能消耗较高
        LuaTable table = LuaManager.Instance.Global.Get<LuaTable>("testClass");
        Debug.Log(table.Get<string>("testFunc"));
        Debug.Log(table.Get<int>("testInt"));
        table.Get<System.Action>("testFunc")();

        // LuaTable必须Dispose 不然会一直占用内存 造成内存泄漏
        table.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Transform> objList = new List<Transform>();

    public void FindSelf(Transform obj)
    {
        if (obj.childCount > 0)
        {
            Transform[] childs = obj.GetComponentsInChildren<Transform>();
            for (int i = 1; i < childs.Length; i++)
            {
                objList.Add(childs[i]);
                FindSelf(childs[i]);
            }
        }
    }

}
