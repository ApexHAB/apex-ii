@title APEXII Balloon Script
@param l Timeout
@default l 1000

rem Max focus value is likely max word variable value (65535)

:loop
wait_click 1
is_key k "remote"
if k=1 then gosub "capture1"
t=t+1
if t > 1000 then gosub "capture1"
goto "loop"


:capture1
t=0
k=0
set_zoom 0
get_focus x
if x <> 65536 then click "up"
click "shoot_full"
cls
goto "loop"
return


end
