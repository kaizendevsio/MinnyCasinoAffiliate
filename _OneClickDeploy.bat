@ECHO OFF

for %%I in (.) do set CurrDirName=%%~nxI

:choice
set /P c=Deploy %CurrDirName%?[Y/N]
if /I "%c%" EQU "Y" goto :somewhere
if /I "%c%" EQU "N" goto :somewhere_else
goto :choice


:somewhere
cls
echo Building Release.MinnyCasinoAffiliate.API ...
dotnet publish MinnyCasinoAffiliate.sln -o C:\Projects\Published\Release.MinnyCasinoAffiliate\MinnyCasinoAffiliate.Api.Published

cls
echo Building Release.MinnyCasinoAffiliate.FrontEnd ...
dotnet publish MinnyCasinoAffiliate.FrontEnd.sln -o C:\Projects\Published\Release.MinnyCasinoAffiliate\MinnyCasinoAffiliate.FrontEnd.Published

cls
echo Deploying to git ...
cd C:\Projects\Published\Release.MinnyCasinoAffiliate
git add *.*
git commit -m "One Click Deploy"

cls
git push

echo Change directory to project folder..
cd C:\Projects\Net Core\MinnyCasinoAffiliate

cls
echo Deploying to server: Portal
plink ubuntu@18.191.243.96 -m oneclick.portal.sh -batch

cls
echo Deploying to server: API
plink ubuntu@18.220.11.117 -m oneclick.api.sh -batch

cls
echo Deployment done. Have a good day :)

pause
exit

:somewhere_else

echo Deployment Canceled
pause
exit