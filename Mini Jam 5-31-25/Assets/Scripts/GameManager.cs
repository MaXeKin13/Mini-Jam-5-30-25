using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public PlayerMovement playerMovement;

    public StabbingManager stabbingManager;

    
    public Knife knife;

    public GameObject character;

    public StabZone stabZone;
    [Space(10)]
    public UnityEvent onFinishStab;
    public enum GameState
    {
        Walking,
        Stabbing,
        FinishStabbing
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
            case GameState.FinishStabbing:
                FinishStabbing();
                break;
        }
    }

    public void StartStabbing()
    {
        stabbingManager.StartStabbing();
    }

    public void StabAnim()
    {
        knife.Stab();
    }

    public void FinishStabbing()
    {
        //onFinishStab?.Invoke();

        ExplodeCharacter();
    }    

    private void ExplodeCharacter()
    {
        character.transform.DOScale(Vector3.zero, 0.25f)
            .SetEase(Ease.InOutSine)
            .OnComplete(() =>
            {
                character.SetActive(false);
                onFinishStab?.Invoke();
            });
    }
}
