using _Project.Scripts.Manager;
using _Project.Scripts.UI;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    [SerializeField] private GameHUD _gameHUD;
    [SerializeField] private UIManager _uiManager;
    
    private void Start()
    {
        _gameHUD.OnStart();
        _uiManager.OnStart();
    }
}
