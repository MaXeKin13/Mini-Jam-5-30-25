using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public PlayerMovement playerMovement;
    private void Start()
    {
        Instance = (Instance == null) ? this : Instance;
    }
}
