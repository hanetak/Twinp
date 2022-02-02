using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TestInitialize
{
// 属性の設定
[RuntimeInitializeOnLoadMethod]
static void OnRuntimeMethodLoad() {
// スクリーンサイズの指定
Screen.SetResolution(1920, 1080, false);
}
}
