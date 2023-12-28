﻿using PKHeX.Core;
using System;
using System.Collections.Generic;

namespace WangPluginPkm.PluginUtil.ModifyPKM
{
    public class EncounterRaid9 : ITeraRaid9
    {
        protected ITeraRaid9 Encounter { get; set; } = null!;

        public EncounterRaid9(ITeraRaid9 encounter) => Encounter = encounter;

        public bool IsDistribution => Encounter.IsDistribution;
        public byte Index => Encounter.Index;
        public byte Stars => Encounter.Stars;
        public byte RandRate => Encounter.RandRate;
        public GemType TeraType => Encounter.TeraType;
        public bool CanBeEncountered(uint seed) => Encounter.CanBeEncountered(seed);

        public ushort Species { get => GetSpecies(); }
        public byte Form { get => GetForm(); }
        public GameVersion Version { get => GetVersion(); }
        public byte FlawlessIVCount { get => GetFlawlessIVCount(); }
        public AbilityPermission Ability { get => GetAbility(); }
        public Shiny Shiny { get => GetShiny(); }
        public Nature Nature { get => GetNature(); }
        public byte Scale { get => GetScale(); }
        public IndividualValueSet IVs { get => GetIVs(); }
        public sbyte Gender { get => GetGender(); }

        public ushort RandRateMinScarlet { get => GetRandRateMinScarlet(); }
        public ushort RandRateMinViolet { get => GetRandRateMinViolet(); }

        public static EncounterRaid9[] GetEncounters(ITeraRaid9[] encounters)
        {
            var res = new List<EncounterRaid9>();
            foreach (var encounter in encounters)
                res.Add(new EncounterRaid9(encounter));
            return res.ToArray();
        }
        public ushort GetRandRateTotalScarlet(int stage)
        {
            if (Encounter is EncounterTera9 tera)
                return 0;
            else if (Encounter is EncounterDist9 dist)
                return dist.GetRandRateTotalScarlet(stage);
            else if (Encounter is EncounterMight9 might)
                return might.GetRandRateTotalScarlet(stage);
            else if (Encounter is PKHeX.Core.EncounterTera9 h_tera)
                return 0;
            else if (Encounter is PKHeX.Core.EncounterDist9 h_dist)
                return h_dist.GetRandRateTotalScarlet(stage);
            else if (Encounter is PKHeX.Core.EncounterMight9 h_might)
                return h_might.GetRandRateTotalScarlet(stage);
            else
                return ((EncounterDist9)Encounter).GetRandRateTotalScarlet(stage);
        }

        public ushort GetRandRateTotalViolet(int stage)
        {
            if (Encounter is EncounterTera9 tera)
                return 0;
            else if (Encounter is EncounterDist9 dist)
                return dist.GetRandRateTotalViolet(stage);
            else if (Encounter is EncounterMight9 might)
                return might.GetRandRateTotalViolet(stage);
            else if (Encounter is PKHeX.Core.EncounterTera9 h_tera)
                return 0;
            else if (Encounter is PKHeX.Core.EncounterDist9 h_dist)
                return h_dist.GetRandRateTotalViolet(stage);
            else if (Encounter is PKHeX.Core.EncounterMight9 h_might)
                return h_might.GetRandRateTotalViolet(stage);
            else
                return ((EncounterDist9)Encounter).GetRandRateTotalViolet(stage);
        }

        public ushort GetRandRateMinScarlet(int stage = 0)
        {
            if (Encounter is EncounterTera9 tera)
                return (ushort)tera.RandRateMinScarlet;
            else if (Encounter is EncounterDist9 dist)
                return dist.GetRandRateMinScarlet(stage);
            else if (Encounter is EncounterMight9 might)
                return might.GetRandRateMinScarlet(stage);
            else if (Encounter is PKHeX.Core.EncounterTera9 h_tera)
                return (ushort)h_tera.RandRateMinScarlet;
            else if (Encounter is PKHeX.Core.EncounterDist9 h_dist)
                return h_dist.GetRandRateMinScarlet(stage);
            else if (Encounter is PKHeX.Core.EncounterMight9 h_might)
                return h_might.GetRandRateMinScarlet(stage);
            else
                return ((EncounterDist9)Encounter).GetRandRateMinScarlet(stage);
        }

        public ushort GetRandRateMinViolet(int stage = 0)
        {
            if (Encounter is EncounterTera9 tera)
                return (ushort)tera.RandRateMinViolet;
            else if (Encounter is EncounterDist9 dist)
                return dist.GetRandRateMinViolet(stage);
            else if (Encounter is EncounterMight9 might)
                return might.GetRandRateMinViolet(stage);
            else if (Encounter is PKHeX.Core.EncounterTera9 h_tera)
                return (ushort)h_tera.RandRateMinViolet;
            else if (Encounter is PKHeX.Core.EncounterDist9 h_dist)
                return h_dist.GetRandRateMinViolet(stage);
            else if (Encounter is PKHeX.Core.EncounterMight9 h_might)
                return h_might.GetRandRateMinViolet(stage);
            else
                return ((EncounterDist9)Encounter).GetRandRateMinViolet(stage);
        }

        private ushort GetSpecies()
        {
            if (Encounter is EncounterTera9 tera)
                return tera.Species;
            else if (Encounter is EncounterMight9 might)
                return might.Species;
            else if (Encounter is EncounterDist9 dist)
                return dist.Species;
            else if (Encounter is EncounterRaid9 raid)
                return raid.Species;
            else if (Encounter is PKHeX.Core.EncounterTera9 h_tera)
                return h_tera.Species;
            else if (Encounter is PKHeX.Core.EncounterDist9 h_dist)
                return h_dist.Species;
            else if (Encounter is PKHeX.Core.EncounterMight9 h_might)
                return h_might.Species;
            else throw new ArgumentOutOfRangeException();
        }

        private byte GetForm()
        {
            if (Encounter is EncounterTera9 tera)
                return tera.Form;
            else if (Encounter is EncounterMight9 might)
                return might.Form;
            else if (Encounter is EncounterDist9 dist)
                return dist.Form;
            else if (Encounter is EncounterRaid9 raid)
                return raid.Form;
            else if (Encounter is PKHeX.Core.EncounterTera9 h_tera)
                return h_tera.Form;
            else if (Encounter is PKHeX.Core.EncounterDist9 h_dist)
                return h_dist.Form;
            else if (Encounter is PKHeX.Core.EncounterMight9 h_might)
                return h_might.Form;
            else throw new ArgumentOutOfRangeException();
        }

        private GameVersion GetVersion()
        {
            if (Encounter is EncounterTera9 tera)
                return tera.Version;
            else if (Encounter is EncounterMight9 might)
                return might.Version;
            else if (Encounter is EncounterDist9 dist)
                return dist.Version;
            else if (Encounter is EncounterRaid9 raid)
                return raid.Version;
            else if (Encounter is PKHeX.Core.EncounterTera9 h_tera)
                return h_tera.Version;
            else if (Encounter is PKHeX.Core.EncounterDist9 h_dist)
                return h_dist.Version;
            else if (Encounter is PKHeX.Core.EncounterMight9 h_might)
                return h_might.Version;
            else throw new ArgumentOutOfRangeException();
        }

        private byte GetFlawlessIVCount()
        {
            if (Encounter is EncounterTera9 tera)
                return tera.FlawlessIVCount;
            else if (Encounter is EncounterMight9 might)
                return might.FlawlessIVCount;
            else if (Encounter is EncounterDist9 dist)
                return dist.FlawlessIVCount;
            else if (Encounter is EncounterRaid9 raid)
                return raid.FlawlessIVCount;
            else if (Encounter is PKHeX.Core.EncounterTera9 h_tera)
                return h_tera.FlawlessIVCount;
            else if (Encounter is PKHeX.Core.EncounterDist9 h_dist)
                return h_dist.FlawlessIVCount;
            else if (Encounter is PKHeX.Core.EncounterMight9 h_might)
                return h_might.FlawlessIVCount;
            else throw new ArgumentOutOfRangeException();
        }

        private AbilityPermission GetAbility()
        {
            if (Encounter is EncounterTera9 tera)
                return tera.Ability;
            else if (Encounter is EncounterMight9 might)
                return might.Ability;
            else if (Encounter is EncounterDist9 dist)
                return dist.Ability;
            else if (Encounter is EncounterRaid9 raid)
                return raid.Ability;
            else if (Encounter is PKHeX.Core.EncounterTera9 h_tera)
                return h_tera.Ability;
            else if (Encounter is PKHeX.Core.EncounterDist9 h_dist)
                return h_dist.Ability;
            else if (Encounter is PKHeX.Core.EncounterMight9 h_might)
                return h_might.Ability;
            else throw new ArgumentOutOfRangeException();
        }

        private Shiny GetShiny()
        {
            if (Encounter is EncounterTera9 tera)
                return tera.Shiny;
            else if (Encounter is EncounterMight9 might)
                return might.Shiny;
            else if (Encounter is EncounterDist9 dist)
                return dist.Shiny;
            else if (Encounter is EncounterRaid9 raid)
                return raid.Shiny;
            else if (Encounter is PKHeX.Core.EncounterTera9 h_tera)
                return h_tera.Shiny;
            else if (Encounter is PKHeX.Core.EncounterDist9 h_dist)
                return h_dist.Shiny;
            else if (Encounter is PKHeX.Core.EncounterMight9 h_might)
                return h_might.Shiny;
            else throw new ArgumentOutOfRangeException();
        }

        private Nature GetNature()
        {
            if (Encounter is EncounterTera9 tera)
                return Nature.Random;
            else if (Encounter is EncounterMight9 might)
                return might.Nature;

            else if (Encounter is EncounterRaid9 raid)
                return raid.Nature;

            else if (Encounter is EncounterMight9 h_might)
                return h_might.Nature;
            else throw new ArgumentOutOfRangeException();
        }

        private byte GetScale()
        {
            if (Encounter is EncounterTera9 tera)
                return 0;
            else if (Encounter is EncounterMight9 might)
                return might.Scale;
            else if (Encounter is EncounterDist9 dist)
                return 0;
            else if (Encounter is EncounterRaid9 raid)
                return raid.Scale;
            else if (Encounter is PKHeX.Core.EncounterTera9 h_tera)
                return 0;
            else if (Encounter is PKHeX.Core.EncounterDist9 h_dist)
                return 0;
            else if (Encounter is PKHeX.Core.EncounterMight9 h_might)
                return h_might.Scale;
            else throw new ArgumentOutOfRangeException();
        }

        private IndividualValueSet GetIVs()
        {
            if (Encounter is EncounterTera9 tera)
                return default;
            else if (Encounter is EncounterMight9 might)
                return might.IVs;
            else if (Encounter is EncounterDist9 dist)
                return default;
            else if (Encounter is EncounterRaid9 raid)
                return raid.IVs;
            else if (Encounter is PKHeX.Core.EncounterTera9 h_tera)
                return default;
            else if (Encounter is PKHeX.Core.EncounterDist9 h_dist)
                return default;
            else if (Encounter is PKHeX.Core.EncounterMight9 h_might)
                return h_might.IVs;
            else throw new ArgumentOutOfRangeException();
        }

        private sbyte GetGender()
        {
            if (Encounter is EncounterTera9 tera)
                return (sbyte)tera.Gender;
            else if (Encounter is EncounterMight9 might)
                return (sbyte)might.Gender;
            else if (Encounter is EncounterDist9 dist)
                return (sbyte)dist.Gender;
            else if (Encounter is EncounterRaid9 raid)
                return raid.Gender;
            else if (Encounter is PKHeX.Core.EncounterTera9 h_tera)
                return (sbyte)h_tera.Gender;
            else if (Encounter is PKHeX.Core.EncounterDist9 h_dist)
                return (sbyte)h_dist.Gender;
            else if (Encounter is PKHeX.Core.EncounterMight9 h_might)
                return (sbyte)h_might.Gender;
            else throw new ArgumentOutOfRangeException();
        }


    }
}
