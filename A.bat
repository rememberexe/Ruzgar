@echo off
setlocal

echo ========================================
echo RUZGAR RELEASE STANDALONE APK BUILD
echo ========================================

set PROJECT=C:\Users\yusuf\Desktop\Mobile\Ruzgar\Ruzgar\Ruzgar.csproj
set BASEOUT=C:\Users\yusuf\Desktop\Mobile\Ruzgar\Ruzgar\bin\Release\net10.0-android
set FINALAPK=C:\Users\yusuf\Desktop\Mobile\Ruzgar\Ruzgar\RUZGAR-RELEASE-SIGNED.apk

echo.
echo Eski Android Release ciktilari temizleniyor...

powershell -NoProfile -ExecutionPolicy Bypass -Command "Remove-Item -LiteralPath 'D:\Mobile\Ruzgar\Ruzgar\bin\Release\net10.0-android' -Recurse -Force -ErrorAction SilentlyContinue"
powershell -NoProfile -ExecutionPolicy Bypass -Command "Remove-Item -LiteralPath 'D:\Mobile\Ruzgar\Ruzgar\obj\Release\net10.0-android' -Recurse -Force -ErrorAction SilentlyContinue"
powershell -NoProfile -ExecutionPolicy Bypass -Command "Remove-Item -LiteralPath 'D:\Mobile\Ruzgar\Ruzgar\RUZGAR-RELEASE-SIGNED.apk' -Force -ErrorAction SilentlyContinue"

echo.
echo Release standalone APK olusturuluyor...

dotnet publish "%PROJECT%" ^
    -f net10.0-android ^
    -c Release ^
    -p:AndroidPackageFormat=apk ^
    -p:RuntimeIdentifier=android-arm64 ^
    -p:AndroidSupportedAbis=arm64-v8a ^
    -p:EmbedAssembliesIntoApk=true ^
    -p:AndroidUseSharedRuntime=false ^
    -p:AndroidLinkMode=None ^
    -p:PublishTrimmed=false ^
    -p:RunAOTCompilation=false ^
    -p:AndroidEnableProfiledAot=false ^
    -p:AndroidKeyStore=false ^
    -p:ApplicationVersion=102 ^
    -p:ApplicationDisplayVersion=1.0.102

if errorlevel 1 (
    echo.
    echo HATA: Release APK derlenemedi.
    pause
    exit /b 1
)

echo.
echo Signed APK araniyor...

set SIGNEDAPK=

for /r "%BASEOUT%" %%f in (*-Signed.apk) do (
    set SIGNEDAPK=%%f
)

if "%SIGNEDAPK%"=="" (
    echo.
    echo HATA: Signed APK bulunamadi.
    echo Klasorde bulunan APK'lar:
    for /r "%BASEOUT%" %%f in (*.apk) do echo %%f
    pause
    exit /b 1
)

copy /Y "%SIGNEDAPK%" "%FINALAPK%" >nul

echo.
echo ========================================
echo APK HAZIR
echo ========================================
echo.
echo Kaynak Signed APK:
echo %SIGNEDAPK%
echo.
echo Telefona kurulacak APK:
echo %FINALAPK%
echo.
pause