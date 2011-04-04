require "propcase"
require "capmode"
--print("Hello CHDK!")

--[[
Working revision for APEX II Launch 2
Flash Now Turns off properly, logfile works and timestamps every line.
Temperature sensors 1 and 2 work reliably. 
@title APEX II 2.00.2
@param a Interval in Seconds
@default a 5

based on APEX II 1st Launch Script
http://chdk.setepontos.com/index.php/topic,2646.0.html
set_backlight(0)
--]]


function timerwait()
    for i=0,a do
        sleep(5000)
	gtemp()
    end
    capture1()
end

function capture1()
   --set_aflock(0)
   --press("shoot_half")
   sleep(1000)
   --set_focus(65535)
   --set_aflock(1)
   sleep(500)
   log("shooting...")
   press("shoot_full")
    repeat 
    sleep(100)
  until get_shooting() == true
  release("shoot_full")
  log("shooting complete")
end

function set_focus_status(n)
	if get_propset() == 2 then
		set_prop(6,n -1)
		else
		set_prop(11,n -1)
		end
end


function gtemp()
    ftemp = get_temperature(0)
    log(ftemp)
     ftemp = get_temperature(1)
    log(ftemp)
     ftemp = get_temperature(2)
    log(ftemp)
end

function timestamp()
    Year=get_time("Y")
    Month=get_time("M")
    Day=get_time("D")
    Hour=get_time("h")
    Min=get_time("m")
    Sec=get_time("s")
    io.write(Year)
    io.write(",")
    io.write(Month)
    io.write(",")
    io.write(Day)
    io.write(" Time: ")
    io.write(Hour)
    io.write(":")
    io.write(Min)
    io.write(":")
    io.write(Sec)
    io.write("     ")
end

function gtimestamp()
    Year=get_time("Y")
    Month=get_time("M")
    Day=get_time("D")
    Hour=get_time("h")
    Min=get_time("m")
    Sec=get_time("s")
end

function log(...)
    logfile=io.open("A/FLIGHTLOG.log","ab")  --"A" Mounted Drive?
    io.output(logfile)
	timestamp()
    io.write(...)
    io.write("\n")
    logfile:close()
end

--******Start of Script*****--
set_prop(16,2)  --Turns flash off --works :)
log("Script Started")
gtemp()

repeat
    timerwait()
until false


log("done!")


