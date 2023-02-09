
-- 泛型类中 因为T是可变的 所以要指定类型 替换几个 就写几个
xlua.hotfix(CS.HotFixTest2(CS.System.String), {
    Test = function(self, str)
        print("Lua中给string打的补丁" .. str)
    end
})

xlua.hotfix(CS.HotFixTest2(CS.System.Int32), {
    Test = function(self, str)
        print("Lua中给int打的补丁" .. str)
    end
})
