using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public InputManager InputManager { get; private set; }

    [Header("Managers")]
    public UIManager UIManager;
    public AudioManager AudioManager;
    
    [Header("Dynamic Game Objects")]
    [SerializeField] private GameObject bossDoor;
    [FormerlySerializedAs("Player")] [SerializeField] private PlayerBehavior player;

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

    public PlayerBehavior GetPlayer()
    {
        return player;
    }
}
