#PICAXE14M
' ---- start of main loop ----
setfreq m8
pause 1800
sound 4,(60,30)
sound 4,(80,30)
sound 4,(105,50)
low 4
main:


validfix:
gosub GetUTCTime
gosub GetLatitude
goto main



GetLatitude:
' use b0 to skip over decimal point
serin 4,T2400,("$GPGGA,")
serin 4,T2400,(","),b1,b2,b3,b4,b0,b5,b6,b7,b8,b0,b9
high 2
sertxd("Lat",b1,b2,b3,b4,b5,b6,b7,b8,b9)
low 1
if b9 <> "," then	'Will be E or W if position is known, otherwise ,
high 1
endif
return

GetLongitude:
serin 4,T2400,("$GPGGA,")
serin 4,T2400,(",")
serin 4,T2400,(","),b0,b0,b1,b2,b3,b4,b5,b0,b6,b7,b8,b9,b0,b10'b0,b0,b0,b0,b0,b0,b0,b0,b0,b0,b0,b0,b0,b0,b0,b0,b0,b0,b0,b1,b2,b3,b4,b5,b0,b6,b7,b8,b9
high 2
sertxd("Lon",b1,b2,b3,b4,b5,b6,b7,b8,b9,b10)
low 2
return


GetUTCTime:
serin 4,T2400,("$GPGGA,"),b1,b2,b3,b4,b5,b6
sertxd("UTC: ",b1,b2,"h ",b3,b4,"m ",b5,b6,"s", 13,10)
return
