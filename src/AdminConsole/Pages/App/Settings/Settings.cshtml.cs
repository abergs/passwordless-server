﻿using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminConsole.Pages.Settings;

public class SettingsModel : PageModel
{
    private readonly ILogger<SettingsModel> _logger;

    public SettingsModel(ILogger<SettingsModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}