using Domain.Entities.Common;

namespace Domain.Entities.Main;

public class AppSetting : BaseEntity<int>
{
    /// <summary>
    /// Gets or sets the ReferenceKey
    /// </summary>
    public string ReferenceKey { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Value
    /// </summary>
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Description
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Type
    /// </summary>
    public string Type { get; set; } = string.Empty;
}