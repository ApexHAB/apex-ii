locate_altitude:
            serin 4,T2400,("$GPGGA,")
            serin 4,T2400,(","),b0,b0,b0,b0,b0,b0,b0,b0,b7,b0,b0,b0,b0,b0,b0

if b7< 2000 then goto send_text 'assuming output is in metres
            goto locate_altitude
'b1= UTC time
'b2=Latitude
'b3=N/S
'b4=Longitude
'b5=W/E
'b6=Horizontal dilution of position
'b7=Altitude (above mean sea level)
'b8=units for Altitude (m or ft?)

send_text:
            serin 4,T2400,("$GPGGA,")
            serin 4,T2400,(","),b1,b2,b3,b4,b5,b0,b0,b6,b7,b8,b0,b0,b0,b0,b0
            serout x,N2400,("AT")
            serin y,N2400,(“OK”)
            serout x,N2400,("AT+CMGF=1") 'sets text mode
            serin y,N2400,(“OK”)
            serout x,N2400,("AT+CSCA=00447973100973") 'centre number of Orange
            serin y,N2400,(“OK”)
            serout x,N2400,("AT+CMGS=phonenumber\n") 'phone number sending to
            pause 100
            serout x,N2400,("Lat: " b2 b3 ", Long: " b4 b5 ", Time: " b1 ", HD: " b6 ", Alt: " b7 b8 \z) 'HD=horizontal dilution

serin y,N2400,(“OK”)

wait 60
            serin 4,T2400,("$GPGGA,")
            serin 4,T2400,(","),b0,b0,b0,b0,b0,b0,b0,b0,b9,b0,b0,b0,b0,b0,b0
            if b7=b9 goto endgame

goto locate_altitude

endgame:        serin 4,T2400,("$GPGGA,")
            serin 4,T2400,(","),b1,b2,b3,b4,b5,b0,b0,b6,b7,b8,b0,b0,b0,b0,b0

serout x,N2400,("AT")
            serin y,N2400,(“OK”)
            serout x,N2400,("AT+CMGF=1") 'sets text mode
            serin y,N2400,(“OK”)
            serout x,N2400,("AT+CSCA=00447973100973") 'centre number of Orange
            serin y,N2400,(“OK”)
            serout x,N2400,("AT+CMGS=phonenumber\n") 'phone number sending to
            pause 100
            serout x,N2400,("Lat: " b2 b3 ", Long: " b4 b5 ", Time: " b1 ", HD: " b6 ", “We have landed!” \z) 'HD=horizontal dilution

serin y,N2400,(“OK”)
            stop