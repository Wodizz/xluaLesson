
xlua.hotfix(CS.Hotfix_Main, {
    -- set_属性名 是设置属性的方法
    -- get_属性名 是得到属性的方法
    set_Age = function(self, v)
        print("Lua重定向得到的属性:" .. v)
    end,
    get_Age = function(self)
        return 10;
    end,

    -- 索引器固定写法
    -- set_Item 索引器设置
    -- get_Item 索引器获取
    set_Item = function(self, index, v)
        print("Lua重定向索引器, 索引:" .. v)
    end,
    get_Item = function(self, index)
        return 999
    end
})
