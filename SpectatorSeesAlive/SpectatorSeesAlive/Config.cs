namespace SpectatorSeesAlive
{
    using System.ComponentModel;
    using Exiled.API.Interfaces;

    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc/>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether debug messages should be shown in the console.
        /// </summary>
        [Description("Whether debug logs should be shown in the console.")]
        public bool Debug { get; set; }

        [Description("Gets or sets the name of the side for 'Chaos and dclass'")]
        public string Chaos { get; set; } = "Chaos and D-Class";

        [Description("Gets or sets the name of the side for 'MTF and Scientist'")]
        public string Foundation { get; set; } = "MTF and Scientist";

        [Description("Gets or sets the name of the side for 'SCPs'")]
        public string Scps { get; set; } = "SCPs";
    }
}