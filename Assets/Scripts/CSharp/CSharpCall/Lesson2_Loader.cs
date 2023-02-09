using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class Lesson2_Loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaEnv luaEnv = new LuaEnv();
        // 传参是个委托
        // Xlua提供的路径重定向的方法
        // 允许自定义加载lua文件的规则
        // 当执行Lua的require()方法时 会自动执行这个函数
        luaEnv.AddLoader(MyCustomLoader);
        luaEnv.DoString("require('Main')");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 自定义加载逻辑
    // 如果找不到 会去找默认路径
    private byte[] MyCustomLoader(ref string filePsth)
    {
        // 重定向自己定义的Lua文件路径
        string path = Application.dataPath + "/Scripts/Lua/" + filePsth + ".Lua";
        // 加载文件 利用c#自带的文件读写
        try
        {
            if (File.Exists(path))
            {
                return File.ReadAllBytes(path);
            }
            return null;
        }
        catch (System.Exception)
        {
            throw;
        }
       
    }
}
