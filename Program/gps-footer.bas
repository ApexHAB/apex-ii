'###############################################################
'###############################################################
				'GPS commands
'###############################################################
'###############################################################

'needs support for heading/speed/altitude
'symbol GPSIn1 = b.2

GetLatitude:
'b0 - X if timeout
'result in variables b1-b9
'b9 - E/W or ',' for no fix


' use b45 to skip over decimal point
serin [2000,endlat], GPSIn1,T2400,("$GPGGA,")
serin [2000,endlat], GPSIn1,(","),b1,b2,b3,b4,b45,b5,b6,b7,b8,b45,b9

'sertxd("Lat",b1,b2,b3,b4,b5,b6,b7,b8,b9)



b0 = 0
return
endlat:
for b0 = 1 to 9
	poke b0,"X"
next
b0 = "X"
return

GetLongitude:
'b0 - X if timeout
'result in variables b1-b10

serin [2000,endlong],GPSIn1,T2400,("$GPGGA,")
serin [2000,endlong],GPSIn1,T2400,(",")
serin [2000,endlong],GPSIn1,T2400,(","),b45,b45,b1,b2,b3,b4,b5,b45,b6,b7,b8,b9,b45,b10'b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b1,b2,b3,b4,b5,b45,b6,b7,b8,b9
'sertxd("Lon",b1,b2,b3,b4,b5,b6,b7,b8,b9,b10)
b0 = 0
return
endlong:
for b0 = 1 to 10
	poke b0,"X"
next
b0 = "X"
return


GetUTCTime:
'b0 - X if timeout
'b1,b2 - hour
'b3 - ':'
'b4,b5 - minute
'b6 - ':'
'b7,b8 - sec
serin [2000,endtime],GPSIn1,T2400,("$GPGGA,"),b1,b2,b4,b5,b7,b8
'sertxd("UTC: ",b1,b2,"h ",b3,b4,"m ",b5,b6,"s", 13,10)
b0 = 0
return
endtime:
for b0 = 1 to 8
	poke b0,"X"
next
b0 = "X"
return