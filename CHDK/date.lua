--[[
  Functions that return Date/Time strings for use in CHDK Lua scripts.
  
  Authors: 2009/01/27 mattkime: replace get_time with os.date
           2008/10/27 fudgey: datestamp(), datetimestamp()
           2008/08/17 Francesco Bonomi: format_nn(), timestamp()
  Licence: GPL
--]]

require "dummy"

date = {}



-- formats a number to two digit string with leading zeroes e.g. 3 to "03"
-- (only works for numbers in range 0 - 99)
function date.format_nn(n)
  local r=tostring(n)
  if n<10 then
    r= "0" .. n
  end 
  return r
end


-- return a formatted timestamp (hh:mm:ss)
-- if called without parameters, gets current camera time and formats it
-- if a parameter is passed, formats the passed number 
function date.timestamp(t)
  if t==nil then
    return os.date("%X")
  else
    return os.date("%X",t)
  end
end


-- Returns formatted date string from camera clock.
-- Output format example: 2008/09/03
function date.datestamp()
  return os.date("%Y/%m/%d")
end

--[[
-- Returns formatted time string from camera clock.
-- Output format example: 23:05:59
function timestamp2()
  local H=get_time("h")
  local M=get_time("m")
  local S=get_time("s")
  return format_nn(H) .. ":" .. format_nn(M) .. ":" .. format_nn(S)
end
--]]

-- Returns formatted date + time string from camera clock.
-- Output format example: 2008/09/03 23:05:59
function date.datetimestamp()
  return os.date("%Y/%m/%d %X")
end