# Start-Services.ps1

param (
  [string]$AspNetDir = "C:\Users\Guose\source\repos\GitHubRepos\DigitalBallotPlatform\Backend\DigitalBallotPlatform.Api",
  [string]$ExpressDir = "/mnt/c/Users/Guose/source/repos/GitHubRepos/DigitalBallotPlatform/Frontend/server",
  [string]$ReactDir = "/mnt/c/Users/Guose/source/repos/GitHubRepos/DigitalBallotPlatform/Frontend/digital-ballot-client"
  )

  function Start-ServiceInNewWindow {
    param (
        [string]$Name,
        [string]$Command,
        [string]$WorkingDirectory,
        [switch]$UseWsl = $false  # Whether to use WSL
    )

    Write-Host "Starting $Name..."
    
    if ($UseWsl) {
      # Define profile and title
    $profileName = 'Linux CLI'
    $title = $Name
    $command = "cd $WorkingDirectory && $Command"

    # Construct the command for Windows Terminal with proper escaping
    $fullCommand = @(
        'new-tab',
        '-p', "`"$profileName`"",
        '--title', "`"$title`"",
        "bash -c `"$command`""
    )
        Start-Process "wt.exe" -ArgumentList $fullCommand
  } else {
      Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd $WorkingDirectory; $Command" -WindowStyle Normal
  }
  
  Start-Sleep -Seconds 10
}

# Start ASP.NET Web API in Windows
Start-ServiceInNewWindow -Name "ASP.NET Web API" -Command "dotnet run" -WorkingDirectory $AspNetDir

# Start Express.js Server in WSL (Ubuntu 22.04.3 LTS)
Start-ServiceInNewWindow -Name "Express.js Server" -Command "npm run dev" -WorkingDirectory $ExpressDir -UseWsl

# Start React App in WSL (Linux CLI)
Start-ServiceInNewWindow -Name "React App" -Command "npm start" -WorkingDirectory $ReactDir -UseWsl

Write-Host "All services have been started."

# function Start-ServiceInNewWindow {
#   param (
#       [string]$Name,
#       [string]$Command,
#       [string]$WorkingDirectory
#   )

#   Write-Host "Starting $Name..."
#   Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd $WorkingDirectory; $Command" -WindowStyle Normal
# }

# # Start ASP.NET Web API
# Start-ServiceInNewWindow -Name "ASP.NET Web API" -Command "dotnet run" -WorkingDirectory "C:\Users\Guose\source\repos\GitHubRepos\DigitalBallotPlatform\Backend\DigitalBallotPlatform.Api"

# # Start Express.js Server
# Start-ServiceInNewWindow -Name "Express.js Server" -Command "npm run dev" -WorkingDirectory "C:\Users\Guose\source\repos\GitHubRepos\DigitalBallotPlatform\Frontend\server"

# # Start React App
# Start-ServiceInNewWindow -Name "React App" -Command "npm start" -WorkingDirectory "C:\Users\Guose\source\repos\GitHubRepos\DigitalBallotPlatform\Frontend\digital-ballot-client"

# Write-Host "All services have been started."
