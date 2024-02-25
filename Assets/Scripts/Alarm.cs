using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float maxVolume = 1f;
    [SerializeField] private float minVolume = 0f;
    [SerializeField] private float volumeChangeSpeed = 0.5f;

    private void Start()
    {
        _audioSource.volume = minVolume;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() == true)
        {
            StartCoroutine(ChangeVolume(maxVolume));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(ChangeVolume(minVolume));
    }

    private IEnumerator ChangeVolume(float volume)
    {
        if (volume > minVolume)
        {
            _audioSource.Play();
        }

        while (Mathf.Approximately(_audioSource.volume, volume) == false)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volume, volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }

        if (volume < maxVolume)
        {
            _audioSource.Stop();
        }
    }
}