using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [SerializeField]
    private Image muteButtonImage;

    [Header("Audio Source to Mute")]
    [SerializeField]
    private AudioSource musicAudioSource;

    [Header("Muted Button Sprite")]
    [SerializeField]
    private Sprite mutedSprite;

    [Header("Unmuted Button Sprite")]
    [SerializeField]
    private Sprite unmutedSprite;

    // true = music audio is muted | false = music audio is not muted   
    private bool isMuted;

    ///-///////////////////////////////////////////////////////////
    ///
    public void MuteAudio()
    {
        // if the audio source is not muted, then mute it
        if (!isMuted)
        {
            isMuted = true;
            musicAudioSource.mute = true;
            ChangeSprite(mutedSprite);
        }

        // otherwise, unmute the audio source
        else
        {
            isMuted = false;
            musicAudioSource.mute = false;
            ChangeSprite(unmutedSprite);
        }
            
    }

    ///-///////////////////////////////////////////////////////////
    ///
    private void ChangeSprite(Sprite newButtonSprite)
    {
        muteButtonImage.sprite = newButtonSprite;
    }

}
