using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public AudioSource ClickNormalButton;
    public AudioSource ClickSwapButton;
    public AudioSource ClickChechboxButton;

    public void PlayClickNormalButton(){
        ClickNormalButton.Play();
    }
    public void PlayClickSwapButton(){
        ClickSwapButton.Play();
    }
    public void PlayClickChechboxButton(){
        ClickChechboxButton.Play();
    }
}
