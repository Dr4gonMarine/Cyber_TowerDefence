using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneNavigationManager : MonoBehaviour
{
   public void LoadScene(string sceneName)
   {
      SceneManager.LoadScene(sceneName);
   }  

   public void LoadNextScene()
   {
      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentSceneIndex + 1);
   }

   public void ReloadScene()
   {
      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentSceneIndex);
   }

   public void ReturnToMenu(){
      SceneManager.LoadScene(0);
   }

    public void QuitGame()
   {
      Application.Quit();
   }
}
