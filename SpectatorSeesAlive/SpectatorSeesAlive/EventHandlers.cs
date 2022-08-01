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
        //public static List<string> HintHidden = new List<string>();
        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">The <see cref="Plugin{TConfig}"/> class reference.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        List<Player> Spectators = new List<Player>();
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
                yield return Timing.WaitForSeconds(1.1f);
                Spectators = Player.Get(Team.RIP).ToList();
                foreach (Player player in Spectators)
                {
                    player.ShowManagedHint(
                        $"<align=right>{plugin.Config.Chaos}:{Player.Get(Side.ChaosInsurgency).Count()} \n {plugin.Config.Foundation}:{Player.Get(Side.Mtf).Count()} \n {plugin.Config.Scps}:{Player.Get(Side.Scp).Count()} </align>",
                        5, true, DisplayLocation.Top);
                }
                

                
            }
            
        }
    }
}