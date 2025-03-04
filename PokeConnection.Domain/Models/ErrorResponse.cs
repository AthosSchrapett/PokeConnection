﻿using Newtonsoft.Json;

namespace PokeConnection.Domain.Models;

public class ErrorResponse
{
    public int StatusCode { get; init; }
    public string Message { get; init; }

    public ErrorResponse(int statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }

    public override string ToString() => JsonConvert.SerializeObject(this);
}
