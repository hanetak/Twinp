using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float spd;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pos.x = pos.x + Time.deltaTime * spd;
        this.gameObject.transform.position = pos;
    }
}
