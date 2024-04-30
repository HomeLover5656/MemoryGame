using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDataScript : MonoBehaviour
{
    public int n,Term,LimitTime,Form,FirP,SecP,ThirP,FourP;
    public double deray_max;
    public bool noncenter,Exreach,Pilemode,Rotatemode;

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
        
        n = 4;
        Term = 0;
        LimitTime = 0;
        Form = 1;
        FirP = 0;
        SecP = 1;
        ThirP = 4;
        FourP = 4;
        deray_max = 1.0;
        noncenter = false;
        Exreach = false;
        Pilemode = false;
        Rotatemode = false;
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
