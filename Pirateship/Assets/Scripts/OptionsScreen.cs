using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScreen : MonoBehaviour
{

    
    [SerializeField]
    private Slider _gameTimeSlider; 
    [SerializeField]
    private Slider _spawnTimeSlider;
    
    [SerializeField]
    private TMPro.TextMeshProUGUI _gameTimeText;
    [SerializeField]
    private TMPro.TextMeshProUGUI _spawnTimeText;
    
    [SerializeField]
    private GameConfig _gameConfig;
   

    public void WhenGameSlideChange()
    {
        _gameConfig._timeOfGame =  _gameTimeSlider.value;
        _gameTimeText.text = _gameConfig._timeOfGame.ToString();

    }
    public void WhenSpawnSlideChange()
    {
        _gameConfig._secondsToSpawn = _spawnTimeSlider.value/10;
        _spawnTimeText.text = _gameConfig._secondsToSpawn.ToString("0.0");
    }
    
    void Start()
    {
        _gameTimeSlider.value = _gameConfig._timeOfGame;
        _gameTimeText.text = _gameConfig._timeOfGame.ToString();

        _spawnTimeSlider.value = _gameConfig._secondsToSpawn * 10;
        _spawnTimeText.text = _gameConfig._secondsToSpawn.ToString("0.0");
    }

    
}
