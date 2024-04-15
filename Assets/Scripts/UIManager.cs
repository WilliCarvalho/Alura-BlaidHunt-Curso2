using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Menu UI properties")] 
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;

    private void Awake()
    {
        startButton.onClick.AddListener(GoToGameplayScene);
        optionsButton.onClick.AddListener(OpenOptionsMenu);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void GoToGameplayScene()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void OpenOptionsMenu()
    {
        //TODO: Criar menu de opções
    }

    private void ExitGame()
    {
//If de compilação        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
