## TalkingData Unity SDK

TalkingData Unity 平台 SDK 由 `封装层` 和 `Native SDK` 两部分构成，目前 GitHub 上提供了封装层代码，需要从 [TalkingData官网](https://www.talkingdata.com/spa/sdk/#/universal?sdkPlatform=Unity) 下载最新版的 Android 和 iOS 平台 Native SDK，组合使用。

### 集成说明

1. 下载本项目（封装层）到本地；
2. 访问 [TalkingData官网](https://www.talkingdata.com/spa/sdk/#/universal?sdkPlatform=Unity) 下载最新版的 Android 和 iOS 平台 TalkingData SDK (Native SDK)
    - 方法1：选择 Unity 平台进行功能定制；
    - 方法2：分别选择 Android 和 iOS 平台进行功能定制，请确保两个平台功能项一致；
3. 将下载的最新版 `Native SDK` 复制到 `封装层` 中，构成完整的 Unity SDK。
    - Android 平台  
      将最新的 `.jar` 文件复制到 `Assets/Plugins/Android` 目录下
    - iOS 平台  
      将最新的 `.h` 和 `.a` 文件复制到 `Assets/Plugins/iOS` 目录下
4. 按 `Native SDK` 功能选项对 `封装层` 代码进行必要的修改，详见“注意事项”第2条；
5. 将 Unity SDK 集成您需要统计的工程中，并按 [集成文档](http://doc.talkingdata.com/posts/1026) 进行必要配置和功能调用。

快速集成-配置权限
Android 平台 SDK 需要获取适当的权限才可以正常工作，开发者需要在 AndroidManifest.xml 文件中添加下列所有权限申明。

权限 用途

* INTERNET 允许程序联网和发送统计数据的权限
* ACCESS_NETWORK_STATE 允许应用检测网络连接状态，在网络异常状态下避免数据发送，节省流量和电量
* READ_PHONE_STATE 允许应用以只读的方式访问手机设备的信息，通过获取的信息来唯一标识用户
* ACCESS_WIFI_STATE 获取设备的MAC地址，同样用来标识唯一用户
* WRITE_EXTERNAL_STORAGE 用于保存设备信息，以及记录日志
* ACCESS_FINE_LOCATION（可选） 可通过GPS获取设备的位置信息，用来修正用户的地域分布数据，使报表数据更准确
* ACCESS_COARSE_LOCATION（可选） 用来获取该应用被使用的粗略位置信息

快速集成-添加依赖框架
iOS 平台 SDK 需要添加适当的依赖框架才可以正常工作，开发者需要在编译生成的 Xcode 工程中添加下列所有依赖框架。

框架 用途

* AdServices.framework Apple Search Ads 归因
* StoreKit.framework Apple SKAdNetwork 归因转化
* AppTrackingTransparency.framework 获取App跟踪授权状态
* AdSupport.framework 获取advertisingIdentifier
* CoreTelephony.framework 获取运营商标识
* Security.framework 辅助存储设备标识
* SystemConfiguration.framework 检测网络状况
* libc++.tbd 支持c++11标准
* libz.tbd 进行数据压缩

iOS 12.0 及以上系统获取 WiFi 信息时，需要添加 Access WiFi Information 选项：
选择要添加的 Target，点击 +Capability，在弹出的框中双击 Access WiFi Information 进行添加。

iOS 14.0 及以上系统获取 IDFA 时，需要用户授权：
在 Info.plist 中添加 Privacy - Tracking Usage Description Key，Type 为 String 类型，Value 为您的声明文字。

### 注意事项

1. 分别选择 Android 和 iOS 平台进行功能定制时，请确保两个平台功能项一致。
2. 如果申请 Native SDK 时选择了可选功能，则需要在本项目中启用所选功能对应的封装层代码。  
   a) 在 `Assets/Plugins/iOS/TalkingDataSDK.mm` 文件中释放所选行业或功能的宏定义。  
   b) 在 Unity 中添加相应功能的宏定义  
   打开 `Build Settings`，先在 `Platform` 中选择 `Android` 或 `iOS` 平台，再点击 `Switch Platform`。当切换完平台后，点击 `Player Settings`，然后在 `Other Settings` 的 `Scripting Define Symbols` 中输入所选行业或功能相应的宏（如果有多个宏，需要用分号隔开；Android 和 iOS 需要分别添加）。

   各行业功能宏定义如下。

   | 行业&功能  | 宏定义       |
            	| ---------- | ------------ |
   | 电商零售   | TD_RETAIL    |
   | 游戏娱乐   | TD_GAME      |
   | 金融借贷   | TD_FINANCE   |
   | 旅游出行   | TD_TOUR      |
   | 在线教育   | TD_ONLINEEDU |
   | 小说阅读   | TD_READING   |
   | 其他行业   | TD_OTHER     |
