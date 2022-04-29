# -*- coding:UTF-8 -*-
# 参数保存例程,param为dictionary,
# 接收时匹配上才会保存参数,其他时候执行脚本就保存
# 保存的参数将在程序关闭后清空
def main(data, str):
    length = len(data)
    if 'a' not in param:  # 第一次进入脚本,没有这个参数,赋初值
        param['a'] = 1
    else:
        param['a'] = param['a']+1
    param['b'] = "21"
    return param['a']
