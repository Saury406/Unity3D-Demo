using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace game_core
{

    /// <summary>
    /// Level manager class; Deals with level load 
    /// transaction.
    /// </summary>
    public class LevelManager : MonoBehaviour
    {

        protected static LevelManager instance;
        protected static string levelName = "";

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static LevelManager Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject obj = new GameObject("LevelManager");
                    instance = obj.AddComponent<LevelManager>();

                    if (instance == null)
                    {
                        Debug.LogError("An instance of is needed in the scene, but there is none.");
                    }
                }

                return instance;
            }
        }
        /// <summary>
        /// Gets or sets the loading level.
        /// </summary>
        /// <value>The loading level.</value>
        public static string loadingLevel
        {
            set { levelName = value; }
            get { return levelName; }
        }

        /// <summary>
        /// Load the specified name.
        /// </summary>
        /// <param name="name">Name.</param>
        public static void Load(string name)
        {
            Object.DontDestroyOnLoad(Instance.gameObject);
            //TimeManager.isPaused 	= false;
            loadingLevel = name;
            //SceneManager.LoadScene("loading");
            Instance.StartCoroutine(Instance.LoadingScene());
        }
        IEnumerator LoadingScene()
        {

            AsyncOperation aOperation = SceneManager.LoadSceneAsync("loading");
            // aOperation.allowSceneActivation = false;
            while (!aOperation.isDone)
            {
                if (aOperation.progress >= 0.9f)
                {
                    // aOperation.allowSceneActivation = true;
                }
                yield return null;
            }
            Instance.StartCoroutine(Instance.LoadTargetScene(loadingLevel));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerator LoadTargetScene(string name)
        {
            AsyncOperation aOperation = SceneManager.LoadSceneAsync(name);
            aOperation.allowSceneActivation = false;
            while (!aOperation.isDone)
            {
                if (aOperation.progress >= 0.9f)
                {
                    aOperation.allowSceneActivation = true;
                }
                yield return null;
            }
        }
    }
}