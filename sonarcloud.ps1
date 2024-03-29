param(
    [string] $sonarSecret
)

Install-package BuildUtils -Confirm:$false -Scope CurrentUser -Force
Import-Module BuildUtils

$runningDirectory = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition

$testOutputDir = "$runningDirectory/TestResults"

if (Test-Path $testOutputDir)
{
    Write-host "Cleaning temporary Test Output path $testOutputDir"
    Remove-Item $testOutputDir -Recurse -Force
}

$version = Invoke-Gitversion
$assemblyVer = $version.assemblyVersion

$branch = git branch --show-current
Write-Host "branch is $branch"


dotnet tool restore
dotnet tool run dotnet-sonarscanner begin /k:"fambda_fambda" /v:"$assemblyVer" /o:"fambda" /d:sonar.login="$sonarSecret" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.cs.xunit.reportsPaths=TestResults/*.trx /d:sonar.cs.opencover.reportsPaths=TestResults/*/coverage.opencover.xml /d:sonar.test.exclusions="**/Bike*.cs" /d:sonar.coverage.exclusions="*.Tests/*.*,*.Tests/**/*.*" /d:sonar.branch.name="$branch"

dotnet restore
dotnet build --configuration 'Release'
dotnet test "./Fambda.Tests/Fambda.Tests.csproj" --collect:"XPlat Code Coverage" --results-directory TestResults/ --logger "trx;LogFileName=coveragetests.trx" --no-build --no-restore --configuration 'Release' -- DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format=opencover

dotnet tool run dotnet-sonarscanner end /d:sonar.login="$sonarSecret"
