print("*******Lua调用C# 泛型方法******")

local obj = CS.Lesson12()

local child = CS.Lesson12.TestChild()
local father = CS.Lesson12.TestFather()

-- lua支持调用有参数有约束的泛型方法
obj:TestFun1(child, father)

-- lua不支持调用有参数无约束的泛型方法
--obj:TestFun2(child)

-- lua不支持调用无参数有约束的泛型方法
--obj:TestFun3()

-- lua不支持调用 非class约束的泛型方法
--obj:TestFun4(child)


-- 有使用限制
-- 在打包时 选择MONO和IL2CPP存在区别
-- 如果MONO打包 支持使用
-- 如果IL2CPP打包 只有泛型参数是引用类型 才能使用
-- 如果IL2CPP打包 如果泛型参数是值类型 除非c#已经调用过同样类型的变量 才能使用

-- 补充：让不支持的泛型函数能用
-- 存在性能浪费
-- 1.得到通用函数
-- 2.设置泛型类型

-- xlua.get_generic_method(类, "函数名")
local testFun2_Method = xlua.get_generic_method(CS.Lesson12, "TestFun2")
-- 传泛型类型 得到的对象才是可以调用的
local testFun2_Invoke = testFun2_Method(CS.System.Int32)

-- 调用
-- 成员方法 第一个参数 传调用函数的对象
-- 静态方法不用传
testFun2_Invoke(obj, 1)
