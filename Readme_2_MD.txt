Added cave for HintInteraction "interaction1700"
Added boulder as BoulderInteraction "interaction1701"
Added goblin wizard as WizardInteraction "interaction1702"

Engine\Interactions\InteractionFactories\MDFactory.cs
Factory for all 3 of my interactions, it just produces all 3 of them in proportional
manner

Engine\Interactions\MyInteractions\BoulderInteraction.cs
This is arena training event
Player can go here to spend some gold or fight some mighty creatures
so he can lvl up some base stats, only 2 fights to upgrade each base stat 
is possible, we can upgrade for gold how many times we want but it stacks 
cost really fast upwards

Engine\Interactions\MyInteractions\WizardInteraction.cs
Player enters to trade with goblin smuggler wizard
Some kind of black market items, which he propably stole
RNG chance of those items being even 2x cheaper than normally, but
also can be even 2x more expensive.
We can try to trick this goblin and steal from him some items,
if we do this he will be hating us and engage with a fight if we try to
approach him next time (first he will give us a warning)
Our attempt of stealing can go wrong and result in fight also or even losing sack of gold


Engine\Interactions\MyInteractions\HintInteraction.cs
We enter a cave and look for shiny hints, after throwing some elemental spells at them
(accessible in this cave for every player), we can collect hint, also phoenix can spawn and
attack us or we can run away, every time we make a mistake we increment fail counter,
we can fail 2 times or cave closes, we need 3 hints collected then go into cave again
to collect some random drop item