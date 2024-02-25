using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float maxVolume = 1.0f;
    [SerializeField] private float volumeChangeSpeed = 0.5f;

    private float targetVolume = 0f;

    private void Start()
    {
        _audioSource.volume = 0f;
    }

    private void Update()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, volumeChangeSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        string player = "Player";

        if (other.CompareTag(player))
        {
            targetVolume = maxVolume;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        targetVolume = 0f;
    }
}