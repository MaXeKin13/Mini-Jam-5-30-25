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

    private StabCursor stabCursor;


    public UnityEvent onStab;

    [Space(10)]
    public int hitsNeeded = 3;
    private void Start()
    {
        stabCursor = cursor.GetComponent<StabCursor>();
    }
    public void StartStabbing()
    {
        stabbing.SetActive(true);
        JiggleMouse();
    }
    public void JiggleMouse()
    {
        cursor.DOMove(mouseCursor.position + new Vector3(Random.Range(-jiggleRange, jiggleRange), Random.Range(-jiggleRange, jiggleRange), 0), 0.1f)
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

    public void FinishStabbing()
    {

    }
}
