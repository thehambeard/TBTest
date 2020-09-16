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
            Game.Instance.Player.PartyCharacters.Add(spawn);
            return spawn;
        }
    }
}
