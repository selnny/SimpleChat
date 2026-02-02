# SimpleChat

Simple TCP Chat Application  
A lightweight multi-user chat for local networks built with C# and .NET, using TCP sockets for real-time communication.

---

## Features
- Supports multiple users on a local network.
- Real-time communication.
- Simple, text-based protocol for communication.

---

## Requirements
- **.NET 8.0**
- **Windows** (for GUI client) — The server can run on any OS with .NET support.

---

## How to Run

### 1. Start the Server
The server listens on **port 9000** by default. Simply start the server application.

---

### 2. Configure and Run the Client
Open `ClientApp/App.config` and set the correct `Host`:

- **Running on the same machine as the server**:
  ```xml
  <add key="Host" value="127.0.0.1"/>
  ```

- **Running on a different machine**:
  ```xml
  <add key="Host" value="x.x.x.x"/>
  ```

- **Using a hostname (if a hosts entry is configured)**:
  ```xml
  <add key="Host" value="myserver.local"/>
  ```

---

### Optional: Use myserver.local via Hosts File
To use a user-friendly hostname instead of an IP address:

1. **Edit the hosts file on each client machine**:
   - **Windows**: `C:\Windows\System32\drivers\etc\hosts`

2. **Add a line with the server's IP address and hostname**:
   ```
   x.x.x.x myserver.local
   ```
   Replace `x.x.x.x` with your server's actual IP address.

---

## Communication Protocol

The app uses a simple text-based protocol:

- Register a new user:
  ```
  JOIN|Username
  ```

- Send a broadcast message:
  ```
  MSG|ALL|text
  ```

- Send a private message:
  ```
  MSG|Username|text
  ```

- Disconnect a user:
  ```
  LEAVE|Username
  ```

- Receive the user list (sent by the server):
  ```
  USERLIST|user1,user2,...
  ```
