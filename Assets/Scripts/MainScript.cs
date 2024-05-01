using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    int[,,] Blocks = new int[10, 10, 10];
    int[,,] Answer = new int[10,10,10];

    int x, y, z, i, j, k, block_num,remember_num,limit_time, remember_time,block_total ,turn = 0,what_time = 0;
    double ElapsedTime=0;
    public GameObject SpherePrefab, Serecting, FramePrefab, WinText, LoseText, BlackPanel;
    public Text WhatTimeText,TimeLimitText;
    GameObject[,,] Cubes = new GameObject[10, 10, 10];
    GameObject[,,] AnswerCubes = new GameObject[10,10,10];
    GameObject[,,] Frames = new GameObject[11, 11, 3];
    
    GameObject Buttons,SetData,AnswerParent;
    SetDataScript setdata;
    public Material[] Materials;
    Color[] colors = {new Color32(0,0,192,255),new Color32(192,0,0,255),new Color32(0,192,0,255),new Color32(192,0,192,255)};

    //ボタンを押したときの挙動（選択中のキューブの更新）　
    public void Xclick()
    {
        x += 1;
        Serecting.transform.position = new Vector3(x % block_num + 0.5f * (1.0f - block_num), y % block_num + 0.5f * (1.0f - block_num), z % block_num + 0.5f * (1.0f - block_num));
    }
    public void X_click()
    {
        x += block_num - 1;
        Serecting.transform.position = new Vector3(x % block_num + 0.5f * (1.0f - block_num), y % block_num + 0.5f * (1.0f - block_num), z % block_num + 0.5f * (1.0f - block_num));
    }
    public void Yclick()
    {
        y += 1;
        Serecting.transform.position = new Vector3(x % block_num + 0.5f * (1.0f - block_num), y % block_num + 0.5f * (1.0f - block_num), z % block_num + 0.5f * (1.0f - block_num));
    }
    public void Y_click()
    {
        y += block_num - 1;
        Serecting.transform.position = new Vector3(x % block_num + 0.5f * (1.0f - block_num), y % block_num + 0.5f * (1.0f - block_num), z % block_num + 0.5f * (1.0f - block_num));
    }
    public void Zclick()
    {
        z += 1;
        Serecting.transform.position = new Vector3(x % block_num + 0.5f * (1.0f - block_num), y % block_num + 0.5f * (1.0f - block_num), z % block_num + 0.5f * (1.0f - block_num));
    }
    public void Z_click()
    {
        z += block_num - 1;
        Serecting.transform.position = new Vector3(x % block_num + 0.5f * (1.0f - block_num), y % block_num + 0.5f * (1.0f - block_num), z % block_num + 0.5f * (1.0f - block_num));
    }

    
    //決定ボタンを押したときの挙動
    public void Det()
    {
        //ブロックが未選択のとき、選択済にする.
        if (Blocks[x % block_num, y % block_num, z % block_num] == 0)
        {            
            //マス目にプレイヤーの情報を入れる
            Blocks[x % block_num, y % block_num, z % block_num] = 1;

            //ブロックに球を配置.
            Cubes[x % block_num, y % block_num, z % block_num] = Instantiate(SpherePrefab) as GameObject;
            Cubes[x % block_num, y % block_num, z % block_num].transform.position = new Vector3(x % block_num + 0.5f * (1.0f - block_num), y % block_num + 0.5f * (1.0f - block_num), z % block_num + 0.5f * (1.0f - block_num));
            Cubes[x % block_num, y % block_num, z % block_num].GetComponent<Renderer>().sharedMaterial = Materials[5];

        }
    }

    //リセットボタンを押したときの挙動
    public void Reset(){
        //選択済のブロックを全て未選択にする.
        for(i=0; i<block_num ; i++){
            for(j=0; j<block_num;j++){
                for(k=0;k<block_num;k++){
                    if(Blocks[i,j,k] == 1){
                        Blocks[i,j,k] = 0;
                        Destroy(Cubes[i,j,k]);
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //SetDataの引き継ぎ=================================
        SetData = GameObject.Find("SetData");
        setdata = SetData.GetComponent<SetDataScript>();

        block_num = setdata.block_num;
        remember_num = setdata.remember_num;
        
        limit_time = setdata.limit_time;
        remember_time = setdata.remember_time;
        //===================================================

        WhatTimeText.text = "暗記時間";

        AnswerParent = new GameObject();

        Buttons = GameObject.Find("Buttons");
        Buttons.gameObject.SetActive(true);

        WinText.SetActive(false);
        LoseText.SetActive(false);

        BlackPanel.SetActive(false);
        Serecting.SetActive(false);

        //=============ブロック枠の配置======================
        for (i = 0; i < block_num + 1; i++)
        {
            for (j = 0; j < block_num + 1; j++)
            {
                Frames[i, j, 0] = Instantiate(FramePrefab) as GameObject;
                Frames[i, j, 0].transform.localScale = new Vector3(0.05f, block_num / 2.0f, 0.05f);
                Frames[i, j, 0].transform.position = new Vector3(0, i - block_num / 2.0f, j - block_num / 2.0f);
                Frames[i, j, 0].transform.rotation *= Quaternion.AngleAxis(90, Vector3.forward);

                Frames[i, j, 1] = Instantiate(FramePrefab) as GameObject;
                Frames[i, j, 1].transform.localScale = new Vector3(0.05f, block_num / 2.0f, 0.05f);
                Frames[i, j, 1].transform.position = new Vector3(i - block_num / 2.0f, 0, j - block_num / 2.0f);

                Frames[i, j, 2] = Instantiate(FramePrefab) as GameObject;
                Frames[i, j, 2].transform.localScale = new Vector3(0.05f, block_num / 2.0f, 0.05f);
                Frames[i, j, 2].transform.position = new Vector3(i - block_num / 2.0f, j - block_num / 2.0f, 0);
                Frames[i, j, 2].transform.rotation *= Quaternion.AngleAxis(90, Vector3.right);
            }
        }

        //================答えの準備（乱数）=================-
        block_total = block_num * block_num * block_num;
 
        List<int> numbers = new List<int>();
        for (i = 0; i <block_total ; i++) {
            numbers.Add(i);
        }
        
        for (i = 0; i<remember_num;i++) {
 
            //乱数の生成.
            int index = Random.Range(0, numbers.Count);
            int answer_int = numbers[index];

            //乱数から答えの生成.
            z = answer_int / (block_num * block_num);
            y = (answer_int-z*block_num*block_num) / block_num;
            x = answer_int - z*block_num*block_num - y*block_num;
            Answer[x,y,z]=1;

            //ブロックに球を配置.            
            AnswerCubes[x,y,z] = Instantiate(SpherePrefab) as GameObject;
            AnswerCubes[x,y,z].transform.position = new Vector3(x + 0.5f * (1.0f - block_num), y + 0.5f * (1.0f - block_num), z + 0.5f * (1.0f - block_num));
            AnswerCubes[x,y,z].GetComponent<Renderer>().sharedMaterial = Materials[6];
            AnswerCubes[x,y,z].transform.SetParent(AnswerParent.transform);

            numbers.RemoveAt(index);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ElapsedTime+=Time.deltaTime;//経過時間.
        switch(what_time){

            //暗記時間.
            case 0:
                TimeLimitText.text = "残り"+(((double)remember_time-ElapsedTime).ToString("f2")+"秒");
                if(ElapsedTime > (double)remember_time){
                    what_time = 1;
                    BlackPanel.SetActive(true);
                    ElapsedTime = 0;
                }
                break;

            //暗転時間.
            case 1:
                AnswerParent.SetActive(false);
                if(ElapsedTime > 1.0){
                    what_time = 2;
                    BlackPanel.SetActive(false);
                    Serecting.SetActive(true);
                    ElapsedTime = 0;
                    WhatTimeText.text = "回答時間";
                }
                break;

            //回答時間.
            case 2:
                TimeLimitText.text = "残り"+(((double)limit_time-ElapsedTime).ToString("f2")+"秒");
                if(ElapsedTime > (double)limit_time){
                    what_time = 3;
                    ElapsedTime = 0;
                }
                break;

            //リザルト.
            case 3:
                break;
        }


    }
}
