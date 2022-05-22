#
# Powershell script for adding/removing/showing entries to the hosts file.
#
# Known limitations:
# - does not handle entries with comments afterwards ("<ip>    <host>    # comment")
#

$file = "C:\Windows\System32\drivers\etc\hosts"

function add-host( [string]$ip, [string]$hostname) {
    #remove-host $file $hostname
    $ip + "`t`t" + $hostname | Out-File -encoding ASCII -append $file
}

function remove-host( [string]$hostname) {
    $c = Get-Content $file
    $newLines = @()

    foreach ($line in $c) {
        $bits = [regex]::Split($line, "\t+")
        if ($bits.count -eq 2) {
            if ($bits[1] -ne $hostname) {
                $newLines += $line
            }
        } else {
            $newLines += $line
        }
    }

    # Write file
    Clear-Content $file
    foreach ($line in $newLines) {
        $line | Out-File -encoding ASCII -append $file
    }
}
function Get-RemoteDebuggerPath
{
	$remoteDebuggerPath = (Get-ChildItem -Path "${env:ProgramFiles(x86)}\Microsoft Visual Studio" -Filter "Remote Debugger" -Recurse `
							| Where-Object { [regex]::Match($_.FullName, "\d{4}").Value -ge 2019 -and $_.FullName -notmatch "Community" } `
							| Select-Object -First 1).FullName
	Write-Verbose "Found remote debugger at $remoteDebuggerPath"
	$remoteDebuggerPath
}

function Get-EnvVariable
{
	Get-Content ".env" | foreach-object -begin {$settings=@{}} -process { if($_.Contains("=")){  $value = [regex]::split($_,'='); if(($value[0].CompareTo("") -ne 0) -and ($value[0].StartsWith("[") -ne $True) -and ($value[0].StartsWith("#") -ne $True) ) { if(-Not $settings.ContainsKey($value[0])) { $settings.Add($value[0], $value[1]) }  } } }
	return $settings
}

function Invoke-WebsiteInitialisation {
	Start-Job -ScriptBlock {
		@(44220, 44221, 44230, 44240) | ForEach-Object {
			Start-Sleep -Seconds 5
			Invoke-WebRequest "http://localhost:$_/"
		}
	}
}

function Invoke-AzureLogin {
	az login
	az account set --subscription "CHANGE_TO_SUBSCRIPTION_NAME"
	az acr login --name "CHANGE_TO_ACR_NAME"
}

function Invoke-PushDockerImages {
	Invoke-AzureLogin
	docker push "$registry$sqlImage"
	docker push "$registry$websiteImage"
}