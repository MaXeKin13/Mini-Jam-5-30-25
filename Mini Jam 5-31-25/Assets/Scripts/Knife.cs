using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float bobAmount = 0.1f;

    private bool canStab = true;

    private int stabNum = 0;
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

    public void Stab()
    {
        if(!canStab) return;
        canStab = false;
        Vector3 ogPos = transform.position;
        transform.DOMove(new Vector3(transform.position.x + -0.273f, transform.position.y, transform.position.z + 0.331f), 0.2f).OnComplete(
            () => {
                GameManager.Instance.stabbingManager.onStab?.Invoke();
                transform.DOMove(ogPos, 0.1f).OnComplete(() => 
                { 
                    stabNum++;
                    if (stabNum >= GameManager.Instance.stabbingManager.hitsNeeded)
                    {
                        GameManager.Instance.FinishStabbing();
                    }
                    else
                    { 
                        canStab = true;
                    }
                });

            }
        );
    }
}
