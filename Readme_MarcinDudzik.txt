Readme for project of Marcin Dudzik 

Engine/CharacterClasses/Player.cs
Changed code of get/set Properties of Strength, Armor, Precision, MagicPower and Stamina
There were situations in which Monsters could not reduce armor(or any other) stat
of player even when we had it on more than 0, it was like this because monster 
were applying their StatPackage class debuffs only to base stats of player, not stats
with items on him. That is why I needed to make changes here.

Engine/Items/FrostSet/FrostArmor.cs
Class for my frost Armor item
This item gives defensive buff for 50% resistance vs armor reduction effects

Engine/Items/FrostSet/FrostyStarWand.cs
Class for my frost armor Wand(class Staff) item
Item applies -12 precision debuff on enemy with every attack

Engine/Items/FrostSet/OldBook.cs
My OldBook item(class Staff, factory FrostSet)
Item doubles base MagicPower of wielder

Engine/Items/FrostSet/RustyFrozenSpear.cs
Spear item(class Spear, factory FrostSet)
Item gives reistance to fire type precision and magic power damage debuffs

Engine/Items/ItemFactories/FrostSetFactory.cs
My factory for frost set of items
Its just creating items of my frost set, all 3 required functions implemented

Engine/Monsters/ArcanePortal.cs
My ArcanePortal monster, it begins chain with GnomeMage appearing
It strikes very strong strike once then can no longer harm player, 
it is like test to pass to start encounter, very low health (1 shot from player)

Engine/Monsters/GnomeMage.cs
GnomeMage monster, appears from ArcanePortal after destroying it
Few different types of attacks

Engine/Monsters/FireSphere.cs
My Fire Sphere monster, working similarly to ArcanePortal
does 1 strong attack at start then lacks of stamina,
low health so 1 shot from player to start encounter of FireDrake

Engine/Monsters/FireDrake.cs
FireDrake appears from FireSphere after destroying it,
Few different types of attacks

Engine/Monsters/Phoenix.cs
Strong monster
Appears from Fire Drake, few different types of attacks
regains stamina when at 0 

Engine/Monsters/MonsterFactories/ArcaneFactory.cs
Factory to create ArcanePortal and GnomeMage

Engine/Monsters/MonsterFactories/FireDrakesFactory.cs
Factory to create FireSphere/Drake/Phoenix chain event

Engine/Skills/ElementalSpells/Blizzard.cs
Water spell - deals dmg and has RNG on chance to reducing strength of enemy

Engine/Skills/ElementalSpells/BlizzardDecorator.cs
Decorator for Blizzard skill

Engine/Skills/ElementalSpells/EarthShield.cs
Earth spell - gives temporary shield to player (for the rest of combat)
Shield is temporary increasing HP of player

Engine/Skills/ElementalSpells/EarthShieldDecorator.cs
Decorator for EarthShield

Engine/Skills/ElementalSpells/LightningChain.cs
Fire spell - deals high amount of damage, has RNG chance to crit
and deal double damage

Engine/Skills/ElementalSpells/LightningChainDecorator.cs
Decorator for LightningChain skill

Engine/Skills/SkillFactories/ElementalSpellFactory.cs
Factory for my 3 own designed elemental spells, 
Allow to make Combo but only to rank 2

Engine/GameSession.cs
added new directory Game.Engine.Skills.ElementalSpells

Engine/Index.cs
added new directory Game.Engine.Items.FrostSet
added new ElementalSpellFactory() to magicSkillFactories
added new items: RustyFrozenSpear(), FrostArmor(), FrostyStarWand(), OldBook() to
weaponSkillFactories
added to itemFactories: FrostSetFactory()
added to monsterFactories: ArcaneFactory(), FireDrakesFactory()

Added in directory Display/Assets:
item1700-item1703
monster1700-monster1704
Those are new images of my monsters and items itroduced to game