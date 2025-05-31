using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public PlayerMovement playerMovement;

    public StabbingManager stabbingManager;
    public enum GameState
    {
        Walking,
        Stabbing
    }
    public GameState gameState = GameState.Walking;

    private void Start()
    {
        Instance = (Instance == null) ? this : Instance;
    }

    public void ChangeState(GameState state)
    {
        gameState = state;
        switch (state)
        {
            case GameState.Walking:
                // Logic for starting the walking state
                Debug.Log("Game State changed to Walking");
                break;
            case GameState.Stabbing:
                StartStabbing();
                break;
        }
    }

    public void StartStabbing()
    {
        stabbingManager.StartStabbing();
    }
}
