using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_StButton : MonoBehaviour
{
    public Button st_button;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = st_button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        Debug.Log("you have clicked the button");
        SceneManager.LoadScene(sceneName: "CharacterSelect");
    }
}