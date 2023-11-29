using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.UI;

public class EndScreen : MonoBehaviour
{

    [SerializeField]
    private GameObject _endPanel;

    [SerializeField]
    private TMPro.TextMeshProUGUI _textPoints;

    private int _endPoints;

    private void OnEnable()
    {
        GameManager.GameEnds += TurnOnPanel;
    }

    private void OnDisable()
    {
        GameManager.GameEnds -= TurnOnPanel;
        
    }

    private void TurnOnPanel()
    {
        _endPanel.SetActive(true);

        _endPoints = GameManager.Instance.GetPoints();

        _textPoints.text = string.Concat("score: ",_endPoints);
    }
}
