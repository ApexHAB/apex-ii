--[[
          util.lua
          utility functions for scripting with lua for CHDK
          
          v. 1.0 2009-01-30
          
          Changelog:
          2009/1/30 mattkime
          created
          
          check_range is copied directly from -
          
          fb-lib.lua
          fbonomi's library of lua functions for CHDK
          
          Copyright 2008 Francesco Bonomi.
          Released under GPL
          
 ]]

util = {} 
 
 -- checks that a value is in a range
 -- returns value (corrected if not in range)
 function util.check_range(current, minimum, maximum)
-- print(" minimum:"..minimum.." maximum:"..maximum)
  v=current
 if v<minimum then
  v=minimum
 end
 if v>maximum then
  v=maximum
 end
 return v
end


-- sleeps for a given number of minutes and prints updates
function util.sleepMinutesVerbose(minutes)
	if minutes>0 then 
  	for remaining=minutes,1,-1 do 
    	print("Sleeping ", remaining, " minutes")
    	sleep(29980)
    	sleep(29990)
  	end
	end
end

function util.sleepUntilTime(time)
	local secondsFuture = (time.hour * 3600) + (time.minute * 60) + time.second
	local secondsNow = os.date("%S")
	local minutesNow = os.date("%M")
	local hoursNow = os.date("%H")
	local secondsNow = (hoursNow * 3600) + (minutesNow * 60) + secondsNow
	
	--if future time is smaller than current time, add 12hrs.
	if(secondsNow > secondsFuture) then
		secondsFuture = secondsFuture + 43200
	end
	local secondsDelta = secondsFuture - secondsNow
	sleep(secondsDelta * 1000)
end

function util.sleepUntilNextPeriodOfAnHour (periodCount)
		local periodLength = 3600 / periodCount
		local secondsAfterHour = (tonumber(os.date("%M")) * 60) + tonumber(os.date("%S"))
		local currentPeriod = secondsAfterHour / periodLength
		sleep((((currentPeriod + 1) * periodLength) - secondsAfterHour) * 1000)
end

function util.printAndPause(...)
	print(...)
	sleep(2000)
end