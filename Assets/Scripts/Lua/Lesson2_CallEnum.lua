print("*******Lua调用C#枚举******")

--调用unity中的枚举
--和类的调用一样
--CS.命名空间.枚举名.枚举成员
--也支持取别名
PrimitiveType = CS.UnityEngine.PrimitiveType
GameObject = CS.UnityEngine.GameObject

local obj = GameObject.CreatePrimitive(PrimitiveType.Cube)

--自定义枚举 注意命名空间
E_MyEnum = CS.E_MyEnum

local c = E_MyEnum.Idle
print(c)

--枚举转换
--数值转枚举
local a = E_MyEnum.__CastFrom(1)
print(a)
--字符串转枚举
local b = E_MyEnum.__CastFrom("Attack")
print(b)