using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject panelMainMenu;
    public GameObject panelStartMenu;
    public GameObject panelSettingMenu;
    public GameObject panelCharacterMenu;
    public GameObject panelHowToPlayMenu;
    public GameObject panelConfirmNCMenu;
    public GameObject panelConfirmQuit;

    [Header("Setting Menu")]
    public GameObject checkBoxSound;
    public GameObject checkBoxVibration;
    public GameObject checkBoxReverse;
    public GameObject panelConfirmSetDefault;
    
    bool isSoundOn;
    bool isVibrationOn;
    bool isReverseOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartButton(){
        panelMainMenu.SetActive(false);
        panelStartMenu.SetActive(true);
        panelSettingMenu.SetActive(false);
        panelCharacterMenu.SetActive(false);
        panelHowToPlayMenu.SetActive(false);
    }

    public void SettingButton(){
        panelMainMenu.SetActive(false);
        panelStartMenu.SetActive(false);
        panelSettingMenu.SetActive(true);
        panelCharacterMenu.SetActive(false);
        panelHowToPlayMenu.SetActive(false);
    }

    public void CharacterButton(){
        panelMainMenu.SetActive(false);
        panelStartMenu.SetActive(false);
        panelSettingMenu.SetActive(false);
        panelCharacterMenu.SetActive(true);
        panelHowToPlayMenu.SetActive(false);
    }

    public void BackButton(){
        panelMainMenu.SetActive(true);
        panelStartMenu.SetActive(false);
        panelSettingMenu.SetActive(false);
        panelCharacterMenu.SetActive(false);
        panelHowToPlayMenu.SetActive(false);
    }

    public void SoundButton(){ 
        if(isSoundOn){
            checkBoxSound.SetActive(false);
            isSoundOn = false;
        }
        else{
            checkBoxSound.SetActive(true);
            isSoundOn = true;
        }
    }

    public void VibrationButton(){
        if(isVibrationOn){
            checkBoxVibration.SetActive(false);
            isVibrationOn = false;
        }
        else{
            checkBoxVibration.SetActive(true);
            isVibrationOn = true;
        }
    }

    public void ReverseButton(){
        if(isReverseOn){
            checkBoxReverse.SetActive(false);
            isReverseOn = false;
        }
        else{
            checkBoxReverse.SetActive(true);
            isReverseOn = true;
        }
    }

    public void ShowConfirmSetDefault(){
        panelConfirmSetDefault.SetActive(true);
    }
    public void DisableConfirmSetDefault(){
        panelConfirmSetDefault.SetActive(false);
    }

    public void ShowConfirmQuit(){
        panelConfirmQuit.SetActive(true);
    }
    public void DisableConfirmQuit(){
        panelConfirmQuit.SetActive(false);
    }

    public void QuitButton(){
        Application.Quit();
    }

    public void confirmNewCampaign(){
        panelMainMenu.SetActive(false);
        panelStartMenu.SetActive(false);
        panelSettingMenu.SetActive(false);
        panelCharacterMenu.SetActive(false);
        panelHowToPlayMenu.SetActive(true);
    }

    public void showHTPPanel(){
        panelMainMenu.SetActive(false);
        panelStartMenu.SetActive(false);
        panelSettingMenu.SetActive(false);
        panelCharacterMenu.SetActive(false);
        panelHowToPlayMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
