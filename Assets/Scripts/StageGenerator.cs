using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] grounds;
    [SerializeField] GameObject[] obstacles;

    [SerializeField] GameObject _camera;
    Vector2 pos;
    float genRange;
    // Start is called before the first frame update
    void Start()
    {
        GenerateLv1(0f,30,31,32);
        GenerateLv1(20f,20,21,22);
        genRange = 20;
    }


    //補助足場用
    [SerializeField]float _floorMoveTime;
    float _floorMoveTimer;
    [SerializeField]int _floorMoveDice;
    // Update is called once per frame
    void Update()
    {
        _floorMoveTimer -= Time.deltaTime;
        pos = _camera.transform.position;
        if (genRange - pos.x< 0)
        {
            GenerateLv1(pos.x + 20f,15,16,17);
            genRange += 20;
        }
        if (_floorMoveTimer < 0)
        {
            int index = Random.Range( 1, 101);
            if(index < _floorMoveDice){
                    float x = pos.x + 20f ;
                    float y = Random.Range(0f,-4f);
                    int isAct = Random.Range(0,2);
                    GameObject newObject = GameObject.Instantiate<GameObject>(grounds[2]);
                    newObject.transform.position = new Vector3(x,y,this.transform.position.z);
                    newObject.GetComponent<Reverse>().isActive = isAct == 1 ? true : false;
                    FloorMove floorMove =  newObject.GetComponent<FloorMove>();
                    floorMove._isMoveX = true;
                    floorMove._isMoveXRight = true;
                    floorMove._Xend = x;
                    floorMove._Xstart = -20;
                    floorMove._moveSpd = Random.Range(0.1f,4.0f);
            }
            _floorMoveTimer = _floorMoveTime;
        }
    }

    void GenerateLv1(float posx,int index1,int index2,int index3){
        float minx;
        float miny;
        
        for (int i = 0; i < 20; i++) {
            for(int j = 0;j < 8; j++)
            {
                //とりあえず存在率二割
                int index = Random.Range(1, 101);
                if(index < index1){
                    //通常のブロック
                    float x = posx + (float)i + Random.Range(-0.25f,0.25f);
                    float y = (float)j - 4 + Random.Range(-0.25f,0.25f);
                    int isAct = Random.Range(0,2);
                    GameObject newObject = GameObject.Instantiate<GameObject>(grounds[1]);
                    newObject.transform.position = new Vector3(x,y,this.transform.position.z);
                    newObject.GetComponent<Reverse>().isActive = isAct == 1 ? true : false;
                }else if(index == index2)
                {
                    //上下に動くブロック
                    float x = posx + (float)i + Random.Range(-0.25f,0.25f);
                    float y = (float)j - 4 + Random.Range(-0.25f,0.25f);
                    int isAct = Random.Range(0,2);
                    GameObject newObject = GameObject.Instantiate<GameObject>(grounds[2]);
                    newObject.transform.position = new Vector3(x,y,this.transform.position.z);
                    newObject.GetComponent<Reverse>().isActive = isAct == 1 ? true : false;
                    FloorMove floorMove =  newObject.GetComponent<FloorMove>();
                    floorMove._isMoveY = true;
                    int isUp = Random.Range(0,2);
                    floorMove._isMoveYUp = isUp == 1 ? true : false;
                    float y1 = Random.Range(-5f,4f);
                    float y2 = Random.Range(-5f,4f);
                    floorMove._Yend = Mathf.Max(y1,y2);
                    floorMove._Ystart = Mathf.Min(y1,y2);
                    if (Mathf.Abs(Mathf.Abs(y1) - Mathf.Abs(y2)) < 1)
                    {
                        floorMove._Yend += 0.5f;
                        floorMove._Ystart -= 0.5f;
                    }
                    floorMove._moveSpd = Random.Range(0.1f,4.0f);
                }
                else if(index == index3)
                {
                    //左右に動くブロック
                    float x = posx + (float)i + Random.Range(-0.25f,0.25f);
                    float y = (float)j - 4 + Random.Range(-0.25f,0.25f);
                    int isAct = Random.Range(0,2);
                    GameObject newObject = GameObject.Instantiate<GameObject>(grounds[2]);
                    newObject.transform.position = new Vector3(x,y,this.transform.position.z);
                    newObject.GetComponent<Reverse>().isActive = isAct == 1 ? true : false;
                    FloorMove floorMove =  newObject.GetComponent<FloorMove>();
                    floorMove._isMoveX = true;
                    int isRi = Random.Range(0,2);
                    floorMove._isMoveXRight = isRi == 1 ? true : false;
                    float x1 = Random.Range(-4f,4f);
                    float x2 = Random.Range(-4f,4f);
                    floorMove._Xend = x + Mathf.Max(x1,x2);
                    floorMove._Xstart = x + Mathf.Min(x1,x2);
                    if (Mathf.Abs(Mathf.Abs(x1) - Mathf.Abs(x2)) < 1)
                    {
                        floorMove._Xend += 0.5f;
                        floorMove._Xstart -= 0.5f;
                    }
                    floorMove._Xend = x + Mathf.Max(x1,x2);
                    floorMove._Xstart = x + Mathf.Min(x1,x2);
                    floorMove._moveSpd = Random.Range(0.1f,4.0f);
                }else 
                {
                    
                }

            }
        }
    }

    void GenerateLv2(){

    }
}
