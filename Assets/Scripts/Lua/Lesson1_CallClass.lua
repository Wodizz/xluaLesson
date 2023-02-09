print("*******Lua调用C#******")

--lua使用c#的类
--固定套路
--CS.命名空间.类名
--Unity的类 都在CS.UnityEngine
--CS.UnityEngine.GameObject

--通过C#中的类 实例化一个对象
--默认调用 相当于无参构造函数
local obj1 = CS.UnityEngine.GameObject()
local obj2 = CS.UnityEngine.GameObject("Wodi")

--为了方便使用 并且节约性能 可以定义全局变量 存C#中的类
--也是一种lua优化方法
GameObject = CS.UnityEngine.GameObject
local obj3 = GameObject("Wodi2")

--类中的静态方法 可以直接调用
local obj4 = GameObject.Find("Wodi")

--得到对象中的成员变量
print(obj4.transform.position)
Debug = CS.UnityEngine.Debug
Debug.Log(obj4.transform.position)

Vector3 = CS.UnityEngine.Vector3
--如果使用对象的成员方法 用:调用！！！！！！！
obj4.transform:Translate(Vector3.right)
Debug.Log(obj4.transform.position)

-- 实例化默认类
local t = CS.Test()
t:Speak("test说话")

--实例化命名空间下的类
local t2 = CS.Wodi.Test2()
t2:Speak("t2说话")

--继承Mono的类 不能直接实例化
local obj5 = GameObject("加脚本测试")
--lua不支持泛型
--xlua提供了一个方法 typeof可以得到类的type
--xlua不支持无参泛型
obj5:AddComponent(typeof(CS.LuaCallCSharp))