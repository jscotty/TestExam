using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : Singleton<SoundController> {
    
    [SerializeField]
    private GameObject _audioPlayer;

    private List<string> _currentSounds = new List<string>();
    private List<AudioSource> _currentAudioSources = new List<AudioSource>();

    public void PlaySound(AudioClip iSound, bool iRepeating, Transform iParentForSound, string iStringForDestroy = "") {
        AudioSource tAudioSource = Instantiate(_audioPlayer, iParentForSound).GetComponent<AudioSource>();
        tAudioSource.loop = iRepeating;
        tAudioSource.clip = iSound;
        tAudioSource.Play();
        if (!iRepeating) {
            StartCoroutine(DestroyAFterDone(tAudioSource));
        }
        else {
            _currentSounds.Add(iStringForDestroy);
            _currentAudioSources.Add(tAudioSource);
        }
    }

    IEnumerator DestroyAFterDone(AudioSource iAudioSource) {
        while (iAudioSource.isPlaying) {
            yield return new WaitForSeconds(1);
        }
        Destroy(iAudioSource.gameObject);
    }

    public void DestroyAudioSource(string iSoundToDestroy) {
        for (int i = 0; i < _currentSounds.Count; i++) {
            if(_currentSounds[i] == iSoundToDestroy) {
                AudioSource tAudioSource = _currentAudioSources[i];
                _currentAudioSources[i].Stop();
                _currentSounds.RemoveAt(i);
                _currentAudioSources.RemoveAt(i);
                Destroy(tAudioSource.gameObject);
                return;
            }
        }
        Debug.LogWarning("The sound '" + iSoundToDestroy + "' is not found");
    }
}
