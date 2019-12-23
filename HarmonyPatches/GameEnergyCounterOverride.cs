using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony;
using TMPro;

/// <summary>
/// See https://github.com/pardeike/Harmony/wiki for a full reference on Harmony.
/// </summary>
namespace BailOutReborn.HarmonyPatches
{

    [HarmonyPatch(typeof(GameEnergyCounter))]
    [HarmonyPatch("AddEnergy")]
    [HarmonyPatch(new Type[] { typeof(float) })]
    class GameEnergyCounterOverride
    {
        static bool Prefix(ref GameEnergyCounter __instance, float value)
        {
            if (__instance.energy + value <= 1E-05f)
            {
                return false;
            }
            return true;
        }
    }
}
