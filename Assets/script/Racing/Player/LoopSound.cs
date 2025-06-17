using UnityEngine;

public class LoopSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
