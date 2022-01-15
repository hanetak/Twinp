using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //壁オブジェクト管理生成
        Wall.parent = new TokenMgr<Wall>("Wall", 128);
        FloorMove.parent = new TokenMgr<FloorMove>("FloorMove", 32);
        //マップデータの読み込み
        FieldMgr field = new FieldMgr();
        field.Load(1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
