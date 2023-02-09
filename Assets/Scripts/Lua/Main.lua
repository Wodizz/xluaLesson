print("Lua主入口")
--require("Test")
require("Hotfix_Lesson6")

-- 判断是否为空的全局函数
function IsNull(obj)
    if obj == nil or obj:Equals(Null) then
        return true
    end
    return false
end
