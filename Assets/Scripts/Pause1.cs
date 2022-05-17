using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pause1 : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    bool pauseScreenActive;
    private void Start()
    {
        pauseScreenActive = false;
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown("p") && pauseScreenActive == false)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
            pauseScreenActive = true;
        }
        else if (Input.GetKeyDown("p") && pauseScreenActive == true)
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
            pauseScreenActive = false;
        }
    }
}
