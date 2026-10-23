namespace Advize_PlantEverything;

using HarmonyLib;
using UnityEngine;

/// <summary>
/// Spawners are not part of the prefabs the game knows about, so they have to
/// be resolved by their hash when the world is loaded again.
/// </summary>
[HarmonyPatch(typeof(ZNetScene), nameof(ZNetScene.GetPrefab), typeof(int))]
static class SpawnerGetPrefabPatch
{
    static void Postfix(int hash, ref GameObject __result)
    {
        if (__result != null) return;

        GameObject spawner = SpawnerFactory.GetByHash(hash);

        if (spawner != null)
        {
            __result = spawner;
        }
    }
}
