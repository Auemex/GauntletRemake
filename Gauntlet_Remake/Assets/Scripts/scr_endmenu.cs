using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_endmenu : MonoBehaviour
{
    public Button mm_button;
    void Start()
    {
        Button btn = mm_button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void TaskOnClick()
    {
        Debug.Log("you have clicked the button");
        SceneManager.LoadScene(sceneName: "Main_Menu");
    }
}
