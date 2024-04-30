using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectRotation : MonoBehaviour{

    bool PrePortrait;
    bool Portrait;
    
    public RectTransform StartButton;
    public RectTransform NoCenterCube;
    public RectTransform ExhibitReach;
    public RectTransform PileMode;
    public RectTransform RotationMode;
    public RectTransform Masuscale;
    public RectTransform WinTerm;
    public RectTransform TimeLimitted;
    public RectTransform DisplayForm;
    public RectTransform ComSpeed;
    public RectTransform FirstPlayer;
    public RectTransform SecondPlayer;
    public RectTransform ThirdPlayer;
    public RectTransform FourthPlayer;
    public RectTransform ToDoRistButton;
    public RectTransform ToDoRistView;

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
            StartButton.anchoredPosition = new Vector3(480,-480,0);
            StartButton.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            NoCenterCube.anchoredPosition = new Vector3(680,300,0);
            NoCenterCube.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            ExhibitReach.anchoredPosition = new Vector3(680,-300,0);
            ExhibitReach.localScale = new Vector3(1.5f,1.5f,1.5f);
            PileMode.anchoredPosition = new Vector3(680,100,0);
            PileMode.localScale = new Vector3(1.5f,1.5f,1.5f);
            RotationMode.anchoredPosition = new Vector3(680,-100,0);
            RotationMode.localScale = new Vector3(1.5f,1.5f,1.5f);
            Masuscale.anchoredPosition = new Vector3(-360,350,0);
            Masuscale.localScale = new Vector3(1.5f,1.5f,1.5f);
            WinTerm.anchoredPosition = new Vector3(80,350,0);
            WinTerm.localScale = new Vector3(1.5f,1.5f,1.5f);
            TimeLimitted.anchoredPosition = new Vector3(-360,150,0);
            TimeLimitted.localScale = new Vector3(1.5f,1.5f,1.5f);
            DisplayForm.anchoredPosition = new Vector3(80,150,0);
            DisplayForm.localScale = new Vector3(1.5f,1.5f,1.5f);
            ComSpeed.anchoredPosition = new Vector3(-360,-50,0);
            ComSpeed.localScale = new Vector3(1.5f,1.5f,1.5f);
            FirstPlayer.anchoredPosition = new Vector3(-360,-300,0);
            FirstPlayer.localScale = new Vector3(1.3f,1.3f,1.3f);
            SecondPlayer.anchoredPosition = new Vector3(100,-300,0);
            SecondPlayer.localScale = new Vector3(1.3f,1.3f,1.3f);
            ThirdPlayer.anchoredPosition = new Vector3(-360,-500,0);
            ThirdPlayer.localScale = new Vector3(1.3f,1.3f,1.3f);
            FourthPlayer.anchoredPosition = new Vector3(100,-500,0);
            FourthPlayer.localScale = new Vector3(1.3f,1.3f,1.3f);
            ToDoRistButton.anchoredPosition = new Vector3(-520,600,0);
            ToDoRistView.anchoredPosition = new Vector3(-240,520,0);
        }
        else{
            StartButton.anchoredPosition = new Vector3(480,-240,0);
            StartButton.localScale = new Vector3(1, 1, 1);
            NoCenterCube.anchoredPosition = new Vector3(620,150,0);
            NoCenterCube.localScale = new Vector3(1, 1, 1);
            ExhibitReach.anchoredPosition = new Vector3(620,-150,0);
            ExhibitReach.localScale = new Vector3(1,1,1);
            PileMode.anchoredPosition = new Vector3(620,50,0);
            PileMode.localScale = new Vector3(1,1,1);
            RotationMode.anchoredPosition = new Vector3(620,-50,0);
            RotationMode.localScale = new Vector3(1,1,1);
            Masuscale.anchoredPosition = new Vector3(-480,150,0);
            Masuscale.localScale = new Vector3(1,1,1);
            WinTerm.anchoredPosition = new Vector3(-240,150,0);
            WinTerm.localScale = new Vector3(1,1,1);
            TimeLimitted.anchoredPosition = new Vector3(0,150,0);
            TimeLimitted.localScale = new Vector3(1,1,1);
            DisplayForm.anchoredPosition = new Vector3(240,150,0);
            DisplayForm.localScale = new Vector3(1,1,1);
            ComSpeed.anchoredPosition = new Vector3(-480,0,0);
            ComSpeed.localScale = new Vector3(1,1,1);
            FirstPlayer.anchoredPosition = new Vector3(-400,-150,0);
            FirstPlayer.localScale = new Vector3(1,1,1);
            SecondPlayer.anchoredPosition = new Vector3(-200,-250,0);
            SecondPlayer.localScale = new Vector3(1,1,1);
            ThirdPlayer.anchoredPosition = new Vector3(0,-150,0);
            ThirdPlayer.localScale = new Vector3(1,1,1);
            FourthPlayer.anchoredPosition = new Vector3(200,-250,0);
            FourthPlayer.localScale = new Vector3(1,1,1);
            ToDoRistButton.anchoredPosition = new Vector3(-520,300,0);
            ToDoRistView.anchoredPosition = new Vector3(-240,230,0);
        }
    }
     
    void Update () {

        Portrait = getPortrait();
        if (PrePortrait != Portrait)
        {
                // 画面の向きが変わるとボタン配置を変更
            if (Portrait){
                StartButton.anchoredPosition = new Vector3(480,-240,0);
            StartButton.anchoredPosition = new Vector3(480,-480,0);
            StartButton.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            NoCenterCube.anchoredPosition = new Vector3(680,300,0);
            NoCenterCube.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            ExhibitReach.anchoredPosition = new Vector3(680,-300,0);
            ExhibitReach.localScale = new Vector3(1.5f,1.5f,1.5f);
            PileMode.anchoredPosition = new Vector3(680,100,0);
            PileMode.localScale = new Vector3(1.5f,1.5f,1.5f);
            RotationMode.anchoredPosition = new Vector3(680,-100,0);
            RotationMode.localScale = new Vector3(1.5f,1.5f,1.5f);
            Masuscale.anchoredPosition = new Vector3(-360,350,0);
            Masuscale.localScale = new Vector3(1.5f,1.5f,1.5f);
            WinTerm.anchoredPosition = new Vector3(80,350,0);
            WinTerm.localScale = new Vector3(1.5f,1.5f,1.5f);
            TimeLimitted.anchoredPosition = new Vector3(-360,150,0);
            TimeLimitted.localScale = new Vector3(1.5f,1.5f,1.5f);
            DisplayForm.anchoredPosition = new Vector3(80,150,0);
            DisplayForm.localScale = new Vector3(1.5f,1.5f,1.5f);
            ComSpeed.anchoredPosition = new Vector3(-360,-50,0);
            ComSpeed.localScale = new Vector3(1.5f,1.5f,1.5f);
            FirstPlayer.anchoredPosition = new Vector3(-360,-300,0);
            FirstPlayer.localScale = new Vector3(1.3f,1.3f,1.3f);
            SecondPlayer.anchoredPosition = new Vector3(100,-300,0);
            SecondPlayer.localScale = new Vector3(1.3f,1.3f,1.3f);
            ThirdPlayer.anchoredPosition = new Vector3(-360,-500,0);
            ThirdPlayer.localScale = new Vector3(1.3f,1.3f,1.3f);
            FourthPlayer.anchoredPosition = new Vector3(100,-500,0);
            FourthPlayer.localScale = new Vector3(1.3f,1.3f,1.3f);
            ToDoRistButton.anchoredPosition = new Vector3(-520,600,0);
            ToDoRistView.anchoredPosition = new Vector3(-240,520,0);
            }
            else{
            StartButton.anchoredPosition = new Vector3(480,-240,0);
            StartButton.localScale = new Vector3(1, 1, 1);
            NoCenterCube.anchoredPosition = new Vector3(620,150,0);
            NoCenterCube.localScale = new Vector3(1, 1, 1);
            ExhibitReach.anchoredPosition = new Vector3(620,-150,0);
            ExhibitReach.localScale = new Vector3(1,1,1);
            PileMode.anchoredPosition = new Vector3(620,50,0);
            PileMode.localScale = new Vector3(1,1,1);
            RotationMode.anchoredPosition = new Vector3(620,-50,0);
            RotationMode.localScale = new Vector3(1,1,1);
            Masuscale.anchoredPosition = new Vector3(-480,150,0);
            Masuscale.localScale = new Vector3(1,1,1);
            WinTerm.anchoredPosition = new Vector3(-240,150,0);
            WinTerm.localScale = new Vector3(1,1,1);
            TimeLimitted.anchoredPosition = new Vector3(0,150,0);
            TimeLimitted.localScale = new Vector3(1,1,1);
            DisplayForm.anchoredPosition = new Vector3(240,150,0);
            DisplayForm.localScale = new Vector3(1,1,1);
            ComSpeed.anchoredPosition = new Vector3(-480,0,0);
            ComSpeed.localScale = new Vector3(1,1,1);
            FirstPlayer.anchoredPosition = new Vector3(-400,-150,0);
            FirstPlayer.localScale = new Vector3(1,1,1);
            SecondPlayer.anchoredPosition = new Vector3(-200,-250,0);
            SecondPlayer.localScale = new Vector3(1,1,1);
            ThirdPlayer.anchoredPosition = new Vector3(0,-150,0);
            ThirdPlayer.localScale = new Vector3(1,1,1);
            FourthPlayer.anchoredPosition = new Vector3(200,-250,0);
            FourthPlayer.localScale = new Vector3(1,1,1);
            ToDoRistButton.anchoredPosition = new Vector3(-520,300,0);
            ToDoRistView.anchoredPosition = new Vector3(-240,230,0);
            }

            PrePortrait = Portrait;
        }
    }


}
