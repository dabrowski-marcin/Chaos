using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Chaos.Src.Engine.Handlers;
using Chaos.Src.Helpers;
using Chaos.Src.Models;
using LumenWorks.Framework.IO.Csv;
using NLog;

namespace Chaos.Engine
{
    public static class CreaturesGenerator
    {
        private static readonly Logger Log = LoggerController.Boot;
        private const string CreaturesFilePath = @"C:\Users\Marcin\ChaosMONO\Chaos\Chaos\Content\Monsters.txt";
        public static readonly List<Creature> CreatureTemplates = new List<Creature>();

        static CreaturesGenerator()
        {
            GenerateCreatureTemplatesFromFile();

        }
        public static void GenerateCreatureTemplatesFromFile()
        {
            using (CsvReader csv = new CsvReader(
                new StreamReader(CreaturesFilePath), false))
            {

                while (csv.ReadNextRecord())
                {
                    var creatureName = Convert.ToString(csv[0]);
                    Log.Debug($"Generating creature template for: {creatureName}");

                    var creature = new Creature();
                    creature.Name = Convert.ToString(csv[0]);
                    creature.InitialHitpoints = Convert.ToInt32(csv[1]);
                    creature.InitialSpellDefense = Convert.ToInt32(csv[2]);
                    creature.InitialAttack = Convert.ToInt32(csv[3]);
                    creature.InitialMovement = Convert.ToInt32(csv[4]);
                    creature.InitialRangedAttack = Convert.ToInt32(csv[5]);
                    creature.InitialRange = Convert.ToInt32(csv[6]);
                    creature.SpecialAttributes = (SpecialAttribute)BitStringToInt(csv[7]);
                    CreatureTemplates.Add(creature);
                }
            }
        }

        public static int BitStringToInt(string bits)
        {
            var reversedBits = bits.ToArray();
            var num = 0;
            for (var power = 0; power < reversedBits.Count(); power++)
            {
                var currentBit = reversedBits[power];
                if (currentBit == '1')
                {
                    var currentNum = (int)Math.Pow(2, power);
                    num += currentNum;
                }
            }

            return num;
        }
    }
}