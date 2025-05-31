using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class StabbingManager : MonoBehaviour
{
    public GameObject stabbing;
    [Space(10)]
    public Transform mouseCursor;
    public Transform cursor;

    public float jiggleRange;

    [Space(10)]
    public Transform character;

    private StabCursor stabCursor;

    public UnityEvent onStartStabbing;
    public UnityEvent onStab;
    public UnityEvent onFinalStab;




    [Space(10)]
    public int hitsNeeded = 3;

    public float jiggleSpeed = 0.1f;
    public float jiggleIncrease = 0.3f;

    private void Start()
    {
        stabCursor = cursor.GetComponent<StabCursor>();
    }
    public void StartStabbing()
    {
        onStartStabbing?.Invoke();
        stabbing.SetActive(true);
        JiggleMouse();
    }
    public void JiggleMouse()
    {
        cursor.DOMove(mouseCursor.position + new Vector3(Random.Range(-jiggleRange, jiggleRange), Random.Range(-jiggleRange, jiggleRange), 0), jiggleSpeed)
            .SetEase(Ease.InOutSine)
            .OnComplete(() => JiggleMouse());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stabCursor.TryStab();
        }
    }

    public void IncreaseJiggle()
    {
        jiggleRange += jiggleIncrease;      
    }
}
