print("*******Lua调用C# ref和out******")

Lesson5 = CS.Lesson5

local obj = Lesson5()

--ref参数 会以多返回值的形式 返回给lua

-- 第一个a接收的是默认返回值
-- 之后的返回值 是ref的结果
-- ref参数需要传默认值
local a, b, c = obj:RefFunction(1, 0, 0)
print("a:" .. a .. " b:" .. b .. " c:" .. c)

--out 参数不需要传默认值 占坑
local a, b, c = obj:OutFunction(1)
print("a:" .. a .. " b:" .. b .. " c:" .. c)

--out可以省略不传 只传ref
local a, b, c = obj:RefAndOutFuction(10, 20)
print("a:" .. a .. " b:" .. b .. " c:" .. c)

--out可以省略不传--out可以省略不传--out可以省略不传
