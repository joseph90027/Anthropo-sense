using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class StartVideo : MonoBehaviour
{
    public GameObject Obj;
    public GameObject Bar1;
    public GameObject Bar2;
    public GameObject Bar3;
    public GameObject Text;
    public GameObject Bar4;
    public GameObject Bar5;
    public GameObject Bar6;

    private VideoPlayer player;
    private int clickNum = 0;
    private int clickNum_Last = 0;
    void Start()
    {
        player = GetComponent<VideoPlayer>();
    }

    public void StartPlayingVideo()
    {
        if(player.isPlaying == false && clickNum == 0)
        {
            player.Play();
            clickNum++;
        }
        else if(player.isPlaying == true && clickNum >= 1 && clickNum <= 8)
        {
            clickNum++;
        }
        else
        {
            Obj.SetActive(false);
            Bar1.SetActive(true);
            Bar2.SetActive(true);
            Bar3.SetActive(true);
            Text.SetActive(true);
            Bar4.SetActive(true);
            Bar5.SetActive(true);
            Bar6.SetActive(true);
        }
    }

    public void StartPlayingVideo_Last()
    {
        if (player.isPlaying == false && clickNum_Last == 0)
        {
            player.Play();
            clickNum_Last++;
        }
        else
        {
            //Obj.SetActive(false);

        }
    }
}
