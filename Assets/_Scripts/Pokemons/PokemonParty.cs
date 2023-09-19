using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PokemonParty : MonoBehaviour
{
    [SerializeField] private List<Pokemon> pokemons;
    public const int NUM_MAX_POKEMON_IN_PARTY = 6;

    public List<Pokemon> Pokemons
    {
        get => pokemons;
    }

    private void Start()
    {
        foreach (var pokemon in pokemons)
        {
            pokemon.InitPokemon();
        }
    }

    public Pokemon GetFirstNonFaintedPokemon()
    {
        return pokemons.Where(p => p.Hp > 0).FirstOrDefault();
    }

    public int GetPositionFromPokemon(Pokemon pokemon)
    {
        for (int i = 0; i < Pokemons.Count; i++)
        {
            if (pokemon == Pokemons[i])
            {
                return i;
            }
        }
        
        return -1;
    }

    public bool AddPokemonToParty(Pokemon pokemon)
    {
        if (pokemons.Count < NUM_MAX_POKEMON_IN_PARTY)
        {
            pokemons.Add(pokemon);
            return true;
        }
        else
        {
            //TODO: Añadir la funcionalidad de enviar al PC de Bill
            return false;
        }
    }
}
