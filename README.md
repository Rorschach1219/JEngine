# JENGINE v0.5.x LTS

JEngine是针对Unity开发者设计的**开箱即用**的框架，封装了强大的功能，小白也能**快速上手**，**轻松制作**可以**热更新的游戏**

该分支是```v0.5```系列分支，是一个长期支持（**LTS**）版本，虽然**已不再继续更新**新功能，**但会修复Bug**，欢迎**PR**和提交**issue**

**注意：**如果```Instantiate```，```SendMessage```等方法出现错误，是CLR重定向没有实现，需要学习ILRuntime去自己实现，也可以更新最新分支（0.6.x就已经实现了）

![topLanguage](https://img.shields.io/github/languages/top/JasonXuDeveloper/JEngine)
![size](https://img.shields.io/github/languages/code-size/JasonXuDeveloper/JEngine)
![issue](https://img.shields.io/github/issues/JasonXuDeveloper/JEngine)
![license](https://img.shields.io/github/license/JasonXuDeveloper/JEngine)
![last](https://img.shields.io/github/last-commit/JasonXuDeveloper/JEngine)

> QQ群: [921271552](https://jq.qq.com/?_wv=1027&k=cF4hODjW)
>
> 已有项目使用JEngine热更新，并成功上架iOS

[English Document](README_en-us.md)

![banner](https://s1.ax1x.com/2020/10/09/0rtUL4.png)


  ## 框架相关
| 主题                                                  | 地址                                                         |
| ----------------------------------------------------- | ------------------------------------------------------------ |
| 教学视频：介绍+使用+更新+入门                         | [点击跳转](https://www.bilibili.com/video/BV14Z4y1N79J/)     |
| 教学视频：核心功能（上）自动绑定+基类+UI+资源解决方案 | [点击跳转](https://www.bilibili.com/video/BV1v54y1y7x7/)     |
| 教学视频：核心功能（中）JAction队列解决方案全系列     | [点击跳转](https://www.bilibili.com/video/BV1Pt4y1q7X2/)     |
| 教学视频：核心功能（下）数据持久化+对象池+助手类+面板 | [点击跳转](https://www.bilibili.com/video/BV12Z4y1N7eG/)     |
| 框架文档                                              | [Wiki文档](https://github.com/JasonXuDeveloper/JEngine/wiki) |
| 知乎文章                                              | [点击跳转](https://zhuanlan.zhihu.com/p/218105381)           |
| 项目地址                                              | [GitHub地址](https://github.com/JasonXuDeveloper/JEngine)    |
| 国内镜像                                              | [Gitee跳转](https://gitee.com/JasonXuDeveloper/JEngine)      |
| QQ群聊                                                | [点击加入](https://jq.qq.com/?_wv=1027&k=cF4hODjW)           |

  ## 框架实战
| 主题                                                         | 地址                                                      |
| ------------------------------------------------------------ | --------------------------------------------------------- |
| 【Unity x JEngine 开发可热更爆款小游戏】第一集（系列介绍及游戏策划） | [点击跳转](https://www.bilibili.com/video/BV1sV41117ka/)  |
| 【Unity x JEngine 开发可热更爆款小游戏】第二集（构建项目及界面设计） | [点击跳转](https://www.bilibili.com/video/BV1m54y117vz/)  |
| 【Unity x JEngine 开发可热更爆款小游戏】第三集（场景界面设计） | [点击跳转](https://www.bilibili.com/video/BV1sk4y1C7b5/)  |
| 【Unity x JEngine 开发可热更爆款小游戏】第四集（界面设计及代码开发） | [点击跳转](https://www.bilibili.com/video/BV1hv411y7iC/)  |
| 【Unity x JEngine 开发可热更爆款小游戏】第五集（首页UI代码开发） | [点击跳转](https://www.bilibili.com/video/BV1ZT4y1c7t7/)  |
| 【Unity x JEngine 开发可热更爆款小游戏】第六集（Bug修复+代码开发+音乐配置） | [点击跳转](https://www.bilibili.com/video/BV1bi4y1E7e7/)  |
| 【Unity x JEngine 开发可热更爆款小游戏】第七集（关卡设计+编辑器开发+数据生成） | [点击跳转](https://www.bilibili.com/video/BV1sv411y7gF/)  |
| 【Unity x JEngine 开发可热更爆款小游戏】第八集（关卡读取+界面生成） | [点击跳转](https://www.bilibili.com/video/BV15f4y1B7oQ/)  |
| 【Unity x JEngine 开发可热更爆款小游戏】第九集（关卡生成+按钮事件+游戏管理类） | [点击跳转 ](https://www.bilibili.com/video/BV1zp4y1Y7cF/) |

  ## 近期star趋势

  [![Stargazers over time](https://starchart.cc/JasonXuDeveloper/JEngine.svg)](https://starchart.cc/JasonXuDeveloper/JEngine)

  ## JEngine能够做些什么？

  - **[热更新解决方案 ](https://github.com/JasonXuDeveloper/JEngine/wiki/开始使用)**

    - **资源热更**基于[**XAsset**](https://github.com/xasset/xasset)，JEngine的作者是该框架贡献成员之一
    - **C#代码热更**基于[**ILRuntime**](https://github.com/Ourpalm/ILRuntime)，JEngine的作者也是该框架U3D工程贡献成员之一
    - **代码加密**，C#热更代码生成的**DLL**会通过**AES-128-ECB**模式加密进Assetbundle，运行游戏时动态解密
    - **资源加密**，XAsset包含VFS功能，可以对资源进行一定程度的加密，AssetStudio无法破解资源
    - **自动赋值**，热更脚本可自动添加到游戏物体或预制体，且可自动赋值，不需要手动写代码赋值

  - **[Action队列解决方案](https://github.com/JasonXuDeveloper/JEngine/wiki/JAction教程)**

    - **更少的代码，实现更多功能，效率大幅度提高**！
    - 轻松**执行、延时、等待、定期循环、条件循环、同步/异步运行、取消队列**
    - **主线程运行代码**

  - **[UI生命周期解决方案](https://github.com/JasonXuDeveloper/JEngine/wiki/JUI教程)**
    - **轻松**管理**UI周期**，**链式编程**让代码**更美观**
    - UI**定期循环**更新，可以选择**毫秒更新或帧更新**，可以指定更新**频率**

    - UI**绑定数据**，当**数据更新**，即可**执行绑定的方法**

  - **[基类解决方案](https://github.com/JasonXuDeveloper/JEngine/wiki/JBehaviour教程)**
    - **轻松管理**生命周期
    - 可以**帧循环**，或者**毫秒循环**
    - **不依赖MonoBehaviour**
    - **简单好用**

  - **[基于XAsset的资源加载方案](https://github.com/JasonXuDeveloper/JEngine/wiki/JResource教程)** 
    - 支持**同步/异步加载**资源
    - **泛型**方法，轻松使用
    - **异步加载**热更**场景**
    
- **[自动绑定热更脚本到GameObject](https://github.com/JasonXuDeveloper/JEngine/wiki/代码绑定)**
  - 输入命名空间，类名，即可**自动绑定**热更脚本**至物体**
  - 可对**该脚本public/private/static数值进行赋值**
  - **特殊类型支持拖拽赋值**
  - **不需要是Mono类**

- **[数据持久化解决方案](https://github.com/JasonXuDeveloper/JEngine/wiki/JSaver教程)**

  - 字符串存本地
  - **JSON**存本地
  - **Protobuf**二进制存本地
  - **自带加密**

- **[多语言解决方案](https://github.com/JasonXuDeveloper/JEngine/wiki/Localization教程)**

  - **CSV配表**
  - 轻松**转换语种**
  - 可通过静态方法**获取key对应的字符串**
  - 可让Text**自动根据语言切换文字**

- **[内存加密解决方案](https://github.com/JasonXuDeveloper/JEngine/wiki/内存加密结构)**

  - 支持**90%数值类型**
  - **偏移值**加密
  - **转JSON和Protobuf**于**普通数据结构一样**
  - 可以**捕获内存作弊**

- **对象池**解决方案

  - 大幅度提升性能及减少内存开销，相比于常规Instantiate操作
  - **无需重复**创建新对象！
  - **智能算法**，贪心算法匹配GameObject，对象池满可自动添加！
  
- **加密解密**解决方案

  - **AES**加密
  - 支持**字符串**
  - 支持**二进制**

- **序列化**解决方案

  - 转**String**
  - 转**JSON**
  - 转**Protobuf-net**二进制

- 面板类
  - **ILRuntime适配器自动生成**
  - **Protobfuf文件与CS类互转**

  - 还有更多功能，尽情自行探索！





  JEngine的目的是针对游戏开发者提供**精简、美观且高效**的**代码**功能，并且使游戏开发者**更加轻松的制作游戏**

  **如果你觉得JEngine对你有帮助，请给该框架一个Star！**

  





## v0.5.8 最新功能

- **Bug修复** 当复制streaming asset时安卓可能会出现错误

- **C# type 转 Proto 文件** 转换器

- **重新排序** 菜单栏

- **优化** 自动绑定

- **更高级的** JBehaviour编辑器

- **JBehaviour** 支持通过 ```new()```创建对象

- **BindableProperty** 支持绑定多个事件（被多个值绑定）

  [点击此处查看历史版本功能（英文）](CHANGE.md)

  

## 即将推出

- ~~热更资源及代码的开发模式~~
- ~~加密解密DLL~~
- ~~对象池~~
- ~~内存加密类~~
- ~~JPrefab，一个更容易管理热更预制体的解决方案~~
- Socket
- JUI延伸API
- UI特效
- 优化算法、代码（一直在优化）



## JEngine热更逻辑

![flowchart](https://s1.ax1x.com/2020/09/06/wenIpV.png)



## 开发环境

- Unity版本：2019.3.13f1 （请使用该版本及以上）

- U3D工程.net环境： .net 4.x

- 热更工程.net环境： .net 4.x

- 开发系统：MacOS 10.15.5

  > 100%支持Windows



## 推荐项目

- [XAsset](https://github.com/xasset/xasset) - 精简高效的资源热更框架
- [IFramework](https://github.com/OnClick9927/IFramework) - Simple Unity Tools
- [QFramework](https://github.com/liangxiegame/QFramework) - Your first K.I.S.S Unity 3D Framework.



## 由衷感谢

- Ekson（赞助）
- 程序-华仔（赞助）
- 默默的奶爸（赞助+宣传推广）
- 马三（赞助）
- 清行（文档）
- 阿飞（赞助）
