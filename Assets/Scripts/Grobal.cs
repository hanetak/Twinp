﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grobal
{
    //初期化
    public static void Init()
    {
        _retryPos = new Vector2(0,0);
        _playerLife = 3;
    }
    //リトライする位置
    static Vector2 _retryPos;
    public static Vector2 RetryPos{
        get{return _retryPos; }
    }

    //残基
    static int _playerLife;
    public static int PlayerRife{
        get{return _playerLife; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
