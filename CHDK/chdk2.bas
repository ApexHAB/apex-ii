@title APEXII Balloon Script
@param l Timeout
@default l 1000

rem Max focus value is likely max word variable value (65535)

:loop
wait_click 1
is_key k "remote"
if k=1 then goto "capture1"
t=t+1
if t > 500 then goto "capture1"
goto "loop"


:capture1
t=0
get_focus x
if x <> 65536 then click "up"
click "shoot_full"
sleep 5000
goto "loop"



end
