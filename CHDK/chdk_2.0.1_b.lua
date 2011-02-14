require "propcase"
require "capmode"
--print("Hello CHDK !")

--[[
@title APEX II 2.00.1 BETA
@param a Interval in Seconds
@default a 5
 
based on APEX II 1st Launch Script
http://chdk.setepontos.com/index.php/topic,2646.0.html
set_backlight(0)
--]]

--logfile=io.open("A/FLIGHTLOG.log","wb")
--io.output(logfile)

function timerwait()
    for i=0,a do
        sleep(1000)
    end
    capture1()
end

function capture1()
   set_aflock(0)
   press("shoot_half")
   sleep(2000)
   set_focus(65535)
   set_aflock(1)
     -- log("shooting...")
    --get battery voltage
    --get temps
    --log("tbat",tbat,"tccd",tccd,"vbat",vbat)
   press("shoot_full")
    repeat 
    sleep(100)
  until get_shooting() == true
  release("shoot_full")
end

function set_focus_status(n)
    if get_propset() == 2 then
        set_prop(6,n -1)
    else
        set_prop(11,n -1)
    end
end

--[[
function vbatt()
    props=require("propcase")
    tv=get_prop(props.TV)

end

function gtime()
    ttime=get_time("D,h,m,s")
    log(ttime)
end

function gtemp()
    ftemp = get_temperature(0)
    log(ftemp)
     ftemp = get_temperature(1)
    log(ftemp)
     ftemp = get_temperature(2)
    log(ftemp)
end
  
logfile=io.open("A/FLIGHTLOG.log","wb")
io.output(logfile)
 
function log(...)
    io.write(...)
    io.write("\n")
end
]]--
--******Start of Script*****--
repeat
    timerwait()
until false

--end

--[[
log("done!")
logfile:close()
]]--
