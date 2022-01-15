using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : Token
{
    public static TokenMgr<FloorMove> parent = null;
    public static FloorMove Add(float x , float y){
        FloorMove floor = parent.Add(x,y);
        //初期化
        floor.Init();
        return floor;
    }
    //前回の更新時のX座標
    float _xprevious = 0;
    // プレイヤーの参照
    Player _target = null;
    //開始の移動速度
    public float StartSpeed = 0.5f;
    // Start is called before the first frame update
    public void Init()
    {
        //開始時は右に進む
        SetVelocityXY(StartSpeed,0);

        //初期座標を保持
        _xprevious = X;
    }

    // Update is called once per frame
    void Update()
    {
        //前回の座標からの差分を求める
        float dx = X - _xprevious;
        if(_target != null){
            _target.X += dx;
        }
        //現在の座標を次に使うように保存
        _xprevious = X;
        
    }

    //消滅
    public override void Vanish(){
        _target = null;
        base.Vanish();
    }

    //トリガーイベント検出
    private void OnTriggerEnter2D(Collider2D other)
    {
        string name = LayerMask.LayerToName(other.gameObject.layer);
        if(name == "Ground"){
            if (X != _xprevious)
            {
                //他の壁・床と当たったら反転
                VX *= -1;
                X = _xprevious;
            }
        }
        else if(name == "Player"){
            _target = other.gameObject.GetComponent<Player>();
        }
    }

    //トリガーイベントから離脱
    private void OnTriggerExit2D(Collider2D other) {
        string name = LayerMask.LayerToName(other.gameObject.layer);
        if(name == "Player"){
            //プレイヤーがいなくなったので参照を消す
            _target = null;
        }
    }
}
