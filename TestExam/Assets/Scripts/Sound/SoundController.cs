using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : Singleton<SoundController> {

    private List<string> _currentSounds = new List<string>();
    private List<AudioSource> _currentAudioSources = new List<AudioSource>();

    void Awake() {
        this.gameObject.AddComponent<AudioSource>();
    }

    /// <summary>
    /// plays a sound when called
    /// </summary>
    /// <param name="iSound"></param>
    /// <param name="iRepeating"></param>
    /// <param name="iParentForSound"></param>
    /// <param name="iStringForDestroy"></param>
    public void PlaySound(AudioClip iSound, bool iRepeating, string iStringForDestroy = "") {
        AudioSource tAudioSource = Instantiate(this.gameObject).GetComponent<AudioSource>();
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

    /// <summary>
    /// Checks if a sound is done playing and destroys it if it is
    /// </summary>
    /// <param name="iAudioSource"></param>
    /// <returns></returns>
    IEnumerator DestroyAFterDone(AudioSource iAudioSource) {
        while (iAudioSource.isPlaying) {
            yield return new WaitForSeconds(1);
        }
        Destroy(iAudioSource.gameObject);
    }

    /// <summary>
    /// Destroys the given audio source
    /// </summary>
    /// <param name="iSoundToDestroy"></param>
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
