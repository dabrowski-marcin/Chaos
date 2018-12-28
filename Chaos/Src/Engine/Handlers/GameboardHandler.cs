﻿using Chaos.Engine;
using Chaos.Models;
using Chaos.Src.Models;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Chaos.Src.Engine.Handlers
{
    public class GameboardHandler : IGameboardHandler
    {
        public Tile SelectedTile { get; set; }
        private IGameboard gameboard;
        private List<ScreenPartCoordinates> _screenParts = new List<ScreenPartCoordinates>();
        
//        private bool _isInMoveMode = false;

        public GameboardHandler(IGameboard gameboard)
        {
            this.gameboard = gameboard;
            _screenParts.Add(new ScreenPartCoordinates(ScreenPart.Gameboard, new Point(0, 0), new Point(575, 575)));               
            _screenParts.Add(new ScreenPartCoordinates(ScreenPart.Spellboard, new Point(578, 0), new Point(672, 528)));              
        }

        private bool cpito(Tile targetTile)
        {
            return targetTile.Occupant != null && targetTile.Occupant.Owner == PhaseHandler.CurrentPlayer;
        }
        public void MovementAction(Tile targetTile)
        {
            if (PhaseHandler.GamePhase == Phase.Movement)
            {
                if (SelectedTile == null)
                {
                    if (CheckIfVoidOrInvalidClicked(targetTile) || !cpito(targetTile))
                    {
                        return;
                    }

                    SoundPlayer.PlaySound(SoundType.Click);
                    SelectedTile = targetTile;
                    return;
                }

                switch (CheckActionOutcome(targetTile))
                {
                    case GameboardAction.Movement:
                        if (CreatureActionHandler.Move(SelectedTile.Occupant))
                        {
                            gameboard.Move(SelectedTile.Position, targetTile.Position);
                            SoundPlayer.PlaySound(SoundType.Step);
                            SelectedTile = targetTile;

                            return;
                        }

                        break;
                }

                SelectedTile = null;
            }
        }

        public bool CheckIfVoidOrInvalidClicked(Tile clickedTile)
        {
            return (clickedTile == null || clickedTile.IsEmpty);
        }

        public GameboardAction CheckActionOutcome(Tile clickedTile)
        {
            var result = GameboardAction.None;

            if (clickedTile.IsEmpty)
            {
                result = GameboardAction.Movement;
            }

            return result;
        }


        public void Update()
        {
            if (InputHandler.LeftButtonReleased)
            {
                var point = InputHandler.Position;

                // 576x576
                switch (GetClickedScreenPart(point.ToPoint()))
                {
                    case ScreenPart.Gameboard:
                    {
                        var tile = gameboard.GetTile(point.ToPoint());
                        MovementAction(tile);
                        return;
                    }

                    case ScreenPart.Spellboard:
                        MessageBox.Show("Spellboard nigga!");
                        break;

                    case ScreenPart.Undefined:
                        break;
                }
            }

            if (InputHandler.LeftButtonReleased)
            {
                SelectedTile = null;
            }
        }


        public ScreenPart GetClickedScreenPart(Point positionClicked)
        {
            var screenCoordinates = _screenParts.FirstOrDefault(x => x.Intersects(positionClicked));
            return screenCoordinates?.ScreenPart ?? ScreenPart.Undefined;
        }

        private bool CheckPartClicked(Point point, int minVal, int maxVal)
        {
            return point.X >= minVal && point.Y >= minVal && point.X <= maxVal && point.Y <= maxVal;

        }
    }
}