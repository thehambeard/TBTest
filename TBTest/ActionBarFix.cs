using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UI.ActionBar;
using Kingmaker.UI.Common;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace TBTest
{
    public class ActionBarFix
    {
        
        [HarmonyLib.HarmonyPatch(typeof(ActionBarManager), "CheckTurnPanelView")]
        internal static class ActionBarManager_CheckTurnPanelView_Patch
        {
            private static void Postfix(ActionBarManager __instance)
            {
                Main.Logger.Log(MethodBase.GetCurrentMethod().ToString());
                HarmonyLib.Traverse.Create(__instance).Method("ShowTurnPanel").GetValue();
            }
        }
    }
}
