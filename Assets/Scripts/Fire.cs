using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 _pos;

    Vector2 _force;
    [SerializeField] float _spd;
    [SerializeField] float _posY;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        _force = new Vector2(0f,_spd);
        rb.AddForce(_force);
    }

    float _time;

    bool _isrun;
    // Update is called once per frame
    void Update()
    {
        _pos = this.gameObject.transform.position;
        if(_pos.y < _posY && rb.velocity.y < 0)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(_force);
        }
    }
}
