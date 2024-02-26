using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float maxVolume = 1f;
    [SerializeField] private float minVolume = 0f;
    [SerializeField] private float volumeChangeSpeed = 0.5f;

    private Coroutine _volumeCoroutine;

    public void TurnOn()
    {
        ManageSound(maxVolume);
    }

    public void TurnOff()
    {
        ManageSound(minVolume);
    }

    private void Start()
    {
        _audioSource.volume = minVolume;
    }

    private void ManageSound(float targetVolume)
    {
        if (_volumeCoroutine != null)
        {
            StopCoroutine(_volumeCoroutine);
        }

        _volumeCoroutine = StartCoroutine(ManageSoundCoroutine(targetVolume));
    }

    private IEnumerator ManageSoundCoroutine(float targetVolume)
    {
        if (targetVolume > minVolume)
        {
            _audioSource.Play();
        }

        while (Mathf.Approximately(_audioSource.volume, targetVolume) == false)
        {
            _audioSource.volume =
                Mathf.MoveTowards(_audioSource.volume, targetVolume, volumeChangeSpeed * Time.deltaTime);

            yield return null;
        }

        if (targetVolume < maxVolume)
        {
            _audioSource.Stop();
        }
    }
}