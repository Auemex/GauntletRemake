using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_Selector : MonoBehaviour
{
    public static int characterSelect;
    public static int level  = 1;
    public int spawn;

    // character prefabs for level_1
    public GameObject wizardPrefab;
    public GameObject valkyriePrefab;
    public GameObject warriorPrefab;
    public GameObject elfPrefab;

    // button choices
    public Button wizardButton;
    public Button valkyrieButton;
    public Button warriorButton;
    public Button elfButton;
    public Button continueButton;
    // Start is called before the first frame update
    void Start()
    {
        // button choices
        Button wiz = wizardButton.GetComponent<Button>();
        Button val = valkyrieButton.GetComponent<Button>();
        Button war = warriorButton.GetComponent<Button>();
        Button elf = elfButton.GetComponent<Button>();
        Button con = continueButton.GetComponent<Button>();

        characterSelect = 1;
        spawn = 1;

        //  check if button click
        wiz.onClick.AddListener(wizOnClick);
        val.onClick.AddListener(valOnClick);
        war.onClick.AddListener(warOnClick);
        elf.onClick.AddListener(elfOnClick);
        con.onClick.AddListener(TaskContinue);
        // static variables
    }

    void Awake ()
    {
        if (level > 1)
        {
            switch(characterSelect)
            {
            case 4:
            Instantiate(elfPrefab, transform.position, transform.rotation);
            break;
            case 3:
            Instantiate(warriorPrefab, transform.position, transform.rotation);
            break;
            case 2:
            Instantiate(valkyriePrefab, transform.position, transform.rotation);
            break;
            case 1:
            Instantiate(wizardPrefab, transform.position, transform.rotation);
            break;
            default:
            Instantiate(wizardPrefab, transform.position, transform.rotation);
            break;
            }
        }
    }

    void wizOnClick ()
    {
        characterSelect = 1;
        Debug.Log ("you have clicked the button! " + characterSelect);
    }
    void valOnClick ()
    {
        characterSelect = 2;
        Debug.Log ("you have clicked the button! " + characterSelect);
    }
    void warOnClick ()
    {
        characterSelect = 3;
        Debug.Log ("you have clicked the button! " + characterSelect);
    }
    void elfOnClick ()
    {
        characterSelect = 4;
        Debug.Log ("you have clicked the button! " + characterSelect);
    }
    void TaskContinue()
    {
        SceneManager.LoadScene(sceneName: "Level_1");
        level = 2;
        Debug.Log ("you have clicked the button! " + characterSelect + "/" + level);
    }
}
