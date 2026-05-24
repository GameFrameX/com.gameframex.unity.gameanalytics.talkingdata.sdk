<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="GameFrameX Logo" width="160" />

  # GameFrameX GameAnalytics TalkingData SDK

  [![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.gameanalytics.talkingdata.sdk)](https://github.com/GameFrameX/com.gameframex.unity.gameanalytics.talkingdata.sdk/releases)
  [![License](https://img.shields.io/badge/license-MIT-orange.svg)](LICENSE.md)
  [![Documentation](https://img.shields.io/badge/docs-gameframex-blue.svg)](https://gameframex.doc.alianblank.com)

  インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援

  [ドキュメント](https://gameframex.doc.alianblank.com) | [クイックスタート](#クイックスタート)

  [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)
</div>

---

## プロジェクト概要

TalkingData Unity SDK は `ラッパー層` と `Native SDK` の2つの部分で構成されています。GitHub ではラッパー層のコードが提供されており、最新の Android および iOS 向け Native SDK は [TalkingDataウェブサイト](https://www.talkingdata.com/spa/sdk/#/universal?sdkPlatform=Unity) からダウンロードする必要があります。

## 統合ガイド

1. このプロジェクト（ラッパー層）をローカルにダウンロード
2. [TalkingDataウェブサイト](https://www.talkingdata.com/spa/sdk/#/universal?sdkPlatform=Unity) から最新の Android および iOS TalkingData SDK (Native SDK) をダウンロード
    - 方法1：Unityプラットフォームを選択して機能カスタマイズ
    - 方法2：Android と iOS プラットフォームを個別に選択して機能カスタマイズ（両プラットフォームで同じ機能を確保）
3. 最新の `Native SDK` を `ラッパー層` にコピーして完全な Unity SDK を構成
    - Android：最新の `.jar` ファイルを `Assets/Plugins/Android` ディレクトリにコピー
    - iOS：最新の `.h` と `.a` ファイルを `Assets/Plugins/iOS` ディレクトリにコピー
4. Native SDK の機能オプションに基づいてラッパー層コードを必要に応じて修正（注意事項の第2項を参照）
5. Unity SDK をプロジェクトに統合し、[統合ドキュメント](http://doc.talkingdata.com/posts/1026) に従って設定と機能呼び出しを行う

## Android 権限

Android SDK は AndroidManifest.xml に以下の権限が必要です：

| 権限 | 目的 |
|---|---|
| INTERNET | ネットワークアクセスとアナリティクスデータ送信 |
| ACCESS_NETWORK_STATE | ネットワークステータス検知、オフライン時のデータ送信回避 |
| READ_PHONE_STATE | デバイス情報アクセスによるユーザー一意識別 |
| ACCESS_WIFI_STATE | デバイスMACアドレスによるユーザー識別 |
| WRITE_EXTERNAL_STORAGE | デバイス情報とログの保存 |
| ACCESS_FINE_LOCATION（オプション） | GPS位置情報による地域データ精度向上 |
| ACCESS_COARSE_LOCATION（オプション） | 概略位置情報の取得 |

## iOS 依存フレームワーク

iOS SDK は生成された Xcode プロジェクトに以下のフレームワークが必要です：

| フレームワーク | 目的 |
|---|---|
| AdServices.framework | Apple Search Ads アトリビューション |
| StoreKit.framework | Apple SKAdNetwork アトリビューション変換 |
| AppTrackingTransparency.framework | アプトラッキング認証ステータスの取得 |
| AdSupport.framework | advertisingIdentifier の取得 |
| CoreTelephony.framework | キャリア識別子の取得 |
| Security.framework | デバイス識別子ストレージの補助 |
| SystemConfiguration.framework | ネットワークステータス検知 |
| libc++.tbd | C++11標準サポート |
| libz.tbd | データ圧縮 |

iOS 12.0 以降でWiFi情報を取得するには、Access WiFi Informationオプションを追加：ターゲットを選択し、+Capability をクリックし、Access WiFi Information をダブルクリックして追加。

iOS 14.0 以降でIDFAを取得するにはユーザー認証が必要：Info.plist に Privacy - Tracking Usage Description Key を追加（Type: String、Value: 説明文）。

## 注意事項

1. Android と iOS プラットフォームを個別に機能カスタマイズする場合、両プラットフォームで同じ機能を確保してください。
2. Native SDK リクエスト時にオプション機能を選択した場合、対応するラッパー層コードを有効にする必要があります：
   a) `Assets/Plugins/iOS/TalkingDataSDK.mm` ファイルで選択した業界または機能のマクロ定義をコメント解除
   b) Unity でマクロ定義を追加：`Build Settings` を開き、プラットフォームを選択して `Switch Platform` をクリック。その後 `Player Settings` > `Other Settings` > `Scripting Define Symbols` にマクロを入力（セミコロンで区切り、Android と iOS は個別に追加）

| 業界＆機能 | マクロ |
|---|---|
| Eコマース小売 | TD_RETAIL |
| ゲームエンターテインメント | TD_GAME |
| 金融ローン | TD_FINANCE |
| 旅行 | TD_TOUR |
| オンライン教育 | TD_ONLINEEDU |
| 小説読書 | TD_READING |
| その他の業界 | TD_OTHER |

## 変更履歴

詳細は [CHANGELOG.md](CHANGELOG.md) をご覧ください。

## ライセンス

このプロジェクトは MIT ライセンスの下で公開されています。詳細は [LICENSE.md](LICENSE.md) をご覧ください。
