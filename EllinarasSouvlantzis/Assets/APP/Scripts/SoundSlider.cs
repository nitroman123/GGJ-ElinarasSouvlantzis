using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    [SerializeField] Slider volumeslider;

    private void Start() {
        volumeslider.onValueChanged.AddListener(vol => Volume(vol));
    }
    public void Volume(float volume) {
        AudioListener.volume = volume;
    }
}
