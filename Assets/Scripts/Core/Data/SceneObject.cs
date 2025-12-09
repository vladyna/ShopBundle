using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif
namespace Core.Data
{
    [CreateAssetMenu(menuName = "BundleShop/Core/SceneObject", fileName = "SceneObject")]
    public class SceneObject : ScriptableObject
    {
        [SerializeField] private Object _sceneAsset;
        [SerializeField] private string _sceneName;

        public string SceneName => _sceneName;

        private void OnValidate()
        {
#if UNITY_EDITOR
            if (_sceneAsset != null)
            {
                string path = AssetDatabase.GetAssetPath(_sceneAsset);
                var scene = EditorSceneManager.GetSceneByPath(path);
                if (_sceneAsset is SceneAsset)
                {
                    _sceneName = _sceneAsset.name;
                }
            }
#endif
        }
    }
}
