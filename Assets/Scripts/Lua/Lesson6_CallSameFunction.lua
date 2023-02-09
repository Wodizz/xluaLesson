print("*******Lua调用C# 重载函数******")

local obj = CS.Lesson6()

-- 虽然lua自己不支持写重载函数 但是支持调用C#的重载函数
print(obj:CalC())
print(obj:CalC(10, 8))

-- 虽然lua支持重载 但是因为lua中的数值只有Number类型 不支持区分int和float
print(obj:CalC(1))
print(obj:CalC(1.2))

-- xlua提供了解决方案
-- 通过反射的机制
-- 尽量别用 反射效率很低

-- 得到指定 函数的相关信息
local m1 = typeof(CS.Lesson6):GetMethod("CalC", { typeof(CS.System.Int32) })
local m2 = typeof(CS.Lesson6):GetMethod("CalC", { typeof(CS.System.Single) })

-- 通过xlua提供的方法  转成lua函数使用
-- 一般转一次 重复使用
local f1 = xlua.tofunction(m1)
local f2 = xlua.tofunction(m2)

-- 成员方法 第一个参数传对象
-- 静态函数 不用传对象
print(f1(obj, 1))
print(f2(obj, 1.2))
