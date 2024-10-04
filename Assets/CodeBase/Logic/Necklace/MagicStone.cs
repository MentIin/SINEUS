using CodeBase.Infrastructure.Data.PlayerData;
using NUnit.Framework;
using UnityEngine;

public class MagicStone : MonoBehaviour
{
    [SerializeField] private GameData.MagicStonesTypes stoneType;
   public void Activate()
    {
        if (stoneType == GameData.MagicStonesTypes.MeleeAttack) Debug.Log("melee");
        if (stoneType == GameData.MagicStonesTypes.SingleShot) Debug.Log("shot");
        if (stoneType == GameData.MagicStonesTypes.BoomerangAttack) return;
    }
}
