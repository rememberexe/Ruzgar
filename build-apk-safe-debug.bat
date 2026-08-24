@echo off
setlocal

echo ========================================
echo RUZGAR SAFE DEBUG APK BUILD
echo ========================================

set PROJECT=D:\Mobile\Ruzgar\Ruzgar\Ruzgar.csproj
set OUTDIR=D:\Mobile\Ruzgar\Ruzgar\bin\Debug\net10.0-android\publish

echo.
echo Proje:
echo %PROJECT%

echo.
if not exist "%PROJECT%" (
    echo HATA: Ruzgar.csproj bulunamadi.
    pause
    exit /b 1
)

echo.
echo Android Debug APK derleniyor...
echo Bu script bin/obj silmez.

dotnet publish "%PROJECT%" ^
    -f net10.0-android ^
    -c Debug ^
    -p:AndroidPackageFormat=apk

if errorlevel 1 (
    echo.
    echo HATA: APK derlenemedi.
    pause
    exit /b 1
)

echo.
echo ========================================
echo APK OLUSTU
echo ========================================
echo.

echo APK klasoru:
echo %OUTDIR%

echo.
dir "%OUTDIR%\*.apk" /b

echo.
pause