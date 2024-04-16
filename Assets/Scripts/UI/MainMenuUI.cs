using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject OptionsPanel;
    [SerializeField] private GameObject MenuPanel;
    
    [Header("Menu UI properties")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject mainMenuFirsSelected;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(mainMenuFirsSelected);
        
        startButton.onClick.AddListener(GoToGameplayScene);
        optionsButton.onClick.AddListener(OpenOptionsMenu);
        exitButton.onClick.AddListener(ExitGame);
    }
    
    private void GoToGameplayScene()
    {
        GameManager.Instance.AudioManager.PlaySFX(SFX.ButtonClick);
        SceneManager.LoadScene("Gameplay");
    }

    private void OpenOptionsMenu()
    {
        GameManager.Instance.AudioManager.PlaySFX(SFX.ButtonClick);
        OptionsPanel.SetActive(true);
    }
    
    private void ExitGame()
    {
        GameManager.Instance.AudioManager.PlaySFX(SFX.ButtonClick);
//If de compilação        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
