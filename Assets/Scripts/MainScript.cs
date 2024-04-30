using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    int[,,] Masume = new int[10, 10, 10];
    int[,,] Value = new int[11, 10, 10];
    int[,] PileHigh = new int[10,10];
    int[] A = new int[4];
    int[] Players;
    int[] abc = new int[8];

    int x, y, z, i, j, k, a, b, c, d, e, f, g, h, n, Term, LimitTime, Form, turn = 0;
    double deray = 0,deray_max,ElapsedTime=0;
    bool Continue = true,Exreach,PileMode = false,Rotatemode;
    public GameObject CubePrefab, SpherePrefab, Serecting, FramePrefab, WinText, LoseText, Turn, WhichTurn,YBut,Y_But,MenuContents;
    public Text TurnText, WhichTurnText,Wintext,TimeLimitText;
    GameObject[,,] Cubes = new GameObject[10, 10, 10];
    GameObject[,,] Frames = new GameObject[11, 11, 3];
    
    GameObject Buttons,SetData;
    SetDataScript setdata;
    public Material[] Materials;
    Color[] colors = {new Color32(0,0,192,255),new Color32(192,0,0,255),new Color32(0,192,0,255),new Color32(192,0,192,255)};

    //ボタンを押したときの挙動（選択中のキューブの更新）　
    public void Xclick()
    {
        x += 1;
        if(PileMode)
        {
            y=PileHigh[x%n,z%n];
        }
        Serecting.transform.position = new Vector3(x % n + 0.5f * (1.0f - n), y % n + 0.5f * (1.0f - n), z % n + 0.5f * (1.0f - n));
    }
    public void X_click()
    {
        x += n - 1;
        if(PileMode)
        {
            y=PileHigh[x%n,z%n];
        }
        Serecting.transform.position = new Vector3(x % n + 0.5f * (1.0f - n), y % n + 0.5f * (1.0f - n), z % n + 0.5f * (1.0f - n));
    }
    public void Yclick()
    {
        y += 1;
        Serecting.transform.position = new Vector3(x % n + 0.5f * (1.0f - n), y % n + 0.5f * (1.0f - n), z % n + 0.5f * (1.0f - n));
    }
    public void Y_click()
    {
        y += n - 1;
        Serecting.transform.position = new Vector3(x % n + 0.5f * (1.0f - n), y % n + 0.5f * (1.0f - n), z % n + 0.5f * (1.0f - n));
    }
    public void Zclick()
    {
        z += 1;
        if(PileMode)
        {
            y=PileHigh[x%n,z%n];
        }
        Serecting.transform.position = new Vector3(x % n + 0.5f * (1.0f - n), y % n + 0.5f * (1.0f - n), z % n + 0.5f * (1.0f - n));
    }
    public void Z_click()
    {
        z += n - 1;
        if(PileMode)
        {
            y=PileHigh[x%n,z%n];
        }
        Serecting.transform.position = new Vector3(x % n + 0.5f * (1.0f - n), y % n + 0.5f * (1.0f - n), z % n + 0.5f * (1.0f - n));
    }

    //勝敗を判定する関数（勝負ありなら1,なしなら0を返す)
    int Judge(int l)
    {
        a = b = c = d = e = f = g = 1;
        for (h = 0; h < n; h++)
        {
            a *= Masume[h, y % n, z % n];
            b *= Masume[x % n, h, z % n];
            c *= Masume[x % n, y % n, h];
            d *= Masume[h, n - 1 - h, z % n];
            e *= Masume[x % n, h, n - 1 - h];
            f *= Masume[n - 1 - h, y % n, h];
        }
        if (a == l || b == l || c == l)
        {
            return (1);
        }
        if (x % n == n - 1 - y % n && d == l) { return (1); }
        if (y % n == n - 1 - z % n && e == l) { return (1); }
        if (z % n == n - 1 - x % n && f == l) { return (1); }

        a = b = c = d = e = f = g = 1;

        for (h = 0; h < n; h++)
        {
            a *= Masume[h, h, z % n];
            b *= Masume[h, y % n, h];
            c *= Masume[x % n, h, h];
            d *= Masume[h, h, n - 1 - h];
            e *= Masume[h, n - 1 - h, h];
            f *= Masume[n - 1 - h, h, h];
            g *= Masume[h, h, h];
        }
        if (x % n == y % n || y % n == z % n)
        {
            if (g == l) { return (1); }
        }
        if (x % n == y % n)
        {
            if (a == l) { return (1); }
            if (x % n == n - 1 - z % n && d == l) { return (1); }
        }
        if (x % n == z % n)
        {
            if (b == l) { return (1); }
            if (x % n == n - 1 - y % n && e == l) { return (1); }
        }
        if (y % n == z % n)
        {
            if (c == l) { return (1); }
            if (n - 1 - x % n == y % n && f == l) { return (1); }
        }

        return (0);
    }
    
    //パスボタンを押したときの挙動
    public void Pass()
    {
        turn++;
        WhichTurnText.color = colors[turn%4];
        WhichTurnText.text = turn % 4 + 1 + "Pのターン";
        TurnText.text = turn / 4 + 1 + "手目";
        ElapsedTime = 0;
        x = z = 0;
        y=PileHigh[x,z];
        Serecting.transform.position = new Vector3(x % n + 0.5f * (1.0f - n), PileHigh[x,z] % n + 0.5f * (1.0f - n), z % n + 0.5f * (1.0f - n));
    }

    //決定ボタンを押したときの挙動
    //とりあえずplayerは1,computerは2にしとく
    public void Det()
    {
        if (Masume[x % n, y % n, z % n] == 0)
        {
            PileHigh[x%n,z%n]+=1;
            //マス目にプレイヤーの情報を入れる
            if (turn % 4 == 3)
            {
                Masume[x % n, y % n, z % n] = 5;
                for (i = 0, j = 1; i < n; i++) { j *= 5; }
            }
            else
            {
                Masume[x % n, y % n, z % n] = turn%4+1;
                for (i = 0, j = 1; i < n; i++) { j *= (turn%4+1); }
            }
            //マス目の色をつける
            switch (Form)
            {
                case 0:
                    Cubes[x % n, y % n, z % n].GetComponent<Renderer>().sharedMaterial = Materials[turn % 4 + 1];
                    break;

                case 1:
                    Cubes[x % n, y % n, z % n] = Instantiate(SpherePrefab) as GameObject;
                    Cubes[x % n, y % n, z % n].transform.position = new Vector3(x % n + 0.5f * (1.0f - n), y % n + 0.5f * (1.0f - n), z % n + 0.5f * (1.0f - n));
                    Cubes[x % n, y % n, z % n].GetComponent<Renderer>().sharedMaterial = Materials[turn % 4 + 5];
                    break;

                case 2:
                    break;
            }

            //勝ったとき
            if (Judge(j) == 1)
            {
                WinText.SetActive(true);
                Wintext.color = colors[turn%4];
                Wintext.text = turn % 4 + 1 + "P Win";
                WhichTurnText.text = "";
                Continue = false;
                Serecting.SetActive(false);
                return;
            }
            //それ以外のとき、次の人のターンへ。
            Pass();
        }

        //打てるマス目が残っていないとき、引き分け。
            a=1;
            for(i=0;i<n;i++)
            {
                for(j=0;j<n;j++)
                {
                    for(k=0;k<n;k++)
                    {
                        if(Masume[i,j,k]==0)
                        {
                            a=0;
                        }
                    }
                }
            }

            if(a!=0)
            {            
                WinText.SetActive(true);
                Wintext.text = "Draw";
                WhichTurnText.text = "";
                Continue=false;
                Serecting.SetActive(false);
                return;
            }        

    }

    //それぞれのマス目の価値value[,,]//と順番A[]//を決める関数（コンピューター用）
    void Eval(int mine)
    {
        if(PileMode)
        {
            Value[0,n,0] = -1;
            A[0]=A[1]=A[2]=n*n;

        }
        else
        {            
            Value[n, 0, 0] = -1;
            A[0] = A[1] = A[2] = n * n * n;
        }
        
        void COUNT()
        {
            if ((abc[7] > 0) || ((n - abc[0] != abc[1]) && (n - abc[0] != abc[2]) && (n - abc[0] != abc[3]) && (n - abc[0] != abc[5])))
            {
                Value[i, j, k] += 0;
            }
            else if (abc[0] == 1)
            {
                if (abc[mine] == n - 1) { Value[i, j, k] += 487917; }
                else Value[i, j, k] += 37532;
            }
            else if (abc[0] == 2)
            {
                if (abc[mine] == n - 2) { Value[i, j, k] += 2887; }
                else Value[i, j, k] += 222;
            }
            else if (abc[mine] == 0) { Value[i, j, k] += ((n - abc[0]) + 1); }
            else { Value[i, j, k] += (2 * (abc[mine]) + 1); }
        }

        //ここから、 COUNT()を使ってvalue[i,j,k]にそれぞれのmasume[i,j,k]の価値を入れていく
        for (i = 0; i < n; i++)
        {
            for (j = 0; j < n; j++)
            {
                for (k = 0; k < n; k++)
                {
                    if (Masume[i, j, k] == 0)
                    {
                        //i,j,kを配列 I[3]とか置いたらこの処理for文ですっきりしそう。でもfor文の入れ子が多すぎる
                        Value[i, j, k] = 0;
                        for (h = 0; h < 8; h++)
                        {
                            abc[h] = 0;
                        }
                        for (h = 0; h < n; h++) abc[Masume[h,j,k]]++;
                        COUNT();

                        for (h = 0; h < 8; h++) { abc[h] = 0; }
                        for (h = 0; h < n; h++) abc[Masume[i, h, k]]++;
                        COUNT();

                        for (h = 0; h < 8; h++) { abc[h] = 0; }
                        for (h = 0; h < n; h++) abc[Masume[i, j, h]]++;
                        COUNT();

                        //重複も考えるからelseは使わない
                        if (i == j)
                        {
                            for (h = 0; h < 8; h++) { abc[h] = 0; }
                            for (h = 0; h < n; h++) abc[Masume[h, h, k]]++;
                            COUNT();

                            if (j == k)
                            {
                                for (h = 0; h < 8; h++) { abc[h] = 0; }
                                for (h = 0; h < n; h++) abc[Masume[h, h, h]]++;
                                COUNT();
                            }
                            if (j == n - 1 - k)
                            {
                                for (h = 0; h < 8; h++) { abc[h] = 0; }
                                for (h = 0; h < n; h++) abc[Masume[h, h, n - 1 - h]]++;
                                COUNT();
                            }
                        }

                        if (i == n - 1 - j)
                        {
                            for (h = 0; h < 8; h++) { abc[h] = 0; }
                            for (h = 0; h < n; h++) abc[Masume[h, n - 1 - h, k]]++;
                            COUNT();

                            if (j == k)
                            {
                                for (h = 0; h < 8; h++) { abc[h] = 0; }
                                for (h = 0; h < n; h++) abc[Masume[h, n - 1 - h, n - 1 - h]]++;
                                COUNT();
                            }
                            if (i == k)
                            {
                                for (h = 0; h < 8; h++) { abc[h] = 0; }
                                for (h = 0; h < n; h++) abc[Masume[h, n - 1 - h, h]]++;
                                COUNT();
                            }
                        }

                        if (j == k)
                        {
                            for (h = 0; h < 8; h++) { abc[h] = 0; }
                            for (h = 0; h < n; h++) abc[Masume[i, h, h]]++ ;
                            COUNT();
                        }

                        if (j == n - 1 - k)
                        {
                            for (h = 0; h < 8; h++) { abc[h] = 0; }
                            for (h = 0; h < n; h++) abc[Masume[i, h, n - 1 - h]]++;
                            COUNT();
                        }

                        if (k == i)
                        {
                            for (h = 0; h < 8; h++) { abc[h] = 0; }
                            for (h = 0; h < n; h++) abc[Masume[h, j, h]]++ ;
                            COUNT();
                        }

                        if (k == n - 1 - i)
                        {
                            for (h = 0; h < 8; h++) { abc[h] = 0; }
                            for (h = 0; h < n; h++) abc[Masume[n - 1 - h, j, h]]++;
                            COUNT();
                        }

                    }

                    else Value[i, j, k] = -1;
                }
            }
        }

        //value[A2/n][A2%n](=最大) > value[A1/n][A1%n] > value[A0/n][A0%n]　になるように
        if(PileMode)
        {      
            for(i=0;i<n;i++)
            {
                for(j=0;j<n;j++)
                {
                    if (Value[i, PileHigh[i,j], j] >= Value[A[2] / n, PileHigh[A[2]/n,A[2]%n], A[2] % n])
                        {
                            A[0] = A[1];
                            A[1] = A[2];
                            A[2] = n * i + j;
                        }
                        else if (Value[i,PileHigh[i,j], j] >= Value[A[1] / n, PileHigh[A[1]/n,A[1]%n], A[1] % n])
                        {
                            A[0] = A[1];
                            A[1] =  n * i + j;
                        }
                        else if (Value[i,PileHigh[i,j], j] >= Value[A[0] / n, PileHigh[A[0]/n,A[0]%n], A[0] % n])
                        {
                            A[0] =  n * i + j;
                        }
                }
            }
        }
        else
        {  
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    for (k = 0; k < n; k++)
                    {
                        if (Value[i, j, k] >= Value[A[2] / (n * n), (A[2] % (n * n)) / n, A[2] % n])
                        {
                            A[0] = A[1];
                            A[1] = A[2];
                            A[2] = n * n * i + n * j + k;
                        }
                        else if (Value[i, j, k] >= Value[A[1] / (n * n), (A[1] % (n * n)) / n, A[1] % n])
                        {
                            A[0] = A[1];
                            A[1] = n * n * i + n * j + k;
                        }
                        else if (Value[i, j, k] >= Value[A[0] / (n * n), (A[0] % (n * n)) / n, A[0] % n])
                        {
                            A[0] = n * n * i + n * j + k;
                        }
                    }
                }
            }
        }

        if (Value[A[1] / (n * n), (A[1] % (n * n)) / n, A[1] % n] == -1) A[1] = A[2];
        if (Value[A[0] / (n * n), (A[0] % (n * n)) / n, A[0] % n] == -1) A[0] = A[1];
    }


    // Start is called before the first frame update
    void Start()
    {
        WhichTurnText.color = colors[0];
     
        //SetDataの引き継ぎ=================================
        SetData = GameObject.Find("SetData");
        setdata = SetData.GetComponent<SetDataScript>();

        n = setdata.n;
        Term = setdata.Term;
        LimitTime = setdata.LimitTime;
        Form = setdata.Form;
        Players = new int [4] { setdata.FirP, setdata.SecP, setdata.ThirP, setdata.FourP };
        deray_max = setdata.deray_max;
        Exreach = setdata.Exreach;
        PileMode = setdata.Pilemode;
        Rotatemode = setdata.Rotatemode;
        
        if(PileMode){
            Destroy(YBut);
            Destroy(Y_But);
        }
        //===================================================

        WhichTurnText.text = "1Pのターン";

        Buttons = GameObject.Find("Buttons");
        WinText.SetActive(false);
        LoseText.SetActive(false);


        //表示形式ごとの初期配置
        switch (Form)
        {
            case 0:
                //キューブの初期配置
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        for (k = 0; k < n; k++)
                        {
                            Cubes[i, j, k] = Instantiate(CubePrefab) as GameObject;
                            Cubes[i, j, k].transform.position = new Vector3(i + 0.5f * (1.0f - n), j + 0.5f * (1.0f - n), k + 0.5f * (1.0f - n));
                            Masume[i, j, k] = 0;
                        }
                        PileHigh[i,j]=0;
                    }
                }
                //真ん中のキューブを選択不能にした時
                if (setdata.noncenter)
                {
                    if (n % 2 == 0)
                    {

                        Masume[n / 2, n / 2, n / 2] = 7;
                        Cubes[n / 2, n / 2, n / 2].GetComponent<Renderer>().sharedMaterial = Materials[9];
                        Masume[n / 2 - 1, n / 2, n / 2] = 7;
                        Cubes[n / 2 - 1, n / 2, n / 2].GetComponent<Renderer>().sharedMaterial = Materials[9];
                        Masume[n / 2, n / 2 - 1, n / 2] = 7;
                        Cubes[n / 2, n / 2 - 1, n / 2].GetComponent<Renderer>().sharedMaterial = Materials[9];
                        Masume[n / 2, n / 2, n / 2 - 1] = 7;
                        Cubes[n / 2, n / 2, n / 2 - 1].GetComponent<Renderer>().sharedMaterial = Materials[9];
                        Masume[n / 2 - 1, n / 2 - 1, n / 2] = 7;
                        Cubes[n / 2 - 1, n / 2 - 1, n / 2].GetComponent<Renderer>().sharedMaterial = Materials[9];
                        Masume[n / 2, n / 2 - 1, n / 2 - 1] = 7;
                        Cubes[n / 2, n / 2 - 1, n / 2 - 1].GetComponent<Renderer>().sharedMaterial = Materials[9];
                        Masume[n / 2 - 1, n / 2, n / 2 - 1] = 7;
                        Cubes[n / 2 - 1, n / 2, n / 2 - 1].GetComponent<Renderer>().sharedMaterial = Materials[9];
                        Masume[n / 2 - 1, n / 2 - 1, n / 2 - 1] = 7;
                        Cubes[n / 2 - 1, n / 2 - 1, n / 2 - 1].GetComponent<Renderer>().sharedMaterial = Materials[9];
                    }
                    else
                    {
                        Masume[n / 2, n / 2, n / 2] = 7;
                        Cubes[n / 2, n / 2, n / 2].GetComponent<Renderer>().sharedMaterial = Materials[9];
                    }         
                }
                break;

            case 1:
                //枠の配置
                for (i = 0; i < n + 1; i++)
                {
                    for (j = 0; j < n + 1; j++)
                    {
                        Frames[i, j, 0] = Instantiate(FramePrefab) as GameObject;
                        Frames[i, j, 0].transform.localScale = new Vector3(0.05f, n / 2.0f, 0.05f);
                        Frames[i, j, 0].transform.position = new Vector3(0, i - n / 2.0f, j - n / 2.0f);
                        Frames[i, j, 0].transform.rotation *= Quaternion.AngleAxis(90, Vector3.forward);

                        Frames[i, j, 1] = Instantiate(FramePrefab) as GameObject;
                        Frames[i, j, 1].transform.localScale = new Vector3(0.05f, n / 2.0f, 0.05f);
                        Frames[i, j, 1].transform.position = new Vector3(i - n / 2.0f, 0, j - n / 2.0f);

                        Frames[i, j, 2] = Instantiate(FramePrefab) as GameObject;
                        Frames[i, j, 2].transform.localScale = new Vector3(0.05f, n / 2.0f, 0.05f);
                        Frames[i, j, 2].transform.position = new Vector3(i - n / 2.0f, j - n / 2.0f, 0);
                        Frames[i, j, 2].transform.rotation *= Quaternion.AngleAxis(90, Vector3.right);
                    }
                }
                //真ん中を選択不能にした時
                if (setdata.noncenter)
                {
                    if (n % 2 == 0)
                    {

                        Masume[n / 2, n / 2, n / 2] = 7;
                        Cubes[n / 2, n / 2, n / 2] = Instantiate(SpherePrefab) as GameObject;
                        Cubes[n / 2, n / 2, n / 2].transform.position = new Vector3(n / 2 + 0.5f * (1.0f - n), n / 2 + 0.5f * (1.0f - n), n / 2 + 0.5f * (1.0f - n));
                        Cubes[n / 2, n / 2, n / 2].GetComponent<Renderer>().sharedMaterial = Materials[9];

                        Masume[n / 2 - 1, n / 2, n / 2] = 7;
                        Cubes[n / 2 - 1, n / 2, n / 2] = Instantiate(SpherePrefab) as GameObject;
                        Cubes[n / 2 - 1, n / 2, n / 2].transform.position = new Vector3(n / 2 - 1 + 0.5f * (1.0f - n), n / 2 + 0.5f * (1.0f - n), n / 2 + 0.5f * (1.0f - n));
                        Cubes[n / 2 - 1, n / 2, n / 2].GetComponent<Renderer>().sharedMaterial = Materials[9];

                        Masume[n / 2, n / 2 - 1, n / 2] = 7;
                        Cubes[n / 2, n / 2 - 1, n / 2] = Instantiate(SpherePrefab) as GameObject;
                        Cubes[n / 2, n / 2 - 1, n / 2].transform.position = new Vector3(n / 2 + 0.5f * (1.0f - n), n / 2 - 1 + 0.5f * (1.0f - n), n / 2 + 0.5f * (1.0f - n));
                        Cubes[n / 2, n / 2 - 1, n / 2].GetComponent<Renderer>().sharedMaterial = Materials[9];

                        Masume[n / 2, n / 2, n / 2 - 1] = 7;
                        Cubes[n / 2, n / 2, n / 2 - 1] = Instantiate(SpherePrefab) as GameObject;
                        Cubes[n / 2, n / 2, n / 2 - 1].transform.position = new Vector3(n / 2 + 0.5f * (1.0f - n), n / 2 + 0.5f * (1.0f - n), n / 2 - 1 + 0.5f * (1.0f - n));
                        Cubes[n / 2, n / 2, n / 2 - 1].GetComponent<Renderer>().sharedMaterial = Materials[9];

                        Masume[n / 2 - 1, n / 2 - 1, n / 2] = 7;
                        Cubes[n / 2 - 1, n / 2 - 1, n / 2] = Instantiate(SpherePrefab) as GameObject;
                        Cubes[n / 2 - 1, n / 2 - 1, n / 2].transform.position = new Vector3(n / 2 - 1 + 0.5f * (1.0f - n), n / 2 - 1 + 0.5f * (1.0f - n), n / 2 + 0.5f * (1.0f - n));
                        Cubes[n / 2 - 1, n / 2 - 1, n / 2].GetComponent<Renderer>().sharedMaterial = Materials[9];

                        Masume[n / 2, n / 2 - 1, n / 2 - 1] = 7;
                        Cubes[n / 2, n / 2 - 1, n / 2 - 1] = Instantiate(SpherePrefab) as GameObject;
                        Cubes[n / 2, n / 2 - 1, n / 2 - 1].transform.position = new Vector3(n / 2 + 0.5f * (1.0f - n), n / 2 - 1 + 0.5f * (1.0f - n), n / 2 - 1 + 0.5f * (1.0f - n));
                        Cubes[n / 2, n / 2 - 1, n / 2 - 1].GetComponent<Renderer>().sharedMaterial = Materials[9];

                        Masume[n / 2 - 1, n / 2, n / 2 - 1] = 7;
                        Cubes[n / 2 - 1, n / 2, n / 2 - 1] = Instantiate(SpherePrefab) as GameObject;
                        Cubes[n / 2 - 1, n / 2, n / 2 - 1].transform.position = new Vector3(n / 2 - 1 + 0.5f * (1.0f - n), n / 2 + 0.5f * (1.0f - n), n / 2 - 1 + 0.5f * (1.0f - n));
                        Cubes[n / 2 - 1, n / 2, n / 2 - 1].GetComponent<Renderer>().sharedMaterial = Materials[9];

                        Masume[n / 2 - 1, n / 2 - 1, n / 2 - 1] = 7;
                        Cubes[n / 2 - 1, n / 2 - 1, n / 2 - 1] = Instantiate(SpherePrefab) as GameObject;
                        Cubes[n / 2 - 1, n / 2 - 1, n / 2 - 1].transform.position = new Vector3(n / 2 - 1 + 0.5f * (1.0f - n), n / 2 - 1 + 0.5f * (1.0f - n), n / 2 - 1 + 0.5f * (1.0f - n));
                        Cubes[n / 2 - 1, n / 2 - 1, n / 2 - 1].GetComponent<Renderer>().sharedMaterial = Materials[9];
                    }
                    else
                    {
                        Masume[n / 2, n / 2, n / 2] = 7;
                        Cubes[n / 2, n / 2, n / 2] = Instantiate(SpherePrefab) as GameObject;
                        Cubes[n / 2, n / 2, n / 2].transform.position = new Vector3(n / 2 + 0.5f * (1.0f - n), n / 2 + 0.5f * (1.0f - n), n / 2 + 0.5f * (1.0f - n));
                        Cubes[n / 2, n / 2, n / 2].GetComponent<Renderer>().sharedMaterial = Materials[9];
                    }
                }
                break;

            case 2:
                break;
        }
        x = y = z = 0;
        Serecting.transform.position = new Vector3(x % n + 0.5f * (1.0f - n), y % n + 0.5f * (1.0f - n), z % n + 0.5f * (1.0f - n));

    }

    // Update is called once per frame
    void Update()
    {
        //時間制限有りのとき
        if(LimitTime != 0)
        {
        ElapsedTime+=Time.deltaTime;
        TimeLimitText.text = "残り時間: "+(((double)LimitTime-ElapsedTime).ToString("f2")+"s");
        if(ElapsedTime >= (double)LimitTime) Pass();
        }

        // コンピュータの番なら、選択ボタンを表示しない
        if ((Players[turn % 4] != 0))
        {
            Buttons.gameObject.SetActive(false);
        }
        // プレイヤーの番なら、ボタンを表示
        if ((Players[turn % 4] == 0)&&Continue)
        {
            Buttons.gameObject.SetActive(true);
        }
        // 打ちてが居ないとき、次に回す
        else if (Players[turn % 4] == 4)
        {
            turn++;
            WhichTurnText.color = colors[turn%4];
            WhichTurnText.text = turn % 4 + 1 + "Pのターン";
            TurnText.text = turn / 4 + 1 + "手目";
        }
        // コンピューターの動作
        else if (Continue){
            if (turn % 4 == 3) Eval(5);
            else Eval(turn % 4+1);
            //積み上げモードのとき
            if(PileMode)
            {
                i=A[Players[turn % 4] - 1] / n;
                j=A[Players[turn % 4] - 1] % n;
                deray += Time.deltaTime;
                if (x % n != i)
                {
                    if (deray > deray_max)
                    {
                        deray = 0;
                        Xclick();
                    }
                }
                else if (z % n != j)
                {
                    if (deray > deray_max)
                    {
                        deray = 0;
                        Zclick();
                    }
                }
                else
                {
                    deray = 0;
                    Det();
                }
            }
            //通常モードのとき
            else
            {                
                i = A[Players[turn%4]-1] / (n * n);
                j = (A[Players[turn % 4] - 1] % (n * n)) / n;
                k = A[Players[turn % 4] - 1] % n;
                deray += Time.deltaTime;
                if (x % n != i)
                {
                    if (deray > deray_max)
                    {
                        deray = 0;
                        Xclick();
                    }
                }
                else if (y % n != j)
                {
                    if (deray > deray_max)
                    {
                        deray = 0;
                        Yclick();
                    }
                }
                else if (z % n != k)
                {
                    if (deray > deray_max)
                    {
                        deray = 0;
                        Zclick();
                    }
                }
                else
                {
                    deray = 0;
                    Det();
                }
            }
        }
        else
        {
            Buttons.gameObject.SetActive(false);
        }
    }
}
