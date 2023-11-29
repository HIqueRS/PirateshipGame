using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Scriptables/GameConfig")]
public class GameConfig : ScriptableObject
{
    public float _timeOfGame;
    public float _secondsToSpawn;
    public bool _hasDrop;
}
