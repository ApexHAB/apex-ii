'###############################################################
'###############################################################
				'GPS commands - for testing
'###############################################################
'###############################################################

'needs support for heading/speed/altitude
'symbol GPSIn1 = b.2

GetLatitude:
'b0 - X if timeout
'result in variables b1-b9
'b9 - E/W or ',' for no fix


' use b45 to skip over decimal point


b0 = 0
b1 = "5"
b2 = "1"
b3 = "."
b4 = "3"
b5 = "7"
b6 = "1"
b7 = "9"
b8 = "5"
b9 = "E"
return

GetLongitude:
'b0 - X if timeout
'result in variables b1-b10

b0 = 0
b1 = "5"
b2 = "1"
b3 = "."
b4 = "3"
b5 = "7"
b6 = "1"
b7 = "9"
b8 = "5"
b9 = "7"
b10 = "4"
return


GetUTCTime:
'b0 - X if timeout
'b1,b2 - hour
'b3 - ':'
'b4,b5 - minute
'b6 - ':'
'b7,b8 - sec
b0 = 0
b1 = "1"
b2 = "2"
b3 = ":"
b4 = "0"
b5 = "4"
b6 = ":"
b7 = "5"
b8 = "4"
return