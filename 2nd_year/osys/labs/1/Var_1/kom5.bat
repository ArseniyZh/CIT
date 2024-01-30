set

set path

echo %path% = fpath.txt
set p1 = %path%

Notepad.exe
set path = C:\windows\notepad.exe
set path = %p1%

set path = %path%;c:\TMP
echo %path% >> fpath.txt