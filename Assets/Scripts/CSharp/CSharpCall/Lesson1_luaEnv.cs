using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class Lesson1_luaEnv : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Lua解析器 让unity中执行lua
        // 一般情况下 保持唯一性
        LuaEnv env = new LuaEnv();
        // 在里面写lua(一般不会这样执行)
        env.DoString("print('Hello Lua!')");

        // 执行一个lua脚本 利用lua的require()方法
        // 默认寻找脚本的路径 在resources 
        // 因为用在resources.load加载 所以lua脚本后缀只能用txt
        env.DoString("require('Main')");

        // 帮助清楚lua中没有手动释放的对象
        // 帧更新中定时执行 或者 切场景执行
        env.Tick();
        // 销毁lua解析器
        env.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
