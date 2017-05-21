del bin\Release\*.nupkg
&("D:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\MSBuild.exe") "NBitcoin.Litecoin.csproj" /t:pack -p:Configuration=Release

cd bin\Release

# nuGet pack NBitcoin.nuspec

forfiles /m *.nupkg /c "cmd /c NuGet.exe push @FILE -source https://api.nuget.org/v3/index.json"
(((dir *.nupkg).Name) -match "[0-9]+?\.[0-9]+?\.[0-9]+?\.[0-9]+")
$ver = $Matches.Item(0)
git tag -a "v$ver" -m "$ver"
git push --tags

cd ..\..