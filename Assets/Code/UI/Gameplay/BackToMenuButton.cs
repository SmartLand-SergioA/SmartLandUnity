using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMenuButton : MonoBehaviour
{
    private Button mainMenuButton;

    private void Awake()
    {
        mainMenuButton = GetComponent<Button>();
        mainMenuButton.onClick.AddListener(BackToMainMenu);
    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
