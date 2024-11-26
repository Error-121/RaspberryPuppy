# Puppy tings
#from sense_hat import SenseHat
from datetime import datetime, timedelta
import time
import threading
import socket
import schedule

# server_adrress =
# server_port =
# client_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

#sense = SenseHat()
r=0
g=0
b=0
#sense.clear(r, g, b)

# Dog Class
class Dog:
    class SoundSignal:
        silent = 0
        loudBarking = 1
        quietBarking = 2

    def __init__(self, id, name, race):
        self.ID = id
        self.name = name
        self.race = race
        self.NeedToWalks = False
        self.Sounds = Dog.SoundSignal.silent

    def send_signal(self):
        r = 0
        b = 0
        self.NeedToWalks = True
        self.Sounds = Dog.SoundSignal.quietBarking
        g = 255  #set green LED
 #       sense.clear(r, g, b)
        time.sleep(30)  # Wait 30 seconds
        self.Sounds = Dog.SoundSignal.loudBarking
        g = 0  # turn off green
        r = 255  # set red LED
  #      sense.clear(r, g, b)

# Dog Object
my_dog = Dog(1, "Buddy", "Golden Retriever")

# Schedule the `send_signal` method of the dog
schedule.every().day.at("12:46:30").do(my_dog.send_signal)
schedule.every().day.at("16:00:00").do(my_dog.send_signal)
schedule.every().day.at("21:00:00").do(my_dog.send_signal)

# Scheduler loop
while True:
    schedule.run_pending()
    time.sleep(1)