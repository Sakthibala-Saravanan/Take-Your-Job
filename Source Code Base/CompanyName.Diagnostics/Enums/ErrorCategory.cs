namespace AspireSystems.Diagnostics.Enums
{
    /// <summary>
    /// Enumeration to handle different error types
    /// </summary>
    public enum ErrorCategory
    {
        // Unhandled Application errors
        Application = 1,
        // Authentication filter, middleware errors
        Authentication = 2,
        // Authorization/forbidden access errors
        Authorization = 3,
        // Security errors like CSRF, XSS, injection errors
        Security = 4,
        // Attribute/Model, business validation errors
        Validation = 5
    }
}
