using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxBattleManager : MonoBehaviour
{

    public static SfxBattleManager Instance { get; set;}
    public AudioClip SFX_Punch;
    public AudioClip SFX_Kick;
    public AudioSource SfxSound;

    private void Awake(){
        if(Instance == null){
            Instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }
    public void PunchSFX(){
        SfxSound.PlayOneShot(SFX_Punch);
    }
    public void KickSFX(){
        SfxSound.PlayOneShot(SFX_Kick);
    }
}
