using UnityEngine;
using UnityEngine.SceneManagement;

public class fourplayer : MonoBehaviour
{
    public void FourPlayerGame()
    {
        SceneManager.LoadSceneAsync(4);
    }
}
