using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurrentDevicePlatform
{
    public static DevicePlatforms Get()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer && Application.isMobilePlatform)
        {
            return DevicePlatforms.Android;
        }

#if UNITY_ANDROID && !UNITY_EDITOR
        return DevicePlatforms.Android;
#elif UNITY_STANDALONE && !UNITY_EDITOR
        return DevicePlatforms.Windows;
#else
        return DevicePlatforms.Windows;
#endif
    }
}
