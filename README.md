# myPort

### 介绍

通用上位机<br>
可使用串口、tcp服务器和tcp客户端<br>
可自动解析通信协议,通信协议可编写任意多条<br>
可根据协议自动返回命令<br>
可根据解析内容形成曲线<br>
可保存配置<br>
可保存数据<br>
可加载python脚本<br>

#### 界面说明

![介绍](/img/介绍.png "介绍")
用户在**接收参数**区域写入用于接收的参数,在**设置参数**区域写入用于设置的参数.<br>接收到数据之后,软件根据协议配置中的协议来匹配接收参数<br>在发送命令区域填写命令,发送命令中的参数变量可以自动填入设置参数对应的值

#### 协议配置

点击协议配置出现如下界面进行协议配置
![协议配置](/img/协议配置.png "协议配置")
双击空白协议行新增协议
![新增协议](/img/新增协议.png "新增协议")
其中协议名可自定义<br><br>
协议格式如果带有```%```则表示该项为变量,软件会自动去匹配**接收参数**中的参数,如果```%```后的的名字和**接收参数**中名字相同,则**接收参数**中对应的参数值将会被替换.对于多个字节表示的参数,只需在变量名后加上```:字节数```,如上图表示**接收数据**这个参数占4个字节,就可以使用```%接收数据:4```来表示.对于不关心的数据,只需```%+任意名字```即可跳过该变量.<br><br>
协议中如果带有```$```则代表调用程序同级目录**function**下的python脚本文件的```mian```函数,调用的脚本名称和```$```后跟的名称相同,脚本默认输入byte数组,脚本可以携带参数,参数使用```()```包裹,并用逗号分隔,在python脚本中以字符串的形式出现.脚本需要返回一个int值,程序会自动将这个值根据设置的大小端模式分配到指定位置.如```chksum(1,5)```表示调用chksum.py脚本中```main```函数,其参数为byte数组,和字符串数组,字符串数组的值为"1"和"5",返回的值将会放在第7位.<br><br>
勾选是否回复,可以在接收到和当前协议匹配的数据后回复对应的数据,如上图表示接收到对应协议回复命令名为<回复>的命令

#### 发送命令

双击发送命令中的任意命令打开下图配置
![发送命令](/img/发送命令.png "发送命令")
命令格式用法和协议配置相同,其中$chksum(1,3)表示使用脚本函数,取数组下标为1,长度为3的数据的校验和.<br><br>
勾选是否连发,软件将会在n毫秒后自动重复发送

#### 接收参数

勾选图像,该参数被匹配时会在**图形**区域生成一条曲线,值为匹配值

#### 脚本

软件支持载入脚本,脚本将会在收到数据时调用dataRec函数,入参为收到的byte数组,脚本需要返回byte数组<br><br>
脚本将会在准备发送数据时调用dataSend函数,入参为即将发送的byte数组,脚本需要返回byte数组<br><br>
下列脚本可以将接收到的第一个数据改为0,将发送数组的第一个数据改为0.
软件提供了一个字典param来保存脚本中的参数,可以查看例程 function/param.py来查看具体使用<br><br>

```
def dataRec(data):
    data[0] = 0;
    return data
def dataSend(data):
    data[0] = 0;
    return data
```

### 曲线的使用

勾选接收参数中的曲线将会在下一次参数匹配时,将值画在曲线上.点击鼠标左键拖到可以放大曲线,点击右键可以缩小曲线.<br><br>
如果曲线数量超过两百个,曲线会自动移动,滚动鼠标滚轮可以查看历史数据.

### 测试

导入**bin/Release/测试.myPort**配置,连接本机的9000端口,发送如下数据

```
fb 01 02 03 04 05 0f fc
```

![测试服务器](/img/测试服务器.png "测试服务器")
![测试](/img/测试.png "测试")

### 软件架构

基于c# winform
使用第三方UI库 [SunnyUI](https://gitee.com/yhuse/SunnyUI)
使用VS2019 社区版进行开发

### 安装教程

打开myPort.exe即可
注意SunnyUI.dll和SunnyUI.Common.dll需要和myPort.exe在同级目录下

### 参与贡献

1. Fork 本仓库
2. 新建 Feat_xxx 分支
3. 提交代码
4. 新建 Pull Request
