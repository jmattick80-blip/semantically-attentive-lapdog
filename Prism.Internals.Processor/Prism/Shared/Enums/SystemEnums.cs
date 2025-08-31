namespace GalleryDrivers.Prism.Shared.Enums
{
    public enum InputIntentType
    {
        None,
        Navigation,
        Selection,
        Manipulation,
        System,
        Custom
    }
    public enum InputActionType
    {
        Button,
        Value,
        PassThrough
    }
    public enum SystemType
    {
        Unknown,
        Core,
        Input,
        Rendering,
        Physics,
        Audio,
        AI,
        Networking,
        UI,
        Custom,
        Generic,
        Emotion
    }

    public enum SystemIntent
    {
        None,
        Initialize,
        Update,
        Shutdown,
        Custom,
        Resolve,
        Trigger
    }
    public enum SystemPhase
    {
        None,
        PreUpdate,
        Update,
        PostUpdate,
        Custom,
        Active
    }

    public enum SystemState
    {
        Triggered,
        Engaged
    }
    
}