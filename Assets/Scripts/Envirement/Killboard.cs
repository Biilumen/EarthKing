using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class Killboard : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private TMP_Text _text;

    private PlayableDirector _director;

    private void Awake()
    {
       _director = GetComponent<PlayableDirector>();
    }

    private void OnEnable()
    {
        _character.UpdateKillboard += updateKillboard;
    }
    private void OnDisable()
    {
        _character.UpdateKillboard -= updateKillboard;
    }

    private void updateKillboard()
    {
        _text.text = $"Kills: {_character.Kills}";
        _director.Play();
    }
}
