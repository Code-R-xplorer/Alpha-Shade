using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utilities
{
    public class LevelManager : MonoBehaviour
    {
        public void MainMenuButtonClicked()
        {
            SceneManager.LoadScene("Main_Menu");
        }

        public void RetryButtonClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void StartGameButtonClicked()
        {
            SceneManager.LoadScene("Tech_Company");
        }

        public void QuitGameButtonClicked()
        {
            Application.Quit();
        }
    }
}
