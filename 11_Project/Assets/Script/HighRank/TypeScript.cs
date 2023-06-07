using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Blue,
    Red,
    Green
}
public enum TypeState
{
    Multiplication,
    Division,
    Nomal
}
public class TypeScript : MonoBehaviour
{
    public static TypeState CheckType(Type MyType, Type otherType)
    {
        TypeState typeState = TypeState.Nomal;
        switch (MyType)
        {
            case Type.Blue:
                switch (otherType)
                {
                    case Type.Blue: typeState = TypeState.Nomal; break;
                    case Type.Green: typeState = TypeState.Multiplication; break;
                    case Type.Red: typeState = TypeState.Division; break;
                }
            break;
            case Type.Red:
                switch(otherType)
                {
                    case Type.Blue: typeState = TypeState.Multiplication; break;
                    case Type.Red: typeState = TypeState.Nomal; break;
                    case Type.Green: typeState = TypeState.Division; break;
                }
            break;
            case Type.Green:
                switch(otherType)
                {
                    case Type.Blue: typeState = TypeState.Division; break;
                    case Type.Red: typeState = TypeState.Multiplication; break;
                    case Type.Green: typeState = TypeState.Nomal; break;
                }
            break;
        }
        return typeState;
    }

    public static int TypeDamage(int damage, Type MyType, Type otherType)
    {
        TypeState state = CheckType(MyType,otherType);
        int Damage = 0;
        switch(state)
        {
            case TypeState.Multiplication: Damage = (damage * 2);  break;
            case TypeState.Division: Damage = (damage / 2); break;
            case TypeState.Nomal: Damage = damage; break;
        }
        return Damage;
    }
}
