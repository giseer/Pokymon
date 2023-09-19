using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{

    [SerializeField] private Text pokemonName;
    [SerializeField] private Text pokemonLevel;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Text pokemonHealth;
    [SerializeField] private GameObject expBar;
    

    private Pokemon _pokemon;

    public void SetPokemonData(Pokemon pokemon)
    {
        _pokemon = pokemon;
        
        pokemonName.text = pokemon.Base.Name;
        SetLevelText();
        healthBar.SetHP((float)_pokemon.Hp / _pokemon.MaxHP);
        SetExp();
        StartCoroutine(UpdatePokemonData(pokemon.Hp));
    }

    public IEnumerator UpdatePokemonData(int oldHPVal)
    {
        StartCoroutine(healthBar.SetSmoothHP((float)_pokemon.Hp / _pokemon.MaxHP));
        StartCoroutine(DecreaseHealthPoints(oldHPVal));
        yield return null;
    }

    private IEnumerator DecreaseHealthPoints(int oldHPVal)
    {
        while (oldHPVal>_pokemon.Hp)
        {
            oldHPVal--;
            pokemonHealth.text = $"{oldHPVal}/{_pokemon.MaxHP}";
            yield return new WaitForSeconds(0.1f);
        }
        pokemonHealth.text = $"{_pokemon.Hp}/{_pokemon.MaxHP}";
    }

    public void SetExp()
    {
        if (expBar == null)
        {
            return;
        }

        expBar.transform.localScale = new Vector3(NormalizedExp(), 1, 1);
    }

    public IEnumerator SetExpSmooth(bool needsToResetBar = false)
    {
        if (expBar == null)
        {
            yield break;
        }

        if (needsToResetBar)
        {
            expBar.transform.localScale = new Vector3(0, 1, 1);
        }

        yield return expBar.transform.DOScaleX(NormalizedExp(), 2f).WaitForCompletion();
    }

    float NormalizedExp()
    {

            float currentLevelExp = _pokemon.Base.GetNecessaryExpForLevel(_pokemon.Level);
            float nextLevelExp = _pokemon.Base.GetNecessaryExpForLevel(_pokemon.Level+1);
            float normalizedExp = (_pokemon.Experience - currentLevelExp) / (nextLevelExp - currentLevelExp);
            return Mathf.Clamp01(normalizedExp);
    }

    public void SetLevelText()
    {
        pokemonLevel.text = $"Lv {_pokemon.Level}";
    }
}
