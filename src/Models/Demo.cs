﻿using CSGO_Demos_Manager.Models.Events;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Collections.Specialized;
using CSGO_Demos_Manager.Properties;

namespace CSGO_Demos_Manager.Models
{
	public class Demo : ObservableObject
	{
		#region Properties

		/// <summary>
		/// Unique demo's ID
		/// </summary>
		private string _id;
		
		/// <summary>
		/// Name of the demo's file
		/// </summary>
		private string _name = "";

		/// <summary>
		/// Demo's date
		/// </summary>
		private string _date;

		/// <summary>
		/// Demo's source (MM, ESEA, FaceIt)
		/// </summary>
		private Source.Source _source;

		/// <summary>
		/// Used for Json
		/// </summary>
		private string _sourceName;

		/// <summary>
		/// Client's name
		/// </summary>
		private string _clientName = "";

		/// <summary>
		/// Hostname
		/// </summary>
		private string _hostname = "";

		/// <summary>
		/// Type (POV or GOTV)
		/// </summary>
		private string _type = "GOTV";

		/// <summary>
		/// Demo's tickrate (16 usually)
		/// </summary>
		private float _tickrate;

		/// <summary>
		/// Server's tickrate (64 or 128 usually)
		/// </summary>
		private float _serverTickrate;

		/// <summary>
		/// Demo duration
		/// </summary>
		private float _duration;

		/// <summary>
		/// Demo's map name
		/// </summary>
		private string _mapName;

		/// <summary>
		/// Path on Windows
		/// </summary>
		private string _path;

		/// <summary>
		/// Game win/lose/draw status
		/// </summary>
		private string _winStatus;

		/// <summary>
		/// Team 1 score
		/// </summary>
		private int _scoreTeam1;

		/// <summary>
		/// Team 2 Score
		/// </summary>
		private int _scoreTeam2;

		/// <summary>
		/// First half team 1 score
		/// </summary>
		private int _scoreFirstHalfTeam1;

		/// <summary>
		/// First half team 2 score
		/// </summary>
		private int _scoreFirstHalfTeam2;

		/// <summary>
		/// Second half team 1 score
		/// </summary>
		private int _scoreSecondHalfTeam1;

		/// <summary>
		/// Second half team 2 score
		/// </summary>
		private int _scoreSecondHalfTeam2;

		/// <summary>
		/// Number of 1K during the match
		/// </summary>
		private int _onekillCount;

		/// <summary>
		/// Number of 2K during the match
		/// </summary>
		private int _twokillCount;

		/// <summary>
		/// Number of 3K during the match
		/// </summary>
		private int _threekillCount;

		/// <summary>
		/// Number of 4K during the match
		/// </summary>
		private int _fourkillCount;

		/// <summary>
		/// Number of 5K during the match
		/// </summary>
		private int _fivekillCount;

		/// <summary>
		/// Clan tag name 1st team
		/// </summary>
		private string _clanTagNameTeam1 = "Team 1";

		/// <summary>
		/// Clan tag name 2nd team
		/// </summary>
		private string _clanTagNameTeam2 = "Team 2";

		/// <summary>
		/// User's comment
		/// </summary>
		private string _comment = "";

		/// <summary>
		/// User's custom status (none, to watch, watched)
		/// </summary>
		private string _status = "None";

		/// <summary>
		/// List of rounds during the match
		/// </summary>
		private ObservableCollection<Round> _rounds = new ObservableCollection<Round>();

		/// <summary>
		/// List of players who played during the match
		/// </summary>
		private ObservableCollection<PlayerExtended> _players = new ObservableCollection<PlayerExtended>();

		/// <summary>
		/// Infos on bomb planted during the match
		/// </summary>
		private ObservableCollection<BombPlantedEvent> _bombPlanted = new ObservableCollection<BombPlantedEvent>();

		/// <summary>
		/// Infos on bomb defused during the match
		/// </summary>
		private ObservableCollection<BombDefusedEvent> _bombDefused = new ObservableCollection<BombDefusedEvent>();

		/// <summary>
		/// Infos on bomb exploded during the match
		/// </summary>
		private ObservableCollection<BombExplodedEvent> _bombExploded = new ObservableCollection<BombExplodedEvent>();

		/// <summary>
		/// All kills during the match
		/// </summary>
		private ObservableCollection<KillEvent> _kills = new ObservableCollection<KillEvent>();

		/// <summary>
		/// Demo's overtimes
		/// </summary>
		private ObservableCollection<Overtime> _overtimes = new ObservableCollection<Overtime>();

		/// <summary>
		/// Team 1 players
		/// </summary>
		private ObservableCollection<PlayerExtended> _playersTeam1 = new ObservableCollection<PlayerExtended>();

		/// <summary>
		/// Team 2 players
		/// </summary>
		private ObservableCollection<PlayerExtended> _playersTeam2 = new ObservableCollection<PlayerExtended>();

		/// <summary>
		/// Player with the best HS ratio
		/// </summary>
		private PlayerExtended _mostHeadshotPlayer;

		/// <summary>
		/// Player with the most bomb planted
		/// </summary>
		private PlayerExtended _mostBombPlantedPlayer;

		/// <summary>
		/// Player with the most entry kill
		/// </summary>
		private PlayerExtended _mostEntryKillPlayer;

		/// <summary>
		/// Weapon with the most kills
		/// </summary>
		private Weapon _mostKillingWeapon;

		/// <summary>
		/// Contains teams of the match
		/// </summary>
		private ObservableCollection<TeamExtended> _teams = new ObservableCollection<TeamExtended>();

		#endregion

		#region Accessors

		[JsonProperty("id")]
		public string Id
		{
			get { return _id; }
			set { Set(() => Id, ref _id, value); }
		}

		[JsonProperty("name")]
		public string Name
		{
			get { return _name; }
			set { Set(() => Name, ref _name, value); }
		}

		[JsonProperty("date")]
		public string Date
		{
			get { return _date; }
			set { Set(() => Date, ref _date, value); }
		}

		[JsonIgnore]
		public Source.Source Source
		{
			get { return _source; }
			set
			{
				Set(() => Source, ref _source, value);
				SourceName = value.Name;
			}
		}

		[JsonProperty("source")]
		public string SourceName
		{
			get { return _sourceName;}
			set { Set(() => SourceName, ref _sourceName, value); }
		}
		[JsonProperty("comment")]
		public string Comment
		{
			get { return _comment; }
			set { Set(() => Comment, ref _comment, value); }
		}

		[JsonProperty("status")]
		public string Status
		{
			get { return _status; }
			set { Set(() => Status, ref _status, value); }
		}

		[JsonProperty("client_name")]
		public string ClientName
		{
			get { return _clientName; }
			set { Set(() => ClientName, ref _clientName, value); }
		}

		[JsonProperty("hostname")]
		public string Hostname
		{
			get { return _hostname; }
			set { Set(() => Hostname, ref _hostname, value); }
		}

		[JsonProperty("type")]
		public string Type
		{
			get { return _type; }
			set { Set(() => Type, ref _type, value); }
		}

		[JsonProperty("tickrate")]
		public float Tickrate
		{
			get { return _tickrate; }
			set { Set(() => Tickrate, ref _tickrate, value); }
		}

		[JsonProperty("server_tickrate")]
		public float ServerTickrate
		{
			get { return _serverTickrate; }
			set { Set(() => ServerTickrate, ref _serverTickrate, value); }
		}

		[JsonProperty("duration")]
		public float Duration
		{
			get { return _duration; }
			set
			{
				Set(() => Duration, ref _duration, value);
				RaisePropertyChanged("DurationTime");
			}
		}

		[JsonIgnore]
		public string DurationTime => TimeSpan.FromSeconds(_duration).ToString(@"hh\:mm\:ss");

		[JsonProperty("map_name")]
		public string MapName
		{
			get { return _mapName; }
			set { Set(() => MapName, ref _mapName, value); }
		}

		[JsonProperty("path")]
		public string Path
		{
			get { return _path; }
			set { Set(() => Path, ref _path, value); }
		}

		[JsonProperty("win_status")]
		public string WinStatus
		{
			get { return _winStatus; }
			set { Set(() => WinStatus, ref _winStatus, value); }
		}

		[JsonProperty("score_team_1")]
		public int ScoreTeam1
		{
			get { return _scoreTeam1; }
			set { Set(() => ScoreTeam1, ref _scoreTeam1, value); }
		}

		[JsonProperty("score_team_2")]
		public int ScoreTeam2
		{
			get { return _scoreTeam2; }
			set { Set(() => ScoreTeam2, ref _scoreTeam2, value); }
		}

		[JsonProperty("score_first_half_team_1")]
		public int ScoreFirstHalfTeam1
		{
			get { return _scoreFirstHalfTeam1; }
			set { Set(() => ScoreFirstHalfTeam1, ref _scoreFirstHalfTeam1, value); }
		}

		[JsonProperty("score_first_half_team_2")]
		public int ScoreFirstHalfTeam2
		{
			get { return _scoreFirstHalfTeam2; }
			set { Set(() => ScoreFirstHalfTeam2, ref _scoreFirstHalfTeam2, value); }
		}

		[JsonProperty("score_second_half_team_1")]
		public int ScoreSecondHalfTeam1
		{
			get { return _scoreSecondHalfTeam1; }
			set { Set(() => ScoreSecondHalfTeam1, ref _scoreSecondHalfTeam1, value); }
		}

		[JsonProperty("score_second_half_team_2")]
		public int ScoreSecondHalfTeam2
		{
			get { return _scoreSecondHalfTeam2; }
			set { Set(() => ScoreSecondHalfTeam2, ref _scoreSecondHalfTeam2, value); }
		}

		[JsonProperty("total_kill_count")]
		public int TotalKillCount => Kills.Count;

		[JsonProperty("five_kill_count")]
		public int FiveKillCount
		{
			get { return _fivekillCount; }
			set { Set(() => FiveKillCount, ref _fivekillCount, value); }
		}

		[JsonProperty("four_kill_count")]
		public int FourKillCount
		{
			get { return _fourkillCount; }
			set { Set(() => FourKillCount, ref _fourkillCount, value); }
		}

		[JsonProperty("three_kill_count")]
		public int ThreeKillCount
		{
			get { return _threekillCount; }
			set { Set(() => ThreeKillCount, ref _threekillCount, value); }
		}

		[JsonProperty("two_kill_count")]
		public int TwoKillCount
		{
			get { return _twokillCount; }
			set { Set(() => TwoKillCount, ref _twokillCount, value); }
		}

		[JsonProperty("one_kill_count")]
		public int OneKillCount
		{
			get { return _onekillCount; }
			set { Set(() => OneKillCount, ref _onekillCount, value); }
		}

		[JsonProperty("bomb_defused_count")]
		public int BombDefusedCount => BombDefused.Count;

		[JsonProperty("bomb_exploded_count")]
		public int BombExplodedCount => BombExploded.Count();

		[JsonProperty("bomb_planted_count")]
		public int BombPlantedCount => BombPlanted.Count;

		[JsonProperty("most_killing_weapon")]
		public Weapon MostKillingWeapon
		{
			get { return _mostKillingWeapon; }
			set { Set(() => MostKillingWeapon, ref _mostKillingWeapon, value); }
		}

		[JsonProperty("clan_tag_name_team1")]
		public string ClanTagNameTeam1
		{
			get { return _clanTagNameTeam1; }
			set { Set(() => ClanTagNameTeam1, ref _clanTagNameTeam1, value); }
		}

		[JsonProperty("clan_tag_name_team2")]
		public string ClanTagNameTeam2
		{
			get { return _clanTagNameTeam2; }
			set { Set(() => ClanTagNameTeam2, ref _clanTagNameTeam2, value); }
		}

		[JsonProperty("rounds")]
		public ObservableCollection<Round> Rounds
		{
			get { return _rounds; }
			set { Set(() => Rounds, ref _rounds, value); }
		}

		[JsonProperty("players")]
		public ObservableCollection<PlayerExtended> Players
		{
			get { return _players; }
			set { Set(() => Players, ref _players, value); }
		}

		[JsonProperty("teams")]
		public ObservableCollection<TeamExtended> Teams
		{
			get { return _teams; }
			set { Set(() => Teams, ref _teams, value); }
		}

		[JsonProperty("overtimes")]
		public ObservableCollection<Overtime> Overtimes
		{
			get { return _overtimes; }
			set { Set(() => Overtimes, ref _overtimes, value); }
		}

		[JsonProperty("most_headshot_player")]
		public PlayerExtended MostHeadshotPlayer
		{
			get { return _mostHeadshotPlayer; }
			set { Set(() => MostHeadshotPlayer, ref _mostHeadshotPlayer, value); }
		}

		[JsonProperty("most_bomb_planted_player")]
		public PlayerExtended MostBombPlantedPlayer
		{
			get { return _mostBombPlantedPlayer; }
			set { Set(() => MostBombPlantedPlayer, ref _mostBombPlantedPlayer, value); }
		}

		[JsonProperty("most_entry_kill_player")]
		public PlayerExtended MostEntryKillPlayer
		{
			get { return _mostEntryKillPlayer; }
			set { Set(() => MostEntryKillPlayer, ref _mostEntryKillPlayer, value); }
		}

		[JsonProperty("clutch_count")]
		public int ClutchCount
		{
			get
			{
				return Players.Sum(
					playerExtended => playerExtended.Clutch1V1Count + playerExtended.Clutch1V2Count
					+ playerExtended.Clutch1V3Count + playerExtended.Clutch1V4Count + playerExtended.Clutch1V5Count);
			}
		}

		public ObservableCollection<PlayerExtended> PlayersTeam1
		{
			get { return _playersTeam1; }
			set { Set(() => PlayersTeam1, ref _playersTeam1, value); }
		}

		public ObservableCollection<PlayerExtended> PlayersTeam2
		{
			get { return _playersTeam2; }
			set { Set(() => PlayersTeam2, ref _playersTeam2, value); }
		}

		public ObservableCollection<BombPlantedEvent> BombPlanted
		{
			get { return _bombPlanted; }
			set { Set(() => BombPlanted, ref _bombPlanted, value); }
		}

		public ObservableCollection<BombDefusedEvent> BombDefused
		{
			get { return _bombDefused; }
			set { Set(() => BombDefused, ref _bombDefused, value); }
		}

		public ObservableCollection<BombExplodedEvent> BombExploded
		{
			get { return _bombExploded; }
			set { Set(() => BombExploded, ref _bombExploded, value); }
		}

		public ObservableCollection<KillEvent> Kills
		{
			get { return _kills; }
			set { Set(() => Kills, ref _kills, value); }
		}

		/// <summary>
		/// Contains all PositionPoint for overview generation 
		/// </summary>
		[JsonIgnore]
		public List<PositionPoint> PositionsPoint { get; set; } = new List<PositionPoint>();

		/// <summary>
		/// DecoyStartedEvent list used for heatmap generation
		/// </summary>
		[JsonIgnore]
		public List<DecoyStartedEvent> DecoyStarted = new List<DecoyStartedEvent>();

		/// <summary>
		/// MolotovFireStartedEvent list used for heatmap generation
		/// </summary>
		[JsonIgnore]
		public List<MolotovFireStartedEvent> MolotovFireStarted = new List<MolotovFireStartedEvent>();

		/// <summary>
		/// Contains information about all shoots occured during the match (Heatmap data)
		/// </summary>
		[JsonIgnore]
		public List<WeaponFire> WeaponFired = new List<WeaponFire>();

		#endregion

		#region User data accessors

		[JsonIgnore]
		public int TotalKillUserCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SteamID);
				if (player == null) return 0;
				return player.KillsCount;
			}
		}

		[JsonIgnore]
		public int OneKillUserCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SteamID);
				if (player == null) return 0;
				return player.OnekillCount;
			}
		}

		[JsonIgnore]
		public int TwoKillUserCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SteamID);
				if (player == null) return 0;
				return player.TwokillCount;
			}
		}

		[JsonIgnore]
		public int ThreeKillUserCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SteamID);
				if (player == null) return 0;
				return player.ThreekillCount;
			}
		}

		[JsonIgnore]
		public int FourKillUserCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SteamID);
				if (player == null) return 0;
				return player.FourKillCount;
			}
		}

		[JsonIgnore]
		public int FiveKillUserCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SteamID);
				if (player == null) return 0;
				return player.FiveKillCount;
			}
		}

		[JsonIgnore]
		public int BombExplodedUserCount
		{
			get { return BombExploded.Count(b => b.Player.SteamId == Settings.Default.SteamID); }
		}

		[JsonIgnore]
		public int BombDefusedUserCount
		{
			get { return BombDefused.Count(b => b.Player.SteamId == Settings.Default.SteamID); }
		}

		[JsonIgnore]
		public int BombPlantedUserCount
		{
			get { return BombPlanted.Count(b => b.Player.SteamId == Settings.Default.SteamID); }
		}

		[JsonIgnore]
		public int TeamKillUserCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SteamID);
				if (player == null) return 0;
				return player.TeamKillCount;
			}
		}

		#endregion

		public Demo()
		{
			Kills.CollectionChanged += OnKillsCollectionChanged;
			BombExploded.CollectionChanged += OnBombExplodedCollectionChanged;
			BombDefused.CollectionChanged += OnBombDefusedCollectionChanged;
			BombPlanted.CollectionChanged += OnBombPlantedCollectionChanged;
		}

		public override bool Equals(object obj)
		{
			var item = obj as Demo;

			return item != null && Id.Equals(item.Id);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public void ResetStats(bool resetTeams = true)
		{
			DispatcherHelper.CheckBeginInvokeOnUI(
				() =>
				{
					_onekillCount = 0;
					_twokillCount = 0;
					_threekillCount = 0;
					_fourkillCount = 0;
					_fivekillCount = 0;
					_scoreTeam1 = 0;
					_scoreTeam2 = 0;
					_scoreFirstHalfTeam1 = 0;
					_scoreFirstHalfTeam2 = 0;
					_scoreSecondHalfTeam1 = 0;
					_scoreSecondHalfTeam2 = 0;
					if (resetTeams)
					{
						_players.Clear();
						_playersTeam1.Clear();
						_playersTeam2.Clear();
						_teams.Clear();
					}
					else
					{
						foreach (PlayerExtended playerExtended in Players)
						{
							playerExtended.ResetStats();
						}
					}
					_rounds.Clear();
					WeaponFired.Clear();
					_kills.Clear();
					_overtimes.Clear();
					PositionsPoint.Clear();
					MolotovFireStarted.Clear();
					DecoyStarted.Clear();
					_bombPlanted.Clear();
					_bombDefused.Clear();
					_bombExploded.Clear();
				});
		}

		#region Handler collections changed

		private void OnKillsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			RaisePropertyChanged("TotalKillCount");
			RaisePropertyChanged("TotalKillUserCount");
			RaisePropertyChanged("OneKillUserCount");
			RaisePropertyChanged("TwoKillUserCount");
			RaisePropertyChanged("ThreeKillUserCount");
			RaisePropertyChanged("FourKillUserCount");
			RaisePropertyChanged("FiveKillUserCount");
			RaisePropertyChanged("ClutchCount");
		}

		private void OnBombExplodedCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			RaisePropertyChanged("BombExplodedCount");
			RaisePropertyChanged("BombExplodedUserCount");
		}

		private void OnBombDefusedCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			RaisePropertyChanged("BombDefusedCount");
			RaisePropertyChanged("BombDefusedUserCount");
		}

		private void OnBombPlantedCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			RaisePropertyChanged("BombPlantedCount");
			RaisePropertyChanged("BombPlantedUserCount");
		}

		#endregion
	}
}
