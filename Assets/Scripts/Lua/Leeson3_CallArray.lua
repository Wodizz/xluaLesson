print("*******Lua调用C#数组******")

--实例化对象
local obj = CS.Lesson3()

-- lua使用c#数组
-- 长度 userData
-- C#怎么用 lua就怎么用 不能用#去获取
print(obj.array.Length)

--访问元素
print(obj.array[0])

--遍历要注意 虽然lua是从1开始
--但要按c#规则来

--注意 最大值一定要-1 lua是能取到最大值的！！！！！！
for i=0, obj.array.Length-1 do
	print(obj.array[i])
end

--创建数组 可以用Array类
local array2 = CS.System.Array.CreateInstance(typeof(CS.System.Int32), 10)
print(array2.Length)

print("*******Lua调用C# List******")
-- 调用成员方法用:!!!!!!
obj.list:Add(1)
obj.list:Add(2)
obj.list:Add(3)
print(obj.list.Count)

-- 遍历
for i=0,obj.list.Count -1 do
	print(obj.list[i])
end

-- 创建List
-- 老版本 List`1相当于一个泛型的list
local list2 = CS.System.Collections.Generic["List`1[System.String]"]()
print(list2)

-- 新版本 > v2.1.2
-- 这个只是获取了一个类
local List_String = CS.System.Collections.Generic.List(CS.System.String)
-- 相当于new 了一个 泛型为string的对象
local list3 = List_String()
list3:Add("uwbduihuw")
print(list3[0])



print("*******Lua调用C# Dictionary******")

--使用和c#一致
obj.dic:Add("wodi", 1)
obj.dic:Add("ww", 2)
obj.dic:Add("ndd", 8)
obj.dic:Add("dididi", 10)
print(obj.dic:get_Item("wodi"))

--遍历
for k,v in pairs(obj.dic) do
	print(k,v)
end

--创建字典对象
--得到了一个Dictionary<String, Vector3>的一个类别名
local Dic_String_Vector3 = CS.System.Collections.Generic.Dictionary(CS.System.String, CS.UnityEngine.Vector3)
--实例化
local dic2 = Dic_String_Vector3()
dic2:Add("123", CS.UnityEngine.Vector3.Up)
--lua中字典直接用[]得不到 是nil
print(dic2["123"])
--固定方法get_Item
print(dic2:get_Item("123"))
--改变值set_Item
dic2:set_Item("123", CS.UnityEngine.Vector3.right)
print(dic2:get_Item("123"))
