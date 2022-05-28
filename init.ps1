##################################
# Configure TLS/HTTPS certificates
##################################
Push-Location ".\docker\data\traefik\certs"
try {
    $mkcert = ".\mkcert.exe"
    if ($null -ne (Get-Command mkcert.exe -ErrorAction SilentlyContinue)) {
        # mkcert installed in PATH
        $mkcert = "mkcert"
    } elseif (-not (Test-Path $mkcert)) {
        Write-Host "Downloading and installing mkcert certificate tool..." -ForegroundColor Green 
        Invoke-WebRequest "https://github.com/FiloSottile/mkcert/releases/download/v1.4.1/mkcert-v1.4.1-windows-amd64.exe" -UseBasicParsing -OutFile mkcert.exe
        if ((Get-FileHash mkcert.exe).Hash -ne "1BE92F598145F61CA67DD9F5C687DFEC17953548D013715FF54067B34D7C3246") {
            Remove-Item mkcert.exe -Force
            throw "Invalid mkcert.exe file"
        }
    }
    Write-Host "Generating Traefik TLS certificate for *.fruitstore.com " -ForegroundColor Green
    & $mkcert -install
    & $mkcert -key-file key.pem -cert-file cert.pem "*.fruitstore.com"
    #api.fruitstore.localhost
    & $mkcert -key-file fruitstore.pem -cert-file cert-fruitstore.pem "api-middleware.fruitstore.com"
    & $mkcert -key-file buyer.pem -cert-file cert-buyer.pem "buyer.fruitstore.com"

}
catch {
    Write-Error "An error occurred while attempting to generate TLS certificate: $_"
}
finally {
    Pop-Location
}

##Helpers
. "$PSScriptRoot\docker\scripts\helpers.ps1"

### Add host entries 
add-host -ip 127.0.0.1 -hostname 'api-middleware.fruitstore.com'
add-host -ip 127.0.0.1 -hostname 'buyer.fruitstore.com'
