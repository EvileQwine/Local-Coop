using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaLevel : MonoBehaviour
{
    public void LavaLevely()
    {
        SceneManager.LoadSceneAsync(4);
    }
}
