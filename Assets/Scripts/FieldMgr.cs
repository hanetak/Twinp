using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMgr
{
    //壁
    const int CHIP_WALl = 2;
    //移動床
    const int CHIP_FLOOR_MOVE = 4;

    //チップx座標から、ワールドX座標を取得する
    float GetChipX(int i)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        var spr = Util.GetSprite("Levels/tileset", "tileset_0");
        var sprW = spr.bounds.size.x;
        return min.x + (sprW * i) + sprW / 2;
    }
    float GetChipY(int j)
    {
        Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);
        var spr = Util.GetSprite("Levels/tileset", "tileset_0");
        var sprH = spr.bounds.size.y;
        return max.y - (sprH * j) + sprH / 2;
    }

    //ロード開始
    public void Load(int stage)
    {
        TMXLoader tmx = new TMXLoader();
        //ファイルパスを作成
        string path = string.Format("Levels/{0:D3}", stage);
        tmx.Load(path);
        //0番目のレイヤーを取得する
        Layer2D layer = tmx.GetLayer(0);

        //タイルの配置
        for (int j = 0; j < layer.Height; j++)
        {
            for (int i = 0; i < layer.Width; i++)
            {
                //座標を指定してレイヤーの値を取得
                int v = layer.Get(i, j);
                float x = GetChipX(i);
                float y = GetChipY(j);
                switch (v)
                {
                    case CHIP_WALl:
                        //壁を作成
                        Wall.Add(x, y);
                        break;
                    case CHIP_FLOOR_MOVE:
                        FloorMove.Add(x,y);
                        break;
                }
            }
        }
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
