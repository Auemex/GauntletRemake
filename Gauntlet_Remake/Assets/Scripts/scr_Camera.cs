using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Camera : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        if (!target)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            Debug.Log ("your target is " + target);
        }
    }

    // Update is called once per frame
    void Update()
    {
                if (!target)
        {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    void LateUpdate()
    {
        this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z - 3.0f);
    }
}
