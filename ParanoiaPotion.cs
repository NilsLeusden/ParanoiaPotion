﻿using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace ParanoiaPotion
{

	[BepInPlugin("NilsThatBoi.ParanoiaPotion", "ParanoiaPotion", "1.0.1")]

	public class ParanoiaPotion : BaseUnityPlugin
	{
		internal static ParanoiaPotion Instance { get; private set; } = null!;
		internal new static ManualLogSource Logger => Instance._logger;
		private ManualLogSource _logger => base.Logger;
		internal Harmony? Harmony { get; set; }

		private void Awake()
		{
			Instance = this;

			this.gameObject.transform.parent = null;
			this.gameObject.hideFlags = HideFlags.HideAndDontSave;

			Patch();

			Logger.LogInfo($"{Info.Metadata.GUID} v{Info.Metadata.Version} has loaded!");
		}

		internal void Patch()
		{
			Harmony ??= new Harmony(Info.Metadata.GUID);
			Harmony.PatchAll();
		}

		internal void Unpatch()
		{
			Harmony?.UnpatchSelf();
		}

		private void Update()
		{
		}
	}
}


