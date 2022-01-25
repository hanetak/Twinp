using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _textGameover = null;
    [SerializeField] GameObject _playerChara = null;

    private GameObject _startObj = null;

    [SerializeField] Vector2 _playerPos = new Vector2(0.05f,0.63f);

    // Start is called before the first frame update
    void Start()
    {
        _textGameover.SetActive(false);
        _startObj = GameObject.FindGameObjectWithTag("Start");
        Grobal.SetRespawn(_startObj.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
