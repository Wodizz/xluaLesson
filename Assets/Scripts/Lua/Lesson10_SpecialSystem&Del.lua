print("*******Lua调用C# 系统类和委托互相使用******")

-- 别名
GameObject = CS.UnityEngine.GameObject
UI = CS.UnityEngine.UI

local slider = GameObject.Find("Slider")
print(slider)
local sliderScript = slider:GetComponent(typeof(UI.Slider))
print(sliderScript)

-- 因为onValueChanged这个委托 没法加CSharpCallLua特性 不能直接存lua的函数
-- 所以现在c#中去批量去给系统委托加特性
sliderScript.onValueChanged:AddListener(function(f)
    print(f)
end)
