print("*******Lua调用C# 委托和事件******")

local obj = CS.Lesson7()

-- 委托 是用来装函数的
-- 使用C#的委托 来装lua函数
local fun = function()
	print("Lua函数fun")
end

-- lua没有复合运算 不能+=
-- 如果第一次往委托中加函数 因为是nil 所以不能直接+
-- 第一次要先 =
obj.del = fun
obj.del = obj.del + function()
	print("类似匿名函数")
end

obj.del()

obj.del = obj.del - fun

-- 置空就是清空 跟c#用法一样
obj.del = nil

print("******调用事件*******")
local fun2 = function()
	print("給事件加的函数")
end

-- 事件加函数
-- 有点类似使用成员方法("+", 事件函数)
obj:Event("+", fun2)
obj:InvokeEvent()
obj:Event("-", fun2)

-- 清除事件不能直接设置nil
-- obj.Event = nil
-- 因为c#事件 不能直接在外部去置空
-- 所以封装一个方法去置空
obj:ClearEvent()