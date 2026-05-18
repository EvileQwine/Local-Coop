using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicLevel : MonoBehaviour
{
    public void BasicLevely()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
