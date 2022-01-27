using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float _spd;
    Rigidbody2D rb;

    Vector2 _force;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        _force = new Vector2(-_spd,0f);
        rb.AddForce(_force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
