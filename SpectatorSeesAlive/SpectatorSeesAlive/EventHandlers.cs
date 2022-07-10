using System.Collections.Generic;
using System.Linq;
using Exiled.Events.EventArgs;
using MEC;
using UnityEngine;
using AdvancedHints;
using AdvancedHints.Enums;
using Exiled.API.Enums;
using Exiled.API.Features.Roles;

namespace SpectatorSeesAlive
{
    using Exiled.API.Features;

    /// <summary>
    /// General event handlers.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;
        CoroutineHandle _coroutineHandle;
        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">The <see cref="Plugin{TConfig}"/> class reference.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        public void OnRoundStart()
        {
            _coroutineHandle = Timing.RunCoroutine(SpecatorCoroutine());
        }

        public void OnRoundEnd(RoundEndedEventArgs ev)
        {
            Timing.KillCoroutines(_coroutineHandle);
        }

        public IEnumerator<float> SpecatorCoroutine()
        {
            for (;;)
            {
                foreach (var player in Player.List)
                {
                    if (player.Role.Type == RoleType.Spectator)
                    {
                        player.ShowManagedHint(
                            $"<align=right>CHI & D-Class:{Player.Get(Side.ChaosInsurgency).Count()} \n MTF & Scientist:{Player.Get(Side.Mtf).Count()} \n SCPs:{Player.Get(Side.Scp).Count()} </align>",
                            5, true, DisplayLocation.Top);
                        
                    }
                    yield return Timing.WaitForSeconds(1.1f);
                }
            }
        }
    }
}