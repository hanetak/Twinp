using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    GameObject _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.x < _camera.transform.position.x - 15f)
        {
            Destroy(this.gameObject);
        }
        
    }
}
