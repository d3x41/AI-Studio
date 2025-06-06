namespace AIStudio.Settings.DataModel;

public sealed class DataApp
{
    /// <summary>
    /// The language behavior.
    /// </summary>
    public LangBehavior LanguageBehavior { get; set; } = LangBehavior.AUTO;
    
    /// <summary>
    /// The language plugin ID to use.
    /// </summary>
    public Guid LanguagePluginId { get; set; } = Guid.Empty;
    
    /// <summary>
    /// The preferred theme to use.
    /// </summary>
    public Themes PreferredTheme { get; set; } = Themes.SYSTEM;
    
    /// <summary>
    /// Should we save energy? When true, we will update content streamed
    /// from the server, i.e., AI, less frequently.
    /// </summary>
    public bool IsSavingEnergy { get; set; }
    
    /// <summary>
    /// Should we enable spellchecking for all input fields?
    /// </summary>
    public bool EnableSpellchecking { get; set; }

    /// <summary>
    /// If and when we should look for updates.
    /// </summary>
    public UpdateBehavior UpdateBehavior { get; set; } = UpdateBehavior.HOURLY;
    
    /// <summary>
    /// The navigation behavior.
    /// </summary>
    public NavBehavior NavigationBehavior { get; set; } = NavBehavior.NEVER_EXPAND_USE_TOOLTIPS;

    /// <summary>
    /// The visibility setting for previews features.
    /// </summary>
    public PreviewVisibility PreviewVisibility { get; set; } = PreviewVisibility.NONE;

    /// <summary>
    /// The enabled preview features.
    /// </summary>
    public HashSet<PreviewFeatures> EnabledPreviewFeatures { get; set; } = new();
    
    /// <summary>
    /// Should we preselect a provider for the entire app?
    /// </summary>
    public string PreselectedProvider { get; set; } = string.Empty;
    
    /// <summary>
    /// Should we preselect a profile for the entire app?
    /// </summary>
    public string PreselectedProfile { get; set; } = string.Empty;
    
    
    /// <summary>
    /// Should we preselect a chat template for the entire app?
    /// </summary>
    public string PreselectedChatTemplate { get; set; } = string.Empty;
}