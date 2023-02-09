print("*******Lua调用C# null和nil的区别******")

-- 往场景对象上添加一个脚本 如果存在就不加

-- 起别名
GameObject = CS.UnityEngine.GameObject
Rigidbody = CS.UnityEngine.Rigidbody

local obj = GameObject("测试加脚本")
local rig = obj:GetComponent(typeof(Rigidbody))
print(rig)
-- 判断空
-- nil与null不能直接比较 必须用Equals
if rig:IsNull() then
    obj:AddComponent(typeof(Rigidbody))
end
print(rig)
