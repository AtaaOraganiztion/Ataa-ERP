namespace Infrastructure.Settings;

public class JwtSetting
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Key { get; set; }
    public int ExpiresIn { get; set; }
    public int RefreshExpiresIn { get; set; }
    public bool ValidateIssuerSigningKey { get; set; }
    public bool ValidateIssuer { get; set; }
    public bool ValidateAudience { get; set; }
    public bool ValidateLifetime { get; set; }
    public bool RequireHttpsMetadata { get; set; }
    public bool SaveToken { get; set; }
}
