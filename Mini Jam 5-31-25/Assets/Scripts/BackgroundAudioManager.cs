using System.Collections;
using DG.Tweening;
using UnityEngine;

public class BackgroundAudioManager : MonoBehaviour
{
    public AudioSource[] audioSources;

    private void Start()
    {
        StartCoroutine(StartAllAudios());
    }

    private IEnumerator StartAllAudios()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            yield return new WaitForSeconds(0.25f);

            float randomPitch = Random.Range(0.5f, 1.5f);
            audioSource.DOPitch(randomPitch, 0.5f);
            audioSource.Play();

        }
    }
}
