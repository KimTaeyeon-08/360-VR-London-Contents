using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class ButtonManager : MonoBehaviour
{
    public GameObject sphere;
    public VideoClip clip01;
    public VideoClip clip02;
    public GameObject button01;
    public GameObject button02;
    public GameObject button03;
  public void toVideoScene()
    {
        SceneManager.LoadScene("360LondonPlay");
    }
    public void goToPark()
    {
        button01.SetActive(false);
        button02.SetActive(true);
        sphere.GetComponent<VideoPlayer>().clip = clip02;
    }
    public void goBacktoTower()
    {
        button01.SetActive(true);
        button02.SetActive(false);
        sphere.GetComponent<VideoPlayer>().clip = clip01;
        Finish();
    }
    public void Finish()
    {
       button03.SetActive(true);
       SceneManager.LoadScene("360Menu");
    }
}
