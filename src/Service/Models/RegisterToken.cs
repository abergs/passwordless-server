﻿using MessagePack;
using Passwordless.Service.Helpers;

namespace Passwordless.Service.Models;

public class RegisterTokenDTO : RegisterToken
{
    [Key(17)]
    public HashSet<string> Aliases { get; set; }

    [Key(18)] public bool AliasHashing { get; set; } = true;

}
[MessagePackObject]
public class RegisterToken : Token
{

    [Key(10)]
    public string UserId { get; set; }
    [Key(11)]
    public string DisplayName { get; set; }
    [Key(12)]
    public string Username { get; set; }
    [Key(13)]
    public string Attestation { get; set; } = "None";
    [Key(14)]
    public string AuthenticatorType { get; set; }
    [Key(15)]
    public bool Discoverable { get; set; } = true;
    [Key(16)]
    public string UserVerification { get; set; } = "Preferred";
}

[MessagePackObject]
public class VerifySignInToken : Token
{
    [Key(10)]
    public string UserId { get; set; }

    [Key(11)]
    public DateTime Timestamp { get; set; }

    [Key(12)]
    public string RPID { get; set; }

    [Key(13)]
    public string Origin { get; set; }

    [Key(14)]
    public bool Success { get; set; }

    [Key(15)]
    public string Device { get; set; }

    [Key(16)]
    public string Country { get; set; }

    [Key(17)]
    public string Nickname { get; set; }

    [Key(18)]
    public byte[] CredentialId { get; set; }
}

[MessagePackObject]
public class Token
{
    [Key(0)]
    public required DateTime ExpiresAt { get; set; }

    [Key(1)]
    public required Guid TokenId { get; set; }

    [Key(2)]
    public required string Type { get; set; }

    public void Validate()
    {
        var now = DateTime.UtcNow;
        if (ExpiresAt < now)
        {
            var drift = now - ExpiresAt;
            throw new ApiException("expired_token", $"The token expired {drift} ago.", 403);
        }
    }
}