using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject MenuContents;

    public void PointerDown()
    {
        MenuContents.gameObject.SetActive(true);
    }

    public void Exit()
    {
//        UnityEditor.EditorApplication.isPlaying = false;
        UnityEngine.Application.Quit();
    }

    public void Title()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void Return()
    {
        MenuContents.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
