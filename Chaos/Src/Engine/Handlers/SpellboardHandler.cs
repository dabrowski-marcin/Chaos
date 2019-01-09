using Chaos.Engine;
using Chaos.Models;
using Chaos.Src.Helpers;
using Chaos.Src.Models;
using NLog;
using NLog.Fluent;

namespace Chaos.Src.Engine.Handlers
{
    public class SpellboardHandler : ISpellboardHandler
    {
        private readonly ISpellboard spellboard;
        private readonly IGameboard gameboard;
        private static readonly Logger Log = LoggerController.Spellboard;

        public SpellboardHandler(ISpellboard spellboard, IGameboard gameboard)
        {
            this.spellboard = spellboard;
            this.gameboard = gameboard;
        }

        public void Update()
        {
            if (InputHandler.LeftButtonReleased)
            {
                var point = InputHandler.Position;
                var screenPart = ScreenManager.GetClickedScreenPart(point.ToPoint());
                // 576x576
                switch (screenPart)
                {
                    case ScreenPart.Gameboard:
                    {
                        if (PhaseHandler.GamePhase == Phase.Spellcasting)
                        {
                            var tile = gameboard.GetTile(point.ToPoint());
                            var currentPlayer = PhaseHandler.CurrentPlayer;
                            var selectedSpell = currentPlayer.SelectedSpell;
                            if (selectedSpell == null)
                            {
                                Log.Debug($"{currentPlayer.Name} has not selected any spell.");
                                PhaseHandler.ChangeTurn();
                                break;
                            }

                            tile.animationType = SpellAnimationType.Casting;
                            tile.Update(Spellcasting.Creation(currentPlayer.SelectedSpell));
                            Log.Debug(
                                $"{currentPlayer.Name} is trying to cast spell {selectedSpell.Name} at POS: {tile.Position}");
                            PhaseHandler.ChangeTurn();
                        }
                        break;
                    }

                    case ScreenPart.Spellboard:
                        Log.Debug($"Player {PhaseHandler.CurrentPlayer.Name} is now picking a spell!");
                        var spellTile = spellboard.GetSpellTile(point.ToPoint());
                        PhaseHandler.CurrentPlayer.SelectedSpell = spellTile.Spell;
                        SoundPlayer.PlaySound(SoundType.Click);
                        Log.Debug($"Player {PhaseHandler.CurrentPlayer.Name} has selected {spellTile.Spell.Name}");
                        PhaseHandler.ChangeTurn();
                        break;

                    case ScreenPart.Undefined:
                        break;
                }
            }
        }
    }
}