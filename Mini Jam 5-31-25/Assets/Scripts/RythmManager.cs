using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;



public class RythmManager : MonoBehaviour
{
    public float walkDistance = 0.1f;
    public bool walking = true;

    public UnityEvent onCanHit;
    public UnityEvent onCantHit;
   
    public float timeToHit = 0.5f;
    public float[] intervals; //interval between first and second step

    public AudioSource stepSound;


    [Space(10)]
    public int hitsNeeded = 10;

    private int hitsDone = 0;

    [Space(10)]
    public GameObject stepLeft;
    public GameObject stepRight;
    public Transform walls;
    public float wallMoveDistance = 0.1f;
    private void Start()
    {
        StartCoroutine(WalkCycle());
    }

    //hit logic
    private bool canHit = false;
    private IEnumerator WalkCycle()
    {
        while (walking)
        {
            for (int i = 0; i < intervals.Length; i++)
            {
                // Wait for the specified interval
                yield return new WaitForSeconds(intervals[i]);
                // Trigger the step action
                Step();

                onCanHit?.Invoke();
                canHit = true;
                yield return new WaitForSeconds(timeToHit);

                onCantHit?.Invoke();
                canHit = false;
                

            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canHit)
        {
            // Trigger hit logic
            Debug.Log("Hit!");

            GameManager.Instance.playerMovement.PlayerStep();
            hitsDone++;
            CheckIfReached();
        }
    }

    private void CheckIfReached()
    {
        if(hitsDone >= hitsNeeded)
        {
            
            walking = false;
            StopAllCoroutines();
            GameManager.Instance.ChangeState(GameManager.GameState.Stabbing);
            canHit = false;
        }
    }    
   
    private void Step()
    {
        if(stepLeft.activeSelf)
        {
            stepLeft.SetActive(false);
            stepRight.SetActive(true);
        }
        else
        {
            stepLeft.SetActive(true);
            stepRight.SetActive(false);
        }
        stepSound.Play();

        //move environment
        walls.DOMove(walls.transform.position - new Vector3(0, 0, wallMoveDistance), 0.5f);
    }

    public void Die()
    {
        //transform.DOScale()
    }
}
