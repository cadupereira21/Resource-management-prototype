using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker colorPicker;
    
    [SerializeField] private GameObject menuCanvas;
    
    [SerializeField] private GameObject loadingCanvas;
    
    [SerializeField] private Slider loadingSlider;

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
    }
    
    private void Start() {
        colorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        colorPicker.onColorChanged += NewColorSelected;
        
        menuCanvas.SetActive(true);
        loadingCanvas.SetActive(false);
    }

    public void StartNewGame() {
        this.StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync() {
        menuCanvas.SetActive(false);
        loadingCanvas.SetActive(true);
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(1);
        
        if (loadAsync == null) yield break;
        do {
            loadingSlider.value = loadAsync.progress;
            yield return null;
        } while (!loadAsync.isDone);
    }

    public void ExitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
