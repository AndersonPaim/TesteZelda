using _Project.Scripts.UI;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    [SerializeField] private GameHUD _gameHUD;
			
    private void Start()
    {
        _gameHUD.OnStart();
    }
}
