﻿using EntitySignal.Hubs;
using EntitySignal.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace EntitySignal.Services
{
  public class EntitySignalSubscribe
  {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EntitySignalSubscribe(
      IHttpContextAccessor httpContextAccessor
      )
    {
      _httpContextAccessor = httpContextAccessor;
    }

    public UrlSubscription<T> Subscribe<T>(string connectionId, Func<T, bool> query = null)
    {
      var url = $"{_httpContextAccessor.HttpContext.Request.Path}{_httpContextAccessor.HttpContext.Request.QueryString}";

      var userContainer = new UrlSubscription<T>()
      {
        ConnectionId = connectionId,
        Url = url,
        Query = query
      };

      EntitySignalDataStore.AddUser(userContainer);

      return userContainer;
    }

  }
}
