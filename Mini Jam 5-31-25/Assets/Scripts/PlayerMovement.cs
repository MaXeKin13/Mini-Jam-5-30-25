using UnityEngine;
using DG.Tweening;
public class PlayerMovement : MonoBehaviour
{
    public float stepDistance = 1.0f; // Distance to move with each step



    public void PlayerStep()
    {
        transform.DOMoveZ(transform.position.z + stepDistance, 0.25f)
            .OnComplete(() =>
            {
                Debug.Log("Player has stepped forward.");
            });
    }
}
