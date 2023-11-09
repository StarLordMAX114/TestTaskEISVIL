using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private int _menuScene = 0;
    private int _firstMapScene = 1;

    public void ClickMenu()
    {
        SceneManager.UnloadScene(_firstMapScene);
        SceneManager.LoadScene(_menuScene);
    }
    
    public void LoadFirstLvL()
    {
        SceneManager.UnloadScene(_menuScene);
        SceneManager.LoadScene(_firstMapScene);
    }
}
