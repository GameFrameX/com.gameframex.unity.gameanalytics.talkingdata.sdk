using UnityEngine;


public class TalkingDataSDKConfig
{
    public AndroidJavaObject javaObj;

    public static TalkingDataSDKConfig CreateConfig()
    {
        var config = new TalkingDataSDKConfig();
#if UNITY_ANDROID || !UNITY_EDITOR
        config.javaObj = new AndroidJavaObject("com.tendcloud.tenddata.TalkingDataSDKConfig");
#endif
        return config;
    }

    /// <summary>
    /// 是否 允许收集IMEI和MEID
    /// </summary>
    /// <param name="enabled"></param>
    /// <returns></returns>
    public TalkingDataSDKConfig SetIMEIAndMEIDEnabled(bool enabled)
    {
#if UNITY_ANDROID || !UNITY_EDITOR
        javaObj.Call<AndroidJavaObject>("setIMEIAndMEIDEnabled", enabled);
#endif
        return this;
    }

    /// <summary>
    /// 是否 允许收集MAC
    /// </summary>
    /// <param name="enabled"></param>
    /// <returns></returns>
    public TalkingDataSDKConfig SetMACEnabled(bool enabled)
    {
#if UNITY_ANDROID || !UNITY_EDITOR
        javaObj.Call<AndroidJavaObject>("setMACEnabled", enabled);
#endif
        return this;
    }

    /// <summary>
    /// 是否 允许收集应用列表
    /// </summary>
    /// <param name="enabled"></param>
    /// <returns></returns>
    public TalkingDataSDKConfig SetAppListEnabled(bool enabled)
    {
#if UNITY_ANDROID || !UNITY_EDITOR
        javaObj.Call<AndroidJavaObject>("setAppListEnabled", enabled);
#endif
        return this;
    }

    /// <summary>
    /// 是否 允许收集位置信息
    /// </summary>
    /// <param name="enabled"></param>
    /// <returns></returns>
    public TalkingDataSDKConfig SetLocationEnabled(bool enabled)
    {
#if UNITY_ANDROID || !UNITY_EDITOR
        javaObj.Call<AndroidJavaObject>("setLocationEnabled", enabled);
#endif
        return this;
    }

    /// <summary>
    /// 是否 允许收集网络信息
    /// </summary>
    /// <param name="enabled"></param>
    /// <returns></returns>
    public TalkingDataSDKConfig SetWifiEnabled(bool enabled)
    {
#if UNITY_ANDROID || !UNITY_EDITOR
        javaObj.Call<AndroidJavaObject>("setWifiEnabled", enabled);
#endif
        return this;
    }
}