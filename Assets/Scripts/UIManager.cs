using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Menu UI properties")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;
    
    [SerializeField] private GameObject OptionsPanel;
    [SerializeField] private GameObject MenuPanel;

    private void Awake()
    {
        OptionsPanel.SetActive(false);
        MenuPanel.SetActive(true);
        
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
        Debug.LogWarning("Botão de opções ainda não está implementado");
        OptionsPanel.SetActive(true);
        MenuPanel.SetActive(false);
    }

    public void OpenMainMenu()
    {
        GameManager.Instance.AudioManager.PlaySFX(SFX.ButtonClick);
        OptionsPanel.SetActive(false);
        MenuPanel.SetActive(true);
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