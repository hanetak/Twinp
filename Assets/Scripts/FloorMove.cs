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

    void Update()
    {
        if(_isMoveX)
        {
            //始点よりも大きい場合
            if(this.gameObject.transform.position.x > _Xstart){

            }
        }
    }
}
