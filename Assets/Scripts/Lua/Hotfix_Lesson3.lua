-- xlua协程在util里
util = require("xlua.util")


xlua.hotfix(CS.Hotfix_Main, {
    TestCoroutine = function(self)
        return util.cs_generator(function()
            while true do
                coroutine.yield(CS.UnityEngine.WaitForSeconds(1))
                print("Lua补丁后的协程函数")
            end
        end)
    end
})
