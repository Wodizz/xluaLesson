print("*******Lua调用C#二维数组******")

local obj = CS.Lesson8()

-- 获取长度
print("行：" .. obj.array:GetLength(0))
print("列：" .. obj.array:GetLength(1))

-- 获取元素
-- 不能通过[0,0]访问元素
-- 用Array类自带的成员方法
print(obj.array:GetValue(0,0))

print("*******二维数组遍历******")
for i=0, obj.array:GetLength(0) - 1 do
	for j=0, obj.array:GetLength(1) - 1 do
		print(obj.array:GetValue(i,j))
	end
end