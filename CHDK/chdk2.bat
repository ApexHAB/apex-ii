@title APEXII Balloon Script
@param l Timeout
@default l 1000

rem Max focus value is likely max word variable value (65535)

:run1

set_zoom 0

 
do
      a = get_usb_power
      t = t + 1
if t > l then gosub "capture"
   until a>0 
   t=0
   if a > 10 then gosub "capture" 
end


:capture
get_focus x
:shoot
if x <> 65536
click "up"
endif
click "shoot_full"
cls
goto "run1"

end
