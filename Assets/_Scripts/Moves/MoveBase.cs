using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Pokemon/Nuevo Movimiento")]
public class MoveBase : ScriptableObject
{
    [SerializeField] private string name;
    public string Name => name;

    [TextArea][SerializeField] private string description;
    public string Description => description;

    [SerializeField] private PokemonType type;
    [SerializeField] private int power;
    [SerializeField] private int accuracy;
    [SerializeField] private int pp;
    [SerializeField] private MoveType moveType;
    [SerializeField] private MoveStatEffect effects;
    [SerializeField] private MoveTarget target;

    public PokemonType Type => type;
    public int Power => power;
    public int Accuracy => accuracy;
    public int Pp => pp;
    public MoveType MoveType => moveType;
    public MoveStatEffect Effects => effects;
    public MoveTarget Target => target;

    public bool IsSpecialMove => moveType == MoveType.Special;
    
    /*if (type == PokemonType.Fire || type == PokemonType.Water || 
        type == PokemonType.Grass || type == PokemonType.Ice || 
        type == PokemonType.Electric || type == PokemonType.Dragon || 
        type == PokemonType.Dark || type == PokemonType.Psychic)
    {
        return true;
    }
    else
    {
        return false;
    }*/
}

public enum MoveType
{
    Physical,
    Special,
    Stats
}

[Serializable]
public class MoveStatEffect
{
    [SerializeField] private List<StatBoosting> boostings;

    public List<StatBoosting> Boostings => boostings;
}

[Serializable]
public class StatBoosting
{
    public Stat stat;
    public int boost;
    public MoveTarget target;
}

public enum MoveTarget
{
    Self,
    Other
}
