clear
set report_txt=Textreport_%date:~-4,4%_%date:~-7,2%_%date:~-10,2%_%time:~1,1%%time:~3,2%%time:~6,2%.txt
echo report_txt

set report_xml=xmlreport_%date:~-4,4%_%date:~-7,2%_%date:~-10,2%_%time:~1,1%%time:~3,2%%time:~6,2%.xml
echo report_xml

set report_html=htmlreport_%date:~-4,4%_%date:~-7,2%_%date:~-10,2%_%time:~1,1%%time:~3,2%%time:~6,2%.html
echo report_html

rem ..\packages\NUnit.ConsoleRunner.3.10.0\tools\nunit3-console.exe --labels=All  --where "cat == insert || cat == navigation" --out=..\ReportFiles\%report_txt% "--result=..\ReportFiles\%report_xml%;format=nunit2" ..\bin\Debug\SAM.dll

..\packages\NUnit.ConsoleRunner.3.10.0\tools\nunit3-console.exe --labels=All --where "cat = mylink" --out=..\ReportFiles\%report_txt% "--result=..\ReportFiles\%report_xml%;format=nunit2" ..\bin\Debug\LinkGroup.dll 


..\packages\SpecFlow.3.1.67\tools\specflow.exe nunitexecutionreport --ProjectFile ..\LinkGroup.csproj --xmlTestResult ..\ReportFiles\%report_xml% --testOutput ..\ReportFiles\%report_txt% --OutputFile ..\ReportFiles\%report_html%



rem Run smoke tests only with  "cat == smoke && cat != wip && cat != manual && cat != regression"






