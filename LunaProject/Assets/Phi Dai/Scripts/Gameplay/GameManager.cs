using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject ui;
    bool ui_Status = true; 

    
    void Start()
    {
        // Turn off mouse at start
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeUIStatus();
    }

    void ChangeUIStatus()
    {
        if (!ui_Status)
            ui.SetActive(false);
    }
}
