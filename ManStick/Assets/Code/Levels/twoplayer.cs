using UnityEngine;
using UnityEngine.SceneManagement;

public class twoplayer : MonoBehaviour
{
   public void TwoPlayerGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
