using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public InputManager InputManager { get; private set; }

    [Header("Managers")]
    public UIManager UIManager;
    public AudioManager AudioManager;
    
    [Header("Dynamic Game Objects")]
    [SerializeField] private GameObject bossDoor;

    private int totalKeysAmount;
    private int keysLeftToCollect;

    private void Awake()
    {
        if (Instance != null) Destroy(this.gameObject);
        Instance = this;

        InputManager = new InputManager();

        totalKeysAmount = FindObjectsOfType<CollectableKey>().Length;
        keysLeftToCollect = totalKeysAmount;
        
        print(totalKeysAmount);
    }

    public void UpdateKeysLeft()
    {
        keysLeftToCollect--;
        CheckAllKeysCollected();
    }

    private void CheckAllKeysCollected()
    {
        if (keysLeftToCollect <= 0)
        {
            Destroy(bossDoor);
        }
    }
}
