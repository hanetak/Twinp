using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Token
{
    private AudioSource audioSource;
    //パーティクル
    [SerializeField] GameObject Particle;

    //ジャンプ音
    [SerializeField] AudioClip _jumpAudio;

    //ゲームオーバーテキスト
    [SerializeField] GameObject _textGameover = null;


    //左を向いているかどうか
    bool _bFacingLeft = false;

    //ゲームクリアテキスト
    [SerializeField] GameObject _textGameclear;

    //状態
    enum eState
    {
        Idle,
        Run,
        Jump,
    }
    //状態
    eState _state = eState.Idle;
    //アニメーションタイマー
    int _tAnim = 0;


    //各種スプライト
    [SerializeField] Sprite Sprite0;
    [SerializeField] Sprite Sprite1;
    [SerializeField] Sprite Sprite2;
    [SerializeField] Sprite Sprite3;

    [SerializeField] Sprite SpriteNull;
   //カメラ消す
    GameObject _camera;


    //反転させる
    bool _isR = true;
    public bool isReverse()
    {
        return _isR;
    }

    void Start()
    {
        _textGameclear.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        _camera = GameObject.FindGameObjectWithTag("MainCamera");

    }
    //固定フレームで更新
    private void FixedUpdate()
    {
        if (this.gameObject.transform.position.x < _camera.transform.position.x - 10f)
        {
            GameOver();
            this.gameObject.transform.position = _camera.transform.position;
        }
        if (!_isLocked)
        {
            //左右の向きを切り替える
            if (_bFacingLeft)
            {
                //左向き
                ScaleX = -1.0f;
            }
            else
            {
                ScaleX = 1.0f;
            }
            //アニメーションタイマーを更新
            _tAnim++;
            //状態更新
            if (_bGround == false)
            {
                //ジャンプ状態
                _state = eState.Jump;
            }
            else if (Mathf.Abs(VX) >= 1.0f)
            {
                //移動しているので走り状態
                _state = eState.Run;
            }
            else
            {
                //待機状態
                _state = eState.Idle;
            }

            //アニメーション更新
            switch (_state)
            {
                case eState.Idle:
                    if (_tAnim % 100 < 10)
                    {
                        //たまに瞬きする
                        SetSprite(Sprite1);
                    }
                    else
                    {
                        SetSprite(Sprite0);
                    }
                    break;
                case eState.Run:
                    if (_tAnim % 12 < 6)
                    {
                        SetSprite(Sprite2);
                    }
                    else
                    {
                        SetSprite(Sprite3);
                    }
                    break;

                case eState.Jump:
                    //ジャンプ中
                    SetSprite(Sprite2);
                    break;
            }
        }

    }
    //走る速さ
    [SerializeField]
    float _RunSpeed = 2;

    //ジャンプの力
    [SerializeField]
    float _JumpSpeed = 4;

    //残りジャンプ回数
    [SerializeField]
    int _JumpCount = 2;

    //地面に着地しているかどうか
    bool _bGround = false;

    bool _isLocked = false;
    [SerializeField]float _timer;
    [SerializeField] GameObject s;

    [SerializeField]float _scoreIndex;

    public bool _isJump;


    void Update()
    {
        if (!_isLocked)
        {
            if (this.gameObject.transform.position.y < -5.5f)
            {
                GameOver();
            }

            //スコアを加算する
            Grobal.ScoreAdd((int)(Time.deltaTime * _scoreIndex));
            //左右キーで移動する
            Vector2 v = Util.GetInputVector();
            VX = v.x * _RunSpeed;

            //向いている方向チェック
            if (VX <= -1.0f)
            {
                //左を向く
                _bFacingLeft = true;
            }
            if (VX >= 1.0f)
            {
                //右を向く
                _bFacingLeft = false;
            }

            _bGround = CheckGround();
            //ジャンプ判定
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // ジャンプする
                if (_JumpCount > 1)
                {
                    _isJump = true;
                    audioSource.PlayOneShot(_jumpAudio);

                    _isR = !_isR;
                    VY = _JumpSpeed; ;

                    _JumpCount--;
                }
            }
            //ジャンプ回数をリセット
            if (_bGround)
            {
                _JumpCount = 2;
            }

        }
        else
        {
            //R押したらプレイヤーを戻す+テキストを消す
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("stage1");
                _textGameover.SetActive(false);
                SetSprite(Sprite0);
                this.gameObject.transform.position = Grobal.RetryPos;
                SceneManager.UnloadSceneAsync(3);
                _isLocked = false;
            }
        }
        _timer -= Time.deltaTime;
        /*if(isJump && _timer < 0){
           Debug.Log(this.gameObject.transform.position);
           Instantiate(s,this.gameObject.transform.position,Quaternion.identity);
           _timer = 0.1f;
        }*/
    }

    //地面に着地しているかどうか
    bool CheckGround()
    {
        //Groundグループのみチェックする
        int mask = 1 << LayerMask.NameToLayer("Ground");
        //キャラクタの半分よりちょっと下までレイを飛ばす
        float distance = SpriteHeight * 0.7f;
        float width = BoxColliderWidth * 1.1f;
        float[] xList = { X - width, X, X + width };
        foreach (float px in xList)
        {
            //チェック実行
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(px, Y), -Vector2.up, distance, mask);
            if (hit.collider != null && hit.collider.gameObject.GetComponent<Reverse>().isActive)
            {
                //着地できた
                _isJump = false;
                return true;
            }
        }
        return false;
    }

    //衝突判定
    void OnTriggerEnter2D(Collider2D col)
    {
        //ゴール判定
        if (col.gameObject.tag == "Goal")
        {
            _textGameclear.SetActive(true);
        }
        //中間設定
        if (col.gameObject.tag == "Respawn")
        {
            Grobal.SetRespawn(col.gameObject.transform.position);
        }


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //障害物判定（即死）
        if (col.gameObject.tag == "Obstacle")
        {
            GameOver();
        }
    }

    //ゲームオーバー字処理
    void GameOver()
    {
        _isLocked = true;
        SetSprite(null);
        this.RigidBody.velocity = Vector3.zero;
        _textGameover.SetActive(true);
        GameObject.Instantiate<GameObject>(Particle, this.gameObject.transform.position, Quaternion.identity);
        _camera.GetComponent<CameraMover>().spd = 0;
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(Grobal.Score);
    }


}