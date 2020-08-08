using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeCircle : MonoBehaviour
{
    public GameObject VolumeImage;

    public void SelectVolume(int volumevalue)
    {
        switch (volumevalue)
        {

            case 0:
                VolumeImage.GetComponent<RectTransform>().rotation = new Quaternion(0, 0, 0, 0);
                MainMenuManager.ChangeVolume(volumevalue);
                break;

            case 25:
                VolumeImage.GetComponent<RectTransform>().rotation = new Quaternion(0, 0, -0.4f, 0.9f);
                MainMenuManager.ChangeVolume(volumevalue);
                break;

            case 50:
                VolumeImage.GetComponent<RectTransform>().rotation = new Quaternion(0, 0, -0.7f, 0.7f);
                MainMenuManager.ChangeVolume(volumevalue);
                break;

            case 75:
                VolumeImage.GetComponent<RectTransform>().rotation = new Quaternion(0, 0, -0.9f, 0.4f);
                MainMenuManager.ChangeVolume(volumevalue);
                break;

            case 100:
                VolumeImage.GetComponent<RectTransform>().rotation = new Quaternion(0, 0, -1, 0);
                MainMenuManager.ChangeVolume(volumevalue);
                break;
        }

    }
}
