using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSin : MonoBehaviour
{
    Vector2 pos;
    [SerializeField] float _spd;
    [SerializeField] float _radius;

    Vector2 _origin;

    float x;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        _origin = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x = _radius * Mathf.Sin(Time.time * _spd);      //X軸の設定
        y = _radius * Mathf.Cos(Time.time * _spd);      //Z軸の設定

        transform.position = new Vector2(x+_origin.x,y + _origin.y);  //自分     
    }
}
