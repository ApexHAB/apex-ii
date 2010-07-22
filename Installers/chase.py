import serial
import urllib2
import time

ser = serial.Serial("/dev/ttyUSB0", 4800)
lasttime = time.time()
while 1:
    line = ser.readline()
    if time.time() - lasttime < 10.0:
        continue
    data = line.split(",")
    if data[0] == "$GPRMC":
        if data[2] != 'A':
            print "no lock"
            continue
        thetime = data[1]
        lat = data[3] + data[4]
        lon = data[5] + data[6]
        speed = str(float(data[7]) * 1.852)
        url = "http://spacenear.us/tracker/track.php?vehicle=chase-M0RND&time=%s&lat=%s&lon=%s&speed=%s&pass=xxxxx" % (thetime, lat, lon, speed)
        result = urllib2.urlopen(url)
        if result.getcode() == 200:
            print "uploaded ok"
        else:
            print "http error " + str(result.getcode())
        lasttime = time.time()