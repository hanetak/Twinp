using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : Token
{

    [SerializeField] float _Xstart;
    [SerializeField] float _Xend;
    [SerializeField] float _Ystart;
    [SerializeField] float _Yend;

    [SerializeField] float _moveSpd;

    [SerializeField] bool _isMoveX;
    [SerializeField] bool _isMoveXRight;
    [SerializeField] bool _isMoveY;
    [SerializeField] bool _isMoveYUp;
    private float _Xpos;
    private float _Ypos;

    //移動量を保存する
    private float _moveXdistance;
    private float _moveYdistance;

    private Vector2 _moveDistance;

    float _xprevious = 0;

    private Rigidbody2D _rigitBody2D;

    //プレイヤーの参照
    Player _target = null;

    void Start(){
        _rigitBody2D = this.GetComponent<Rigidbody2D> ();
        //開始時は右に進むようにする
        SetVelocityXY(_moveSpd, 0);

        //初期座標を保持
        _xprevious = X;
    }

    void Update()
    {
        Vector2 pos = this.gameObject.transform.position; 
         //前回の座標から差分を求める
        float dx = X - _xprevious;
        if(_target != null)
        {
            //上にターゲットが乗っていたら動かす
            _target.X += dx;
        }
        //げんざいの座標を次のように保存
        _xprevious = X;
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
        this.transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        string name = LayerMask.LayerToName(other.gameObject.layer);
        if (name == "Ground")
        {
            if(X != _xprevious)
            {
                //ほかの壁、床と当たったら反転
                VX *= -1;
                //X座標を一フレーム前のX座標に戻す
                X = _xprevious;
  
            }

        }
        else if(name == "Player")
        {
            //プレイヤーに当たったので参照を保持
            _target = other.gameObject.GetComponent<Player>();
        }
    }
    private void OnCollisionExit2D(Collision2D otehr)
    {
        string name = LayerMask.LayerToName(otehr.gameObject.layer);
        if(name == "Player")
        {
            //プレイヤーがいなくなったので参照を消す
            _target = null;
        }
    }
}
