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
            _audioSource.Play();
            StartCoroutine(ChangeVolume(maxVolume));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _audioSource.Stop();
        _audioSource.volume = minVolume;
    }

    private IEnumerator ChangeVolume(float volume)
    {
        while (Mathf.Approximately(_audioSource.volume, volume) == false)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volume, volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}