<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="GameFrameX Logo" width="160" />

  # GameFrameX GameAnalytics TalkingData SDK

  [![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.gameanalytics.talkingdata.sdk)](https://github.com/GameFrameX/com.gameframex.unity.gameanalytics.talkingdata.sdk/releases)
  [![License](https://img.shields.io/badge/license-MIT-orange.svg)](LICENSE.md)
  [![Documentation](https://img.shields.io/badge/docs-gameframex-blue.svg)](https://gameframex.doc.alianblank.com)

  인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현

  [문서](https://gameframex.doc.alianblank.com) | [빠른 시작](#빠른-시작)

  [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**
</div>

---

## 프로젝트 개요

TalkingData Unity SDK는 `래퍼 레이어`와 `Native SDK` 두 부분으로 구성됩니다. GitHub에서는 래퍼 레이어 코드를 제공하며, 최신 Android 및 iOS Native SDK는 [TalkingData 웹사이트](https://www.talkingdata.com/spa/sdk/#/universal?sdkPlatform=Unity)에서 다운로드해야 합니다.

## 통합 가이드

1. 이 프로젝트(래퍼 레이어)를 로컬에 다운로드
2. [TalkingData 웹사이트](https://www.talkingdata.com/spa/sdk/#/universal?sdkPlatform=Unity)에서 최신 Android 및 iOS TalkingData SDK (Native SDK) 다운로드
    - 방법 1: Unity 플랫폼을 선택하여 기능 맞춤 설정
    - 방법 2: Android와 iOS 플랫폼을 개별적으로 선택하여 기능 맞춤 설정 (두 플랫폼의 기능이 동일해야 함)
3. 최신 `Native SDK`를 `래퍼 레이어`에 복사하여 완전한 Unity SDK 구성
    - Android: 최신 `.jar` 파일을 `Assets/Plugins/Android` 디렉토리에 복사
    - iOS: 최신 `.h` 및 `.a` 파일을 `Assets/Plugins/iOS` 디렉토리에 복사
4. Native SDK 기능 옵션에 따라 래퍼 레이어 코드를 필요에 따라 수정 (주의사항 제2항 참조)
5. Unity SDK를 프로젝트에 통합하고 [통합 문서](http://doc.talkingdata.com/posts/1026)에 따라 설정 및 기능 호출

## Android 권한

Android SDK는 AndroidManifest.xml에 다음 권한이 필요합니다:

| 권한 | 목적 |
|---|---|
| INTERNET | 네트워크 접근 및 분석 데이터 전송 |
| ACCESS_NETWORK_STATE | 네트워크 상태 감지, 오프라인 시 데이터 전송 방지 |
| READ_PHONE_STATE | 기기 정보 접근을 통한 고유 사용자 식별 |
| ACCESS_WIFI_STATE | 기기 MAC 주소를 통한 사용자 식별 |
| WRITE_EXTERNAL_STORAGE | 기기 정보 및 로그 저장 |
| ACCESS_FINE_LOCATION (선택) | GPS 위치 정보로 지역 데이터 정확도 향상 |
| ACCESS_COARSE_LOCATION (선택) | 대략적인 위치 정보 획득 |

## iOS 종속 프레임워크

iOS SDK는 생성된 Xcode 프로젝트에 다음 프레임워크가 필요합니다:

| 프레임워크 | 목적 |
|---|---|
| AdServices.framework | Apple Search Ads 어트리뷰션 |
| StoreKit.framework | Apple SKAdNetwork 어트리뷰션 전환 |
| AppTrackingTransparency.framework | 앱 추적 인증 상태 획득 |
| AdSupport.framework | advertisingIdentifier 획득 |
| CoreTelephony.framework | 통신사 식별자 획득 |
| Security.framework | 기기 식별자 저장 보조 |
| SystemConfiguration.framework | 네트워크 상태 감지 |
| libc++.tbd | C++11 표준 지원 |
| libz.tbd | 데이터 압축 |

iOS 12.0 이상에서 WiFi 정보를 가져오려면 Access WiFi Information 옵션 추가: 대상 Target을 선택하고 +Capability를 클릭한 후 Access WiFi Information을 더블클릭하여 추가.

iOS 14.0 이상에서 IDFA를 가져오려면 사용자 인증이 필요: Info.plist에 Privacy - Tracking Usage Description Key를 추가 (Type: String, Value: 설명 문구).

## 주의사항

1. Android와 iOS 플랫폼을 개별적으로 기능 맞춤 설정할 때 두 플랫폼의 기능이 동일한지 확인하세요.
2. Native SDK 요청 시 선택 기능을 선택한 경우 해당 래퍼 레이어 코드를 활성화해야 합니다:
   a) `Assets/Plugins/iOS/TalkingDataSDK.mm` 파일에서 선택한 산업 또는 기능의 매크로 정의 주석 해제
   b) Unity에서 매크로 정의 추가: `Build Settings` 열기, 플랫폼 선택 후 `Switch Platform` 클릭. 그런 다음 `Player Settings` > `Other Settings` > `Scripting Define Symbols`에 매크로 입력 (세미콜론으로 구분, Android와 iOS는 개별적으로 추가)

| 산업 & 기능 | 매크로 |
|---|---|
| 이커머스 소매 | TD_RETAIL |
| 게임 엔터테인먼트 | TD_GAME |
| 금융 대출 | TD_FINANCE |
| 여행 | TD_TOUR |
| 온라인 교육 | TD_ONLINEEDU |
| 소설 독서 | TD_READING |
| 기타 산업 | TD_OTHER |

## 변경 로그

자세한 내용은 [CHANGELOG.md](CHANGELOG.md)를 참조하세요.

## 라이선스

이 프로젝트는 MIT 라이선스에 따라 배포됩니다. 자세한 내용은 [LICENSE.md](LICENSE.md)를 참조하세요.
