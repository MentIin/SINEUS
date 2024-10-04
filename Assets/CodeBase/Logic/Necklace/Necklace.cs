using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services;

public class Necklace : MonoBehaviour
{
    private static Necklace _instance;
    public static Necklace Container => _instance ?? (_instance = new Necklace());

    public List<MagicStone> activeStones=new List<MagicStone>();
}
