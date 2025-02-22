#if useCsharpMarkup
using MyExtensionsApp.Infrastructure;

#endif
namespace MyExtensionsApp;

public sealed partial class App : global::Microsoft.UI.Xaml.Application
{
	private Window? _window;
	private IHost? _host;

	public App()
	{
		this.InitializeComponent();
	}

	/// <summary>
	/// Invoked when the application is launched normally by the end user.  Other entry points
	/// will be used such as when the application is launched to open a specific file.
	/// </summary>
	/// <param name="args">Details about the launch request and process.</param>
	protected async override void OnLaunched(LaunchActivatedEventArgs args)
	{
		var builder = this.CreateBuilder(args)
//+:cnd:noEmit
#if useCsharpMarkup
			.ConfigureResources()
#endif
#if (useDefaultNav)
			// Add navigation support for toolkit controls such as TabBar and NavigationView
			.UseToolkitNavigation()
#endif
//-:cnd:noEmit
			.Configure(host => host
#if DEBUG
				// Switch to Development environment when running in DEBUG
				.UseEnvironment(Environments.Development)
#endif
//+:cnd:noEmit
#if logging
				.UseLogging(configure: (context, logBuilder) =>
				{
					// Configure log levels for different categories of logging
					logBuilder.SetMinimumLevel(
						context.HostingEnvironment.IsDevelopment() ?
							LogLevel.Information :
							LogLevel.Warning);
				}, enableUnoLogging: true)
#if useSerilog
				.UseSerilog(consoleLoggingEnabled: true, fileLoggingEnabled: true)
#endif
#endif
#if useConfiguration
				.UseConfiguration(configure: configBuilder =>
					configBuilder
#if configuration
						.EmbeddedSource<AppConfig>()
						.Section<AppConfig>()
#else
						.EmbeddedSource<MainPage>()
#endif
				)
#endif
#if localization
				// Enable localization (see appsettings.json for supported languages)
				.UseLocalization()
#endif
				// Register Json serializers (ISerializer and ISerializer)
				.UseSerialization()
				.ConfigureServices((context, services) => {
#if http
					// Register HttpClient
					services
//-:cnd:noEmit
#if DEBUG
						// DelegatingHandler will be automatically injected into Refit Client
						.AddTransient<DelegatingHandler, DebugHttpHandler>()
#endif
//+:cnd:noEmit
						.AddRefitClient<IApiClient>(context);

#endif
					// TODO: Register your services
					//services.AddSingleton<IMyService, MyService>();
				})
#if (useDefaultNav)
#if (useMvux)
				.UseNavigation(ReactiveViewModelMappings.ViewModelMappings, RegisterRoutes)
#else
				.UseNavigation(RegisterRoutes)
#endif
#endif
			);
		_window = builder.Window;

#if useFrameNav
//-:cnd:noEmit
		_host = builder.Build();

		// Do not repeat app initialization when the Window already has content,
		// just ensure that the window is active
		if (_window.Content is not Frame rootFrame)
		{
			// Create a Frame to act as the navigation context and navigate to the first page
			rootFrame = new Frame();

			rootFrame.NavigationFailed += OnNavigationFailed;

			if (args.UWPLaunchActivatedEventArgs.PreviousExecutionState == ApplicationExecutionState.Terminated)
			{
				// TODO: Load state from previously suspended application
			}

			// Place the frame in the current Window
			_window.Content = rootFrame;
		}

#if !(NET6_0_OR_GREATER && WINDOWS)
		if (args.UWPLaunchActivatedEventArgs.PrelaunchActivated == false)
#endif
		{
			if (rootFrame.Content == null)
			{
				// When the navigation stack isn't restored navigate to the first page,
				// configuring the new page by passing required information as a navigation
				// parameter
				rootFrame.Navigate(typeof(MainPage), args.Arguments);
			}
			// Ensure the current window is active
			_window.Activate();
		}
//+:cnd:noEmit
#else
		_host = await builder.NavigateAsync<Shell>();
#endif
	}

#if useFrameNav
	/// <summary>
	/// Invoked when Navigation to a certain page fails
	/// </summary>
	/// <param name="sender">The Frame which failed navigation</param>
	/// <param name="e">Details about the navigation failure</param>
	private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
	{
		throw new InvalidOperationException($"Failed to load {e.SourcePageType.FullName}: {e.Exception}");
	}
#else
	private static void RegisterRoutes(IViewRegistry views, IRouteRegistry routes)
	{
#if useDefaultNav
#if (useMvux)
		views.Register(
			new ViewMap(ViewModel: typeof(ShellModel)),
			new ViewMap<MainPage, MainModel>(),
			new DataViewMap<SecondPage, SecondModel, Entity>()
		);

		routes.Register(
			new RouteMap("", View: views.FindByViewModel<ShellModel>(),
				Nested: new RouteMap[]
				{
					new RouteMap("Main", View: views.FindByViewModel<MainModel>()),
					new RouteMap("Second", View: views.FindByViewModel<SecondModel>()),
				}
			)
		);
#else
		views.Register(
			new ViewMap(ViewModel: typeof(ShellViewModel)),
			new ViewMap<MainPage, MainViewModel>(),
			new DataViewMap<SecondPage, SecondViewModel, Entity>()
		);

		routes.Register(
			new RouteMap("", View: views.FindByViewModel<ShellViewModel>(),
				Nested: new RouteMap[]
				{
					new RouteMap("Main", View: views.FindByViewModel<MainViewModel>()),
					new RouteMap("Second", View: views.FindByViewModel<SecondViewModel>()),
				}
			)
		);
#endif
#endif
	}
#endif
}
