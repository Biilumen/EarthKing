using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private List<Character> _characters;
    [SerializeField] private List<TMP_Text> _texts;

    private void OnEnable()
    {
        for (int i = 0; i < _characters.Count; i++)
        {
            _characters[i].ScoreChange += Sort;
        }
    }


    private void OnDisable()
    {
        for (int i = 0; i < _characters.Count; i++)
        {
            _characters[i].ScoreChange -= Sort;
        }
    }

    private void Start()
    {
         ShowInfo();
    }

    private void Sort()
    {
        _characters = _characters.OrderByDescending(character => character.Score).ToList();
        ShowInfo();
    }

    private void ShowInfo()
    {
        for (int i = 0; i < _texts.Count; i++)
        {
            _texts[i].text = $"{i + 1}. {_characters[i].Name} {_characters[i].Score}";
            _texts[i].color = _characters[i].Color;
            _characters[i].Crown.SetActive(false);

            if (i == 0) 
                _characters[i].Crown.SetActive(true);

            if (_characters[i].IsAlive != true)
            {
                _texts[i].text = $"<s>{i + 1}. {_characters[i].Name} {_characters[i].Score}</s>";
                _texts[i].color = Color.gray;
            }
        }
    }
}