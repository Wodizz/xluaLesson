-- xlua热补丁固定写法
-- xlua.hotfix(类，“函数名”， lua函数)
-- 成员函数默认第一个传self！！！！！！！！
xlua.hotfix(CS.Hotfix_Main, {
    Update = function(self)
        print(os.time())
    end,
    Add = function(self, a, b)
        return a + b
    end,
    PrintLog = function(a)
        print(a)
    end
})


xlua.hotfix(CS.HotFixTest, {
    -- 构造函数热补丁固定写法！！！
    [".ctor"] = function()
        print("Lua热补丁构造函数固定写法")
    end,
    PrintLog = function(self, a)
        print("构造函数测试类的" .. a)
    end,
    -- 析构函数固定写法
    Finalize = function()
        -- body
    end
})
