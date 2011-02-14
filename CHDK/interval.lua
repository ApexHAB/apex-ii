
--[[
rem 20080805
@title yet another accurate intervalometer
@param a Duration (min)/-1 disable
@default a -1
@param b Duration (sec)/n of seqs
@default b 5
@param c Delay 1st sequence (min)
@default c 0
@param d Delay 1st sequence (sec)
@default d 3
@param e Trigger every n min
@default e 0
@param f ...every n sec
@default f 3
@param g ...every .n sec
@default g 0
@param h Endless?
@default h 0
@param i Seq dur (m)/-1
@default i -1
@param j Seq dur (s)/n of shots/seq
@default j 1
--]]
 
drivemode_continuous = 1
 
if a < -1 then a = -1 end
if ( a > -1 and b < 0 ) then b = 0 end
if ( a == -1 and b < 1 ) then b = 1 end
if c < 0 then c = 0 end
if d < 0 then d = 0 end
if e < 0 then e = 0 end
if f < 0 then f = 0 end
if g < 0 then g = 0 end
if ( h < 0 or h > 1 ) then h = 0 end
if i < -1 then i = -1 end
if ( i > -1 and j < 0 ) then j = 0 end
if ( i == -1 and j < 1 ) then j = 1 end
if (( i == -1 and j > 1 ) or i > -1 ) then
  if get_drive_mode() ~= drivemode_continuous then
    print( "set drive mode" )
    print( "to continuous" )
    sleep(1500)
    cannot_continue = true
  end
end
 
if a > -1 then duration = a*60000 + b*1000 else duration = b end
delay_first= c*60000 + d*1000
if g < 0 then delay = e*60000 + f*1000 + g*10 else delay = e*60000 + f*1000 + g*100 end
if i > -1 then sequence = i*60000 + j*1000 else sequence = j end
 
 
function shoot_by_numbers( sequence_target )
sequence_current = 0
repeat
  tick_target = get_tick_count() + delay
  sequence_current = sequence_current + 1
  print( "sequence " .. sequence_current .. " of " .. sequence_target )
  if i == -1 then shoot_count( sequence ) else shoot_tick( sequence ) end
  while ( get_tick_count() < tick_target and sequence_current < sequence_target ) do
  end
until sequence_current >= sequence_target
end
 
function shoot_by_duration( duration )
duration_target = get_tick_count() + duration
repeat
  tick_target = get_tick_count() + delay
  if i == -1 then shoot_count( sequence ) else shoot_tick( sequence ) end
  print( (duration_target-get_tick_count())/1000 .. " sec to go" )
  while ( get_tick_count() < tick_target and get_tick_count() < duration_target ) do
  end
until get_tick_count() >= duration_target
end
 
function shoot_forever()
tick_initial = get_tick_count()
sequence_current = 0
repeat
  tick_target = get_tick_count() + delay
  sequence_current = sequence_current + 1
  print( "sequence " .. sequence_current )
  if i == -1 then shoot_count( sequence ) else shoot_tick( sequence ) end
  print ( (get_tick_count()-tick_initial)/1000 .. " sec elapsed")
  while ( get_tick_count() < tick_target ) do
  end
until false
end
 
function shoot_count( count_inc )
count_target = get_exp_count() + count_inc
if count_target > 9999 then count_target = count_target - 9999 end
press( "shoot_half" )
press( "shoot_full" )
repeat
until get_exp_count() == count_target
release( "shoot_full" )
repeat
until get_shooting() == false
end
 
function shoot_tick( tick_duration )
tick_target = get_tick_count() + tick_duration
press( "shoot_half" )
press( "shoot_full" )
while ( get_tick_count() < tick_target ) do
end
release( "shoot_full" )
repeat
until get_shooting() == false
end
 
if not cannot_continue then
  tick_target = get_tick_count() + delay_first
  print( "waiting " .. delay_first/1000 .. " sec" )
  while ( get_tick_count() < tick_target ) do
    tick_current = get_tick_count()
  end
  if h == 1 then shoot_forever() end
  if a > -1 then shoot_by_duration( duration ) else shoot_by_numbers( duration ) end
end

