using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenuAnimation;
    public GameObject startMenuUI;
    public static bool startMenuActive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startMenuActive)
        {
            Time.timeScale = 0f;
        }

        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1))
            {
                return;
            }
            else
            {
                startMenuAnimation.GetComponent<Animator>().enabled = true;
                startMenuAnimation.GetComponent<Animator>().Play("StartMenuFade", 0, 0);
                startMenuUI.SetActive(false);
                startMenuActive = false;
                Time.timeScale = 1f;
            }
        }
    }
}
