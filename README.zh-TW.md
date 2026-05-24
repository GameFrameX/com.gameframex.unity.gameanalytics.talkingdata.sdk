<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="GameFrameX Logo" width="160" />

  # GameFrameX GameAnalytics TalkingData SDK

  [![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.gameanalytics.talkingdata.sdk)](https://github.com/GameFrameX/com.gameframex.unity.gameanalytics.talkingdata.sdk/releases)
  [![License](https://img.shields.io/badge/license-MIT-orange.svg)](LICENSE.md)
  [![Documentation](https://img.shields.io/badge/docs-gameframex-blue.svg)](https://gameframex.doc.alianblank.com)

  獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使

  [文檔](https://gameframex.doc.alianblank.com) | [快速開始](#快速開始)

  [English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)
</div>

---

## 項目簡介

TalkingData Unity 平台 SDK 由 `封裝層` 和 `Native SDK` 兩部分構成，目前 GitHub 上提供了封裝層程式碼，需要從 [TalkingData官網](https://www.talkingdata.com/spa/sdk/#/universal?sdkPlatform=Unity) 下載最新版的 Android 和 iOS 平台 Native SDK，組合使用。

## 整合說明

1. 下載本專案（封裝層）到本機
2. 訪問 [TalkingData官網](https://www.talkingdata.com/spa/sdk/#/universal?sdkPlatform=Unity) 下載最新版的 Android 和 iOS 平台 TalkingData SDK (Native SDK)
    - 方法1：選擇 Unity 平台進行功能自訂
    - 方法2：分別選擇 Android 和 iOS 平台進行功能自訂，請確保兩個平台功能項一致
3. 將下載的最新版 `Native SDK` 複製到 `封裝層` 中，構成完整的 Unity SDK
    - Android 平台：將最新的 `.jar` 檔案複製到 `Assets/Plugins/Android` 目錄下
    - iOS 平台：將最新的 `.h` 和 `.a` 檔案複製到 `Assets/Plugins/iOS` 目錄下
4. 按 `Native SDK` 功能選項對 `封裝層` 程式碼進行必要的修改，詳見「注意事項」第2條
5. 將 Unity SDK 整合到您需要統計的專案中，並按 [整合文件](http://doc.talkingdata.com/posts/1026) 進行必要設定和功能呼叫

## Android 權限設定

Android 平台 SDK 需要在 AndroidManifest.xml 檔案中新增以下權限：

| 權限 | 用途 |
|---|---|
| INTERNET | 允許程式聯網和傳送統計資料的權限 |
| ACCESS_NETWORK_STATE | 允許應用檢測網路連線狀態，在網路異常狀態下避免資料傳送，節省流量和電量 |
| READ_PHONE_STATE | 允許應用以唯讀的方式存取手機裝置的資訊，透過取得的資訊來唯一標識使用者 |
| ACCESS_WIFI_STATE | 取得裝置的MAC位址，同樣用來標識唯一使用者 |
| WRITE_EXTERNAL_STORAGE | 用於儲存裝置資訊以及記錄日誌 |
| ACCESS_FINE_LOCATION（可選） | 可透過GPS取得裝置的位置資訊，用來修正使用者的地域分佈資料，使報表資料更準確 |
| ACCESS_COARSE_LOCATION（可選） | 用來取得該應用被使用的粗略位置資訊 |

## iOS 依賴框架

iOS 平台 SDK 需要在編譯產生的 Xcode 專案中新增以下依賴框架：

| 框架 | 用途 |
|---|---|
| AdServices.framework | Apple Search Ads 歸因 |
| StoreKit.framework | Apple SKAdNetwork 歸因轉化 |
| AppTrackingTransparency.framework | 取得App追蹤授權狀態 |
| AdSupport.framework | 取得advertisingIdentifier |
| CoreTelephony.framework | 取得運營商標識 |
| Security.framework | 輔助儲存裝置標識 |
| SystemConfiguration.framework | 檢測網路狀況 |
| libc++.tbd | 支援c++11標準 |
| libz.tbd | 進行資料壓縮 |

iOS 12.0 及以上系統取得 WiFi 資訊時，需要新增 Access WiFi Information 選項：選擇要新增的 Target，點擊 +Capability，在彈出的框中雙擊 Access WiFi Information 進行新增。

iOS 14.0 及以上系統取得 IDFA 時，需要使用者授權：在 Info.plist 中新增 Privacy - Tracking Usage Description Key，Type 為 String 類型，Value 為您的宣告文字。

## 注意事項

1. 分別選擇 Android 和 iOS 平台進行功能自訂時，請確保兩個平台功能項一致。
2. 如果申請 Native SDK 時選擇了可選功能，則需要在本專案中啟用所選功能對應的封裝層程式碼。
   a) 在 `Assets/Plugins/iOS/TalkingDataSDK.mm` 檔案中釋放所選行業或功能的巨集定義。
   b) 在 Unity 中新增相應功能的巨集定義：開啟 `Build Settings`，先在 `Platform` 中選擇 `Android` 或 `iOS` 平台，再點擊 `Switch Platform`。切換完平台後，點擊 `Player Settings`，然後在 `Other Settings` 的 `Scripting Define Symbols` 中輸入所選行業或功能相應的巨集（多個巨集用分號隔開；Android 和 iOS 需要分別新增）。

| 行業&功能 | 巨集定義 |
|---|---|
| 電商零售 | TD_RETAIL |
| 遊戲娛樂 | TD_GAME |
| 金融借貸 | TD_FINANCE |
| 旅遊出行 | TD_TOUR |
| 線上教育 | TD_ONLINEEDU |
| 小說閱讀 | TD_READING |
| 其他行業 | TD_OTHER |

## 更新日誌

詳見 [CHANGELOG.md](CHANGELOG.md)。

## 開源協議

本專案基於 MIT 協議開源，詳見 [LICENSE.md](LICENSE.md)。
