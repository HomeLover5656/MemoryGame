using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScript : MonoBehaviour
{
    
    GameObject SetData;
    SetDataScript setdata;
    // Start is called before the first frame update
    void Start()
    {
        SetData = GameObject.Find("SetData");
        setdata = SetData.GetComponent<SetDataScript>();
        this.transform.localScale *= setdata.block_num / 3.0f;

    }

    // Update is called once per frame
    void Update()
    {
    }
}
