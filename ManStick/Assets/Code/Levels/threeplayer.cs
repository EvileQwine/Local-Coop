using UnityEngine;
using UnityEngine.SceneManagement;

public class threeplayer : MonoBehaviour
{
    public void ThreePlayerGame()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
