echo %0
echo %1
echo %2

if "%1%"  ==  ""  goto M1
if "%2%" == ""  goto M1

set p1=%1
set  p2=%2

set /A p3=p1+p2

goto M2
:M1

echo OLD >> %0.Log

goto M3
:M2

echo NEW >> %0.Log
echo %p3% >> %0.Log
:M3