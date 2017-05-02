using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {
    private static bool isInitialized = false;

    public static MappingStandardsToCourses Settings {
        get; private set;
    }

    private static void Initialize() {
        if (isInitialized) {
            return;
        }

        IConfigReader configReader = new WebJSONConfigReader();
        Settings = configReader.LoadSettings();

        isInitialized = true;
    }

    public void Start() {
        Initialize();

    }
}