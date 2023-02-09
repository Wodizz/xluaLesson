xlua.hotfix(CS.Hotfix_Main, {
    -- add_事件名
    -- remove_事件名
    add_eventTest = function(self, del)
        print(del)
        print("添加事件方法")

        --重定向的时候 千万别用lua调用c#加事件 会死循环
        --self:eventTest("+", del)
    end,

    remove_eventTest = function(self, del)
        print(del)
        print("移除事件方法")
    end
})
