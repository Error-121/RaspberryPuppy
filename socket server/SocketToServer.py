import socket
import json
import mysql.connector

# UDP server details
UDP_IP = "0.0.0.0"
UDP_PORT = 11000

# MySQL server details
MYSQL_HOST = "localhost"
MYSQL_USER = "your_username"
MYSQL_PASSWORD = "your_password"
MYSQL_DATABASE = "your_database"

# Set up the UDP socket
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
sock.bind((UDP_IP, UDP_PORT))

print(f"UDP Server is listening on port {UDP_PORT}...")

# Connect to the MySQL server
db_connection = mysql.connector.connect(
    host=MYSQL_HOST,
    user=MYSQL_USER,
    password=MYSQL_PASSWORD,
    database=MYSQL_DATABASE
)
cursor = db_connection.cursor()

while True:
    data, addr = sock.recvfrom(1024)  # buffer size is 1024 bytes
    print(f"Received message: {data.decode()} from {addr}")
    
    try:
        # Parse the JSON data
        json_data = json.loads(data.decode())
        
        # Insert the data into the MySQL database
        # Assuming the JSON data has keys 'key1', 'key2', 'key3'
        query = "INSERT INTO your_table (key1, key2, key3) VALUES (%s, %s, %s)"
        values = (json_data['key1'], json_data['key2'], json_data['key3'])
        cursor.execute(query, values)
        db_connection.commit()
        
        response = "Message received and inserted into database"
    except json.JSONDecodeError:
        response = "Invalid JSON format"
    except mysql.connector.Error as err:
        response = f"MySQL error: {err}"
    except KeyError:
        response = "Missing keys in JSON data"
    
    sock.sendto(response.encode(), addr)