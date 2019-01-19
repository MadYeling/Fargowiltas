using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.NPCs
{
    [AutoloadHead]
    public class Mutant : ModNPC
    {
        public static bool shop1;
        public static bool shop2;
        public static bool shop3;
        public static int shopnum = 1;

        public override bool Autoload(ref string name)
        {
            name = "Mutant";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mutant");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;

            npc.defense = NPC.downedMoonlord ? 50 : 15;

            npc.lifeMax = NPC.downedMoonlord ? 5000 : 250;

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
            Main.npcCatchable[npc.type] = true;
            npc.catchItem = (short)mod.ItemType("Mutant");

            /*if(ModLoader.GetMod("FargowiltasSouls") != null)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModLoader.GetMod("FargowiltasSouls").ItemType("Masochist");
            }*/
        }

        #region other mod bools

        //thorium bools
        public bool ThoriumDownedBird => ThoriumMod.ThoriumWorld.downedThunderBird;
        public bool ThoriumDownedJelly => ThoriumMod.ThoriumWorld.downedJelly;
        public bool ThoriumDownedStorm => ThoriumMod.ThoriumWorld.downedStorm;
        public bool ThoriumDownedChamp => ThoriumMod.ThoriumWorld.downedChampion;
        public bool ThoriumDownedScout => ThoriumMod.ThoriumWorld.downedScout;
        public bool ThoriumDownedStrider => ThoriumMod.ThoriumWorld.downedStrider;
        public bool ThoriumDownedBeholder => ThoriumMod.ThoriumWorld.downedFallenBeholder;
        public bool ThoriumDownedLich => ThoriumMod.ThoriumWorld.downedLich;
        public bool ThoriumDownedAbyss => ThoriumMod.ThoriumWorld.downedDepthBoss;
        public bool ThoriumDownedRag => ThoriumMod.ThoriumWorld.downedRealityBreaker;

        //calamity bools
        public bool CalamityDownedScourge => CalamityMod.CalamityWorld.downedDesertScourge;
        public bool CalamityDownedHive => CalamityMod.CalamityWorld.downedHiveMind;
        public bool CalamityDownedPerfor => CalamityMod.CalamityWorld.downedPerforator;
        public bool CalamityDownedSlime => CalamityMod.CalamityWorld.downedSlimeGod;
        public bool CalamityDownedCryo => CalamityMod.CalamityWorld.downedCryogen;
        public bool CalamityDownedBrim => CalamityMod.CalamityWorld.downedBrimstoneElemental;
        public bool CalamityDownedCalamitas => CalamityMod.CalamityWorld.downedCalamitas;
        public bool CalamityDownedLevi => CalamityMod.CalamityWorld.downedLeviathan;
        public bool CalamityDownedPlague => CalamityMod.CalamityWorld.downedPlaguebringer;
        public bool CalamityDownedGuardian => CalamityMod.CalamityWorld.downedGuardians;
        public bool CalamityDownedProv => CalamityMod.CalamityWorld.downedProvidence;
        public bool CalamityDownedDOG => CalamityMod.CalamityWorld.downedDoG;
        public bool CalamityDownedYharon => CalamityMod.CalamityWorld.downedYharon;
        public bool CalamityDownedSCAL => CalamityMod.CalamityWorld.downedSCal;
        public bool CalamityDownedRav => CalamityMod.CalamityWorld.downedScavenger;
        public bool CalamityDownedCrab => CalamityMod.CalamityWorld.downedCrabulon;
        public bool CalamityDownedAstrum => CalamityMod.CalamityWorld.downedStarGod;
        public bool CalamityDownedBirb => CalamityMod.CalamityWorld.downedBumble;
        public bool CalamityDownedPolter => CalamityMod.CalamityWorld.downedPolterghast;
        public bool CalamityDownedAquatic => CalamityMod.CalamityWorld.downedAquaticScourge;
        public bool CalamityDownedAstragel => CalamityMod.CalamityWorld.downedAstrageldon;

        //sacred tools bools
        public bool SacredDownedHarpy => SacredTools.ModdedWorld.downedHarpy;
        public bool SacredDownedHarpy2 => SacredTools.ModdedWorld.downedRaynare;
        public bool SacredDownedAbbadon => SacredTools.ModdedWorld.OblivionSpawns;
        public bool SacredDownedSerpent => SacredTools.ModdedWorld.FlariumSpawns;
        public bool SacredDownedLunar => SacredTools.ModdedWorld.downedLunarians;
        public bool SacredDownedPump => SacredTools.ModdedWorld.downedPumpboi;

        //grealm bools
        public bool GRealmDownedFolivine => GRealm.MWorld.downedFolivine;
        public bool GRealmDownedMantid => GRealm.MWorld.downedMatriarch;

        //pumpking
        public bool PumpkingDownedHorse => Pumpking.PumpkingWorld.downedPumpkingHorseman;
        public bool PumpkingDownedTerra => Pumpking.PumpkingWorld.downedTerraLord;

        //joost
        public bool JoostDownedCactuar => JoostMod.JoostWorld.downedJumboCactuar;
        public bool JoostDownedSAX => JoostMod.JoostWorld.downedSAX;
        public bool JoostDownedGilga => JoostMod.JoostWorld.downedGilgamesh;

        //tremor
        public bool TremorDownedCorn => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.EvilCorn];
        public bool TremorDownedRukh => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Rukh];
        public bool TremorDownedFungus => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.FungusBeetle];
        public bool TremorDownedWhale => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.SpaceWhale];
        public bool TremorDownedTrinity => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Trinity];
        public bool TremorDownedTotem => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.TikiTotem];
        public bool TremorDownedJelly => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.StormJellyfish];
        public bool TremorDownedCyber => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.CyberKing];
        public bool TremorDownedHeater => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.HeaterofWorlds];
        public bool TremorDownedFrost => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.FrostKing];
        public bool TremorDownedEmperor => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.DarkEmperor];
        public bool TremorDownedPixie => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.PixieQueen];
        public bool TremorDownedAlchemaster => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Alchemaster];
        public bool TremorDownedBrutallisk => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Brutallisk];
        public bool TremorDownedCog => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.CogLord];
        public bool TremorDownedWall => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.WallOfShadow];
        public bool TremorDownedMotherboard => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Motherboard];
        public bool TremorDownedDragon => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.AncientDragon];
        public bool TremorDownedAndas => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Andas];

        //spirit
        public bool SpiritDownedScarab => SpiritMod.MyWorld.downedScarabeus;
        public bool SpiritDownedFlier => SpiritMod.MyWorld.downedAncientFlier;
        public bool SpiritDownedRaider => SpiritMod.MyWorld.downedRaider;
        public bool SpiritDownedInfer => SpiritMod.MyWorld.downedInfernon;
        public bool SpiritDownedDusking => SpiritMod.MyWorld.downedDusking;
        public bool SpiritDownedIlluminant => SpiritMod.MyWorld.downedIlluminantMaster;
        public bool SpiritDownedAtlas => SpiritMod.MyWorld.downedAtlas;
        public bool SpiritDownedOverseer => SpiritMod.MyWorld.downedOverseer;
        public bool SpiritDownedVine => SpiritMod.MyWorld.downedReachBoss;
        public bool SpiritDownedUmbra => SpiritMod.MyWorld.downedSpiritCore;

        //BTFA
        public bool BtfaTitan => ForgottenMemories.TGEMWorld.downedTitanRock;
        public bool BtfaAcheron => ForgottenMemories.TGEMWorld.downedAcheron;
        public bool BtfaArtery => ForgottenMemories.TGEMWorld.downedArterius;
        public bool BtfaGhastly => ForgottenMemories.TGEMWorld.downedGhastlyEnt;

        //Bluemagics
        public bool BlueDownedPhantom => Bluemagic.BluemagicWorld.downedPhantom;
        public bool BlueDownedAbom => Bluemagic.BluemagicWorld.downedAbomination;

        //Eota
        public bool AncientsDownedWorms => EchoesoftheAncients.AncientWorld.downedWyrms;

        //Crystilium
        public bool CrystiliumDownedKing => CrystiliumMod.CrystalWorld.downedCrystalKing;

        //exodus
        public bool ExodusDownedAbom => Exodus.ExodusWorld.downedExodusAbomination;
        public bool ExodusDownedBlob => Exodus.ExodusWorld.downedExodusEvilBlob;
        public bool ExodusDownedColoss => Exodus.ExodusWorld.downedExodusColossus;
        public bool ExodusDownedEmperor => Exodus.ExodusWorld.downedExodusDesertEmperor;
        public bool ExodusDownedHive => Exodus.ExodusWorld.downedExodusHivemind;
        public bool ExodusDownedMaster => Exodus.ExodusWorld.downedExodusMaster;
        public bool ExodusDownedHeart => Exodus.ExodusWorld.downedExodusSludgeheart;

        //W1K
        public bool W1KDownedKutku => W1KModRedux.MWorld.downedKutKu;
        public bool W1KDownedArdorix => W1KModRedux.MWorld.downedArdorix;
        public bool W1KDownedArborix => W1KModRedux.MWorld.downedArborix;
        public bool W1KDownedAquatix => W1KModRedux.MWorld.downedAquatix;
        public bool W1KDownedIvy => W1KModRedux.MWorld.downedIvy;
        public bool W1KDownedDeath => W1KModRedux.MWorld.downedDeath;
        public bool W1KDownedRathalos => W1KModRedux.MWorld.downedRathalos;
        public bool W1KDownedRidley => W1KModRedux.MWorld.downedRidley;
        public bool W1KDownedOkiku => W1KModRedux.MWorld.downedOkiku;

        //fernium
        /*public bool FerniumDownedMargrama => Fernium.world.downedMargrama;
        public bool FerniumDownedLunarRex => Fernium.world.downedLunarRex;
        public bool FerniumFernite => Fernium.world.downedFerniteTheUnpleasant;*/

        //elements awoken
        public bool ElementsDownedWaste => ElementsAwoken.MyWorld.downedWasteland;
        public bool ElementsDownedInfern => ElementsAwoken.MyWorld.downedInfernace;
        public bool ElementsDownedScourge => ElementsAwoken.MyWorld.downedScourgeFighter;
        public bool ElementsDownedReg => ElementsAwoken.MyWorld.downedRegaroth;
        public bool ElementsDownedCelestial => ElementsAwoken.MyWorld.downedCelestial;
        public bool ElementsDownedObsid => ElementsAwoken.MyWorld.downedObsidious;
        public bool ElementsDownedPerma => ElementsAwoken.MyWorld.downedPermafrost;
        public bool ElementsDownedAque => ElementsAwoken.MyWorld.downedAqueous;
        public bool ElementsDownedEye => ElementsAwoken.MyWorld.downedEye;
        public bool ElementsDownedDragon => ElementsAwoken.MyWorld.downedAncientDragon;
        public bool ElementsDownedGuardian => ElementsAwoken.MyWorld.downedGuardian;
        public bool ElementsDownedVoid => ElementsAwoken.MyWorld.downedVoidLeviathan;

        //antiaris
        public bool AntiarisDownedAntlion => Antiaris.AntiarisWorld.DownedAntlionQueen;
        public bool AntiarisDownedKeeper => Antiaris.AntiarisWorld.DownedTowerKeeper;

        //disarray
        public bool DisarrayDownedPlant => Disarray.DisarrayWorld.downedPlantKing;
        public bool DisarrayDownedCrusher => Disarray.DisarrayWorld.downedDesertCrusher;
        public bool DisarrayDownedProbe => Disarray.DisarrayWorld.downedProbeMother;
        public bool DisarrayDownedGeneral => Disarray.DisarrayWorld.downedTheGeneral;
        public bool DisarrayDownedSerpent => Disarray.DisarrayWorld.downedLunarSerpent;
        public bool DisarrayDownedCold => Disarray.DisarrayWorld.downedColdBoss;
        public bool DisarrayDownedShadows => Disarray.DisarrayWorld.downedShadows;
        public bool DisarrayDownedLuna => Disarray.DisarrayWorld.downedLuna;
        public bool DisarrayDownedBell => Disarray.DisarrayWorld.downedBell;
        public bool DisarrayDownedMech => Disarray.DisarrayWorld.downedMech;
        public bool DisarrayDownedSludge => Disarray.DisarrayWorld.downedCosmicSludge;
        public bool DisarrayDownedDeva => Disarray.DisarrayWorld.downedCoreOfTheDevastator;
        public bool DisarrayDownedMeteor => Disarray.DisarrayWorld.downedMeteorzoid;
        public bool DisarrayDownedDungeon => Disarray.DisarrayWorld.downedDungeon;

        //cookie
        public bool CookieDownedCookie => CookieMod.CookieModWorld.downedCookieBoss;
        public bool CookieDownedBunny => CookieMod.CookieModWorld.downedBunny;

        //enigma
        public bool EnigmaDownedAnnih => Laugicality.LaugicalityWorld.downedAnnihilator;
        public bool EnigmaDownedSlyber => Laugicality.LaugicalityWorld.downedSlybertron;
        public bool EnigmaDownedTrain => Laugicality.LaugicalityWorld.downedSteamTrain;
        public bool EnigmaDownedShark => Laugicality.LaugicalityWorld.downedDuneSharkron;
        public bool EnigmaDownedHypo => Laugicality.LaugicalityWorld.downedHypothema;
        public bool EnigmaDownedRagnar => Laugicality.LaugicalityWorld.downedRagnar;
        public bool EnigmaDownedRocks => Laugicality.LaugicalityWorld.downedRocks;
        public bool EnigmaDownedEther => Laugicality.LaugicalityWorld.downedTrueEtheria;
        public bool EnigmaDownedDio => Laugicality.LaugicalityWorld.downedAnDio;

        //trelamium 
        public bool TrelamiumAzolinth => TrelamiumMod.TrelamiumModWorld.downedAzolinth;
        public bool TrelamiumSerpent => TrelamiumMod.TrelamiumModWorld.downedCrystallineSerpent;
        public bool TrelamiumCumulor => TrelamiumMod.TrelamiumModWorld.downedCumulor;
        public bool TrelamiumParadox => TrelamiumMod.TrelamiumModWorld.downedParadoxHive;
        public bool TrelamiumPermafrost => TrelamiumMod.TrelamiumModWorld.downedPermafrost;
        public bool TrelamiumGoliath => TrelamiumMod.TrelamiumModWorld.downedPholiotaGoliath;
        public bool TrelamiumPyron => TrelamiumMod.TrelamiumModWorld.downedPyron;
        public bool TrelamiumSymphony => TrelamiumMod.TrelamiumModWorld.downedSymphony;

        //Ancients Awakened
        public bool AAMonarch => AAMod.AAWorld.downedMonarch;
        public bool AAGrips => AAMod.AAWorld.downedGrips;
        public bool AABrood => AAMod.AAWorld.downedBrood;
        public bool AAHydra => AAMod.AAWorld.downedHydra;
        public bool AARetriever => AAMod.AAWorld.downedRetriever;
        public bool AARaider => AAMod.AAWorld.downedRaider;
        public bool AAOrthrus => AAMod.AAWorld.downedOrthrus;
        public bool AAEquinox => AAMod.AAWorld.downedEquinox;
        public bool AAYamata => AAMod.AAWorld.downedYamata;
        public bool AAYamataA => AAMod.AAWorld.downedYamata && Main.expertMode;
        public bool AAAkuma => AAMod.AAWorld.downedAkuma;
        public bool AAAkumaA => AAMod.AAWorld.downedAkuma && Main.expertMode;
        public bool AAZero => AAMod.AAWorld.downedZero;
        public bool AAZeroA => AAMod.AAWorld.downedZero && Main.expertMode;
        public bool AAShen => AAMod.AAWorld.downedShen;
        public bool AAShenA => AAMod.AAWorld.downedShen && Main.expertMode;
        public bool AAIZ => AAMod.AAWorld.downedIZ;

        //pinky
        public bool PinkySlime => pinkymod.Global.Pinkyworld.downedMythrilSlime;
        public bool PinkyValdaris => pinkymod.Global.Pinkyworld.downedValdaris;
        public bool PinkySunlight => pinkymod.Global.Pinkyworld.downedSunlightTrader;
        public bool PinkyAbyssmal => pinkymod.Global.Pinkyworld.downedAbyssmalDuo;

        //Redemption
        public bool RedeChicken => Redemption.RedeWorld.downedKingChicken;
        public bool RedeKeeper => Redemption.RedeWorld.downedTheKeeper;
        public bool RedeXeno => Redemption.RedeWorld.downedXenomiteCrystal;
        public bool RedeEye => Redemption.RedeWorld.downedInfectedEye;
        public bool RedePortal => Redemption.RedeWorld.downedStrangePortal;
        public bool RedeGigipede=> Redemption.RedeWorld.downedVlitch2;
        public bool RedeCleaver => Redemption.RedeWorld.downedVlitch1;
        public bool RedeSlayer => Redemption.RedeWorld.downedSlayer;

        #endregion other mod bools

        public override bool CanTownNPCSpawn(int numTownNpcs, int money) => FargoWorld.downedBoss;

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(9))
            {
                case 0:
                    return "Flacken";

                case 1:
                    return "Dorf";

                case 2:
                    return "Bingo";

                case 3:
                    return "Hans";

                case 4:
                    return "Fargo";

                case 5:
                    return "Grim";

                case 6:
                    return "Furgo";

                case 7:
                    return "Fargu";

                default:
                    return "Polly";
            }
        }

        public override string GetChat()
        {
            if (NPC.downedMoonlord && Fargowiltas.instance.fargoLoaded && Main.rand.Next(28) == 0)
            {
                return "Now that you've defeated the big guy, I'd say it's time to start collecting those materials! ;)";
            }

            if (Main.bloodMoon)
            {
                switch (Main.rand.Next(1))
                {
                    case 0:
                        return "Lovely night, isn't it?";

                    default:
                        return "I hope the constant arguing I'm hearing isn't my fault.";
                }
            }

            if (BirthdayParty.PartyIsUp)
            {
                return "I don't know what everyone's so happy about, but as long as nobody mistakes me for a Pigronata, I'm happy too.";
            }

            //specific other npc quotes
            int nurse = NPC.FindFirstNPC(NPCID.Nurse);
            int witchDoctor = NPC.FindFirstNPC(NPCID.WitchDoctor);
            int dryad = NPC.FindFirstNPC(NPCID.Dryad);
            int stylist = NPC.FindFirstNPC(NPCID.Stylist);
            int guide = NPC.FindFirstNPC(NPCID.Guide);
            int tax = NPC.FindFirstNPC(NPCID.TaxCollector);
            int truffle = NPC.FindFirstNPC(NPCID.Truffle);
            int cyborg = NPC.FindFirstNPC(NPCID.Cyborg);

            if (nurse >= 0 && Main.rand.Next(27) == 0)
            {
                return "Whenever we're alone, " + Main.npc[nurse].GivenName + " keeps throwing syringes at me, no matter how many times I tell her to stop!";
            }
            if (witchDoctor >= 0 && Main.rand.Next(26) == 0)
            {
                return "Please go tell " + Main.npc[witchDoctor].GivenName + " to drop the 'mystical' shtick, I mean, come on! I get it, you make tainted water or something.";
            }
            if (dryad >= 0 && Main.rand.Next(25) == 0)
            {
                return "Why does " + Main.npc[dryad].GivenName + "'s outfit make my wings flutter?";
            }
            if (stylist >= 0 && Main.rand.Next(24) == 0)
            {
                return Main.npc[stylist].GivenName + " once gave me a wig... I look hideous with long hair.";
            }
            if (truffle >= 0 && Main.rand.Next(23) == 0)
            {
                return "That mutated mushroom seems like my type of fella.";
            }
            if (tax >= 0 && Main.rand.Next(22) == 0)
            {
                return Main.npc[tax].GivenName + " keeps asking me for money, but he won't accept my spawners!";
            }
            if (guide >= 0 && Main.rand.Next(21) == 0)
            {
                return "Any idea why " + Main.npc[guide].GivenName + " is always cowering in fear when I get near him?";
            }
            if (truffle >= 0 && witchDoctor >= 0 && cyborg >= 0 && Main.rand.Next(20) == 0)
            {
                return "If any of us could play instruments, I'd totally start a band with " + Main.npc[witchDoctor].GivenName + ", " + Main.npc[truffle].GivenName + ", and " + Main.npc[cyborg].GivenName + ".";
            }
            /* (Fargowiltas.instance.aaLoaded && Main.rand.Next(28) == 0 && AAZero == true)
            {
                return "I'm not gonna lie, that Zero thing kinda freaks me out.";
            }
            if (Fargowiltas.instance.aaLoaded && Main.rand.Next(29) == 0 && AAZeroA == true)
            {
                return "I know my bosses, but that...thing that came out of Zero...I've never seen anything like it before. Good job killin' it though.";
            }*/

            if (Main.dayTime != true && Main.rand.Next(10) == 0)
            {
                return "I'd follow and help, but I'd much rather sit around right now.";
            }

            switch (Main.rand.Next(19))
            {
                case 0:
                    return "Savagery, barbarism, bloodthirst, that's what I like seeing in people.";
                case 1:
                    return "The stronger you get, the more stuff I sell. Makes sense, right?";
                case 2:
                    return "There's something all of you have that I don't... Death perception, I think it's called?";
                case 3:
                    return "It would be pretty cool if I could sell a summon for myself...";
                case 4:
                    return "The only way to get stronger is to keep buying from me and in bulk too!";
                case 5:
                    return "What's that? You want to fight me? ...you're not worthy you rat.";
                case 6:
                    return "Don't bother with anyone else, all you'll ever need is right here.";
                case 7:
                    return "You're lucky I'm on your side.";
                case 8:
                    return "Thanks for the house, I guess.";
                case 9:
                    return "Why yes I would love a ham and swiss sandwich.";
                case 10:
                    return "Should I start wearing clothes? ...Nah.";
                case 11:
                    return "It's not like I can actually use all the gold you're spending.";
                case 12:
                    return "Violence for violence is the law of the beast.";
                case 13:
                    return "Those guys really need to get more creative. All of their first bosses are desert themed!";
                case 14:
                    return "I am proud to be known as the Mutant, but thank Fargo I'm no Abominationn";
                case 15:
                    return "I'm all you need for a calamity.";
                case 16:
                    return "Everything shall bow before me! ...after you make this purchase.";
                case 17:
                    return "It's clear that I'm helping you out, but uh.. what's in this for me? A house you say? I eat zombies for breakfast.";
                default:
                    return "Cthulhu's got nothing on me!";
            }
        }

        /*
        //will he ever sell souls ? idk
        -oh is that a soul of the universe? Fascinating I'll get all mine from the back
        -Oh wow is that a speed soul. I coulda sold you one man
        -all souls need one
        "I know, I know, these souls look really pricy, buy I'm selling them at a loss here! Nobody would buy them otherwise! What a ripoff!"


        Ancients Awakened will have a lot of bosses. May need it’s own tab all together. Mutant should be annoyed by this. 
        -Eliza
        “Damn fish, making me add another page to my store...”
        fish = Alphakip
        */

        public override void SetChatButtons(ref string button, ref string button2)
        {
            switch (shopnum)
            {
                case 1:
                    button = "Pre Hardmode";
                    break;
                case 2:
                    button = "Hardmode";
                    break;
                default:
                    button = "Post Moon Lord";
                    break;
            }

            if (Main.hardMode)
            {
                button2 = "Cycle Shop";
            }

            if (NPC.downedMoonlord)
            {
                if (shopnum >= 4)
                {
                    shopnum = 1;
                }
            }
            else
            {
                if (shopnum >= 3)
                {
                    shopnum = 1;
                }
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;

                switch (shopnum)
                {
                    case 1:
                        shop1 = true;
                        shop2 = false;
                        shop3 = false;
                        break;
                    case 2:
                        shop2 = true;
                        shop1 = false;
                        shop3 = false;
                        break;
                    default:
                        shop3 = true;
                        shop1 = false;
                        shop2 = false;
                        break;
                }
            }

            if (!firstButton && Main.hardMode)
            {
                shopnum++;
            }
        }

        private void AddItem(bool check, string mod, string item, int price, ref Chest shop, ref int nextSlot)
        {
            if (!check) return;
            shop.item[nextSlot].SetDefaults(ModLoader.GetMod(mod).ItemType(item));
            shop.item[nextSlot].value = price;
            nextSlot++;
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            #region PREHARDMODE BOSSES

            if (shop1)
            {
                AddItem(true, "Fargowiltas", "Overloader", 500000, ref shop, ref nextSlot);

                if(Fargowiltas.instance.fargoLoaded)
                {
                    AddItem(true, "FargowiltasSouls", "PandorasBox", 250000, ref shop, ref nextSlot);
                }

                //goblin king - true eater

                if (Fargowiltas.instance.redemptionLoaded)
                {
                    //The Mighty King Chicken
                    AddItem(RedeChicken, "Redemption", "EggCrown", 2000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.aaLoaded)
                {
                    //Mushroom Monarch
                    AddItem(AAMonarch, "AAMod", "IntimidatingMushroom", 2000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.exodusLoaded)
                {
                    AddItem(ExodusDownedAbom, "Exodus", "ZombieMeat", 20000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {
                    //Scarabeus
                    AddItem(SpiritDownedScarab, "SpiritMod", "ScarabIdol", 20000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedPlant, "Disarray", "YoungSapling", 20000, ref shop, ref nextSlot);
                }

                if(Fargowiltas.instance.trelamiumLoaded)
                {
                    AddItem(TrelamiumGoliath, "TrelamiumMod", "MycelialCluster", 20000, ref shop, ref nextSlot);
                }

                //antlion queen - true eater

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    //Grand Thunderbird
                    AddItem(ThoriumDownedBird, "ThoriumMod", "StormFlare", 50000, ref shop, ref nextSlot);
                }
                
                //Slime King
                AddItem(NPC.downedSlimeKing, "Fargowiltas", "SlimyCrown", 60000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedCrusher, "Disarray", "ScorpionIdol", 60000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Desert Scourge
                    AddItem(CalamityDownedScourge, "CalamityMod", "DriedSeafood", 60000, ref shop, ref nextSlot);
                }
                
                //Eye of Cthulhu
                AddItem(NPC.downedBoss1, "Fargowiltas", "SuspiciousEye", 80000, ref shop, ref nextSlot);

                if(Fargowiltas.instance.aaLoaded)
                {
                    //Grips of Chaos
                    AddItem(AAGrips, "AAMod", "CuriousClaw", 80000, ref shop, ref nextSlot);
                    AddItem(AAGrips, "AAMod", "InterestingClaw", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.redemptionLoaded)
                {
                    //Keeper
                    if (WorldGen.crimson)
                    {
                        AddItem(RedeKeeper, "Redemption", "MysteriousTabletCrimson", 80000, ref shop, ref nextSlot);
                    }
                    else
                    {
                        AddItem(RedeKeeper, "Redemption", "MysteriousTabletCorrupt", 80000, ref shop, ref nextSlot);
                    }
                }

                if (Fargowiltas.instance.w1kLoaded)
                {
                    AddItem(W1KDownedKutku, "W1KModRedux", "GoldenFeather", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedShark, "Laugicality", "TastyMorsel", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.exodusLoaded)
                {
                    AddItem(ExodusDownedColoss, "Exodus", "GraniteAnomaly", 80000, ref shop, ref nextSlot);
                    AddItem(ExodusDownedBlob, "Exodus", "DisgustingJelly", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedHypo, "Laugicality", "ChilledMesh", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedProbe, "Disarray", "ProbeCaller", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedRagnar, "Laugicality", "MoltenMess", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedWaste, "ElementsAwoken", "WastelandSummon", 80000, ref shop, ref nextSlot);
                }

                //The Spirit - Split

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Rukh
                    AddItem(TremorDownedRukh, "Tremor", "DesertCrown", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Crabulon
                    AddItem(CalamityDownedCrab, "CalamityMod", "DecapoditaSprout", 80000, ref shop, ref nextSlot);
                }
                
                //Eater of Worlds
                AddItem(NPC.downedBoss2, "Fargowiltas", "WormyFood", 100000, ref shop, ref nextSlot);
                //Brain of Cthulhu
                AddItem(NPC.downedBoss2, "Fargowiltas", "GoreySpine", 100000, ref shop, ref nextSlot);

                if(Fargowiltas.instance.aaLoaded)
                {
                    //Broodmother
                    AddItem(AABrood, "AAMod", "DragonBell", 100000, ref shop, ref nextSlot);
                    //Hydra
                    AddItem(AAHydra, "AAMod", "HydraChow", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.redemptionLoaded)
                {
                    //Strange Portal
                    AddItem(RedePortal, "Redemption", "UnstableCrystal", 100000, ref shop, ref nextSlot);
                    AddItem(RedePortal, "Redemption", "GeigerCounter", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.cookieLoaded)
                {
                    AddItem(CookieDownedCookie, "CookieMod", "BloodyCookie", 100000, ref shop, ref nextSlot);
                    AddItem(CookieDownedCookie, "CookieMod", "CursedCookie", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.trelamiumLoaded)
                {
                    AddItem(TrelamiumCumulor, "TrelamiumMod", "StormyCloud", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    //Queen Jellyfish
                    AddItem(ThoriumDownedJelly, "ThoriumMod", "JellyfishResonator", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Tiki Totem
                    AddItem(TremorDownedTotem, "Tremor", "MysteriousDrum", 100000, ref shop, ref nextSlot);
                }

                //One Shot -Split

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Evil Corn
                    AddItem(TremorDownedCorn, "Tremor", "CursedPopcorn", 100000, ref shop, ref nextSlot);
                }

                /*if (Fargowiltas.instance.ferniumLoaded)
                {
                    AddItem(FerniumDownedMargrama, "Fernium", "LunarFlame", 100000, ref shop, ref nextSlot);
                }
                */
                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedGeneral, "Disarray", "TornBattleArmor", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Perforators
                    AddItem(CalamityDownedPerfor, "CalamityMod", "BloodyWormFood", 100000, ref shop, ref nextSlot);
                    //Hive Mind
                    AddItem(CalamityDownedHive, "CalamityMod", "Teratoma", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.grealmLoaded)
                {
                    //Folvine
                    AddItem(GRealmDownedFolivine, "GRealm", "JungleBait", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Storm Jellyfish
                    AddItem(TremorDownedJelly, "Tremor", "StormJelly", 100000, ref shop, ref nextSlot);
                }

                //Clampula - True Eater

                if (Fargowiltas.instance.spiritLoaded)
                {
                    AddItem(SpiritDownedVine, "SpiritMod", "ReachBossSummon", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Ancient Dragon
                    AddItem(TremorDownedDragon, "Tremor", "RustyLantern", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.exodusLoaded)
                {
                    AddItem(ExodusDownedEmperor, "Exodus", "AncientArtifact", 100000, ref shop, ref nextSlot);
                }
                //Queen Bee
                AddItem(NPC.downedQueenBee, "Fargowiltas", "Abeemination2", 150000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedSerpent, "Disarray", "MoonStone", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.nightmaresLoaded)
                {
                    AddItem(NPC.downedBoss3, "TrueEater", "SpitterSpawner", 150000, ref shop, ref nextSlot);
                }

                //magnoliac - btfa ?

                if (Fargowiltas.instance.spiritLoaded)
                {
                    AddItem(SpiritDownedFlier, "SpiritMod", "JewelCrown", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.antiarisLoaded)
                {
                    AddItem(AntiarisDownedAntlion, "Antiaris", "AntlionDoll", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.sacredToolsLoaded)
                {
                    //Flaming Pumpkin
                    AddItem(SacredDownedPump, "SacredTools", "PumpkinLantern", 150000, ref shop, ref nextSlot);
                }
                //Skeletron
                AddItem(NPC.downedBoss3, "Fargowiltas", "SuspiciousSkull", 150000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.cookieLoaded)
                {
                    AddItem(CookieDownedBunny, "CookieMod", "BunnyCrown ", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.trelamiumLoaded)
                {
                    AddItem(TrelamiumSymphony, "TrelamiumMod", "LamentedPearl", 150000, ref shop, ref nextSlot);
                }
                
                if(Fargowiltas.instance.pinkyLoaded)
                {
                    AddItem(PinkySunlight, "pinkymod", "STItem", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.w1kLoaded)
                {
                    AddItem(W1KDownedIvy, "W1KModRedux", "CursedFlower", 150000, ref shop, ref nextSlot);
                    AddItem(W1KDownedArdorix, "W1KModRedux", "FieryEgg", 150000, ref shop, ref nextSlot);
                    AddItem(W1KDownedArborix, "W1KModRedux", "GrassyEgg", 150000, ref shop, ref nextSlot);
                    AddItem(W1KDownedAquatix, "W1KModRedux", "WateryEgg", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {
                    //Starplate Raider
                    AddItem(SpiritDownedRaider, "SpiritMod", "StarWormSummon", 150000, ref shop, ref nextSlot);
                }

                //the cluster -peculiarity

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    //Granite Core
                    AddItem(ThoriumDownedStorm, "ThoriumMod", "UnstableCore", 150000, ref shop, ref nextSlot);
                }

                /*if (Fargowiltas.instance.ferniumLoaded)
                {
                    AddItem(FerniumDownedMargrama, "Fernium", "HardenedSludge", 150000, ref shop, ref nextSlot);
                }*/

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedInfern, "ElementsAwoken", "InfernaceSummon", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedCold, "Disarray", "PermaFreeze", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Slime God
                    AddItem(CalamityDownedSlime, "CalamityMod", "OverloadedSludge", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.btfaLoaded)
                {
                    AddItem(BtfaAcheron, "ForgottenMemories", "Unstable_Wisp", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Heater of Worlds
                    AddItem(TremorDownedHeater, "Tremor", "MoltenHeart", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.sacredToolsLoaded)
                {
                    AddItem(SacredDownedHarpy, "SacredTools", "HarpySummon", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    //Buried Champion
                    AddItem(ThoriumDownedChamp, "ThoriumMod", "AncientBlade", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedDio, "Laugicality", "AncientAwakener", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Fungus Beetle
                    AddItem(TremorDownedFungus, "Tremor", "MushroomCrystal", 150000, ref shop, ref nextSlot);
                }

                //alpha cactus worm - joost

                if (Fargowiltas.instance.exodusLoaded)
                {
                    AddItem(ExodusDownedHive, "Exodus", "VineSerpent", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    //Star Scouter
                    AddItem(ThoriumDownedScout, "ThoriumMod", "StarCaller", 150000, ref shop, ref nextSlot);
                }
                
                //Wall of Flesh
                AddItem(Main.hardMode, "Fargowiltas", "FleshyDoll", 250000, ref shop, ref nextSlot);
                //All Pre-HM bosses
                AddItem(Main.hardMode, "Fargowiltas", "DeathBringerFairy", 500000, ref shop, ref nextSlot);
            }

            #endregion PREHARDMODE BOSSES

            #region HARDMODE BOSSES

            else if (shop2)
            {
                AddItem(true, "Fargowiltas", "Overloader", 500000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.redemptionLoaded)
                {
                    AddItem(RedeEye, "Redemption", "XenoEye", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    //Borean Strider
                    AddItem(ThoriumDownedStrider, "ThoriumMod", "StriderTear", 250000, ref shop, ref nextSlot);
                }

                /*if(Fargowiltas.instance.ferniumLoaded)
                {
                    AddItem(FerniumFernite, "Fernium", "FerniumCore ", 250000, ref shop, ref nextSlot);
                }*/

                if (Fargowiltas.instance.trelamiumLoaded)
                {
                    AddItem(TrelamiumPyron, "TrelamiumMod", "SolarMandibleTotem", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.btfaLoaded)
                {
                    AddItem(BtfaArtery, "ForgottenMemories", "BloodClot", 250000, ref shop, ref nextSlot);
                }

                if(Fargowiltas.instance.antiarisLoaded)
                {
                    AddItem(AntiarisDownedKeeper, "Antiaris", "PocketCursedMirror", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Alchemaster
                    AddItem(TremorDownedAlchemaster, "Tremor", "AncientMosaic", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {
                    //Infernon
                    AddItem(SpiritDownedInfer, "SpiritMod", "CursedCloth", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Cryogen
                    AddItem(CalamityDownedCryo, "CalamityMod", "CryoKey", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedShadows, "Disarray", "EnhancedShadowFragment", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.exodusLoaded)
                {
                    AddItem(ExodusDownedMaster, "Exodus", "GlowingSkull", 250000, ref shop, ref nextSlot);
                }

                //ichor blaster/ grasper - true eater

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    //Coznix
                    AddItem(ThoriumDownedBeholder, "ThoriumMod", "VoidLens", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.btfaLoaded)
                {
                    AddItem(BtfaTitan, "ForgottenMemories", "anomalydetector", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.w1kLoaded)
                {
                    AddItem(W1KDownedRathalos, "W1KModRedux", "MysteryTicket", 250000, ref shop, ref nextSlot);
                    AddItem(W1KDownedRidley, "W1KModRedux", "MetroidCapsule", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.aaLoaded)
                {
                    //Retriever
                    AddItem(AARetriever, "AAMod", "CyberneticClaw", 250000, ref shop, ref nextSlot);
                    //Raider Ultima
                    AddItem(AARaider, "AAMod", "CyberneticBell", 250000, ref shop, ref nextSlot);
                    //Orthrus X
                    AddItem(AAOrthrus, "AAMod", "ScrapHeap", 250000, ref shop, ref nextSlot);
                    //All Storm bosses
                    //AddItem((AARetriever && AARaider && AAOrthrus), "Fargowiltas", "CyberneticAmalgam", 600000, ref shop, ref nextSlot);
                }
                
                //Destroyer
                AddItem(NPC.downedMechBoss1, "Fargowiltas", "MechWorm", 400000, ref shop, ref nextSlot);
                //Twins
                AddItem(NPC.downedMechBoss2, "Fargowiltas", "MechEye", 400000, ref shop, ref nextSlot);
                //Skeletron Prime
                AddItem(NPC.downedMechBoss3, "Fargowiltas", "MechSkull", 400000, ref shop, ref nextSlot);
                //All Mechs
                AddItem((NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3), "Fargowiltas", "MechanicalAmalgam", 1000000, ref shop, ref nextSlot);
                
                //Ogre
                AddItem(FargoWorld.downedBetsy, "Fargowiltas", "BatteredClub", 400000, ref shop, ref nextSlot);

                if(Fargowiltas.instance.pinkyLoaded)
                {
                    AddItem(PinkySlime, "pinkymod", "MythrilGel", 400000, ref shop, ref nextSlot);
                }
                
                if (Fargowiltas.instance.trelamiumLoaded)
                {
                    AddItem(TrelamiumPermafrost, "TrelamiumMod", "TemporalLens", 400000, shop: ref shop, nextSlot: ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {
                    //Dusking
                    AddItem(SpiritDownedDusking, "SpiritMod", "DuskCrown", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedLuna, "Disarray", "MastersPresent", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Brimstone Elemental
                    AddItem(CalamityDownedBrim, "CalamityMod", "CharredIdol", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {
                    //Etheral Umbra
                    AddItem(SpiritDownedUmbra, "SpiritMod", "UmbraSummon", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Motherboard
                    AddItem(TremorDownedMotherboard, "Tremor", "MechanicalBrain", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedBell, "Disarray", "ABell", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Aquatic Scourge
                    AddItem(CalamityDownedAquatic, "CalamityMod", "Seafood", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedAnnih, "Laugicality", "MechanicalMonitor", 400000, ref shop, ref nextSlot);
                    AddItem(EnigmaDownedSlyber, "Laugicality", "SteamCrown ", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedScourge, "ElementsAwoken", "ScourgeFighterSummon", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedReg, "ElementsAwoken", "RegarothSummon", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedTrain, "Laugicality", "SuspiciousTrainWhistle", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedMech, "Disarray", "MechPrism", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.sacredToolsLoaded)
                {
                    AddItem(SacredDownedHarpy2, "SacredTools", "HarpySummon2", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    //Lich
                    AddItem(ThoriumDownedLich, "ThoriumMod", "LichCatalyst", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Fairy Queen
                    AddItem(TremorDownedPixie, "Tremor", "PixieinaJar", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Calamitas
                    AddItem(CalamityDownedCalamitas, "CalamityMod", "BlightedEyeball", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {  
                    //Illumant Master
                    AddItem(SpiritDownedIlluminant, "SpiritMod", "ChaosFire", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.w1kLoaded)
                {
                    AddItem(W1KDownedOkiku, "W1KModRedux", "OminousMask", 400000, ref shop, ref nextSlot);
                }
                
                //Plantera
                AddItem(NPC.downedPlantBoss, "Fargowiltas", "Plantera", 500000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.redemptionLoaded)
                {
                    AddItem(RedeSlayer, "Redemption", "KingSummon", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.pinkyLoaded)
                {
                    AddItem(PinkyValdaris, "pinkymod", "ValdarisItem", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Leviathan
                    AddItem(CalamityDownedLevi, "Fargowiltas", "LeviathanSummon", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.exodusLoaded)
                {
                    AddItem(ExodusDownedHeart, "Exodus", "JungleCrown", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedEther, "Laugicality", "EmblemOfEtheria", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {  
                    //Frost King
                    AddItem(TremorDownedFrost, "Tremor", "FrostCrown", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Astrageldon
                    AddItem(CalamityDownedAstragel, "CalamityMod", "AstralChunk", 500000, ref shop, ref nextSlot);
                    //Astrum Deus
                    AddItem(CalamityDownedAstrum, "CalamityMod", "Starcore", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Wall of Shadows
                    AddItem(TremorDownedWall, "Tremor", "ShadowRelic", 500000, ref shop, ref nextSlot);
                }
                
                //Golem
                AddItem(NPC.downedGolemBoss, "Fargowiltas", "LihzahrdPowerCell2", 600000, ref shop, ref nextSlot);
                
                //Betsy
                AddItem(FargoWorld.downedBetsy, "Fargowiltas", "BetsyEgg", 600000, ref shop, ref nextSlot);
                
                if(Fargowiltas.instance.pinkyLoaded)
                {
                    AddItem(PinkyAbyssmal, "pinkymod", "MindGodItem", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedCelestial, "ElementsAwoken", "CelestialSummon", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedPerma, "ElementsAwoken", "PermafrostSummon", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedObsid, "ElementsAwoken", "ObsidiousSummon", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    //Abyssion
                    AddItem(ThoriumDownedAbyss, "Fargowiltas", "AbyssionSummon", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Cog Lord
                    AddItem(TremorDownedCog, "Tremor", "ArtifactEngine", 600000, ref shop, ref nextSlot);
                    //Mothership/Cyber King
                    AddItem(TremorDownedCyber, "Tremor", "AdvancedCircuit", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.nightmaresLoaded)
                {
                    AddItem(NPC.downedPlantBoss, "TrueEater", "MimicKey", 600000, ref shop, ref nextSlot);
                }

                //the ancient - exodus

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Plaguebringer Goliath
                    AddItem(CalamityDownedPlague, "CalamityMod", "Abomination", 600000, ref shop, ref nextSlot);
                }

                //behemoth - true eater

                if (Fargowiltas.instance.crystiliumLoaded)
                {
                    //Crystal King
                    AddItem(CrystiliumDownedKing, "CrystiliumMod", "CrypticCrystal", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.w1kLoaded)
                {
                    AddItem(W1KDownedDeath, "W1KModRedux", "DungeonMasterGuide", 600000, ref shop, ref nextSlot);
                }

                AddItem(NPC.downedFishron, "Fargowiltas", "TruffleWorm2", 600000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.blueMagicLoaded)
                {
                    AddItem(BlueDownedPhantom, "Bluemagic", "PaladinEmblem", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedAque, "ElementsAwoken", "AqueousSummon", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.pumpkingLoaded)
                {
                    AddItem(PumpkingDownedHorse, "Pumpking", "PumpkingSoul", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {   
                    //Atlas
                    AddItem(SpiritDownedAtlas, "SpiritMod", "StoneSkin", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Ravager
                    AddItem(CalamityDownedRav, "CalamityMod", "AncientMedallion", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.blueMagicLoaded)
                {
                    AddItem(BlueDownedAbom, "Bluemagic", "FoulOrb", 600000, ref shop, ref nextSlot);
                }
                //Lunatic Cultist
                AddItem(NPC.downedAncientCultist, "Fargowiltas", "CultistSummon", 750000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedEye, "ElementsAwoken", "EyeSummon", 750000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedDragon, "ElementsAwoken", "AncientDragonSummon", 750000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.redemptionLoaded)
                {
                    AddItem(RedeCleaver, "Redemption", "CorruptedHeroSword", 750000, ref shop, ref nextSlot);
                    AddItem(RedeGigipede, "Redemption", "CorruptedWormMedallion", 750000, ref shop, ref nextSlot);
                }
                
                //Lunar Pillars
                AddItem(NPC.downedTowers, "Fargowiltas", "PillarSummon", 750000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedGuardian, "ElementsAwoken", "GuardianSummon", 750000, ref shop, ref nextSlot);
                }
                
                //Moon Lord
                AddItem(NPC.downedMoonlord, "Fargowiltas", "CelestialSigil2", 1000000, ref shop, ref nextSlot);
                //All Vanilla Bosses
                AddItem(NPC.downedMoonlord, "Fargowiltas", "MutantVoodoo", 2000000, ref shop, ref nextSlot);
            }

            #endregion HARDMODE BOSSES

            #region POST MOONLORD BOSSES

            else
            {
                AddItem(true, "Fargowiltas", "Overloader", 500000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.aaLoaded)
                {
                    //Equinox Worms
                    AddItem(AAEquinox, "AAMod", "EquinoxWorm", 1000000, ref shop, ref nextSlot);
                    //Akuma
                    AddItem(AAAkuma, "AAMod", "DraconianSigil", 1000000, ref shop, ref nextSlot);
                    //Akuma Awakened
                    AddItem(AAAkumaA, "AAMod", "DraconianRune", 1000000, ref shop, ref nextSlot);
                    //Yamata
                    AddItem(AAYamata, "AAMod", "DreadSigil", 1000000, ref shop, ref nextSlot);
                    //Yamata Awakened
                    AddItem(AAYamataA, "AAMod", "DreadRune", 1000000, ref shop, ref nextSlot);
                }
                
                if (Fargowiltas.instance.trelamiumLoaded)
                {
                    AddItem(TrelamiumAzolinth, "TrelamiumMod", "PlanetaryBeacon", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedSludge, "Disarray", "VileSlimeBall", 1000000, ref shop, ref nextSlot);
                }
                if (Fargowiltas.instance.spiritLoaded)
                {
                    //Overseer
                    AddItem(SpiritDownedOverseer, "SpiritMod", "SpiritIdol", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.pumpkingLoaded)
                {
                    AddItem(PumpkingDownedTerra, "Pumpking", "TerraCore", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    AddItem(TremorDownedEmperor, "Tremor", "EmperorCrown", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.trelamiumLoaded)
                {
                    AddItem(TrelamiumParadox, "TrelamiumMod", "WarpedMirror", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedVoid, "ElementsAwoken", "VoidLeviathanSummon", 1000000, ref shop, ref nextSlot);
                }

                //abomination rematch - blue

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Brutalisk
                    AddItem(TremorDownedBrutallisk, "Tremor", "RoyalEgg", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.sacredToolsLoaded)
                {   
                    //Abbadon
                    AddItem(SacredDownedAbbadon, "SacredTools", "ShadowWrathSummonItem", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Profaned Guardians
                    AddItem(CalamityDownedGuardian, "CalamityMod", "ProfanedShard", 5000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.joostLoaded)
                {
                    //Cactuar
                    AddItem(JoostDownedCactuar, "JoostMod", "Cactusofdoom", 5000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    //Space Whale
                    AddItem(TremorDownedWhale, "Tremor", "CosmicKrill", 5000000, ref shop, ref nextSlot);
                    //Trinity
                    AddItem(TremorDownedTrinity, "Tremor", "StoneofKnowledge", 5000000, ref shop, ref nextSlot);
                    //Andas
                    AddItem(TremorDownedAndas, "Tremor", "InfernoSkull", 5000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedDeva, "Disarray", "EyeOfSouls", 5000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Providence
                    AddItem(CalamityDownedProv, "CalamityMod", "ProfanedCore", 10000000, ref shop, ref nextSlot);
                }

                //void marshal -true eater

                if (Fargowiltas.instance.sacredToolsLoaded)
                {
                    AddItem(SacredDownedSerpent, "SacredTools", "SerpentSummon", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.grealmLoaded)
                {
                    //Mantid Matriarch
                    AddItem(GRealmDownedMantid, "GRealm", "CrownOfMantodea", 10000000, ref shop, ref nextSlot);
                    //Rift Daemon - When he's released
                }

                if (Fargowiltas.instance.joostLoaded)
                {
                    AddItem(JoostDownedSAX, "JoostMod", "InfectedArmCannon", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedMeteor, "Disarray", "RandomSpaceRock", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.sacredToolsLoaded)
                {
                    //Lunarians
                    AddItem(SacredDownedLunar, "SacredTools", "MoonEmblem", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    //Ragnorok
                    AddItem(ThoriumDownedRag, "ThoriumMod", "RagSymbol", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.ancientsLoaded)
                {
                    AddItem(AncientsDownedWorms, "EchoesoftheAncients", "Wyrm_Rune", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.joostLoaded)
                {
                    AddItem(JoostDownedGilga, "JoostMod", "Excalipoor", 15000000, ref shop, ref nextSlot);
                }

                //the challenger -sacred tools

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedDungeon, "Disarray", "DungeonAmalgamation", 15000000, ref shop, ref nextSlot);
                }

                //spirit of purity
                
                if (Fargowiltas.instance.aaLoaded)
                {
                    //Zero
                    AddItem(AAZero, "AAMod", "ZeroTesseract", 15000000, ref shop, ref nextSlot);
                    //Zero Awakened
                    AddItem(AAZeroA, "AAMod", "ZeroRune", 15000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //Bumblebirb
                    AddItem(CalamityDownedBirb, "CalamityMod", "BirbPheromones", 20000000, ref shop, ref nextSlot);
                }

                //spirit of chaos

                //spirit of purity rematch
                
                if (Fargowiltas.instance.aaLoaded)
                {
                    //Shen Doragon
                    AddItem(AAShen, "AAMod", "ChaosSigil", 20000000, ref shop, ref nextSlot);
                    //Infinity Zero
                    AddItem(AAIZ, "AAMod", "InfinityOverloader", 30000000, ref shop, ref nextSlot);
                    //Shen Doragon Awakened
                    AddItem(AAShenA, "AAMod", "ChaosRune", 40000000, ref shop, ref nextSlot);
                }
                //Pain
                AddItem(true, "Fargowiltas", "AncientSeal", 100000000, ref shop, ref nextSlot);
            }

            #endregion POST MOONLORD BOSSES
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            if (NPC.downedMoonlord)
            {
                damage = 500;
                knockback = 10f;
            }
            else if (Main.hardMode)
            {
                damage = 60;
                knockback = 5f;
            }
            else
            {
                damage = 20;
                knockback = 4f;
            }
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            if (NPC.downedMoonlord)
            {
                cooldown = 1;
            }
            else if (Main.hardMode)
            {
                cooldown = 20;
                randExtraCooldown = 25;
            }
            else
            {
                cooldown = 30;
                randExtraCooldown = 30;
            }
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            if (NPC.downedMoonlord)
            {
                projType = mod.ProjectileType("PhantasmalEyeProjectile");
            }
            else if (Main.hardMode)
            {
                projType = mod.ProjectileType("MechEyeProjectile");
            }
            else
            {
                projType = mod.ProjectileType("EyeProjectile");
            }

            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }

        public override void NPCLoot()
        {
            if (Main.rand.Next(4) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MutantGrabBag"));
            }
        }

        //gore
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 8; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.8f);
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/MutantGore3"));
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/MutantGore2"));
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/MutantGore1"));
                }
            }
            else
            {
                for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)hitDirection, -1f, 0, default(Color), 0.6f);
                }
            }
        }
    }
}
