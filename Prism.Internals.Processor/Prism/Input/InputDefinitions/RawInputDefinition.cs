using GalleryDrivers.Prism.Shared.Enums;

namespace GalleryDrivers.Prism.Input.InputDefinitions
{
    /// <summary>
    /// Represents a narratable input definition used to map contributor intent to runtime envelopes.
    /// This class is engine-agnostic and safe for manifest serialization, annotation, and replay.
    /// </summary>
    public class RawInputDefinition
    {
        public string Role { get; }
        public string ActionName { get; }
        public string DisplayName { get; }
        public string BindingPath { get; }
        public InputIntentType IntentType { get; }

        public RawInputDefinition(
            string role,
            string actionName,
            string displayName,
            string bindingPath,
            InputIntentType intentType)
        {
            Role = role;
            ActionName = actionName;
            DisplayName = displayName;
            BindingPath = bindingPath;
            IntentType = intentType;
        }

        public override string ToString()
        {
            return $"{Role} → {DisplayName} [{IntentType}] @ {BindingPath}";
        }
    }
}