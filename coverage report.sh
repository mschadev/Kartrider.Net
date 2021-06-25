#!/bin/bash
function clean {
	local targetDir=$1
	rm "$targetDir/coverage.opencover.xml"
	rm -rf "$targetDir/TestResults"
}
dotnet test -p:CollectCoverage=true -p:CoverletOutputFormat=opencover
dotnet tool install -g dotnet-reportgenerator-globaltool
reportgenerator "-reports:./Kartrider.Api.Test/coverage.opencover.xml" "-targetdir:Coverage Report" -reporttypes:Html

clean "Kartrider.Api.Test"