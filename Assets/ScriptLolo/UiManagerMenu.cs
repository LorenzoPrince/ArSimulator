using UnityEngine;
using UnityEngine.SceneManagement;
public class UiManagerMenu : MonoBehaviour
{ 
    public void OnStartButtonClicked()
    {

        SceneManager.LoadScene("SampleScene");
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();

    }
}