﻿using System.Text.Json;

namespace HangryHub.RestaurantService.Presentation.Common.Models;

public class ErrorDetailModel
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
