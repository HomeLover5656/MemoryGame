using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartBut : MonoBehaviour
{
    public Dropdown CubeScale,WinTerm,TimeLimit,DisplayForm,ComSpeed,FirstP,SecondP,ThirdP,FourthP;
    public Toggle NonCenter,ExReach,PileMode,RotateMode;
    public static int n,Term,LimitTime,Form,FirP,SecP,ThirP,FourP;
    public static double deray_max;
    public static bool noncenter,Exreach,Pilemode,Rotatemode;
    GameObject SetData;
    SetDataScript setdata;

    public void Startbutton()
    {
        setdata.n = CubeScale.value + 3;
        setdata.Term = WinTerm.value;
        setdata.Form = DisplayForm.value;
        setdata.FirP = FirstP.value;
        setdata.SecP = SecondP.value;
        setdata.ThirP = ThirdP.value;
        setdata.FourP = FourthP.value;
        switch(ComSpeed.value){
            case 0:
                setdata.deray_max=0.1;
            break;
            case 1:
                setdata.deray_max=0.5;
            break;
            case 2:
                setdata.deray_max=1.0;
            break;
            case 3:
                setdata.deray_max=3.0;
            break;
            case 4:
                setdata.deray_max=5.0;
            break;
        }
        switch(TimeLimit.value){
            case 0:
                setdata.LimitTime=0;
            break;
            case 1:
                setdata.LimitTime=10;
            break;
            case 2:
                setdata.LimitTime=30;
            break;
            case 3:
                setdata.LimitTime=60;
            break;
            case 4:
                setdata.LimitTime=180;
            break;
            case 5:
                setdata.LimitTime=300;
            break;
        }

        setdata.noncenter = NonCenter.isOn;
        setdata.Exreach = ExReach.isOn;
        setdata.Pilemode = PileMode.isOn;
        setdata.Rotatemode = RotateMode.isOn;

        SceneManager.LoadScene("SanmokuScene");

    }

    // Start is called before the first frame update
    void Start()
    {
        SetData = GameObject.Find("SetData");
        setdata = SetData.GetComponent<SetDataScript>();

        //各ボタンの初期値を、SetDataの値にする。
        CubeScale.value = setdata.n - 3;
        WinTerm.value = setdata.Term;
        TimeLimit.value = setdata.LimitTime;
        DisplayForm.value = setdata.Form;
        FirstP.value = setdata.FirP;
        SecondP.value = setdata.SecP;
        ThirdP.value = setdata.ThirP;
        FourthP.value = setdata.FourP;
        switch(setdata.deray_max){
            case 0.1:
                ComSpeed.value = 0;
            break;
            case 0.5:
                ComSpeed.value = 1;
            break;
            case 1.0:
                ComSpeed.value = 2;
            break;
            case 3.0:
                ComSpeed.value = 3;
            break;
            case 5.0:
                ComSpeed.value = 4;
            break;
        }
        switch(setdata.LimitTime){
            case 0:
                TimeLimit.value = 0;
            break;
            case 10:
                TimeLimit.value = 1;
            break;
            case 30:
                TimeLimit.value = 2;
            break;
            case 60:
                TimeLimit.value = 3;
            break;
            case 180:
                TimeLimit.value = 4;
            break;
            case 300:
                TimeLimit.value = 5;
            break;
        }

        NonCenter.isOn = setdata.noncenter;
        ExReach.isOn = setdata.Exreach;
        PileMode.isOn = setdata.Pilemode;
        RotateMode.isOn = setdata.Rotatemode;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
