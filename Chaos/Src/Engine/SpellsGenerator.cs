using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Text;
using Chaos.Src.Engine.Handlers;
using Chaos.Src.Helpers;
using Chaos.Src.Models;
using LumenWorks.Framework.IO.Csv;
using NLog;

namespace Chaos.Engine
{
    public class SpellsGenerator
    {
        private static readonly Logger Log = LoggerController.Boot;
        private const string SpellsFilePath = @"C:\Users\Marcin\ChaosMONO\Chaos\Chaos\Content\Spells.txt";
        private List<Spell> AllSpells = new List<Spell>();

        public void GenerateSpells(int spellsNumber = 99)
        {
            LoadSpellsFromFile();

            foreach (var player in StateGlobals.Players)
            {
                for (int i = 0; i < spellsNumber; i++)
                {
                    var rolledSpell = RollSpell();
                    Log.Debug($"Id: {i}, Player: {player}, Spell: {rolledSpell.Name}");
                    player.Spells.Add(rolledSpell);
                }
            }
        }

        public void LoadSpellsFromFile()
        {
            using (CsvReader csv = new CsvReader(
                new StreamReader(SpellsFilePath), true))
            {

                while (csv.ReadNextRecord())
                {
                    var spellName = Convert.ToString(csv[0]);
                    Log.Debug($"Generating spell: {spellName}");

                    var spell = new Spell();
                    spell.Name = spellName;
                    spell.Power = Convert.ToInt32(csv[1]);
                    spell.Range = Convert.ToInt32(csv[2]);
                    spell.RequiresLoS = Convert.ToBoolean(csv[3]);
                    spell.Chance = Convert.ToDecimal(csv[4]);
                    spell.EffectChance = Convert.ToDecimal(csv[5]);
                    spell.Type = (SpellType)Enum.Parse(typeof(SpellType), csv[6]);
                    spell.SpellAnimationType = (SpellAnimationType)Enum.Parse(typeof(SpellAnimationType), csv[7]);

                    AllSpells.Add(spell);
                }
            }
        }

        public static Random rand = new Random();

        private Spell RollSpell()
        {
            int spellsPoolSize = 0;
            for (int i = 0; i < AllSpells.Count; i++)
            {
                spellsPoolSize += (int)AllSpells[i].Chance;
            }

            int randomNumber = rand.Next(0, spellsPoolSize) + 1;

            int accumulatedProbability = 0;
            for (int i = 0; i < AllSpells.Count; i++)
            {
                accumulatedProbability += (int)AllSpells[i].Chance;
                if (randomNumber <= accumulatedProbability)
                    return AllSpells[i];
            }
            return null;
        }


    }
}