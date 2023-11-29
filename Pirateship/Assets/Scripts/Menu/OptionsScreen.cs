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

    private int _minutes;
    private int _seconds;

    [SerializeField]
    private Toggle _toggle;

    public void WhenGameSlideChange()
    {
        _gameConfig._timeOfGame =  _gameTimeSlider.value;
        FormatFloatToMin();
        _gameTimeText.text = string.Concat(_minutes.ToString("00"), ":", _seconds.ToString("00"),"min");

    }
    public void WhenSpawnSlideChange()
    {
        _gameConfig._secondsToSpawn = _spawnTimeSlider.value/10;
        _spawnTimeText.text = string.Concat( _gameConfig._secondsToSpawn.ToString("0.0"), "s");
    }
    
    void Start()
    {

         _toggle.isOn = _gameConfig._hasDrop;

        _gameTimeSlider.value = _gameConfig._timeOfGame;
        FormatFloatToMin();
        _gameTimeText.text = string.Concat(_minutes.ToString("00"), ":", _seconds.ToString("00"), "min");

        _spawnTimeSlider.value = _gameConfig._secondsToSpawn * 10;
        _spawnTimeText.text = string.Concat(_gameConfig._secondsToSpawn.ToString("0.0"), "s");
    }

    private void FormatFloatToMin()
    {
        _minutes = (int)_gameConfig._timeOfGame / 60;
        _seconds = (int)_gameConfig._timeOfGame % 60;
    }

    public void HasDrop()
    {
        _gameConfig._hasDrop = _toggle.isOn;
    }
    
}
