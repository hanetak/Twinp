using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Token
{
    public static TokenMgr<Wall> parent = null;

    //壁を作る
    public static Wall Add(float x, float y)
    {
        Wall w = parent.Add(x, y);
        return w;
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
