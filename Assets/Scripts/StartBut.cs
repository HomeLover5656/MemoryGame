using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartBut : MonoBehaviour
{
    [SerializeField] Dropdown BlockNum,RememberNum,LimitTime,RememberTime;
    GameObject SetData;
    SetDataScript setdata;

    public void ChangedBlockNum(){
        int rem_num_val = RememberNum.value;
        int block_num = BlockNum.value + 3;
        RememberNum.ClearOptions();    //現在の要素をクリアする
        
        List<string> list = new List<string>();
        for(int i = 1 ; i< (block_num * block_num * block_num) ; i++){
            list.Add(i.ToString());
        }
        RememberNum.AddOptions(list);  //新しく要素のリストを設定する
        RememberNum.value = rem_num_val; 
        Debug.Log("changed");
    }

    public void StartButton(){

        setdata.block_num = BlockNum.value + 3;
        setdata.remember_num = RememberNum.value + 1;
        
        switch(LimitTime.value){
            case 0:
                setdata.limit_time=10;
                break;
            case 1:
                setdata.limit_time=20;
                break;
            case 2:
                setdata.limit_time=30;
                break;
            case 3:
                setdata.limit_time=40;
                break;
            case 4:
                setdata.limit_time=50;
                break;
            case 5:
                setdata.limit_time=60;
                break;
        }

        switch(RememberTime.value){
            case 0:
                setdata.remember_time=1;
                break;
            case 1:
                setdata.remember_time=2;
                break;
            case 2:
                setdata.remember_time=3;
                break;
            case 3:
                setdata.remember_time=4;
                break;
            case 4:
                setdata.remember_time=5;
                break;
        }

        SceneManager.LoadScene("GameScene");

    }

    // Start is called before the first frame update
    void Start()
    {
        SetData = GameObject.Find("SetData");
        setdata = SetData.GetComponent<SetDataScript>();

        //各ボタンの初期値を、SetDataの値にする.
        BlockNum.value = setdata.block_num - 3;
        RememberNum.value = setdata.remember_num - 1;
        RememberTime.value = setdata.remember_time - 1;

        switch(setdata.limit_time){
            case 10:
                LimitTime.value = 0;
            break;
            case 20:
                LimitTime.value = 1;
            break;
            case 30:
                LimitTime.value = 2;
            break;
            case 40:
                LimitTime.value = 3;
            break;
            case 50:
                LimitTime.value = 4;
            break;
            case 60:
                LimitTime.value = 5;
            break;
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
