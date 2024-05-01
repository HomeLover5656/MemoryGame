using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDataScript : MonoBehaviour
{
    public int block_num,remember_num,limit_time,remember_time;

    //オブジェクトを破壊させないための処理===============================
    public static SetDataScript Instance {
        get; private set;
    }

    void Awake(){
        if (Instance != null) {
            Destroy (gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad (gameObject);
        
        block_num = 4;
        remember_num = 5;
        limit_time = 20;
        remember_time = 3;
    }
    //===================================================================

    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
