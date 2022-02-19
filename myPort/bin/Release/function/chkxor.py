# -*- coding:UTF-8 -*-
def main(data,str):
    length = len(data)
    checksum = 0
    index = int(str[0],10)
    print(str[0],str[1])
    for i in range(0, int(str[1],10)):
        checksum ^= data[index+i]
    return checksum