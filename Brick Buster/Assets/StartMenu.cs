using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] public CanvasGroup uiGroup;
    public GameObject startMenuUI;
    public static bool startMenuActive = true, fadeOut = true;
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
                if (fadeOut)
                {
                    uiGroup.alpha -= Time.deltaTime;
                }

                startMenuActive = false;
                Time.timeScale = 1f;
            }
        }

        if (fadeOut == true && startMenuActive == false)
        {
            uiGroup.alpha -= Time.deltaTime;
        }

    }
}
