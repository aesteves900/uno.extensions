﻿namespace Playground.ViewModels;
public class ThemeSwitchViewModel
{
	private readonly IThemeService _ts;
	public ThemeSwitchViewModel(IThemeService themeService)
	{
		_ts = themeService;
		_ts.DesiredThemeChanged += ts_DesiredThemeChanged;
	}

	private void ts_DesiredThemeChanged(object? sender, AppTheme e)
	{
		Console.WriteLine($"Theme was changed to:{e.ToString()}");
		Console.WriteLine($"Desired Theme is:{_ts.Theme}");
	}

	public async Task ChangeToSystem()
	{
		await _ts.SetThemeAsync(AppTheme.System);
	}

	public async Task ChangeToLight()
	{
		await _ts.SetThemeAsync(AppTheme.Light);
	}

	public async Task ChangeToDark()
	{
		await _ts.SetThemeAsync(AppTheme.Dark);
	}
}

