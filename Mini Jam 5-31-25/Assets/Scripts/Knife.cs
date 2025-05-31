using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float bobAmount = 0.1f;


    private void Start()
    {
        // Start the bobbing animation coroutine
        StartCoroutine(BobAnim());
    }
    public IEnumerator BobAnim()
    {
        yield return new WaitForSeconds(0.5f);
        while(GameManager.Instance.gameState == GameManager.GameState.Walking)
        {
            // Move the knife up and down
            transform.DOMoveY(transform.position.y + bobAmount, 1f)
                .SetEase(Ease.InOutSine);
            yield return new WaitForSeconds(1f);
            transform.DOMoveY(transform.position.y - bobAmount, 1f)
                .SetEase(Ease.InOutSine);
            yield return new WaitForSeconds(1f);
        }
    }
}
