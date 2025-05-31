using DG.Tweening;
using UnityEngine;

public class StabbingManager : MonoBehaviour
{
    public GameObject stabbing;
    [Space(10)]
    public Transform mouseCursor;
    public Transform cursor;

    public float jiggleRange;

    private void Start()
    {
        
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
}
