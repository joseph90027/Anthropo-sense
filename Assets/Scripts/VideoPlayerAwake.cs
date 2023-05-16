

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEditor;




public class VideoPlayerAwake : MonoBehaviour

    
{
    private VideoPlayer videoPlayer;
    public GameObject rawImageObject;
    private RawImage rawImage;
    private long frame = 0;

 
    // Start is called before the first frame update
    void Start()
    {
        //RenderTexture.active = videoPlayer.targetTexture;
        //GL.Clear(true, true, Color.black);
        //RenderTexture.active = null;

        videoPlayer = GetComponent<VideoPlayer>();



    }

    /*
    void Awake()
    {
        // Get the RawImage component on the specified GameObject
        rawImage = rawImageObject.GetComponent<RawImage>();

        // Check if the RawImage component was found
        if (rawImage == null)
        {
            Debug.LogError("RawImage component not found on specified GameObject");
        }


        //Set time of the VideoPlayer to 0
        videoPlayer.time = 0;
        //Plays the video for one frame
        videoPlayer.Play();
        //Sets the frame to display on the RawImage
        rawImage.texture = videoPlayer.texture;
        //Pauses the video after one frame so that the first frame
        //of the video is displayed during idle
        videoPlayer.Pause();        //Set time of the VideoPlayer to 0
        videoPlayer.time = 0;
        //Plays the video for one frame
        videoPlayer.Play();
        //Sets the frame to display on the RawImage
        rawImage.texture = videoPlayer.texture;
        //Pauses the video after one frame so that the first frame
        //of the video is displayed during idle
        videoPlayer.Pause();
    }
    */

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Print "Hello World" to the console
            videoPlayer.frame = frame;
            videoPlayer.Pause();


            //long frame = videoPlayer.frame;


            // Do something with the current frame
            Debug.Log("Current frame: " + frame);
            //stopthegame();

            /*
            // Quit the Unity editor application
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #else
                        Application.Quit();
            #endif
            */

            /*
            // Stop the game
            if (Application.isEditor)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
            */
        }
    }

    /*
    private void stopthegame()
    {
        if (EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }

    }
    */

}
