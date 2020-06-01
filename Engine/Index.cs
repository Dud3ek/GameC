using System;
using System.Collections.Generic;
using Game.Engine.Skills.SkillFactories;
using Game.Engine.Monsters.MonsterFactories;
using Game.Engine.Items;
using Game.Engine.Items.ItemFactories;
using Game.Engine.Items.BasicArmor;
using Game.Engine.Interactions;
using Game.Engine.Interactions.InteractionFactories;
using Game.Engine.Items.FrostSet;

namespace Game.Engine
{
    // contains information about skills, items and monsters that will be available in the game
    public partial class Index
    {
        private static List<SkillFactory> magicSkillFactories = new List<SkillFactory>()
        {
            new BasicSpellFactory(),
            new ElementalSpellFactory()
        };

        private static List<SkillFactory> weaponSkillFactories = new List<SkillFactory>()
        {
            new BasicWeaponMoveFactory()
        };

        private static List<Item> items = new List<Item>()
        {
            new BasicStaff(),
            new BasicSpear(),
            new BasicAxe(),
            new BasicSword(),
            new SteelArmor(),
            new AntiMagicArmor(),
            new BerserkerArmor(),
            new GrowingStoneArmor(),
            new RustyFrozenSpear(),
            new FrostArmor(),
            new FrostyStarWand(),
            new OldBook()
        };

        private static List<ItemFactory> itemFactories = new List<ItemFactory>()
        {
            new BasicArmorFactory(),
            new FrostSetFactory()
        };

        private static List<MonsterFactory> monsterFactories = new List<MonsterFactory>()
        {
            new Monsters.MonsterFactories.RatFactory(),
            new Monsters.MonsterFactories.ArcaneFactory(),
            new Monsters.MonsterFactories.FireDrakesFactory()
        };

        private static List<InteractionFactory> interactionFactories = new List<InteractionFactory>()
        {
            new SkillForgetFactory(),
            new GymirHymirFactory(),
            new CaveFactory(),
            new SmugglerFactory(),
            new ArenaFactory()
        };

    }
}
