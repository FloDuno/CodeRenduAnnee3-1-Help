using UnityEngine;
using System.Collections;

public class ArchOpening : MonoBehaviour
{
    public bool _archOpened;
    public float _doorSpeed;
    public GameObject _archDoor;
    public GameObject _archDoorDown;
    public GameObject _archDoorUp;
    private bool _canPlaySound = true;
    public AudioSource _doorSounds;
    public AudioClip _doorOpened;
    public AudioClip _doorClosed;
    public ColorManager sColorManager;
    private bool _isPlaying;

    // Update is called once per frame
    void Update()
    {
        _archOpened = sColorManager.isEquivalent;
        if (_archOpened)
        {
            if (_archDoor.transform.position.y > _archDoorDown.transform.position.y)
            {
                _archDoor.transform.Translate(Vector3.down * _doorSpeed * Time.deltaTime);
                if (_canPlaySound)
                {
                    DoorSounds();
                    _canPlaySound = false;
                }
            }
            else
            {
                _canPlaySound = true;
            }
        }
        else
        {
            if (_archDoor.transform.position.y < _archDoorUp.transform.position.y)
            {
                _archDoor.transform.Translate(Vector3.up * _doorSpeed * Time.deltaTime);
                if (_canPlaySound)
                {
                    DoorSounds();
                    _canPlaySound = false;
                }
            }
            else
            {
                _canPlaySound = true;
            }
        }
    }

    void DoorSounds()
    {
        if (_isPlaying)
            return;
        PlayOneShot(_archOpened ? _doorOpened : _doorClosed, 0.8f);
    }

    void PlayOneShot(AudioClip clip, float volume)
    {
        _doorSounds.PlayOneShot(clip, volume);
        StartCoroutine(CheckIfPlaying());
    }

    IEnumerator CheckIfPlaying()
    {
        float _timer = 0;
        _isPlaying = true;
        while (_timer <= _doorOpened.length)
        {
            _timer += Time.deltaTime;
            yield return null;
        }
        _isPlaying = false;
    }
}