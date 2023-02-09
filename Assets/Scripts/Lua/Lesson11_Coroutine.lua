print("*******Lua调用C# 协程******")
-- xlua提供的一个工具表 必须先require引用
util = require("xlua.util")

-- c#中协程的启动 都是通过继承了mono的类 通过启动函数
GameObject = CS.UnityEngine.GameObject
WaitForSeconds = CS.UnityEngine.WaitForSeconds

-- 挂一个继承mono的脚本
local obj = GameObject("Coroutine")
local mono = obj:AddComponent(typeof(CS.LuaCallCSharp))

-- 希望被用来开启的协程函数
fun =  function()
	local a = 1
	while true do
		-- lua中不能直接使永yield return
		-- 使用lua的协程返回
		coroutine.yield(WaitForSeconds(1))
		print(a)
		a = a + 1
		if a > 10 then
			-- 停止协程和c#一样
			mono:StopCoroutine(method)
		end
	end
end

-- 不能直接将lua函数传入开启协程中
-- 使用xlua提供的工具表
-- 必须先调用xlua.util的cs_generator方法 这是一个生成器
method = mono:StartCoroutine(util.cs_generator(fun))