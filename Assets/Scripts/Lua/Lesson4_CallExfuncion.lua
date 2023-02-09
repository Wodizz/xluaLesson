print("*******Lua调用C# 扩展方法******")

Lesson4  = CS.Lesson4

Lesson4.Eat()

local obj = Lesson4()
obj:Speak("卧底说话")
-- 使用拓展方法和使用成员方法一致
obj:Move()