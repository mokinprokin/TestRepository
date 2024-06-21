using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    // Start is called before the first frame update

    public void Load(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
