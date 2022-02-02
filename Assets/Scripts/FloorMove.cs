using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : Token
{

    public float _Xstart;
    public float _Xend;
    public float _Ystart;
    public float _Yend;

    public float _moveSpd;

    public bool _isMoveX = false;
    public bool _isMoveXRight;
    public bool _isMoveY = false;
    public bool _isMoveYUp;
    private float _Xpos;
    private float _Ypos;

    //移動量を保存する
    private float _moveXdistance;
    private float _moveYdistance;

    private Vector2 _moveDistance;

    float _xprevious = 0;
    float _yprevious = 0;
    private Rigidbody2D _rigitBody2D;

    //プレイヤーの参照
    Player _target = null;

    void Start(){
        _rigitBody2D = this.GetComponent<Rigidbody2D> ();
        //開始時の動き
        if(_isMoveX){
            if(_isMoveXRight){
                SetVelocityXY(_moveSpd, 0);
            }else{
                SetVelocityXY(-_moveSpd, 0);
            }
        }
        if(_isMoveY){
            if(_isMoveYUp){
                SetVelocityXY(0,_moveSpd);
            }else{
                SetVelocityXY(0,-_moveSpd);
            }
        }

        //初期座標を保持
        _xprevious = X;
        _yprevious = Y;
    }

    void Update()
    {
        if (_target != null)
        {
            if (_target._isJump)
            {
                Debug.Log("ターゲットから離れた");
                _target = null;
            }
        }
        Vector2 pos = this.gameObject.transform.position; 
         //前回の座標から差分を求める
        float dx = X - _xprevious;
        float dy = Y - _yprevious;
        if(_target != null)
        {
            //上にターゲットが乗っていたら動かす
            _target.X += dx;
            _target.Y += dy;
        }
        //げんざいの座標を次のように保存
        _xprevious = X;
        _yprevious = Y;
        if(_isMoveX)
        {
            //右向きかつ始点よりも大きい場合
            if(pos.x >= _Xstart && _isMoveXRight)
            {
                //終点よりも座標が大きくなったら切り替える
                if(pos.x > _Xend)
                {
                    _isMoveXRight = false;
                    SetVelocityXY(-_moveSpd, 0);
                }
            }
            //左向きかつ終点よりも小さい場合
            if(pos.x <= _Xend && !_isMoveXRight)
            {

                //始点よりも座標が小さくなったら切り替える
                if(pos.x < _Xstart)
                {
                    _isMoveXRight = true;
                    SetVelocityXY(_moveSpd, 0);
                }
            }
        }
        if(_isMoveY)
        {
            //上向き
            if(pos.y >= _Ystart && _isMoveYUp)
            {
                //終点よりも座標が大きくなったら切り替える
                if(pos.y > _Yend)
                {
                    _isMoveYUp = false;
                    SetVelocityXY(0, -_moveSpd);
                }
            }
            //下向き
            if(pos.y <= _Yend && !_isMoveYUp)
            {

                //始点よりも座標が小さくなったら切り替える
                if(pos.y < _Ystart)
                {
                    _isMoveYUp = true;
                    SetVelocityXY(0, _moveSpd);
                }
            }
        }
        this.transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        string name = LayerMask.LayerToName(other.gameObject.layer);

        if(name == "Player")
        {
            //プレイヤーに当たったので参照を保持
            _target = other.gameObject.GetComponent<Player>();
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        string name = LayerMask.LayerToName(other.gameObject.layer);
        if(name == "Player")
        {
            //プレイヤーがいなくなったので参照を消す
            _target = null;
        }
    }
}
