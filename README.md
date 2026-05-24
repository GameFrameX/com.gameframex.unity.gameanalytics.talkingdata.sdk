<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="GameFrameX Logo" width="160" />

  # GameFrameX GameAnalytics TalkingData SDK

  [![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.gameanalytics.talkingdata.sdk)](https://github.com/GameFrameX/com.gameframex.unity.gameanalytics.talkingdata.sdk/releases)
  [![License](https://img.shields.io/badge/license-MIT-orange.svg)](LICENSE.md)
  [![Documentation](https://img.shields.io/badge/docs-gameframex-blue.svg)](https://gameframex.doc.alianblank.com)

  All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams

  [Documentation](https://gameframex.doc.alianblank.com) | [Quick Start](#quick-start)

  **English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)
</div>

---

## Project Overview

TalkingData Unity SDK consists of a `wrapper layer` and `Native SDK`. The wrapper layer code is available on GitHub, while the latest Android and iOS Native SDKs need to be downloaded from the [TalkingData website](https://www.talkingdata.com/spa/sdk/#/universal?sdkPlatform=Unity).

## Integration Guide

1. Download this project (wrapper layer) locally
2. Visit the [TalkingData website](https://www.talkingdata.com/spa/sdk/#/universal?sdkPlatform=Unity) to download the latest Android and iOS TalkingData SDK (Native SDK)
    - Option 1: Select Unity platform for feature customization
    - Option 2: Select Android and iOS platforms separately for feature customization, ensure both platforms have the same features
3. Copy the latest `Native SDK` into the `wrapper layer` to form the complete Unity SDK
    - Android: Copy the latest `.jar` file to `Assets/Plugins/Android` directory
    - iOS: Copy the latest `.h` and `.a` files to `Assets/Plugins/iOS` directory
4. Modify the `wrapper layer` code as needed based on Native SDK feature options (see Notes section)
5. Integrate the Unity SDK into your project and configure it according to the [integration documentation](http://doc.talkingdata.com/posts/1026)

## Android Permissions

Android SDK requires the following permissions in AndroidManifest.xml:

| Permission | Purpose |
|---|---|
| INTERNET | Allow network access for sending analytics data |
| ACCESS_NETWORK_STATE | Detect network status to avoid sending data when offline |
| READ_PHONE_STATE | Access device info for unique user identification |
| ACCESS_WIFI_STATE | Get device MAC address for user identification |
| WRITE_EXTERNAL_STORAGE | Save device info and logs |
| ACCESS_FINE_LOCATION (Optional) | Get GPS location to improve regional data accuracy |
| ACCESS_COARSE_LOCATION (Optional) | Get approximate location info |

## iOS Dependencies

iOS SDK requires the following frameworks in the generated Xcode project:

| Framework | Purpose |
|---|---|
| AdServices.framework | Apple Search Ads attribution |
| StoreKit.framework | Apple SKAdNetwork attribution conversion |
| AppTrackingTransparency.framework | Get app tracking authorization status |
| AdSupport.framework | Get advertisingIdentifier |
| CoreTelephony.framework | Get carrier identifier |
| Security.framework | Assist with device identifier storage |
| SystemConfiguration.framework | Detect network status |
| libc++.tbd | Support C++11 standard |
| libz.tbd | Data compression |

For iOS 12.0+, add the Access WiFi Information capability: Select Target, click +Capability, and double-click Access WiFi Information.

For iOS 14.0+, user authorization is required to get IDFA: Add Privacy - Tracking Usage Description Key in Info.plist with Type String and your description text as Value.

## Notes

1. When selecting features for Android and iOS separately, ensure both platforms have the same features.
2. If optional features were selected when requesting the Native SDK, enable the corresponding wrapper layer code:
   a) Uncomment the macro definitions for selected industry or features in `Assets/Plugins/iOS/TalkingDataSDK.mm`
   b) Add macro definitions in Unity: Open `Build Settings`, select platform, click `Switch Platform`, then in `Player Settings` > `Other Settings` > `Scripting Define Symbols`, enter the macros (separate with semicolons; add separately for Android and iOS)

| Industry & Feature | Macro |
|---|---|
| E-commerce Retail | TD_RETAIL |
| Gaming & Entertainment | TD_GAME |
| Financial Lending | TD_FINANCE |
| Travel | TD_TOUR |
| Online Education | TD_ONLINEEDU |
| Novel Reading | TD_READING |
| Other Industries | TD_OTHER |

## Changelog

See [CHANGELOG.md](CHANGELOG.md) for details.

## License

This project is licensed under the MIT License - see [LICENSE.md](LICENSE.md) for details.
