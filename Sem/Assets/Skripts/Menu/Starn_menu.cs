using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics;
using UnityEngine.UI;
using CnControls;
//using UnityEditor;

public class Starn_menu : MonoBehaviour
{

    #region Pole
    enum Status
    {
        Indecs, ophens, message
    }
    public List<string> NextScen;
    int number_map = 0;

    public GameObject ophens;
    public GameObject indecs;
    public GameObject messege_box;

    Status position_map;
    bool is_true;

    #region Audio
    public AudioClip[] Music;
    public AudioSource[] audioSource;

    bool IsStep = false;
    float StopStep;
    public float StartStopStep;
    public float speed_my = 1.3f;

    public Slider music_slider;
    public Slider sound_slider;

    

    public int langveh;

    #endregion Audio


   
 


    #endregion Pole
    // Use this for initialization
    void Start()
    {
        loadOphens();


        is_true = false;
        position_map = Status.Indecs;
        ophens.active = false;
        indecs.active = true;
        messege_box.active = false;
        MoweAudio();
       
        langveh = 0;
    }
    void OnApplicationQuit()
    {
        saveOphens();
    }
    void OnDisable()
    {
        saveOphens();
    }

    #region 


    #region button
    public void Start_Game()
    {

        Application.LoadLevel(NextScen[number_map]);
    }
    public void Start_Ophens()
    {
        indecs.active = false;
        ophens.active = true;
        messege_box.active = false;
        position_map = Status.ophens;
    }
    public void Start_Indecs()
    {
        indecs.active = true;
        ophens.active = false;
        messege_box.active = false;
        position_map = Status.Indecs;
    }
    public void Start_message()
    {
        messege_box.active = true;
        position_map = Status.message;
    }


    public void Message_OK()
    {
        Exit();
    }
    public void Message_NO()
    {
        Start_Indecs();
    }

    void Exit()
    {
        Application.Quit();
    }
    #endregion button
    public void Back()
    {

        switch (position_map)
        {
            case Status.Indecs:

                Start_message();

                break;
            case Status.ophens:


                Start_Indecs();


                break;
            case Status.message:


                break;

        }
    }



    #endregion



        // Update is called once per frame
        void FixedUpdate()
        {


            SoundChose();



        }

        #region Audio
        void MoweAudio()
        {


            //  if (IsStep)
            //  {
            audioSource[0].clip = Music[0];
            audioSource[0].Play();
            // audioSource.PlayOneShot(FootSteps[0]);//[Random.Range(0, FootSteps.Length)]);

            //      IsStep = false;
            //  }


            //   if (StopStep < 0)
            //  {
            //       StopStep = StartStopStep;
            //       IsStep = true;
            //   }
            //   if (StopStep > 0)
            //   {
            //       StopStep -= Time.deltaTime;
            //   }


        }


        public void PlaySound()
        {
            audioSource[1].Stop();
            audioSource[1].clip = Music[1];
            audioSource[1].Play();
        }

        void SoundChose()
        {
            music_slider.value = audioSource[0].volume;
            sound_slider.value = audioSource[1].volume;
        }

        void StopAudio()
        {
            audioSource[0].Stop();

            StopStep = StartStopStep;
            IsStep = true;
        }
    #endregion Audio

    #region Data

    public void saveOphens()
    {
   
        PlayerPrefs.SetFloat("Music", music_slider.value); // т.к. автоматической работы 
        PlayerPrefs.SetFloat("Sound", sound_slider.value); // с массивами нет, разбиваем на
        PlayerPrefs.SetInt("Launh", langveh);  // отдельные float и записываем
 
    }

    public void loadOphens()
    {

        music_slider.value = PlayerPrefs.GetFloat("Music");
        sound_slider.value = PlayerPrefs.GetFloat("Sound");
        langveh = PlayerPrefs.GetInt("Launh");
        
        audioSource[0].volume = music_slider.value;
        audioSource[1].volume = sound_slider.value;

    }

    #endregion Data
}
