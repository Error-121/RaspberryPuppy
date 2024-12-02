# Importerer nødvendige biblioteker
from sense_hat import SenseHat
from datetime import datetime
import time
import threading
import requests
import schedule

import numpy as np

# Indstil API-oplysninger
API_KEY = "6a0ef35108054010834112455242711"  # Skift til din OpenWeatherMap API-nøgle
CITY = "Roskilde"  # Skift til din by
URL = f"http://api.weatherapi.com/v1/current.json?key={API_KEY}&q={CITY}&aqi=no"

# Funktion til at hente udendørs temperatur
def get_outdoor_temperature():
    try:
        response = requests.get(URL)
        response.raise_for_status()  # Tjek for fejl
        data = response.json()
        
        # Hent relevante data
        location = data['location']['name']
        country = data['location']['country']
        current_temp = data['current']['temp_c']
        humidity = data['current']['humidity']
        last_updated = data['current']['last_updated']
        
        # Print de relevante oplysninger
        print(f"Tid: {last_updated}")
        print(f"Lokation: {location}, {country}")
        print(f"Temperatur: {current_temp:.2f}°C")
        print(f"Luftfugtighed: {humidity}%")
        
        return current_temp
    except requests.RequestException as e:
        print(f"Fejl ved hentning af udendørs temperatur: {e}")
        return None
    except KeyError as e:
        print(f"Fejl: Nøglen {e} findes ikke i svaret fra API'et")
        return None

# Definerer en SenseHat-instans
sense = SenseHat()
sense.clear(0, 0, 0)  # Slukker alle lys på Sense HAT

# Klasse til at repræsentere en hund
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
        self.time_outside = None
        self.tid_til_dif = None

    def send_signal(self):
        self.NeedToWalks = True
        self.Sounds = Dog.SoundSignal.quietBarking
        sense.clear(0, 255, 0)
        time.sleep(30)
        self.Sounds = Dog.SoundSignal.loudBarking
        sense.clear(255, 0, 0)

    def print_current_temp(self):
        temp = sense.get_temperature()
        print(f"Current temp on the puppy is: {temp:.2f}°C")

    def check_outside_status(self):
        indoor_temp = sense.get_temperature()
        outdoor_temp = get_outdoor_temperature()

        if outdoor_temp is None:
            print("Kunne ikke få udendørs temperatur. Tjek forbindelsen.")
            return

        print(f"Hundens temperatur: {indoor_temp:.2f}°C")
        print(f"Udendørs temperatur: {outdoor_temp:.2f}°C")

        temperature_difference = abs(indoor_temp - outdoor_temp)
        print(f"Temperaturforskellen er: {temperature_difference:.2f}°C")

        if temperature_difference < 15:
            self.handle_dog_outside()
        else:
            self.handle_dog_inside()

    def handle_dog_outside(self):
        if self.tid_til_dif is None:
            self.tid_til_dif = time.time()
            print("Hunden er ude - stopper med at gø!")
            self.Sounds = Dog.SoundSignal.silent
            sense.clear(0, 0, 255)
        elif time.time() - self.tid_til_dif >= 30:
            print("Hunden har været ude isekunder!")
            self.time_outside = np.int32(time.time() - self.tid_til_dif)
            self.Sounds = Dog.SoundSignal.silent
            sense.clear(255, 255, 0)

    def handle_dog_inside(self):
        print("Hunden er ikke udenfor!")
        if self.time_outside is not None:
            self.time_outside
            print(f"Final outside time set to: {self.time_outside}")
            if time.time() - self.time_outside < 30:
                print("Hunden er kommet ind før de 30 sekunder - gør igen.")
                self.Sounds = Dog.SoundSignal.loudBarking
                sense.clear(255, 0, 0)
            self.time_outside = None
        

# Opret et objekt af klassen Dog
my_dog = Dog(1, "Lilo", "Golden Retriever")

# Planlægger `send_signal` til at køre på specifikke tidspunkter
schedule.every().day.at("07:00:30").do(my_dog.send_signal)
schedule.every().day.at("16:00:00").do(my_dog.send_signal)
schedule.every().day.at("21:00:00").do(my_dog.send_signal)

# Testplanlægning
schedule.every().day.at("10:46:00").do(my_dog.send_signal)

# Tråd til opdatering af temperatur
def update_temperature():
    while True:
        my_dog.print_current_temp()
        time.sleep(30)

temperature_thread = threading.Thread(target=update_temperature)
temperature_thread.daemon = True
temperature_thread.start()

# Evig løkke til planlægning og opdatering
while True:
    my_dog.check_outside_status()
    schedule.run_pending()
    time.sleep(5)
