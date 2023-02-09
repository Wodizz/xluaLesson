-- 热更四步：
-- 1.加特效
-- 2.加宏
-- 3.生产代码
-- 4.hotfix注入

-- xlua热补丁固定写法
-- xlua.hotfix(类，“函数名”， lua函数)
-- 成员函数默认第一个传self！！！！！！！！
xlua.hotfix(CS.Hotfix_Main, "Add", function(self, a, b)
    return a * b
end)

xlua.hotfix(CS.Hotfix_Main, "PrintLog", function(a)
    print(a)
end)
