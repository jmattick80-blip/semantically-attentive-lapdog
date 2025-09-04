namespace Prism.Shared.Contracts.Enums
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
        Trigger,
        Unspecified,
        Emotional,
        Semantic,
        Input
    }
    public enum SystemPhase
    {
        None,
        PreUpdate,
        Update,
        PostUpdate,
        Custom,
        Active,
        Curator,
        Unspecified,
        Onboarding,
        Runtime,
        Review
    }

    public enum SystemState
    {
        Triggered,
        Engaged
    }
    
}