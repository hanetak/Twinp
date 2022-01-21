using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    [SerializeField] GameObject ButtonStart;
    [SerializeField] GameObject ButtonCont;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void PressStart()
     {
         SceneManager.LoadScene("Stage1");
     }

     public void PressNext(){
         int i = 1;
         SceneManager.LoadScene($"Stage{i}");
     }
}
