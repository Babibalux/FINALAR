using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KF_ChangeScene : MonoBehaviour
{
    public void ChangeSceneMenu()
    {
        SceneManager.LoadScene("KF_Menu");
    }

    public void ChangeSceneGame()
    {
        SceneManager.LoadScene("FusionQuiMarcheTropBien");
    }

}
