using Core.Data;
using UnityEngine.SceneManagement;

namespace Core.Services
{
    public static class SceneLoaderService
    {
        public static void LoadScene(SceneObject scene)
        {
            SceneManager.LoadScene(scene.SceneName);
        }
    }
}
