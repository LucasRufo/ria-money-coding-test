﻿using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace Exercise02.IntegrationTests.Extensions;

public static class JsonContentExtensions
{
    public static StringContent ToJsonContent(this object obj)
        => new(JsonSerializer.Serialize(obj), Encoding.UTF8, MediaTypeNames.Application.Json);
}
