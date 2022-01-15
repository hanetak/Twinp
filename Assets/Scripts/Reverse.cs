using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse : MonoBehaviour
{
    [SerializeField]
    bool isActive = true;
    bool b;
    GameObject playerObject;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<Player>();
        b = player.isReverse();
        ReverseBlock();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isReverse() != b)
        {
            isActive = !isActive;
            ReverseBlock();
        }
        b = player.isReverse();
    }

    public void ReverseBlock()
    {
        GetComponent<Renderer>().material.color = isActive ? Color.white : Color.black;
        if (!isActive)
        //黒の時に当たり判定をなくす
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
