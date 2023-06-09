using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneNavigationManager : MonoBehaviour
{
   public void LoadScene(string sceneName)
   {
      SceneManager.LoadScene(sceneName);
   }
}
