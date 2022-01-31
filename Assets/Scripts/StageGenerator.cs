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
        for (int i = 0; i < 20; i++) {
            for(int j = 0;j < 8; j++)
            {
                //とりあえず存在率二割
                int index = Random.Range(1, 101);
                if(index < 15){
                    float x = posx + (float)i + Random.Range(-0.25f,0.25f);
                    float y = (float)j - 4 + Random.Range(-0.25f,0.25f);
                    int isAct = Random.Range(0,2);
                    GameObject newObject = GameObject.Instantiate<GameObject>(grounds[1]);
                    newObject.transform.position = new Vector3(x,y,this.transform.position.z);
                    newObject.GetComponent<Reverse>().isActive = isAct == 1 ? true : false;
                }

            }
        }
    }

    void GenerateLv2(){

    }
}
