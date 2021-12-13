using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QModManager.API.ModLoading;
using HarmonyLib;
using Subnautica;
using UnityEngine;
using Logger = QModManager.Utility.Logger;
using SMLHelper.V2.Handlers;

namespace SlowAscend
{
    [QModCore]
    public static class SlowAscend
    {
        public static SlowAscendConfig Config { get; private set; }

        // Your patching method must have the QModPatch attribute (and must be public)
        [QModPatch]
        public static void MyInitializationMethod()
        {
            Config = OptionsPanelHandler.Main.RegisterModOptions<SlowAscendConfig>();

            // Add your patching code here
            Harmony harmony = new Harmony("SlowAscent");
            harmony.PatchAll();

            Logger.Log(Logger.Level.Info, "Patched successfully!");

        }
    }

    // Your patching method must have the QModPatch attribute (and must be public)
    [HarmonyPatch(typeof(GameInput))]
    [HarmonyPatch("GetMoveDirection")]
    internal class GameInputPatcher
    {
        [HarmonyPostfix]
        public static Vector3 GameInputGetMoveDirection(Vector3 param)
        {
            if (param.y > 0)
            {
                param.y *= SlowAscend.Config.ascentMultiplier;
            } else if (param.y < 0)
            {
                param.y *= SlowAscend.Config.descentMultiplier;
            }
            return param;

        }
    }
}
