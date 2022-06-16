using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; set;}

    public AudioClip[] BGMClips;
    
    public AudioSource BGM;

    int BGMIndex = 0;

    private void Awake(){
        if(Instance == null){
            Instance = this;
        }
        else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode){

        if(scene.name == "MainMenu"){
            Debug.Log("MainMenu");
            BGM.clip = BGMClips[0];
            BGM.time = 19;
            BGM.Play();
        }
        else if(scene.name == "Game"){
            BGM.clip = BGMClips[1];
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        if(BGM.isPlaying == false){
            switch (BGMIndex)
            {
                case 0:
                    BGM.time = 19;
                    BGM.Play();
                    break;
                case 1:
                    break;
                default:
                    break;
            }      
        }
        
    }

    public void MuteSound(){
        if(BGM.mute == false){
            BGM.mute = true;
        }
        else{
            BGM.mute = false;
        }
    }

    
}
