using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UI.Common;
using System.Collections.Generic;
using UnityEngine;

namespace TBTest
{
    public class ActionBarFix
    {
        private static UnitEntityData spawn;

        public UnitEntityData CSpawn(string guid)
        {
            UnitEntityData value = Game.Instance.Player.MainCharacter.Value;
            spawn = Game.Instance.EntityCreator.SpawnUnit(ResourcesLibrary.TryGetBlueprint<BlueprintUnit>(guid), value.Position, Quaternion.LookRotation(value.OrientationDirection), Game.Instance.CurrentScene.MainState);
            spawn.Descriptor.SwitchFactions(Game.Instance.BlueprintRoot.PlayerFaction, true);
            return spawn;
        }

        [HarmonyLib.HarmonyPatch(typeof(UIUtility), "GetGroup")]
        internal static class UIUtility_GetGroup_Patch
        {
            private static void Postfix(ref List<UnitEntityData> __result)
            {
                __result.Add(spawn);
            }
        }
    }
}
