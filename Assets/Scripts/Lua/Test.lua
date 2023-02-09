print("调用脚本Test.lua")
testNumber = 1
testBool = true
testFloat = 3.7
testString = "卧底"

-- C# 无法获得
local  testLocalNumber = 8

-- 无参无返回
function testFun1()
	print("无参无返回值")
end

-- 有参有返回
function testFun2(i)
	print("有参有返回值")
	return i+1
end

-- 多返回值
function testFun3(a)
	print("多返回值")
	return a, a+1, "卧底", true
end

-- 变长参数
function testFun4(...)
	print("变长参数")
	arg = {...}
	for k,v in pairs(arg) do
		print(k,v)
	end
end

-- List
testList = {1,2,35,6,782,3}
testList2 = {"ww", 1, false, 3.9}


-- Dictionary
testDic = {
	["1"] = 1,
	["2"] = 2,
	["3"] = 3,
	["4"] = 4,
}

testDic2 = {
	["1"] = 1,
	[true] = 2,
	[false] = "wodi",
	[3] = true,
}

-- class
testClass = {
	testInt = 2,
	testFloat = 1.2,
	testBool = true,
	testFunc = function()
		print("function")
	end,
	testString = "啊哈哈哈",
}