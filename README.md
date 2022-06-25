## install packages
* NSwag.AspNet.Owin
* Microsoft.AspNet.WebApi.Owin
* Microsoft.Owin.Host.SystemWeb

## swagger 設定
Global.asax.cs 增加 swagger 設定
```cs
            RouteTable.Routes.MapOwinPath("swagger", app =>
            {
                app.UseSwaggerUi3(typeof(WebApiApplication).Assembly, settings =>
                {
                    settings.MiddlewareBasePath = "/swagger";

                    settings.PostProcess = document =>
                    {
                        document.Info.Title = "WebAPI NSwag";
                    };
                });
            });
```

Web.config 增加 swagger handler
```xml
    <handlers>
      <add name="NSwag" path="swagger" verb="*" type="System.Web.Handlers.TransferRequestHandler" preCondition="integratedMode,runtimeVersionv4.0" />
    </handlers>
```

