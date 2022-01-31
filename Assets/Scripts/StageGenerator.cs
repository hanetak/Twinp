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
        GenerateLv1(0f);
        GenerateLv1(20f);
        genRange = 20;
    }

    // Update is called once per frame
    void Update()
    {
        pos = _camera.transform.position;
        if (genRange - pos.x< 0)
        {
            GenerateLv1(pos.x + 20f);
            genRange += 20;
        }
    }

    void GenerateLv1(float posx){
        float minx;
        float miny;

        for (int i = 0; i < 20; i++) {
            for(int j = 0;j < 8; j++)
            {
                //とりあえず存在率二割
                int index = Random.Range(1, 101);
                if(index < 15){
                    //通常のブロック
                    float x = posx + (float)i + Random.Range(-0.25f,0.25f);
                    float y = (float)j - 4 + Random.Range(-0.25f,0.25f);
                    int isAct = Random.Range(0,2);
                    GameObject newObject = GameObject.Instantiate<GameObject>(grounds[1]);
                    newObject.transform.position = new Vector3(x,y,this.transform.position.z);
                    newObject.GetComponent<Reverse>().isActive = isAct == 1 ? true : false;
                }else if(index == 16)
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
                    floorMove._moveSpd = Random.Range(0.1f,4.0f);
                }

            }
        }
    }

    void GenerateLv2(){

    }
}
