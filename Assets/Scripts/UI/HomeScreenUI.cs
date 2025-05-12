using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HomeScreenUI : MonoBehaviour
{
    //HomeScreen UI References 
    [SerializeField] private GameObject infoPanel;

    [SerializeField] Button playGameButton;
    [SerializeField] Button quitGameButton;
    [SerializeField] Button howToPlayButton;
    [SerializeField] Button closeInfoButton;

    private bool isInfoPanelOpen = false;
    private void Start()
    {
        playGameButton.onClick.AddListener(PlayGame);
        closeInfoButton.onClick.AddListener(ShowInfoPanelStatus);
        howToPlayButton.onClick.AddListener(ShowInfoPanelStatus);
        quitGameButton.onClick.AddListener(QuitGame);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level");
    }
    public void ShowInfoPanelStatus()
    {
        isInfoPanelOpen = !isInfoPanelOpen;
        infoPanel.SetActive(isInfoPanelOpen);
    }
    public void CloseInfoPanel()
    {
        isInfoPanelOpen = false;
        infoPanel.gameObject.SetActive(isInfoPanelOpen);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
