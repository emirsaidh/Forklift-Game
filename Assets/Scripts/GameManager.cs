using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject menuPanel;
    public Camera vehicleCamera;
    public Camera forkCamera;

    public void OpenMenu()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }

    public void ChangeCamera()
    {
        if (vehicleCamera.enabled)
        {
            vehicleCamera.enabled = false;
            forkCamera.enabled = true;
        }else
        {
            vehicleCamera.enabled = true;
            forkCamera.enabled = false;
        }
        
    }
}
