﻿//-:cnd:noEmit
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Net.Http;
global using System.Threading;
global using System.Threading.Tasks;
global using Microsoft.Extensions.DependencyInjection;
//+:cnd:noEmit
#if useDefaultAppTemplate
global using Microsoft.Extensions.Hosting;
#endif
global using Microsoft.Extensions.Logging;
global using Microsoft.UI.Xaml;
#if useCsharpMarkup
global using Microsoft.UI.Xaml.Automation;
global using Microsoft.UI.Xaml.Controls;
global using Microsoft.UI.Xaml.Data;
#else
global using Microsoft.UI.Xaml.Controls;
#endif
global using Microsoft.UI.Xaml.Media;
global using Microsoft.UI.Xaml.Navigation;
#if useDefaultAppTemplate
global using MyExtensionsApp.Business.Models;
#if http
global using MyExtensionsApp.Infrastructure;
#endif
#if (notFrameNav)
global using MyExtensionsApp.Presentation;
#endif
#if http
global using MyExtensionsApp.Services;
#endif
#if http
global using Refit;
#endif
global using Uno.Extensions;
#if useConfiguration
global using Uno.Extensions.Configuration;
#endif
global using Uno.Extensions.Hosting;
#if http
global using Uno.Extensions.Http;
#endif
#if localization
global using Uno.Extensions.Localization;
#endif
#if logging
global using Uno.Extensions.Logging;
#endif
global using Uno.Extensions.Navigation;
#if useCsharpMarkup
global using Uno.Material;
global using Uno.Themes.Markup;
global using Uno.Toolkit.UI;
global using Uno.Toolkit.UI.Material;
#else
global using Uno.Toolkit.UI;
#endif
#endif
global using Windows.ApplicationModel;
global using Application = Microsoft.UI.Xaml.Application;
global using ApplicationExecutionState = Windows.ApplicationModel.Activation.ApplicationExecutionState;
#if useCsharpMarkup
global using Button = Microsoft.UI.Xaml.Controls.Button;
global using Color = Windows.UI.Color;
#endif
//-:cnd:noEmit
