using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [Header("Character Menu")]
    public GameObject character1;
    public GameObject character2;
    int characterStatus = 0;

    bool isSoundOn;
    bool isVibrationOn;
    public bool isReverseOn = false;
    public static MainMenuManager Instance { get; set; }
    // Start is called before the first frame update
    private void Awake(){
        if(Instance == null){
            Instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //ngeluaudio
        if (AudioManager.Instance.BGM.mute == true)
        {

            checkBoxSound.SetActive(false);
            isSoundOn = false;
        }
        else
        {
            checkBoxSound.SetActive(true);
            isSoundOn = true;
        }

        //ngelureverse
        if (Reversebutton.Instance.reverses == true)
        {
            checkBoxReverse.SetActive(true);
            isReverseOn = true;
        }
        else
        {
            checkBoxReverse.SetActive(false);
            isReverseOn = false;
        }
    }

    public void StartButton()
    {
        panelMainMenu.SetActive(false);
        panelStartMenu.SetActive(true);
        panelSettingMenu.SetActive(false);
        panelCharacterMenu.SetActive(false);
        panelHowToPlayMenu.SetActive(false);
    }

    public void SettingButton()
    {
        panelMainMenu.SetActive(false);
        panelStartMenu.SetActive(false);
        panelSettingMenu.SetActive(true);
        panelCharacterMenu.SetActive(false);
        panelHowToPlayMenu.SetActive(false);
    }

    public void CharacterButton()
    {
        panelMainMenu.SetActive(false);
        panelStartMenu.SetActive(false);
        panelSettingMenu.SetActive(false);
        panelCharacterMenu.SetActive(true);
        panelHowToPlayMenu.SetActive(false);
    }

    public void BackButton()
    {
        panelMainMenu.SetActive(true);
        panelStartMenu.SetActive(false);
        panelSettingMenu.SetActive(false);
        panelCharacterMenu.SetActive(false);
        panelHowToPlayMenu.SetActive(false);
    }

    public void SoundButton()
    {
        AudioManager.Instance.MuteSound();
        if (AudioManager.Instance.BGM.mute == true)
        {

            checkBoxSound.SetActive(false);
            isSoundOn = false;
        }
        else
        {
            checkBoxSound.SetActive(true);
            isSoundOn = true;
        }
    }

    public void VibrationButton()
    {
        if (isVibrationOn)
        {
            checkBoxVibration.SetActive(false);
            isVibrationOn = false;
        }
        else
        {
            checkBoxVibration.SetActive(true);
            isVibrationOn = true;
        }
    }

    public void ReverseButton()
    {
        if (!isReverseOn)
        {
            checkBoxReverse.SetActive(true);
            isReverseOn = true;
        }
        else
        {
            checkBoxReverse.SetActive(false);
            isReverseOn = false;
        }
    }

    public void ShowConfirmSetDefault()
    {
        panelConfirmSetDefault.SetActive(true);
    }
    public void DisableConfirmSetDefault()
    {
        panelConfirmSetDefault.SetActive(false);
    }

    public void ShowConfirmQuit()
    {
        panelConfirmQuit.SetActive(true);
    }
    public void DisableConfirmQuit()
    {
        panelConfirmQuit.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void confirmNewCampaign()
    {
        panelMainMenu.SetActive(false);
        panelStartMenu.SetActive(false);
        panelSettingMenu.SetActive(false);
        panelCharacterMenu.SetActive(false);
        panelHowToPlayMenu.SetActive(true);
    }

    public void showHTPPanel()
    {
        if (!panelHowToPlayMenu.activeInHierarchy)
        {
            panelHowToPlayMenu.SetActive(true);
        }
        else
        {
            panelHowToPlayMenu.SetActive(false);
        }
    }

    public void NextCharacter()
    {
        if (characterStatus == 0)
        {
            character1.SetActive(false);
            character2.SetActive(true);
            characterStatus = 1;
        }
        else if (characterStatus == 1)
        {
            character2.SetActive(false);
            character1.SetActive(true);
            characterStatus = 0;
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
