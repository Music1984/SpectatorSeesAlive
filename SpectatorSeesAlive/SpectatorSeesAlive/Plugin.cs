namespace SpectatorSeesAlive
{
    using System;
    using Exiled.API.Features;
    using PlayerHandlers = Exiled.Events.Handlers.Player;
    using Handlers = Exiled.Events.Handlers;
    
    /// <inheritdoc />
    public class Plugin : Plugin<Config>
    {
        private EventHandlers eventHandlers;

        /// <inheritdoc/>
        public override string Author { get; } = "Music";

        /// <inheritdoc/>
        public override string Name { get; } = "SpectatorSeesAlive";

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

        /// <inheritdoc/>
        public override string Prefix { get; } = "SpectatorSeesAlive";

        /// <inheritdoc/>
        public override Version Version { get; } = new Version(1, 0, 0);
        
        /// <inheritdoc/>
        public override void OnEnabled()
        {
            eventHandlers = new EventHandlers(this);
            Handlers.Server.RoundStarted += eventHandlers.OnRoundStart;
            Handlers.Server.RoundEnded += eventHandlers.OnRoundEnd;
            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            Handlers.Server.RoundStarted -= eventHandlers.OnRoundStart;
            Handlers.Server.RoundEnded -= eventHandlers.OnRoundEnd;
            eventHandlers = null;
            base.OnDisabled();
        }
    }
}