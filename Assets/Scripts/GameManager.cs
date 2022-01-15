﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject _textGameover = null;
    public GameObject _playerChara = null;

    // Start is called before the first frame update
    void Start()
    {
        _textGameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerChara.transform.position.y < -5.5f){
            _textGameover.SetActive(true);
        }
    }
}