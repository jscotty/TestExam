//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{

    [SerializeField]
    private AudioClip _backgroundMusic;

    private SoundController _soundController;

    void Start()
    {
        _soundController = SoundController.Instance;
        _soundController.PlaySound(_backgroundMusic, true);
    }
}
