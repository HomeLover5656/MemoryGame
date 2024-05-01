using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectRotatePlay : MonoBehaviour{

    bool PrePortrait;
    bool Portrait;
    
    public RectTransform WhichTurn;
    public RectTransform TimeLimit;
    public GameObject Buttons;
    public RectTransform DetButton;
    public RectTransform MenuButton;
    public RectTransform ExitButton;
    public RectTransform TitleButton;
    public RectTransform ReturnButton;
    public Camera MainCamera;
    public Camera SubCamera;
    

    // 端末の向きを取得するメソッド
    bool getPortrait() {
        bool result;

        if (Screen.width < Screen.height)
        {
            result = true;
        }
        else
        {
            result = false;
        }
        return result;
    }

    void Start () {
        PrePortrait = getPortrait();
        //画面の向きに合わせて初期配置を設定
        if (PrePortrait){
            WhichTurn.anchoredPosition = new Vector3(-180,600,0);
            WhichTurn.localScale = new Vector3(3,3,1);
            TimeLimit.anchoredPosition = new Vector3(-180,420,0);
            TimeLimit.localScale = new Vector3(3,3,1);
            Buttons.transform.localPosition = new Vector3(-300,-600,0);
            Buttons.transform.localScale = new Vector3(1.5f,1.5f,1f);
            DetButton.anchoredPosition = new Vector3(-150,-150,0);
            DetButton.localScale = new Vector3(1,1,1);
            MenuButton.anchoredPosition = new Vector3(-450,1050,0);
            MenuButton.localScale = new Vector3(1.5f,1.5f,1);
            ExitButton.anchoredPosition = new Vector3(0,500,0);
            ExitButton.localScale = new Vector3(3,3,1);
            TitleButton.anchoredPosition = new Vector3(0,0,0);
            TitleButton.localScale = new Vector3(3,3,1);
            ReturnButton.anchoredPosition = new Vector3(0,-500,0);
            ReturnButton.localScale = new Vector3(3,3,1);
            MainCamera.fieldOfView = 90;
            SubCamera.rect = new Rect(0.65f, 0.8f, 0.35f, 0.2f);
            }
        else{
            WhichTurn.anchoredPosition = new Vector3(0,240,0);
            WhichTurn.localScale = new Vector3(1,1,1);
            TimeLimit.anchoredPosition = new Vector3(0,180,0);
            TimeLimit.localScale = new Vector3(1,1,1);
            Buttons.transform.localPosition = new Vector3(0,0,0);
            Buttons.transform.localScale = new Vector3(1,1,1);
            DetButton.anchoredPosition = new Vector3(-450,-150,0);
            DetButton.localScale = new Vector3(1,1,1);
            MenuButton.anchoredPosition = new Vector3(-610,300,0);
            MenuButton.localScale = new Vector3(1,1,1);
            ExitButton.anchoredPosition = new Vector3(500,0,0);
            ExitButton.localScale = new Vector3(1,1,1);
            TitleButton.anchoredPosition = new Vector3(0,0,0);
            TitleButton.localScale = new Vector3(1,1,1);
            ReturnButton.anchoredPosition = new Vector3(-500,0,0);
            ReturnButton.localScale = new Vector3(1,1,1);
            MainCamera.fieldOfView = 60;
            SubCamera.rect = new Rect(0.75f, 0.7f, 0.25f, 0.3f);
            }
    }
     
    void Update () {

        Portrait = getPortrait();
        if (PrePortrait != Portrait)
        {
                // 画面の向きが変わるとボタン配置を変更
            if (Portrait){
            WhichTurn.anchoredPosition = new Vector3(-180,600,0);
            WhichTurn.localScale = new Vector3(3,3,1);
            TimeLimit.anchoredPosition = new Vector3(-180,420,0);
            TimeLimit.localScale = new Vector3(3,3,1);
            Buttons.transform.localPosition = new Vector3(-300,-600,0);
            Buttons.transform.localScale = new Vector3(1.5f,1.5f,1f);
            DetButton.anchoredPosition = new Vector3(-150,-150,0);
            DetButton.localScale = new Vector3(1,1,1);
            MenuButton.anchoredPosition = new Vector3(-450,1050,0);
            MenuButton.localScale = new Vector3(1.5f,1.5f,1);
            ExitButton.anchoredPosition = new Vector3(0,500,0);
            ExitButton.localScale = new Vector3(3,3,1);
            TitleButton.anchoredPosition = new Vector3(0,0,0);
            TitleButton.localScale = new Vector3(3,3,1);
            ReturnButton.anchoredPosition = new Vector3(0,-500,0);
            ReturnButton.localScale = new Vector3(3,3,1);
            MainCamera.fieldOfView = 90;
            SubCamera.rect = new Rect(0.65f, 0.8f, 0.35f, 0.2f);
            }
            else{
            WhichTurn.anchoredPosition = new Vector3(0,240,0);
            WhichTurn.localScale = new Vector3(1,1,1);
            TimeLimit.anchoredPosition = new Vector3(0,180,0);
            TimeLimit.localScale = new Vector3(1,1,1);
            Buttons.transform.localPosition = new Vector3(0,0,0);
            Buttons.transform.localScale = new Vector3(1,1,1);
            DetButton.anchoredPosition = new Vector3(-450,-150,0);
            DetButton.localScale = new Vector3(1,1,1);
            MenuButton.anchoredPosition = new Vector3(-610,300,0);
            MenuButton.localScale = new Vector3(1,1,1);
            ExitButton.anchoredPosition = new Vector3(500,0,0);
            ExitButton.localScale = new Vector3(1,1,1);
            TitleButton.anchoredPosition = new Vector3(0,0,0);
            TitleButton.localScale = new Vector3(1,1,1);
            ReturnButton.anchoredPosition = new Vector3(-500,0,0);
            ReturnButton.localScale = new Vector3(1,1,1);
            MainCamera.fieldOfView = 60;
            SubCamera.rect = new Rect(0.75f, 0.7f, 0.25f, 0.3f);
            }

            PrePortrait = Portrait;
        }
    }


}