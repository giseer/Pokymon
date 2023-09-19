using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyMemberHUD : MonoBehaviour
{
    [SerializeField] private Text nameText, lvlText, typeText, hpText;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Image pokemonImage;

    private Pokemon _pokemon;

    public void SetPokemonData(Pokemon pokemon)
    {
        _pokemon = pokemon;

        nameText.text = pokemon.Base.Name;
        lvlText.text = $"Lv {pokemon.Level}";
        typeText.text = pokemon.Base.Type1.ToString();
        hpText.text = $"{pokemon.Hp} / {pokemon.MaxHP}";
        healthBar.SetHP((float)pokemon.Hp/pokemon.MaxHP);
        pokemonImage.sprite = pokemon.Base.FrontSprite;

        GetComponent<Image>().color = ColorManager.TypeColor.GetColorFromType(pokemon.Base.Type1);
    }
    
    public void SetSelectedPokemon(bool selected)
    {
        if (selected)
        {
            nameText.color = ColorManager.SharedInstance.SelectedColor;
        }
        else
        {
            nameText.color = Color.black;
        }
    }
}
